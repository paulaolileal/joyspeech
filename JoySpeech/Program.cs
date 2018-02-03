using JoySpeech.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoySpeech {
    static class Program {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main() {
            //Teste.tt();
            //var dd = Teste.FindWindowsWithText( "Snes9X v1.52 for Windows" );
            //var ff = Teste.GetWindowText( dd.First() );
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new Form1() );
        }
    }
}
