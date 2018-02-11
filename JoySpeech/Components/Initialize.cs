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
        public static void Joysticks() {
            if (!Directory.Exists( Directory.GetCurrentDirectory() + @"\Joysticks" ) || Directory.GetFiles( Directory.GetCurrentDirectory() + @"\Joysticks" ).Count() <= 0) {
                Joystick km = new Joystick {
                    Game = new Game {
                        Name = "Super Mario World",
                        ProcessName = "Snes9X v1.52 for Windows",
                        ProcessTitle = "Snes9X v1.52 for Windows"
                    },
                    Map = new Dictionary<JoystickKeys, KeyCommand> ()
                };

                km.Map.Add( JoystickKeys.STICK,
                new KeyCommand {
                    Command = "ANALOGICO",
                    Category = KeyCategory.CONTROL,
                    Input = VirtualKeyCode.NONAME
                } );
                // Acabar de trocar os empty por comandos
                km.Map.Add( JoystickKeys.STICK_LEFT,
                new KeyCommand {
                    Command = "ESQUERDA",
                    Valid = false,
                    Category = KeyCategory.MOVE,
                    Input = VirtualKeyCode.VK_A
                } );

                km.Map.Add( JoystickKeys.STICK_UP,
                new KeyCommand {
                    Command = "CIMA",
                    Valid = false,
                    Category = KeyCategory.MOVE,
                    Input = VirtualKeyCode.VK_W
                } );

                km.Map.Add( JoystickKeys.STICK_RIGHT,
                new KeyCommand {
                    Command = "DIREITA",
                    Valid = false,
                    Category = KeyCategory.MOVE,
                    Input = VirtualKeyCode.VK_D
                } );

                km.Map.Add( JoystickKeys.STICK_DOWN,
                new KeyCommand {
                    Command = "BAIXO",
                    Valid = false,
                    Category = KeyCategory.MOVE,
                    Input = VirtualKeyCode.VK_S
                } );

                km.Map.Add( JoystickKeys.CAMERA,
                new KeyCommand {
                    Command = "CAMERA",
                    Category = KeyCategory.CONTROL,
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.CAMERA_LEFT,
                new KeyCommand {
                    Command = "ESQUERDA",
                    Valid = false,
                    Category = KeyCategory.MOVE,
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.CAMERA_UP,
                new KeyCommand {
                    Command = "CIMA",
                    Valid = false,
                    Category = KeyCategory.MOVE,
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.CAMERA_RIGHT,
                new KeyCommand {
                    Command = "DIREITA",
                    Valid = false,
                    Category = KeyCategory.MOVE,
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.CAMERA_DOWN,
                new KeyCommand {
                    Command = "BAIXO",
                    Valid = false,
                    Category = KeyCategory.MOVE,
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.LEFT,
                new KeyCommand {
                    Command = "ESQUERDA",
                    Category = KeyCategory.MOVE,
                    Input = VirtualKeyCode.LEFT
                });
                km.Map.Add( JoystickKeys.UP,
                new KeyCommand {
                    Command = "CIMA",
                    Category = KeyCategory.MOVE,
                    Input = VirtualKeyCode.UP
                } );

                km.Map.Add( JoystickKeys.RIGHT,
                new KeyCommand {
                    Command = "DIREITA",
                    Category = KeyCategory.MOVE,
                    Input = VirtualKeyCode.RIGHT
                } );

                km.Map.Add( JoystickKeys.DOWN,
                new KeyCommand {
                    Command = "BAIXO",
                    Category = KeyCategory.MOVE,
                    Input = VirtualKeyCode.DOWN
                } );

                km.Map.Add( JoystickKeys.STOP,
                new KeyCommand {
                    Command = "PARAR",
                    Category = KeyCategory.MOVE,
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.A,
                new KeyCommand {
                    Command = "GIRAR",
                    Category = KeyCategory.ACTION,
                    Input = VirtualKeyCode.VK_V
                } );

                km.Map.Add( JoystickKeys.B,
                new KeyCommand {
                    Command = "PULAR",
                    Category = KeyCategory.ACTION,
                    Input = VirtualKeyCode.VK_C
                } );

                km.Map.Add( JoystickKeys.X,
                new KeyCommand {
                    Command = "ATACAR",
                    Category = KeyCategory.ACTION,
                    Input = VirtualKeyCode.VK_D
                } );

                km.Map.Add( JoystickKeys.Y,
                new KeyCommand {
                    Command = "CORRER",
                    CanHold = true,
                    Category = KeyCategory.ACTION,
                    Input = VirtualKeyCode.VK_X
                } );

                km.Map.Add( JoystickKeys.TRIGGER,
                new KeyCommand {
                    Command = "GATILHO",
                    Category = KeyCategory.CONTROL,
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.LB,
                new KeyCommand {
                    Command = "ESQUERDA",
                    Valid = false,
                    Category = KeyCategory.TRIGGER,
                    Input = VirtualKeyCode.VK_A
                } );

                km.Map.Add( JoystickKeys.RB,
                new KeyCommand {
                    Command = "DIREITA",
                    Valid = false,
                    Category = KeyCategory.TRIGGER,
                    Input = VirtualKeyCode.VK_S
                } );

                km.Map.Add( JoystickKeys.START,
                new KeyCommand {
                    Command = "INICIAR",
                    Category = KeyCategory.MENU,
                    Input = VirtualKeyCode.SPACE
                } );

                km.Map.Add( JoystickKeys.SELECT,
                new KeyCommand {
                    Command = "SELECIONAR",
                    Category = KeyCategory.MENU,
                    Input = VirtualKeyCode.RETURN
                } );

                km.Map.Add( JoystickKeys.LOGO,
                new KeyCommand {
                    Command = "LOGO",
                    Category = KeyCategory.MENU,
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.HOLD_MOVE,
                new KeyCommand {
                    Command = "SEGUIR",
                    Category = KeyCategory.CONTROL,
                    Input = VirtualKeyCode.NONAME
                } );

                if (!Directory.Exists( Directory.GetCurrentDirectory() + @"\Joysticks\" )){
                    Directory.CreateDirectory( Directory.GetCurrentDirectory() + @"\Joysticks\" );
                }

                var json = JsonConvert.SerializeObject( km, Formatting.Indented );
                using (StreamWriter writer = new StreamWriter( Directory.GetCurrentDirectory() + @"\Joysticks\" + km.Game.Name + ".json" )) {
                    writer.Write( json );
                    writer.Close();
                }
            }
        }
    }
}
