using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoySpeech.Components {
    class Teste {
        // Declarações.
[ DllImport( "user32.dll", CharSet = CharSet.Auto ) ]
static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport( "user32.dll" )]
        private static extern IntPtr GetDesktopWindow();

        [DllImport( "user32.dll" )]
        static extern IntPtr GetWindow(IntPtr hWnd, GetWindow_Cmd uCmd);

        [DllImport( "user32.dll", CharSet = CharSet.Auto )]
        static extern int GetWindowText(IntPtr hWnd, [Out] StringBuilder lpString, int nMaxCount);

        [DllImport( "user32.dll", CharSet = CharSet.Auto )]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        enum GetWindow_Cmd {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }
        // Classe que serve para armazenar o nome da classe,
        // título e handle de uma janela.
        public class JanelaInfo {
            public string Titulo;
            public string NomeDaClasse;
            public IntPtr Handle;
        }

        private static List<JanelaInfo> ListaJanelas(IntPtr hWndInicial) {
            // Se não há um handle válido, retorna.
            if (( hWndInicial == IntPtr.Zero )) {
                return null;
            }
            // Lista para armazenar objetos JanelaInfo.
            List<JanelaInfo> lista = new List<JanelaInfo>();
            // Obtém o handle da primeira janela filho.
            IntPtr hWnd = GetWindow( hWndInicial, GetWindow_Cmd.GW_CHILD );
            // Se encontrou o handle, continua a iteração.
            while (( hWnd != IntPtr.Zero )) {
                // Faz uma busca em todas as janelas filho por recursão.
                lista.AddRange( ListaJanelas( hWnd ) );
                // Obtém o título da janela e o nome da classe.
                StringBuilder sbTitulo = new StringBuilder( 255 );
                int ret = GetWindowText( hWnd, sbTitulo, 255 );
                string tituloDaJanela = sbTitulo.ToString();
                // Retira caracteres nulos do nome.
                tituloDaJanela = tituloDaJanela.Substring( 0, ret );
                StringBuilder sbNomeDaClasse = new StringBuilder( 255 );
                ret = GetClassName( hWnd, sbNomeDaClasse, 255 );
                string NomeDaClasse = sbNomeDaClasse.ToString();
                // Retira caracteres nulos do nome.
                NomeDaClasse = NomeDaClasse.Substring( 0, ret );

                // Nova instância do objeto que armazena as informações
                // sobre tíulo, nome da classe e handle da janela.
                JanelaInfo ji = new JanelaInfo();
                // Preenche valores.
                ji.Titulo = tituloDaJanela;
                ji.NomeDaClasse = NomeDaClasse;
                ji.Handle = hWnd;
                // Inclue objeto na lista.
                lista.Add( ji );
                // Obtém o handle da próxima janela.
                hWnd = GetWindow( hWnd, GetWindow_Cmd.GW_HWNDNEXT );
            }
            return lista;
        }

        // Tenta localizar uma instância do Internet Explorer.


        public static void tt() {
            IntPtr hWnd = FindWindowEx( IntPtr.Zero, IntPtr.Zero, "ZSNES", null );
            // Verifica se alguma inância do IE foi encontrada. Aborta, caso não.
            if (hWnd == IntPtr.Zero) {
                MessageBox.Show( "Nenhuma instância do Internet Explorer foi encontrada." );
                return; // Aborta.
            }
            // Obtém um lista de objetos JanelaInfo contendo informações sobre
            // nome da clásse, título da janela e handle das janelas internas do IE.
            List<JanelaInfo> janelas = ListaJanelas( hWnd );
            // Verifica se o método ListaJanelas() foi bem-sucedido
            // e retornou objetos JanelaInfo.
            if (janelas != null) {
                // Faz uma iteração pela lista exibindo as informações
                // contidas nos objetos JanelaInfo.
                foreach (JanelaInfo janela in janelas) {
                    Console.WriteLine( "Título: {0}", janela.Titulo );
                    Console.WriteLine( "Nome da Classe: {0}", janela.NomeDaClasse );
                    Console.WriteLine( "Handle: {0}", janela.Handle.ToString() );
                    // Linha separatória.
                    Console.WriteLine( new String( '-', 50 ) );
                }
            }
        }




 

        [DllImport( "user32.dll", CharSet = CharSet.Unicode )]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport( "user32.dll" )]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        // Delegate to filter which windows to include 
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        /// <summary> Get the text for the window pointed to by hWnd </summary>
        public static string GetWindowText(IntPtr hWnd) {
            int size = GetWindowTextLength( hWnd );
            if (size > 0) {
                var builder = new StringBuilder( size + 1 );
                GetWindowText( hWnd, builder, builder.Capacity );
                return builder.ToString();
            }

            return String.Empty;
        }

        /// <summary> Find all windows that match the given filter </summary>
        /// <param name="filter"> A delegate that returns true for windows
        ///    that should be returned and false for windows that should
        ///    not be returned </param>
        public static IEnumerable<IntPtr> FindWindows(EnumWindowsProc filter) {
            IntPtr found = IntPtr.Zero;
            List<IntPtr> windows = new List<IntPtr>();

            EnumWindows( delegate (IntPtr wnd, IntPtr param)
            {
                if (filter( wnd, param )) {
                    // only add the windows that pass the filter
                    windows.Add( wnd );
                }

                // but return true here so that we iterate all windows
                return true;
            }, IntPtr.Zero );

            return windows;
        }

        /// <summary> Find all windows that contain the given title text </summary>
        /// <param name="titleText"> The text that the window title must contain. </param>
        public static IEnumerable<IntPtr> FindWindowsWithText(string titleText) {
            return FindWindows( delegate (IntPtr wnd, IntPtr param)
            {
                return GetWindowText( wnd ).Contains( titleText );
            } );
        }






        [DllImport( "user32.dll", SetLastError = true )]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        public static void PressKey(Keys key, bool up) {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            if (up) {
                keybd_event( ( byte ) key, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, ( UIntPtr ) 0 );
            } else {
                keybd_event( ( byte ) key, 0x45, KEYEVENTF_EXTENDEDKEY, ( UIntPtr ) 0 );
            }
        }

        void TestProc() {
            PressKey( Keys.ControlKey, false );
            PressKey( Keys.P, false );
            PressKey( Keys.P, true );
            PressKey( Keys.ControlKey, true );
        }

    }
}
