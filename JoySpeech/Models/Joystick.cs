using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoySpeech.Models {
    public class Joystick {
        public Game Game { get; set; }
        public Dictionary<JoystickKeys, KeyCommand> Map { get; set; }

        public Joystick() {
            Map = new Dictionary<JoystickKeys, KeyCommand>();
        }

        public Dictionary<JoystickKeys, KeyCommand> GetActionKeys() {
            return Map.Where( a => a.Value.Category.Contains( KeyCategory.ACTION ) ).ToDictionary( b => b.Key, c => c.Value );
        }

        public Dictionary<JoystickKeys, KeyCommand> GetMoveKeys(bool arrow = true, bool stick = true, bool camera = true) {
            var resp = new List<KeyValuePair<JoystickKeys, KeyCommand>>();

            if (arrow) {
                resp.AddRange( Map.Where( a => a.Value.Category.Contains( KeyCategory.MOVE ) && a.Value.Category.Contains( KeyCategory.ARROW ) ).ToDictionary( b => b.Key, c => c.Value ) );

            }
            if (stick) {
                resp.AddRange( Map.Where( a => a.Value.Category.Contains( KeyCategory.MOVE ) && a.Value.Category.Contains( KeyCategory.STICK ) ).ToDictionary( b => b.Key, c => c.Value ) );
            }
            if (camera) {
                resp.AddRange( Map.Where( a => a.Value.Category.Contains( KeyCategory.MOVE ) && a.Value.Category.Contains( KeyCategory.CAMERA ) ).ToDictionary( b => b.Key, c => c.Value ) );
            }

            return resp.ToDictionary( a => a.Key, b => b.Value );
        }

        public Dictionary<JoystickKeys, KeyCommand> GetTriggerKeys() {
            return Map.Where( a => a.Value.Category.Contains( KeyCategory.TRIGGER ) ).ToDictionary( b => b.Key, c => c.Value );
        }

        public Dictionary<JoystickKeys, KeyCommand> GetControlKeys() {
            return Map.Where( a => a.Value.Category.Contains( KeyCategory.CONTROL ) ).ToDictionary( b => b.Key, c => c.Value );
        }
    }
}
