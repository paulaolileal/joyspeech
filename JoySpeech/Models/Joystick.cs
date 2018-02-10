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

        public Dictionary<JoystickKeys, KeyCommand> GetActionKeys() {
            return Map.Where( a => a.Value.Category == KeyCategory.ACTION ).ToDictionary( b=> b.Key, c => c.Value );
        }

        public Dictionary<JoystickKeys, KeyCommand> GetMoveKeys( bool basic = true, bool stick = true, bool camera = true ) {
            var resp = new Dictionary<JoystickKeys, KeyCommand>();

            if (basic) {
                resp.Add( JoystickKeys.LEFT, Map[ JoystickKeys.LEFT ] );
                resp.Add( JoystickKeys.UP, Map[ JoystickKeys.UP ] );
                resp.Add( JoystickKeys.RIGHT, Map[ JoystickKeys.RIGHT ] );
                resp.Add( JoystickKeys.DOWN, Map[ JoystickKeys.DOWN ] );
            }
            if (stick) {
                resp.Add( JoystickKeys.STICK_LEFT, Map[ JoystickKeys.STICK_LEFT ] );
                resp.Add( JoystickKeys.STICK_UP, Map[ JoystickKeys.STICK_UP ] );
                resp.Add( JoystickKeys.STICK_RIGHT, Map[ JoystickKeys.STICK_RIGHT ] );
                resp.Add( JoystickKeys.STICK_DOWN, Map[ JoystickKeys.STICK_DOWN ] );
            }
            if (camera) {
                resp.Add( JoystickKeys.CAMERA_LEFT, Map[ JoystickKeys.CAMERA_LEFT ] );
                resp.Add( JoystickKeys.CAMERA_UP, Map[ JoystickKeys.CAMERA_UP ] );
                resp.Add( JoystickKeys.CAMERA_RIGHT, Map[ JoystickKeys.CAMERA_RIGHT ] );
                resp.Add( JoystickKeys.CAMERA_DOWN, Map[ JoystickKeys.CAMERA_DOWN ] );
            }

           // return Map.Select( a => a.Value.Category == KeyCategory.MOVE );

            return resp;
        }

        public Dictionary<JoystickKeys, KeyCommand> GetTriggerKeys() {
            return Map.Where( a => a.Value.Category == KeyCategory.TRIGGER ).ToDictionary( b => b.Key, c => c.Value );
        }

        public Dictionary<JoystickKeys, KeyCommand> GetControlKeys() {
            return Map.Where( a => a.Value.Category == KeyCategory.CONTROL ).ToDictionary( b => b.Key, c => c.Value );
        }
    }
}
