using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoySpeech.Models {
    public class Record {
        public string Game { get; set; }
        public string Command { get; set; }
        public float Precision { get; set; }
        public long TimeToAction { get; set; }
    }
}
