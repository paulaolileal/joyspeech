using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoySpeech.Models {
    public enum JoystickKeys {
        LEFT,
        UP,
        RIGHT,
        DOWN,

        STOP,

        HOLD_MOVE,
        HOLD_ACTION,

        STICK,
        STICK_CLICK,
        STICK_LEFT,
        STICK_UP,
        STICK_RIGHT,
        STICK_DOWN,

        CAMERA,
        CAMERA_CLICK,
        CAMERA_LEFT,
        CAMERA_UP,
        CAMERA_RIGHT,
        CAMERA_DOWN,

        START,
        SELECT,
        LOGO,

        X,
        Y,
        A,
        B,

        TRIGGER,

        LB,
        LT,

        RB,
        RT,

        RECOGNIZE,

        OTHER,
        NONE
    }

    public enum KeyCategory {
        MOVE,
        ACTION,
        TRIGGER,
        MENU,
        CONTROL,

        STICK,
        CAMERA,
        ARROW,

        OTHER
    }
}
