using JoySpeech.Components;
using JoySpeech.Models;
using Microsoft.Speech.Recognition;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace JoySpeech {
    public partial class Form1 : Form {

        // Components
        SpeechRecognitionEngine sre;
        InputSimulator input;
        Joystick joystick;

        // Textbox
        Dictionary<JoystickKeys, TextBox> texts;

        // Control variables
        bool _HOLD_MOVE;
        bool _HOLD_ACTION;
        bool _STICK;
        bool _TRIGGER;
        bool _CAMERA;
        bool _RECOGNIZE;


        // Action variables
        bool _A;
        bool _B;
        bool _X;
        bool _Y;


        bool _canRecognize;

        public Form1() {
            // Create a new SpeechRecognitionEngine instance.
            sre = new SpeechRecognitionEngine( new System.Globalization.CultureInfo( "pt-BR" ) );
            input = new InputSimulator();

            // Initialize control variables
            _HOLD_MOVE = false;
            _STICK = false;
            _CAMERA = false;
            _TRIGGER = false;
            _RECOGNIZE = true;

            _canRecognize = true;

            // Initialize action variables
            _A = false;
            _B = false;
            _X = false;
            _Y = false;

            InitializeComponent();

            // Map the textbox to the joystick key
            texts = new Dictionary<JoystickKeys, TextBox> {
                // Stick
                { JoystickKeys.STICK_LEFT, stick_leftBox },
                { JoystickKeys.STICK_UP, stick_upBox },
                { JoystickKeys.STICK_RIGHT, stick_rightBox },
                { JoystickKeys.STICK_DOWN, stick_downBox },
                { JoystickKeys.STICK, stickBox },
                // Camera
                { JoystickKeys.CAMERA_LEFT, camera_leftBox },
                { JoystickKeys.CAMERA_UP, camera_upBox },
                { JoystickKeys.CAMERA_RIGHT, camera_rightBox },
                { JoystickKeys.CAMERA_DOWN, camera_downBox },
                { JoystickKeys.CAMERA, cameraBox },
                // Arrows
                { JoystickKeys.LEFT, leftBox },
                { JoystickKeys.UP, upBox },
                { JoystickKeys.RIGHT, rightBox },
                { JoystickKeys.DOWN, downBox },
                // Action
                { JoystickKeys.X, xBox },
                { JoystickKeys.Y, yBox },
                { JoystickKeys.A, aBox },
                { JoystickKeys.B, bBox },
                // Menu
                { JoystickKeys.START, startBox },
                { JoystickKeys.SELECT, selectBox },
                { JoystickKeys.LOGO, logoBox },
                // Control
                { JoystickKeys.HOLD_MOVE, hold_MoveBox },
                { JoystickKeys.STOP, stopBox },
                { JoystickKeys.TRIGGER, triggerBox },
                { JoystickKeys.RECOGNIZE_START, recognizeBox },
                { JoystickKeys.RECOGNIZE_STOP, recognizeBox },
                // Trigger
                { JoystickKeys.LB, lbBox },
                { JoystickKeys.RB, rbBox },
            };


            // Remove the joystck's border
            UnSemi( ( Bitmap )this.pictureBox1.Image );

            // Initilize the recognition in parallel thread
            InitializeRecogition( LoadJoystick() );
        }

        // Create a simple handler for the SpeechRecognized event.
        void sre_SpeechRecognized(object sender, SpeechHypothesizedEventArgs e) {
            Console.WriteLine( "Speech recognized: " + e.Result.Text + " - Precision: " + e.Result.Confidence + " Recognition: "+ _RECOGNIZE );
            if (e.Result.Confidence < 0.1) {
                return;
            }

            var time = new Stopwatch();
            time.Start();

            // Search for a key mapped on the command
            var command = joystick.Map.ToList().SingleOrDefault( a => a.Value.Command.Equals( e.Result.Text ) && a.Value.Valid );
            VirtualKeyCode virtualKey = VirtualKeyCode.NONAME;
            JoystickKeys joystickKey = JoystickKeys.NONE;

            switch (command.Key) {

                case JoystickKeys.RECOGNIZE_START:
                    if (!_RECOGNIZE) {
                        _RECOGNIZE = true;
                        AllKeys( block: _RECOGNIZE );
                    }
                    break;

                case JoystickKeys.RECOGNIZE_STOP:
                    if (_RECOGNIZE) {
                        _RECOGNIZE = false;
                        AllKeys( block: _RECOGNIZE );
                    }
                    break;

                // Case controllers:
                case JoystickKeys.STICK:
                    if (_RECOGNIZE) {
                        _STICK = !_STICK;
                        if (_STICK) {
                            ActiveBox( command.Key );
                        } else {
                            ReleaseMoveKeys( false, true, false );
                            DesactiveBox( command.Key );
                        }
                    }
                    break;

                case JoystickKeys.CAMERA:
                    if (_RECOGNIZE) {
                        _CAMERA = !_CAMERA;
                        if (_CAMERA) {
                            ActiveBox( command.Key );
                        } else {
                            ReleaseMoveKeys( false, false, true );
                            DesactiveBox( command.Key );
                        }
                    }
                    break;

                case JoystickKeys.HOLD_MOVE:
                    if (_RECOGNIZE) {
                        _HOLD_MOVE = !_HOLD_MOVE;
                        if (_HOLD_MOVE) {
                            ActiveBox( command.Key );
                        } else {
                            ReleaseMoveKeys( true, true, true );
                            DesactiveBox( command.Key );
                        }
                    }
                    break;

                case JoystickKeys.TRIGGER:
                    if (_RECOGNIZE) {
                        _TRIGGER = !_TRIGGER;
                        if (_TRIGGER) {
                            ActiveBox( command.Key );
                        } else {
                            DesactiveBox( command.Key );
                            ReleaseTriggerKeys();
                        }
                    }
                    break;

                // Case moving:
                case JoystickKeys.LEFT:
                    if (_RECOGNIZE) {
                        ReleaseMoveKeys( true, true, true );
                        if (_STICK) {
                            joystickKey = JoystickKeys.STICK_LEFT;
                        } else if (_CAMERA) {
                            joystickKey = JoystickKeys.CAMERA_LEFT;
                        } else if (_TRIGGER) {
                            joystickKey = JoystickKeys.LB;
                        } else {
                            joystickKey = JoystickKeys.LEFT;
                        }
                        virtualKey = joystick.Map[ joystickKey ].Input;
                        if (_HOLD_MOVE && !_TRIGGER) {
                            input.Keyboard.KeyDown( virtualKey );
                            ActiveBox( joystickKey );
                        } else if (_HOLD_ACTION && _TRIGGER) {
                            input.Keyboard.KeyDown( virtualKey );
                            ActiveBox( joystickKey );
                        } else {
                            PressKey( joystickKey );
                        }
                    }
                    break;

                case JoystickKeys.RIGHT:
                    if (_RECOGNIZE) {
                        ReleaseMoveKeys( true, true, true );
                        if (_STICK) {
                            joystickKey = JoystickKeys.STICK_RIGHT;
                        } else if (_CAMERA) {
                            joystickKey = JoystickKeys.CAMERA_RIGHT;
                        } else if (_TRIGGER) {
                            joystickKey = JoystickKeys.RB;
                        } else {
                            joystickKey = JoystickKeys.RIGHT;
                        }
                        virtualKey = joystick.Map[ joystickKey ].Input;
                        if (_HOLD_MOVE && !_TRIGGER) {
                            input.Keyboard.KeyDown( virtualKey );
                            ActiveBox( joystickKey );
                        } else if (_HOLD_ACTION && _TRIGGER) {
                            input.Keyboard.KeyDown( virtualKey );
                            ActiveBox( joystickKey );
                        } else {
                            PressKey( joystickKey );
                        }
                    }
                    break;

                case JoystickKeys.UP:
                    if (_RECOGNIZE) {
                        ReleaseMoveKeys( true, true, true );
                        if (_STICK) {
                            joystickKey = JoystickKeys.STICK_UP;
                            virtualKey = joystick.Map[ joystickKey ].Input;
                        } else if (_CAMERA) {
                            joystickKey = JoystickKeys.CAMERA_UP;
                            virtualKey = joystick.Map[ joystickKey ].Input;
                        } else {
                            joystickKey = JoystickKeys.UP;
                            virtualKey = joystick.Map[ joystickKey ].Input;
                        }
                        if (_HOLD_MOVE) {
                            input.Keyboard.KeyDown( virtualKey );
                            ActiveBox( joystickKey );
                        } else {
                            PressKey( joystickKey );
                        }
                    }
                    break;

                case JoystickKeys.DOWN:
                    if (_RECOGNIZE) {
                        if (_STICK) {
                            joystickKey = JoystickKeys.STICK_DOWN;
                            virtualKey = joystick.Map[ joystickKey ].Input;
                        } else if (_CAMERA) {
                            joystickKey = JoystickKeys.CAMERA_DOWN;
                            virtualKey = joystick.Map[ joystickKey ].Input;
                        } else {
                            joystickKey = JoystickKeys.DOWN;
                            virtualKey = joystick.Map[ joystickKey ].Input;
                        }
                        if (_HOLD_MOVE) {
                            input.Keyboard.KeyDown( virtualKey );
                            ActiveBox( joystickKey );
                        } else {
                            PressKey( joystickKey );
                        }
                    }
                    break;

                case JoystickKeys.STOP:
                    if (_RECOGNIZE) {
                        ReleaseMoveKeys( true, true, true );
                        ReleaseActionKeys();
                        ReleaseControlKeys();
                        ReleaseTriggerKeys();
                        PressKey( command.Key );
                    }
                    break;

                // Case action:
                case JoystickKeys.A:
                    if (_RECOGNIZE) {
                        if (command.Value.CanHold) {
                            _A = !_A;
                            if (_A) {
                                input.Keyboard.KeyDown( command.Value.Input );
                                ActiveBox( command.Key );
                            } else {
                                input.Keyboard.KeyUp( command.Value.Input );
                                DesactiveBox( command.Key );
                            }
                        } else {
                            PressKey( command.Key );
                        }
                    }
                    break;

                case JoystickKeys.B:
                    if (_RECOGNIZE) {
                        if (command.Value.CanHold) {
                            _B = !_B;
                            if (_B) {
                                input.Keyboard.KeyDown( command.Value.Input );
                                ActiveBox( command.Key );
                            } else {
                                input.Keyboard.KeyUp( command.Value.Input );
                                DesactiveBox( command.Key );
                            }
                        } else {
                            PressKey( command.Key );
                        }
                    }
                    break;

                case JoystickKeys.X:
                    if (_RECOGNIZE) {
                        if (command.Value.CanHold) {
                            _X = !_X;
                            if (_X) {
                                input.Keyboard.KeyDown( command.Value.Input );
                                ActiveBox( command.Key );
                            } else {
                                input.Keyboard.KeyUp( command.Value.Input );
                                DesactiveBox( command.Key );
                            }
                            texts[ command.Key ].Invoke( new Action( () => texts[ command.Key ].BackColor = ( _X ? Color.Green : Color.White ) ) );
                        } else {
                            PressKey( command.Key );
                        }
                    }
                    break;

                case JoystickKeys.Y:
                    if (_RECOGNIZE) {
                        if (command.Value.CanHold) {
                            _Y = !_Y;
                            if (_Y) {
                                input.Keyboard.KeyDown( command.Value.Input );
                                ActiveBox( command.Key );
                            } else {
                                input.Keyboard.KeyUp( command.Value.Input );
                                DesactiveBox( command.Key );
                            }
                        } else {
                            PressKey( command.Key );
                        }
                    }
                    break;

                // Case menu:
                case JoystickKeys.START:
                    if (_RECOGNIZE) {
                        PressKey( command.Key );
                    }
                    break;

                case JoystickKeys.SELECT:
                    if (_RECOGNIZE) {
                        PressKey( command.Key );
                    }
                    break;

                case JoystickKeys.LOGO:
                    if (_RECOGNIZE) {
                        PressKey( command.Key );
                        _canRecognize = false;
                        Recognize();
                        try {
                            JogosForm jogosForm = new JogosForm();
                            var result = jogosForm.ShowDialog();
                            if (result == DialogResult.Cancel) {
                                var g = LoadJoystick( jogosForm.gameChoosed );
                                InitializeRecogition( g );
                            }
                        }catch(Exception ex) {
                            _canRecognize = true;
                            Recognize();
                            Console.WriteLine( ex.Message );
                        }
                    }
                    break;

                default:
                    break;
            }
            time.Stop();
            var timeElapsed = time.ElapsedMilliseconds;
            ReportGenerator.Save( new Record { Game = joystick.Game.Name, Command = e.Result.Text, Precision = e.Result.Confidence, TimeToAction = timeElapsed } );
        }

        private void ReleaseMoveKeys(bool arrows, bool stick, bool camera) {
            foreach (var key in joystick.GetMoveKeys( arrows, stick, camera )) {
                if (input.InputDeviceState.IsKeyDown( key.Value.Input )) {
                    input.Keyboard.KeyUp( key.Value.Input );
                }
                DesactiveBox( key.Key );
            }
        }

        private void ReleaseActionKeys() {
            foreach (var key in joystick.GetActionKeys()) {
                if (input.InputDeviceState.IsKeyDown( key.Value.Input )) {
                    input.Keyboard.KeyUp( key.Value.Input );
                }
                DesactiveBox( key.Key );
            }
        }

        private void ReleaseTriggerKeys() {
            foreach (var key in joystick.GetTriggerKeys()) {
                if (input.InputDeviceState.IsKeyDown( key.Value.Input )) {
                    input.Keyboard.KeyUp( key.Value.Input );
                }
                DesactiveBox( key.Key );
                _TRIGGER = false;
            }
        }

        private void ReleaseControlKeys() {
            foreach (var key in joystick.GetControlKeys()) {
                if (input.InputDeviceState.IsKeyDown( key.Value.Input )) {
                    input.Keyboard.KeyUp( key.Value.Input );
                }
                DesactiveBox( key.Key );
            }
            _HOLD_MOVE = false;
            _HOLD_ACTION = false;
            _STICK = false;
            _CAMERA = false;
        }

        private void ActiveBox(JoystickKeys key) {
            texts[ key ].Invoke( new Action( () => texts[ key ].BackColor = Color.Green ) );
        }

        private void DesactiveBox(JoystickKeys key) {
            texts[ key ].Invoke( new Action( () => texts[ key ].BackColor = Color.White ) );
        }

        private void PressKey(JoystickKeys key) {
            this.Invoke( new Action( async () => {
                input.Keyboard.KeyDown( joystick.Map[ key ].Input );
                texts[ key ].BackColor = Color.Green;
                await Task.Delay( 150 );
                texts[ key ].BackColor = Color.White;
                input.Keyboard.KeyUp( joystick.Map[ key ].Input );
            } ) );
        }

        private void AllKeys( bool block ) {
            if (!block) {
                ReleaseActionKeys();
                ReleaseControlKeys();
                ReleaseMoveKeys( true, true, true );
                ReleaseTriggerKeys();

                this.Invoke( new Action( () => {
                    foreach (var box in texts) {
                        box.Value.BackColor = Color.DimGray;
                    }
                } ) );

                this.Invoke( new Action( () => {
                    texts[ JoystickKeys.RECOGNIZE_START ].BackColor = Color.White;
                    texts[ JoystickKeys.RECOGNIZE_START ].Text = joystick.Map.SingleOrDefault( a => a.Key == JoystickKeys.RECOGNIZE_START ).Value.Command;
                } ) );

            } else {
                this.Invoke( new Action( () => {
                    foreach (var x in texts) {
                        joystick.Map.TryGetValue( x.Key, out KeyCommand command );
                        if (command != null) {
                            x.Value.Invoke( new Action( () => {
                                x.Value.Text = joystick.Map[ x.Key ].Command;
                                x.Value.Enabled = false;
                                x.Value.Font = new Font( FontFamily.GenericSansSerif, 8, FontStyle.Regular );
                                x.Value.BackColor = Color.White;
                            } ) );
                        }
                    }
                } ) );

                this.Invoke( new Action( () => {
                    texts[ JoystickKeys.RECOGNIZE_STOP ].BackColor = Color.White;
                    texts[ JoystickKeys.RECOGNIZE_STOP ].Text = joystick.Map.SingleOrDefault( a => a.Key == JoystickKeys.RECOGNIZE_STOP ).Value.Command;
                } ) );
            }
        }


        // Remove image borders
        public static void UnSemi(Bitmap bmp) {
            Size s = bmp.Size;
            PixelFormat fmt = bmp.PixelFormat;
            Rectangle rect = new Rectangle( Point.Empty, s );
            BitmapData bmpData = bmp.LockBits( rect, ImageLockMode.ReadOnly, fmt );
            int size1 = bmpData.Stride * bmpData.Height;
            byte[] data = new byte[ size1 ];
            System.Runtime.InteropServices.Marshal.Copy( bmpData.Scan0, data, 0, size1 );
            for (int y = 0; y < s.Height; y++) {
                for (int x = 0; x < s.Width; x++) {
                    int index = y * bmpData.Stride + x * 4;
                    data[ index + 3 ] = ( data[ index + 3 ] < 255 ) ? ( byte )0 : ( byte )255;
                }
            }
            System.Runtime.InteropServices.Marshal.Copy( data, 0, bmpData.Scan0, data.Length );
            bmp.UnlockBits( bmpData );
        }

        // Load the joystick file or iniizalize with the default
        public Grammar LoadJoystick(string name = "") {
            // Create joysticks's files case not exists
            Initialize ini = new Initialize();

            foreach (var x in texts) {
                x.Value.Text = String.Empty;
                x.Value.Enabled = false;
                x.Value.Font = new Font( FontFamily.GenericSansSerif, 8, FontStyle.Regular );
                x.Value.BackColor = Color.DarkGray;
            }

            if (String.IsNullOrEmpty( name )) {
                joystick = ini.defaultJoystick;

                foreach (var x in texts) {
                    x.Value.Text = joystick.Map[ x.Key ].Command;
                    x.Value.Enabled = false;
                    x.Value.Font = new Font( FontFamily.GenericSansSerif, 8, FontStyle.Regular );
                    x.Value.BackColor = Color.White;
                }
            } else {
                // Load saved joysticks
                using (StreamReader reader = new StreamReader( Directory.GetCurrentDirectory() + @"\Joysticks\" + name + ".json" )) {
                    joystick = JsonConvert.DeserializeObject<Joystick>( reader.ReadToEnd() );
                    reader.Close();
                }
                foreach (var x in texts) {
                    joystick.Map.TryGetValue( x.Key, out KeyCommand command );
                    if (command != null) {
                        x.Value.Invoke( new Action( () => {
                            x.Value.Text = joystick.Map[ x.Key ].Command;
                            x.Value.Enabled = false;
                            x.Value.Font = new Font( FontFamily.GenericSansSerif, 8, FontStyle.Regular );
                            x.Value.BackColor = Color.White;
                        } ) );
                    }
                }
            }
            _canRecognize = false;
            Recognize();

            sre = new SpeechRecognitionEngine( new System.Globalization.CultureInfo( "pt-BR" ) );

            // Create a simple grammar that recognizes the commands.
            Choices commands = new Choices();
            commands.Add( joystick.Map.ToList().Where( b => b.Value.Valid == true ).Select( a => a.Value.Command ).ToArray() );

            // Create a GrammarBuilder object and append the Choices object.
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append( commands );

            // Create the Grammar instance and load it into the speech recognition engine.
            Grammar g = new Grammar( gb );

            return g;
        }

        public void InitializeRecogition(Grammar g) {
            // Configure the input to the recognizer.
            sre.SetInputToDefaultAudioDevice();

            sre.LoadGrammar( g );

            // Register a handler for the SpeechRecognized event.
            sre.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>( sre_SpeechRecognized );

            // Initilize the recognition in parallel thread
            _canRecognize = true;
            Recognize();
        }

        // Initialize the recognition
        public void Recognize() {
            if (_canRecognize) {
                sre.RecognizeAsync( RecognizeMode.Multiple );
            } else {
                sre.RecognizeAsyncCancel();
            }
        }

        private void exitButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }






        // Drag

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute( "user32.dll" )]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute( "user32.dll" )]
        public static extern bool ReleaseCapture();

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage( Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0 );
            }
        }
    }
}
