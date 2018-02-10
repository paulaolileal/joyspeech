using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput.Native;

namespace JoySpeech.Models {
    class KeyCommand {
        
        public string Command { get; set; }
        private bool valid = true;
        public bool Valid { get => valid; set => valid = value; }
        public KeyCategory Category { get; set; }
        public VirtualKeyCode Input { get; set; }
    }
}
