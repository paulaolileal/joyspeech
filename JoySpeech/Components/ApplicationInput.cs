using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoySpeech.Components {
    class ApplicationInput {

        [DllImport( "user32.dll", EntryPoint = "FindWindow" )]
        private static extern IntPtr FindWindow(string lp1, string lp2);

        [DllImport( "user32.dll", ExactSpelling = true, CharSet = CharSet.Auto )]
        [return: MarshalAs( UnmanagedType.Bool )]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void SendCommand(string appName, string appTitle, string command) {
            // find window handle of Notepad
            IntPtr handle = FindWindow( appName, appTitle );
            if (!handle.Equals( IntPtr.Zero )) {
                // activate Notepad window
                if (SetForegroundWindow( handle )) {
                    SendKeys.SendWait( command );
                }
            }

        }

        [DllImport( "user32.dll", SetLastError = true )]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        public static void PressKey(Keys key, bool keepPress, string appName, string appTitle) {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            if (keepPress) {
                keybd_event( ( byte ) key, 0x45, KEYEVENTF_EXTENDEDKEY, ( UIntPtr ) 0 );
            } else {
                keybd_event( ( byte ) key, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, ( UIntPtr ) 0 );
                Thread.Sleep( 150 );
                keybd_event( ( byte ) key, 0x45, KEYEVENTF_EXTENDEDKEY, ( UIntPtr ) 0 );
            }

        }
    }
}

