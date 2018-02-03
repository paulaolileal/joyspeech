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
                km.Map.Add( JoystickKeys.LEFT,
                new KeyCommand {
                    Command = "ESQUERDA",
                    Input = VirtualKeyCode.LEFT
                });
                km.Map.Add( JoystickKeys.UP,
                new KeyCommand {
                    Command = "CIMA",
                    Input = VirtualKeyCode.UP
                } );

                km.Map.Add( JoystickKeys.RIGHT,
                new KeyCommand {
                    Command = "DIREITA",
                    Input = VirtualKeyCode.RIGHT
                } );

                km.Map.Add( JoystickKeys.DOWN,
                new KeyCommand {
                    Command = "BAIXO",
                    Input = VirtualKeyCode.DOWN
                } );

                km.Map.Add( JoystickKeys.STOP,
                new KeyCommand {
                    Command = "PARAR",
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.A,
                new KeyCommand {
                    Command = "GIRAR",
                    Input = VirtualKeyCode.VK_V
                } );

                km.Map.Add( JoystickKeys.B,
                new KeyCommand {
                    Command = "PULAR",
                    Input = VirtualKeyCode.VK_C
                } );

                km.Map.Add( JoystickKeys.X,
                new KeyCommand {
                    Command = "ATACAR",
                    Input = VirtualKeyCode.VK_D
                } );

                km.Map.Add( JoystickKeys.Y,
                new KeyCommand {
                    Command = "CORRER",
                    Input = VirtualKeyCode.VK_X
                } );

                km.Map.Add( JoystickKeys.START,
                new KeyCommand {
                    Command = "INICIAR",
                    Input = VirtualKeyCode.SPACE
                } );

                km.Map.Add( JoystickKeys.BACK,
                new KeyCommand {
                    Command = "SELECIONAR",
                    Input = VirtualKeyCode.RETURN
                } );

                km.Map.Add( JoystickKeys.LOGO,
                new KeyCommand {
                    Command = "LOGO",
                    Input = VirtualKeyCode.NONAME
                } );

                km.Map.Add( JoystickKeys.HOLD,
                new KeyCommand {
                    Command = "MANTER",
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
