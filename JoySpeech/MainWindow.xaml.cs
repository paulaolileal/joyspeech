using Microsoft.Speech.Recognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace JoySpeech {
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent( );
            // Inicializando a engine de reconhecimento
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine( new System.Globalization.CultureInfo( "pt-BR" ) );

            sre.SetInputToDefaultAudioDevice( );

            // Criando a gramatica
            Choices colors = new Choices( );
            colors.Add( new string[ ] { "vermelho", "verde", "azul", "preto", "açogueiro", "cima", "baixo", "paralelepipedo", "mover para frente" } );

            GrammarBuilder gb = new GrammarBuilder( );
            gb.Append( colors );

            Grammar g = new Grammar( gb );

            // Adicionando a gramatica na engine
            sre.LoadGrammar( g );
            
            Console.WriteLine( ">> Valendo" );
            while (true) {
                sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>( sre_SpeechRecognized );

                sre.Recognize( );
            }
        }

        static void sre_SpeechRecognized( object sender, SpeechRecognizedEventArgs e ) {
            Console.WriteLine( "> RECONHECIDO: " + e.Result.Text );
            Vocals.VirtualKeyboard.PressKey( Keys.J, Keys.J );
        }
    }
}
