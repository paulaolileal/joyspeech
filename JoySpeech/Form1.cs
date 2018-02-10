using JoySpeech.Components;
using JoySpeech.Models;
using Microsoft.Speech.Recognition;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace JoySpeech {
    public partial class Form1 : Form {

        SpeechRecognitionEngine sre;
        Joystick joystick;

        Dictionary<JoystickKeys, TextBox> texts;

        bool _HOLD_MOVE;
        bool _HOLD_ACTION;
        bool _STICK;
        bool _TRIGGER;
        bool _CAMERA;

        public Form1() {
            // Create a new SpeechRecognitionEngine instance.
            sre = new SpeechRecognitionEngine( new System.Globalization.CultureInfo( "pt-BR" ) );


            _HOLD_MOVE = false;
            _HOLD_ACTION = false;
            _STICK = false;
            _CAMERA = false;
            _TRIGGER = false;

            InitializeComponent();

            Initialize.Joysticks();
            using (StreamReader reader = new StreamReader( Directory.GetCurrentDirectory() + @"\Joysticks\Super Mario World.json" )) {
                joystick = JsonConvert.DeserializeObject<Joystick>( reader.ReadToEnd() );
                reader.Close();
            }
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
                { JoystickKeys.HOLD_ACTION, hold_ActionBox },
                { JoystickKeys.STOP, stopBox },
                { JoystickKeys.TRIGGER, triggerBox },
                // Trigger
                { JoystickKeys.LB, lbBox },
                { JoystickKeys.RB, rbBox },

            };

            // Popule textsBox with the command
            foreach (var x in texts) {
                x.Value.Text = joystick.Map[ x.Key ].Command;
                x.Value.Enabled = false;
                x.Value.Font = new Font( FontFamily.GenericSerif, 8, FontStyle.Bold );
            }

            // Configure the input to the recognizer.
            sre.SetInputToDefaultAudioDevice();

            // Create a simple grammar that recognizes the commands.
            Choices commands = new Choices();
            commands.Add( joystick.Map.ToList().Where( b => b.Value.Valid == true ).Select( a => a.Value.Command ).ToArray() );

            // Create a GrammarBuilder object and append the Choices object.
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append( commands );

            // Create the Grammar instance and load it into the speech recognition engine.
            Grammar g = new Grammar( gb );
            sre.LoadGrammar( g );

            // Register a handler for the SpeechRecognized event.
            sre.SpeechHypothesized +=
              new EventHandler<SpeechHypothesizedEventArgs>( sre_SpeechRecognized );

            Thread recognize = new Thread( () => {
                while (true) {
                    // Start recognition.
                    sre.Recognize();
                }
            } );
            recognize.Start();

        }

        private void Form1_Load(object sender, EventArgs e) {
        }

        public InputSimulator input = new InputSimulator();
        // Create a simple handler for the SpeechRecognized event.
        void sre_SpeechRecognized(object sender, SpeechHypothesizedEventArgs e) {
            Console.WriteLine( "Speech recognized: " + e.Result.Text + " - Precision: " + e.Result.Confidence );
            //if (e.Result.Confidence < 0.09) {
            //    return;
            //}
            var x = joystick.Map.ToList().SingleOrDefault( a => a.Value.Command.Equals( e.Result.Text ) && a.Value.Valid );
            VirtualKeyCode virtualKey = VirtualKeyCode.NONAME;
            JoystickKeys joystickKey = JoystickKeys.NONE;
            switch (x.Key) {
                case JoystickKeys.STICK:
                    _STICK = !_STICK;
                    texts[ x.Key ].Invoke( new Action( () => texts[ x.Key ].BackColor = ( _STICK ? Color.Green : Color.White ) ) );
                    break;

                case JoystickKeys.CAMERA:
                    _CAMERA = !_CAMERA;
                    texts[ x.Key ].Invoke( new Action( () => texts[ x.Key ].BackColor = ( _CAMERA ? Color.Green : Color.White ) ) );
                    break;

                case JoystickKeys.LEFT:
                    ReleaseMoveKeys();
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
                    break;

                case JoystickKeys.RIGHT:
                    ReleaseMoveKeys();
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
                    break;

                case JoystickKeys.UP:
                    ReleaseMoveKeys();
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
                    break;

                case JoystickKeys.DOWN:
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
                    break;

                case JoystickKeys.STOP:
                    ReleaseMoveKeys();
                    ReleaseActionKeys();
                    ReleaseControlKeys();
                    ReleaseTriggerKeys();
                    PressKey( x.Key );
                    break;

                case JoystickKeys.A:
                    if (_HOLD_ACTION) {
                        input.Keyboard.KeyPress( x.Value.Input );
                        texts[ x.Key ].Invoke( new Action( () => texts[ x.Key ].BackColor = Color.Green ) );
                    } else {
                        PressKey( x.Key );
                    }
                    break;

                case JoystickKeys.B:
                    if (_HOLD_ACTION) {
                        input.Keyboard.KeyPress( x.Value.Input );
                        texts[ x.Key ].Invoke( new Action( () => texts[ x.Key ].BackColor = Color.Green ) );
                    } else {
                        PressKey( x.Key );
                    }
                    break;

                case JoystickKeys.X:
                    if (_HOLD_ACTION) {
                        input.Keyboard.KeyPress( x.Value.Input );
                        texts[ x.Key ].Invoke( new Action( () => texts[ x.Key ].BackColor = Color.Green ) );
                    } else {
                        PressKey( x.Key );
                    }
                    break;

                case JoystickKeys.Y:
                    if (_HOLD_ACTION) {
                        input.Keyboard.KeyPress( x.Value.Input );
                        texts[ x.Key ].Invoke( new Action( () => texts[ x.Key ].BackColor = Color.Green ));
                    } else {
                        PressKey( x.Key );
                    }
                    break;

                case JoystickKeys.START:
                    PressKey( x.Key );
                    break;

                case JoystickKeys.SELECT:
                    PressKey( x.Key );
                    break;

                case JoystickKeys.HOLD_MOVE:
                    _HOLD_MOVE = !_HOLD_MOVE;
                    texts[ x.Key ].Invoke( new Action( () => texts[ x.Key ].BackColor = ( _HOLD_MOVE ? Color.Green : Color.White ) ) );
                    if (!_HOLD_MOVE) {
                        ReleaseMoveKeys();
                    }
                    break;

                case JoystickKeys.HOLD_ACTION:
                    _HOLD_ACTION = !_HOLD_ACTION;
                    texts[ x.Key ].Invoke( new Action( () => texts[ x.Key ].BackColor = ( _HOLD_ACTION ? Color.Green : Color.White ) ) );
                    if (!_HOLD_ACTION) {
                        ReleaseActionKeys();
                        ReleaseTriggerKeys();
                    }
                    break;

                case JoystickKeys.TRIGGER:
                    _TRIGGER = !_TRIGGER;
                    texts[ x.Key ].Invoke( new Action( () => texts[ x.Key ].BackColor = ( _TRIGGER ? Color.Green : Color.White ) ) );
                    break;
            }

        }
        private void ReleaseMoveKeys() {
            foreach (var key in joystick.GetMoveKeys()) {
                if (input.InputDeviceState.IsKeyDown( key.Value.Input )) {
                    input.Keyboard.KeyUp( key.Value.Input );
                }
                texts[ key.Key ].Invoke( new Action( () => texts[ key.Key ].BackColor = Color.White ) );
            }
        }

        private void ReleaseActionKeys() {
            foreach (var key in joystick.GetActionKeys()) {
                if (input.InputDeviceState.IsKeyDown( key.Value.Input )) {
                    input.Keyboard.KeyUp( key.Value.Input );
                }
                texts[ key.Key ].Invoke( new Action( () => texts[ key.Key ].BackColor = Color.White ) );
            }
        }

        private void ReleaseTriggerKeys() {
            foreach (var key in joystick.GetTriggerKeys()) {
                if (input.InputDeviceState.IsKeyDown( key.Value.Input )) {
                    input.Keyboard.KeyUp( key.Value.Input );
                }
                texts[ key.Key ].Invoke( new Action( () => texts[ key.Key ].BackColor = Color.White ) );
            }
        }

        private void ReleaseControlKeys() {
            foreach (var key in joystick.GetControlKeys()) {
                if (input.InputDeviceState.IsKeyDown( key.Value.Input )) {
                    input.Keyboard.KeyUp( key.Value.Input );
                }
                texts[ key.Key ].Invoke( new Action( () => texts[ key.Key ].BackColor = Color.White ) );
            }
            _HOLD_MOVE = false;
            //texts[ JoystickKeys.HOLD_MOVE ].Invoke( new Action( () => texts[ JoystickKeys.HOLD_MOVE ].BackColor = Color.White ) );
            _HOLD_ACTION = false;
            //texts[ JoystickKeys.HOLD_ACTION ].Invoke( new Action( () => texts[ JoystickKeys.HOLD_MOVE ].BackColor = Color.White ) );
            _STICK = false;
            //texts[ JoystickKeys.STICK ].Invoke( new Action( () => texts[ JoystickKeys.HOLD_MOVE ].BackColor = Color.White ) );
            _CAMERA = false;
            //texts[ JoystickKeys.CAMERA ].Invoke( new Action( () => texts[ JoystickKeys.HOLD_MOVE ].BackColor = Color.White ) );
        }

        private void ActiveBox(JoystickKeys key) {
            texts[ key ].Invoke( new Action( () => texts[ key ].BackColor = Color.Green ) );
        }

        private void DesactiveBox(JoystickKeys key) {
            texts[ key ].Invoke( new Action( () => texts[ key ].BackColor = Color.White ) );
        }

        private void PressKey(JoystickKeys key) {
            input.Keyboard.KeyDown( joystick.Map[ key ].Input );
            texts[ key ].Invoke( new Action( () => texts[ key ].BackColor = Color.Green ) );
            Thread.Sleep( 150 );
            input.Keyboard.KeyUp( joystick.Map[ key ].Input );
            texts[ key ].Invoke( new Action( () => texts[ key ].BackColor = Color.White ) );
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
                    // alpha,  threshold = 255
                    data[ index + 3 ] = ( data[ index + 3 ] < 255 ) ? ( byte ) 0 : ( byte ) 255;
                }
            }
            System.Runtime.InteropServices.Marshal.Copy( data, 0, bmpData.Scan0, data.Length );
            bmp.UnlockBits( bmpData );
        }


    }
}
