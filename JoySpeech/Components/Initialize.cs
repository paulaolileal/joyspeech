using JoySpeech.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput.Native;

namespace JoySpeech.Components {
    class Initialize {

        public Joystick defaultJoystick;

        public Initialize() {

            if (!Directory.Exists( Directory.GetCurrentDirectory() + @"\Joysticks\" )) {
                Directory.CreateDirectory( Directory.GetCurrentDirectory() + @"\Joysticks\" );
            }

            defaultJoystick = new Joystick {
                Game = new Game {
                    Name = "Default",
                    ImagePath = "Default.jpg"
                },
                Map = new Dictionary<JoystickKeys, KeyCommand>()
            };

            defaultJoystick.Map.Add( JoystickKeys.RECOGNIZE,
            new KeyCommand {
                Command = "RECONHECER",
                Category = { KeyCategory.OTHER },
                Input = VirtualKeyCode.NONAME
            } );

            defaultJoystick.Map.Add( JoystickKeys.STICK,
            new KeyCommand {
                Command = "ANALOGICO",
                Category = { KeyCategory.CONTROL },
                Input = VirtualKeyCode.NONAME
            } );

            defaultJoystick.Map.Add( JoystickKeys.STICK_LEFT,
            new KeyCommand {
                Command = "ESQUERDA",
                Valid = false,
                Category = { KeyCategory.MOVE, KeyCategory.STICK },
                Input = VirtualKeyCode.VK_A
            } );

            defaultJoystick.Map.Add( JoystickKeys.STICK_UP,
            new KeyCommand {
                Command = "CIMA",
                Valid = false,
                Category = { KeyCategory.MOVE, KeyCategory.STICK },
                Input = VirtualKeyCode.VK_W
            } );

            defaultJoystick.Map.Add( JoystickKeys.STICK_RIGHT,
            new KeyCommand {
                Command = "DIREITA",
                Valid = false,
                Category = { KeyCategory.MOVE, KeyCategory.STICK },
                Input = VirtualKeyCode.VK_D
            } );

            defaultJoystick.Map.Add( JoystickKeys.STICK_DOWN,
            new KeyCommand {
                Command = "BAIXO",
                Valid = false,
                Category = { KeyCategory.MOVE, KeyCategory.STICK },
                Input = VirtualKeyCode.VK_S
            } );

            defaultJoystick.Map.Add( JoystickKeys.CAMERA,
            new KeyCommand {
                Command = "CAMERA",
                Category = { KeyCategory.CONTROL },
                Input = VirtualKeyCode.NONAME
            } );

            defaultJoystick.Map.Add( JoystickKeys.CAMERA_LEFT,
            new KeyCommand {
                Command = "ESQUERDA",
                Valid = false,
                Category = { KeyCategory.MOVE, KeyCategory.CAMERA },
                Input = VirtualKeyCode.NONAME
            } );

            defaultJoystick.Map.Add( JoystickKeys.CAMERA_UP,
            new KeyCommand {
                Command = "CIMA",
                Valid = false,
                Category = { KeyCategory.MOVE, KeyCategory.CAMERA },
                Input = VirtualKeyCode.NONAME
            } );

            defaultJoystick.Map.Add( JoystickKeys.CAMERA_RIGHT,
            new KeyCommand {
                Command = "DIREITA",
                Valid = false,
                Category = { KeyCategory.MOVE, KeyCategory.CAMERA },
                Input = VirtualKeyCode.NONAME
            } );

            defaultJoystick.Map.Add( JoystickKeys.CAMERA_DOWN,
            new KeyCommand {
                Command = "BAIXO",
                Valid = false,
                Category = { KeyCategory.MOVE, KeyCategory.CAMERA },
                Input = VirtualKeyCode.NONAME
            } );

            defaultJoystick.Map.Add( JoystickKeys.LEFT,
            new KeyCommand {
                Command = "ESQUERDA",
                Category = { KeyCategory.MOVE, KeyCategory.ARROW },
                Input = VirtualKeyCode.LEFT
            } );
            defaultJoystick.Map.Add( JoystickKeys.UP,
            new KeyCommand {
                Command = "CIMA",
                Category = { KeyCategory.MOVE, KeyCategory.ARROW },
                Input = VirtualKeyCode.UP
            } );

            defaultJoystick.Map.Add( JoystickKeys.RIGHT,
            new KeyCommand {
                Command = "DIREITA",
                Category = { KeyCategory.MOVE, KeyCategory.ARROW },
                Input = VirtualKeyCode.RIGHT
            } );

            defaultJoystick.Map.Add( JoystickKeys.DOWN,
            new KeyCommand {
                Command = "BAIXO",
                Category = { KeyCategory.MOVE, KeyCategory.ARROW },
                Input = VirtualKeyCode.DOWN
            } );

            defaultJoystick.Map.Add( JoystickKeys.STOP,
            new KeyCommand {
                Command = "PARAR",
                Category = { KeyCategory.MOVE },
                Input = VirtualKeyCode.NONAME
            } );

            defaultJoystick.Map.Add( JoystickKeys.A,
            new KeyCommand {
                Command = "GIRAR",
                Category = { KeyCategory.ACTION },
                Input = VirtualKeyCode.VK_V
            } );

            defaultJoystick.Map.Add( JoystickKeys.B,
            new KeyCommand {
                Command = "PULAR",
                Category = { KeyCategory.ACTION },
                Input = VirtualKeyCode.VK_C
            } );

            defaultJoystick.Map.Add( JoystickKeys.X,
            new KeyCommand {
                Command = "ATACAR",
                Category = { KeyCategory.ACTION },
                Input = VirtualKeyCode.VK_D
            } );

            defaultJoystick.Map.Add( JoystickKeys.Y,
            new KeyCommand {
                Command = "CORRER",
                CanHold = true,
                Category = { KeyCategory.ACTION },
                Input = VirtualKeyCode.VK_X
            } );

            defaultJoystick.Map.Add( JoystickKeys.TRIGGER,
            new KeyCommand {
                Command = "GATILHO",
                Category = { KeyCategory.CONTROL },
                Input = VirtualKeyCode.NONAME
            } );

            defaultJoystick.Map.Add( JoystickKeys.LB,
            new KeyCommand {
                Command = "ESQUERDA",
                Valid = false,
                Category = { KeyCategory.TRIGGER },
                Input = VirtualKeyCode.VK_A
            } );

            defaultJoystick.Map.Add( JoystickKeys.RB,
            new KeyCommand {
                Command = "DIREITA",
                Valid = false,
                Category = { KeyCategory.TRIGGER },
                Input = VirtualKeyCode.VK_S
            } );

            defaultJoystick.Map.Add( JoystickKeys.START,
            new KeyCommand {
                Command = "INICIAR",
                Category = { KeyCategory.MENU },
                Input = VirtualKeyCode.SPACE
            } );

            defaultJoystick.Map.Add( JoystickKeys.SELECT,
            new KeyCommand {
                Command = "SELECIONAR",
                Category = { KeyCategory.MENU },
                Input = VirtualKeyCode.RETURN
            } );

            defaultJoystick.Map.Add( JoystickKeys.LOGO,
            new KeyCommand {
                Command = "LOGO",
                Category = { KeyCategory.MENU },
                Input = VirtualKeyCode.NONAME
            } );

            defaultJoystick.Map.Add( JoystickKeys.HOLD_MOVE,
            new KeyCommand {
                Command = "SEGUIR",
                Category = { KeyCategory.CONTROL },
                Input = VirtualKeyCode.NONAME
            } );

            if(( Directory.GetFiles( Directory.GetCurrentDirectory() + @"\Joysticks" ).SingleOrDefault( a => a.Equals( "Default.json" ) ) == null )) {
                var json = JsonConvert.SerializeObject( defaultJoystick, Formatting.Indented );
                using (StreamWriter writer = new StreamWriter( Directory.GetCurrentDirectory() + @"\Joysticks\" + defaultJoystick.Game.Name + ".json" )) {
                    writer.Write( json );
                    writer.Close();
                }
            }

            // Initialize others
            SuperMario();
            SonicMania();
        }

        private void SuperMario() {
            if (!Directory.Exists( Directory.GetCurrentDirectory() + @"\Joysticks" ) || ( Directory.GetFiles( Directory.GetCurrentDirectory() + @"\Joysticks" ).SingleOrDefault( a => a.Equals( "Super Mario World.json" ) ) == null )) {
                Joystick km = new Joystick {
                    Game = new Game {
                        Name = "Super Mario World",
                        ImagePath = "Super_mario_world.jpg"
                    },
                    Map = new Dictionary<JoystickKeys, KeyCommand>()
                };

                km.Map.Add( JoystickKeys.RECOGNIZE,
                new KeyCommand {
                    Command = "RECONHECER",
                    Category = { KeyCategory.OTHER },
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.LEFT,
                new KeyCommand {
                    Command = "ESQUERDA",
                    Category = { KeyCategory.MOVE, KeyCategory.ARROW },
                    Input = VirtualKeyCode.LEFT
                } );
                km.Map.Add( JoystickKeys.UP,
                new KeyCommand {
                    Command = "CIMA",
                    Category = { KeyCategory.MOVE, KeyCategory.ARROW },
                    Input = VirtualKeyCode.UP
                } );

                km.Map.Add( JoystickKeys.RIGHT,
                new KeyCommand {
                    Command = "DIREITA",
                    Category = { KeyCategory.MOVE, KeyCategory.ARROW },
                    Input = VirtualKeyCode.RIGHT
                } );

                km.Map.Add( JoystickKeys.DOWN,
                new KeyCommand {
                    Command = "BAIXO",
                    Category = { KeyCategory.MOVE, KeyCategory.ARROW },
                    Input = VirtualKeyCode.DOWN
                } );

                km.Map.Add( JoystickKeys.STOP,
                new KeyCommand {
                    Command = "PARAR",
                    Category = { KeyCategory.MOVE },
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.A,
                new KeyCommand {
                    Command = "GIRAR",
                    Category = { KeyCategory.ACTION },
                    Input = VirtualKeyCode.VK_V
                } );

                km.Map.Add( JoystickKeys.B,
                new KeyCommand {
                    Command = "PULAR",
                    Category = { KeyCategory.ACTION },
                    Input = VirtualKeyCode.VK_C
                } );

                km.Map.Add( JoystickKeys.X,
                new KeyCommand {
                    Command = "ATACAR",
                    Category = { KeyCategory.ACTION },
                    Input = VirtualKeyCode.VK_D
                } );

                km.Map.Add( JoystickKeys.Y,
                new KeyCommand {
                    Command = "CORRER",
                    CanHold = true,
                    Category = { KeyCategory.ACTION },
                    Input = VirtualKeyCode.VK_X
                } );
                
                km.Map.Add( JoystickKeys.START,
                new KeyCommand {
                    Command = "INICIAR",
                    Category = { KeyCategory.MENU },
                    Input = VirtualKeyCode.SPACE
                } );

                km.Map.Add( JoystickKeys.LOGO,
                new KeyCommand {
                    Command = "LOGO",
                    Category = { KeyCategory.MENU },
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.HOLD_MOVE,
                new KeyCommand {
                    Command = "SEGUIR",
                    Category = { KeyCategory.CONTROL },
                    Input = VirtualKeyCode.NONAME
                } );

                if (!Directory.Exists( Directory.GetCurrentDirectory() + @"\Joysticks\" )) {
                    Directory.CreateDirectory( Directory.GetCurrentDirectory() + @"\Joysticks\" );
                }

                var json = JsonConvert.SerializeObject( km, Formatting.Indented );
                using (StreamWriter writer = new StreamWriter( Directory.GetCurrentDirectory() + @"\Joysticks\" + km.Game.Name + ".json" )) {
                    writer.Write( json );
                    writer.Close();
                }
            }
        }

        private void SonicMania() {
            if (!Directory.Exists( Directory.GetCurrentDirectory() + @"\Joysticks" ) || ( Directory.GetFiles( Directory.GetCurrentDirectory() + @"\Joysticks" ).SingleOrDefault( a => a.Equals( "Sonic Mania.json" ) ) == null )) {
                Joystick km = new Joystick {
                    Game = new Game {
                        Name = "Sonic Mania",
                        ImagePath = "Sonic_Mania.jpg"
                    },
                    Map = new Dictionary<JoystickKeys, KeyCommand>()
                };

                km.Map.Add( JoystickKeys.RECOGNIZE,
                new KeyCommand {
                    Command = "RECONHECER",
                    Category = { KeyCategory.OTHER },
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.LEFT,
                new KeyCommand {
                    Command = "ESQUERDA",
                    Category = { KeyCategory.MOVE, KeyCategory.ARROW },
                    Input = VirtualKeyCode.LEFT
                } );

                km.Map.Add( JoystickKeys.UP,
                new KeyCommand {
                    Command = "CIMA",
                    Category = { KeyCategory.MOVE, KeyCategory.ARROW },
                    Input = VirtualKeyCode.UP
                } );

                km.Map.Add( JoystickKeys.RIGHT,
                new KeyCommand {
                    Command = "DIREITA",
                    Category = { KeyCategory.MOVE, KeyCategory.ARROW },
                    Input = VirtualKeyCode.RIGHT
                } );

                km.Map.Add( JoystickKeys.DOWN,
                new KeyCommand {
                    Command = "BAIXO",
                    Category = { KeyCategory.MOVE, KeyCategory.ARROW },
                    Input = VirtualKeyCode.DOWN
                } );

                km.Map.Add( JoystickKeys.STOP,
                new KeyCommand {
                    Command = "PARAR",
                    Category = { KeyCategory.MOVE },
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.A,
                new KeyCommand {
                    Command = "PULAR",
                    Category = { KeyCategory.ACTION },
                    Input = VirtualKeyCode.VK_A
                } );

                km.Map.Add( JoystickKeys.START,
                new KeyCommand {
                    Command = "INICIAR",
                    Category = { KeyCategory.MENU },
                    Input = VirtualKeyCode.RETURN
                } );

                km.Map.Add( JoystickKeys.LOGO,
                new KeyCommand {
                    Command = "LOGO",
                    Category = { KeyCategory.MENU },
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.HOLD_MOVE,
                new KeyCommand {
                    Command = "SEGUIR",
                    Category = { KeyCategory.CONTROL },
                    Input = VirtualKeyCode.NONAME
                } );



                var json = JsonConvert.SerializeObject( km, Formatting.Indented );
                using (StreamWriter writer = new StreamWriter( Directory.GetCurrentDirectory() + @"\Joysticks\" + km.Game.Name + ".json" )) {
                    writer.Write( json );
                    writer.Close();
                }
            }
        }
    }
}
