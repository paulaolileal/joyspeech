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

        bool _HOLD;

        public Form1() {
            sre = new SpeechRecognitionEngine( new System.Globalization.CultureInfo( "pt-BR" ) );
            _HOLD = false;
            InitializeComponent();
            Initialize.Joysticks();
            using (StreamReader reader = new StreamReader( Directory.GetCurrentDirectory() + @"\Joysticks\Super Mario World.json" )) {
                joystick = JsonConvert.DeserializeObject<Joystick>(reader.ReadToEnd());
                reader.Close();
            }

            leftBox.Text =  joystick.Map[ JoystickKeys.LEFT ].Command;
            upBox.Text =    joystick.Map[ JoystickKeys.UP ].Command;
            rightBox.Text = joystick.Map[ JoystickKeys.RIGHT ].Command;
            downBox.Text =  joystick.Map[ JoystickKeys.DOWN ].Command;
            xBox.Text =     joystick.Map[ JoystickKeys.X ].Command;
            yBox.Text =     joystick.Map[ JoystickKeys.Y ].Command;
            aBox.Text =     joystick.Map[ JoystickKeys.A ].Command;
            bBox.Text =     joystick.Map[ JoystickKeys.B ].Command;
            startBox.Text = joystick.Map[ JoystickKeys.START ].Command;
            selectBox.Text =joystick.Map[ JoystickKeys.BACK ].Command;
            logoBox.Text =  joystick.Map[ JoystickKeys.LOGO ].Command;
            holdBox.Text =  joystick.Map[ JoystickKeys.HOLD ].Command;

            // Create a new SpeechRecognitionEngine instance.

            // Configure the input to the recognizer.
            sre.SetInputToDefaultAudioDevice();

            // Create a simple grammar that recognizes "red", "green", or "blue".
            Choices commands = new Choices();
            commands.Add( joystick.Map.ToList().Select( a => a.Value.Command ).ToArray());

            // Create a GrammarBuilder object and append the Choices object.
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append( commands );

            // Create the Grammar instance and load it into the speech recognition engine.
            Grammar g = new Grammar( gb );
            sre.LoadGrammar( g );

            // Register a handler for the SpeechRecognized event.
            sre.SpeechRecognized +=
              new EventHandler<SpeechRecognizedEventArgs>( sre_SpeechRecognized );

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

        // Create a simple handler for the SpeechRecognized event.
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e) {
           // MessageBox.Show( "Speech recognized: " + e.Result.Text  + " - Precision: " + e.Result.Confidence );
            Console.WriteLine( "Speech recognized: " + e.Result.Text + " - Precision: " + e.Result.Confidence );
            InputSimulator input = new InputSimulator();
            var x = joystick.Map.ToList().SingleOrDefault( a => a.Value.Command.Equals( e.Result.Text ) );
            switch (x.Key) {
                case JoystickKeys.RIGHT:
                    var left = joystick.Map[JoystickKeys.LEFT ].Input;
                    if ( input.InputDeviceState.IsKeyDown(left)) {
                        input.Keyboard.KeyUp( left );
                        leftBox.Invoke( new Action( () => leftBox.BackColor = Color.White ) );
                    }
                    input.Keyboard.KeyDown( x.Value.Input );
                    rightBox.Invoke( new Action( () => rightBox.BackColor = Color.Green ) );
                    break;

                case JoystickKeys.LEFT:
                    var right = joystick.Map[JoystickKeys.RIGHT].Input;
                    if (input.InputDeviceState.IsKeyDown( right )) {
                        input.Keyboard.KeyUp( right );
                        rightBox.Invoke( new Action( () => rightBox.BackColor = Color.White ) );
                    }
                    input.Keyboard.KeyDown( x.Value.Input );
                    leftBox.Invoke( new Action( () => leftBox.BackColor = Color.Green ) );
                    break;

                case JoystickKeys.UP:
                    if (_HOLD) {
                        input.Keyboard.KeyDown( x.Value.Input );
                        upBox.Invoke( new Action( () => upBox.BackColor = Color.Green ) );
                    } else {
                        input.Keyboard.KeyDown( x.Value.Input );
                        upBox.Invoke( new Action( () => upBox.BackColor = Color.Green ) );
                        Thread.Sleep( 150 );
                        input.Keyboard.KeyUp( x.Value.Input );
                        upBox.Invoke( new Action( () => upBox.BackColor = Color.White ) );
                    }                    
                    break;

                case JoystickKeys.DOWN:
                    input.Keyboard.KeyDown( x.Value.Input );
                    downBox.Invoke( new Action( () => downBox.BackColor = Color.Green ) );
                    Thread.Sleep( 150 );
                    input.Keyboard.KeyUp( x.Value.Input );
                    downBox.Invoke( new Action( () => downBox.BackColor = Color.White ) );
                    break;

                case JoystickKeys.STOP:
                    foreach (var z in joystick.Map) {
                        if (input.InputDeviceState.IsKeyDown( z.Value.Input )) {
                            input.Keyboard.KeyUp( z.Value.Input );
                        }
                    }
                    _HOLD = false;
                    leftBox.Invoke(     new Action( () => leftBox.BackColor = Color.White ) );
                    upBox.Invoke(       new Action( () => upBox.BackColor = Color.White ) );
                    rightBox.Invoke(    new Action( () => rightBox.BackColor = Color.White ) );
                    downBox.Invoke(     new Action( () => downBox.BackColor = Color.White ) );
                    xBox.Invoke(        new Action( () => xBox.BackColor = Color.White ) );
                    yBox.Invoke(        new Action( () => yBox.BackColor = Color.White ) );
                    aBox.Invoke(        new Action( () => aBox.BackColor = Color.White ) );
                    bBox.Invoke(        new Action( () => bBox.BackColor = Color.White ) );
                    startBox.Invoke(    new Action( () => startBox.BackColor = Color.White ) );
                    selectBox.Invoke(   new Action( () => selectBox.BackColor = Color.White ) );
                    logoBox.Invoke(     new Action( () => logoBox.BackColor = Color.White ) );
                    holdBox.Invoke(     new Action( () => holdBox.BackColor = Color.White ) );

                    break;

                case JoystickKeys.A:
                    input.Keyboard.KeyDown( x.Value.Input );
                    aBox.Invoke( new Action( () => aBox.BackColor = Color.Green ) );
                    Thread.Sleep( 150 );
                    input.Keyboard.KeyUp( x.Value.Input );
                    aBox.Invoke( new Action( () => aBox.BackColor = Color.White ) );
                    break;

                case JoystickKeys.B:
                    input.Keyboard.KeyDown( x.Value.Input );
                    bBox.Invoke( new Action( () => bBox.BackColor = Color.Green ) );
                    Thread.Sleep( 150 );
                    input.Keyboard.KeyUp( x.Value.Input );
                    bBox.Invoke( new Action( () => bBox.BackColor = Color.White ) );
                    break;

                case JoystickKeys.X:
                    input.Keyboard.KeyDown( x.Value.Input );
                    xBox.Invoke( new Action( () => xBox.BackColor = Color.Green ) );
                    Thread.Sleep( 150 );
                    input.Keyboard.KeyUp( x.Value.Input );
                    xBox.Invoke( new Action( () => xBox.BackColor = Color.White ) );
                    break;

                case JoystickKeys.Y:
                    if (input.InputDeviceState.IsKeyDown( x.Value.Input )) {
                        input.Keyboard.KeyUp( x.Value.Input );
                        yBox.Invoke( new Action( () => yBox.BackColor = Color.White ) );
                    } else {
                        input.Keyboard.KeyDown( x.Value.Input );
                        yBox.Invoke( new Action( () => yBox.BackColor = Color.Green ) );
                    }
                    break;

                case JoystickKeys.HOLD:
                    _HOLD = !_HOLD;
                    holdBox.Invoke( new Action( () => holdBox.BackColor = (_HOLD ? Color.Green : Color.White ) ) );
                    if (!_HOLD) {
                        foreach (var z in joystick.Map) {
                            if (input.InputDeviceState.IsKeyDown( z.Value.Input )) {
                                input.Keyboard.KeyUp( z.Value.Input );
                            }
                        }

                        leftBox.Invoke( new Action( () => leftBox.BackColor = Color.White ) );
                        upBox.Invoke( new Action( () => upBox.BackColor = Color.White ) );
                        rightBox.Invoke( new Action( () => rightBox.BackColor = Color.White ) );
                        downBox.Invoke( new Action( () => downBox.BackColor = Color.White ) );
                        xBox.Invoke( new Action( () => xBox.BackColor = Color.White ) );
                        yBox.Invoke( new Action( () => yBox.BackColor = Color.White ) );
                        aBox.Invoke( new Action( () => aBox.BackColor = Color.White ) );
                        bBox.Invoke( new Action( () => bBox.BackColor = Color.White ) );
                        startBox.Invoke( new Action( () => startBox.BackColor = Color.White ) );
                        selectBox.Invoke( new Action( () => selectBox.BackColor = Color.White ) );
                        logoBox.Invoke( new Action( () => logoBox.BackColor = Color.White ) );
                        
                    }
                    break;

            }
        }
    }
}
