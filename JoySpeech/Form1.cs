using JoySpeech.Components;
using JoySpeech.Models;
using Microsoft.Speech.Recognition;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        bool _CAMERA;
        bool _inExecution;

        public Form1() {
            // Create a new SpeechRecognitionEngine instance.
            sre = new SpeechRecognitionEngine( new System.Globalization.CultureInfo( "pt-BR" ) );


            _HOLD_MOVE = false;
            _HOLD_ACTION = false;
            _STICK = false;
            _CAMERA = false;
            _inExecution = false;

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
                { JoystickKeys.STOP, stopBox }

            };

            // Popule textsBox with the command
            foreach (var x in texts) {
                x.Value.Text = joystick.Map[ x.Key ].Command;
            }

            // Configure the input to the recognizer.
            sre.SetInputToDefaultAudioDevice();

            // Create a simple grammar that recognizes "red", "green", or "blue".
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
            // MessageBox.Show( "Speech recognized: " + e.Result.Text  + " - Precision: " + e.Result.Confidence );
            Console.WriteLine( "Speech recognized: " + e.Result.Text + " - Precision: " + e.Result.Confidence );
            //if(e.Result.Confidence < 0.2) {
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
                        virtualKey = joystick.Map[ joystickKey ].Input;
                    } else if (_CAMERA) {
                        joystickKey = JoystickKeys.CAMERA_LEFT;
                        virtualKey = joystick.Map[ joystickKey ].Input;
                    } else {
                        joystickKey = JoystickKeys.LEFT;
                        virtualKey = joystick.Map[ joystickKey ].Input;
                    }
                    if (_HOLD_MOVE) {
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
                        virtualKey = joystick.Map[ joystickKey ].Input;
                    } else if (_CAMERA) {
                        joystickKey = JoystickKeys.CAMERA_RIGHT;
                        virtualKey = joystick.Map[ joystickKey ].Input;
                    } else {
                        joystickKey = JoystickKeys.RIGHT;
                        virtualKey = joystick.Map[ joystickKey ].Input;
                    }
                    if (_HOLD_MOVE) {
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
                    PressKey( x.Key );
                    break;

                case JoystickKeys.A:
                    if (_HOLD_ACTION) {
                        input.Keyboard.KeyPress( x.Value.Input );
                    } else {
                        PressKey( x.Key );
                    }
                    break;

                case JoystickKeys.B:
                    if (_HOLD_ACTION) {
                        input.Keyboard.KeyPress( x.Value.Input );
                    } else {
                        PressKey( x.Key );
                    }
                    break;

                case JoystickKeys.X:
                    if (_HOLD_ACTION) {
                        input.Keyboard.KeyPress( x.Value.Input );
                    } else {
                        PressKey( x.Key );
                    }
                    break;

                case JoystickKeys.Y:
                    if (_HOLD_ACTION) {
                        input.Keyboard.KeyPress( x.Value.Input );
                    } else {
                        PressKey( x.Key );
                    }
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
                    }
                    break;
            }

        }
        private void ReleaseMoveKeys() {
            foreach (var key in joystick.GetMoveKeys()) {
                if (input.InputDeviceState.IsKeyDown( key.Value.Input )) {
                    input.Keyboard.KeyUp( key.Value.Input );
                    texts[ key.Key ].Invoke( new Action( () => texts[ key.Key ].BackColor = Color.White ) );
                }
            }
        }

        private void ReleaseActionKeys() {
            foreach (var key in joystick.GetActionKeys()) {
                if (input.InputDeviceState.IsKeyDown( key.Value.Input )) {
                    input.Keyboard.KeyUp( key.Value.Input );
                    texts[ key.Key ].Invoke( new Action( () => texts[ key.Key ].BackColor = Color.White ) );
                }
            }
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


    }
}
