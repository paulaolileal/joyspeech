using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoySpeech.Models {
    class Joystick {
        public Game Game { get; set; }
        public Dictionary<JoystickKeys, KeyCommand> Map { get; set; }        

        public Joystick() {
            Map = new Dictionary<JoystickKeys, KeyCommand>();
        }
    }
}
