using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput.Native;

namespace JoySpeech.Models {
    public class KeyCommand {
        
        public string Command { get; set; }
        private bool valid = true;
        public bool Valid { get => valid; set => valid = value; }
        private bool canHold = false;
        public bool CanHold { get => canHold; set => canHold = value; }
        public List<KeyCategory> Category { get; set; }
        public VirtualKeyCode Input { get; set; }

        public KeyCommand() {
            Category = new List<KeyCategory>();
        }
    }
}
