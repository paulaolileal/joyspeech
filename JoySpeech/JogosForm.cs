using JoySpeech.Components;
using JoySpeech.Models;
using Microsoft.Speech.Recognition;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace JoySpeech {
    public partial class JogosForm : Form {

        SpeechRecognitionEngine sre;
        InputSimulator input;
        Thread recognize;

        bool _canRecognize;

        List<Joystick> _joysticks;

        public string gameChoosed;

        public JogosForm() {
            _joysticks = new List<Joystick>();
            InitializeComponent();
            sre = new SpeechRecognitionEngine( new System.Globalization.CultureInfo( "pt-BR" ) );
            input = new InputSimulator();
            _canRecognize = true;

            DirectoryInfo directory = new DirectoryInfo( Directory.GetCurrentDirectory() + @"\Joysticks\" );
            foreach(var x in directory.GetFiles( "*.json")) {
                using (StreamReader reader = new StreamReader( x.FullName )) {
                    var text = reader.ReadToEnd();
                    _joysticks.Add( JsonConvert.DeserializeObject<Joystick>( text ) );
                }
            }



            // Configure the input to the recognizer.
            sre.SetInputToDefaultAudioDevice();

            // Create a simple grammar that recognizes the commands.
            Choices commands = new Choices();
            commands.Add( new string[] { "DIREITA", "ESQUERDA", "ESCOLHER" } );

            // Create a GrammarBuilder object and append the Choices object.
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append( commands );

            // Create the Grammar instance and load it into the speech recognition engine.
            Grammar g = new Grammar( gb );
            sre.LoadGrammar( g );

            // Register a handler for the SpeechRecognized event.
            sre.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>( sre_SpeechRecognized );

            // Initilize the recognition in parallel thread
            recognize = new Thread( () => {
                while (_canRecognize) {
                    // Start recognition.
                    sre.Recognize();
                }
            } );
            recognize.Start();


        }

        void sre_SpeechRecognized(object sender, SpeechHypothesizedEventArgs e) {
            Console.WriteLine( "Speech recognized: " + e.Result.Text + " - Precision: " + e.Result.Confidence );
            SetMainWindows(  );
            // Search for a key mapped on the command
            switch (e.Result.Text) {

                // Case controllers:
                case "DIREITA":
                    this.Invoke( new Action( async () => {
                        input.Keyboard.KeyDown( VirtualKeyCode.RIGHT );
                        rightBox.BackColor = Color.Green;
                        await Task.Delay( 150 );
                        rightBox.BackColor = Color.White;
                        input.Keyboard.KeyUp( VirtualKeyCode.RIGHT );
                    } ) );
                    break;
                case "ESQUERDA":
                    this.Invoke( new Action( async () => {
                        input.Keyboard.KeyDown( VirtualKeyCode.LEFT );
                        rightBox.BackColor = Color.Green;
                        await Task.Delay( 150 );
                        rightBox.BackColor = Color.White;
                        input.Keyboard.KeyUp( VirtualKeyCode.LEFT );
                    } ) );
                    break;
                case "ESCOLHER":
                    listView1.Invoke( new Action( async () => {
                        chooseBox.BackColor = Color.Green;
                        var choosed = listView1.SelectedItems;
                        gameChoosed = choosed[ 0 ].Text;
                        _canRecognize = false;
                        await Task.Delay( 150 );
                        chooseBox.BackColor = Color.White;
                        this.Close();
                    } ) );
                    break;
            }
        }

        void listView1_DrawItem(object sender, DrawListViewItemEventArgs e) {
            Color textColor = Color.Black;
            if (( e.State & ListViewItemStates.Selected ) != 0) {
                e.Graphics.FillRectangle( SystemBrushes.Highlight, e.Bounds );
                textColor = SystemColors.HighlightText;
            } else {
                e.Graphics.FillRectangle( Brushes.White, e.Bounds );
            }
            e.Graphics.DrawRectangle( Pens.DarkGray, e.Bounds );

            TextRenderer.DrawText( e.Graphics, e.Item.Text, listView1.Font, e.Bounds,
                                  textColor, Color.Empty,
                                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter );
        }

        private void JogosForm_Load(object sender, EventArgs e) {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size( 180, 180 );

            int cont = 0;

            foreach(var image in _joysticks) {
                imageList.Images.Add( Image.FromFile( Directory.GetCurrentDirectory() + @"\Joysticks\" + image.Game.ImagePath ) );
                AddRow( listView1, cont, image.Game.Name);
                cont++;
            }

            listView1.View = View.LargeIcon;
            listView1.LargeImageList = imageList;
            listView1.SmallImageList = imageList;
            listView1.Alignment = ListViewAlignment.Left;
            //listView1.OwnerDraw = true;
            listView1.DrawItem += listView1_DrawItem;
            listView1.TileSize = new Size( 100, 100 );

            // Make the column headers.
            MakeColumnHeaders( listView1,
                "Title", 230, HorizontalAlignment.Left,
                "URL", 220, HorizontalAlignment.Left,
                "ISBN", 130, HorizontalAlignment.Left,
                "Picture", 230, HorizontalAlignment.Left,
                "Pages", 50, HorizontalAlignment.Right,
                "Year", 60, HorizontalAlignment.Right );

            listView1.Items[ 0 ].Selected = true;
            listView1.Select();
        }

        // Make the ListView's column headers.
        // The ParamArray entries should alternate between
        // strings and HorizontalAlignment values.
        public void MakeColumnHeaders(
            ListView lvw, params object[] header_info) {
            // Remove any existing headers.
            lvw.Columns.Clear();

            // Make the column headers.
            for (int i = header_info.GetLowerBound( 0 );
                     i <= header_info.GetUpperBound( 0 );
                     i += 3) {
                lvw.Columns.Add(
                    ( string )header_info[ i ],
                    ( int )header_info[ i + 1 ],
                    ( HorizontalAlignment )header_info[ i + 2 ] );
            }
        }

        // Add a row to the ListView.
        public void AddRow(ListView lvw, int image_index,
            string item_title, params string[] subitem_titles) {
            // Make the item.
            ListViewItem new_item = lvw.Items.Add( item_title, 1 );

            // Set the item's image index.
            new_item.ImageIndex = image_index;
            // Make the sub-items.
            for (int i = subitem_titles.GetLowerBound( 0 );
                     i <= subitem_titles.GetUpperBound( 0 );
                     i++) {
                new_item.SubItems.Add( subitem_titles[ i ] );
            }
        }

        //

        [DllImport( "user32.dll", ExactSpelling = true, CharSet = CharSet.Auto )]
        [return: MarshalAs( UnmanagedType.Bool )]
        private static extern bool SetForegroundWindow(IntPtr hWnd);


        public void SetMainWindows() {

            IntPtr handle = FindWindowsWithText( "Jogos" ).First();

            if (!handle.Equals( IntPtr.Zero )) {
                // activate Notepad window
                if (SetForegroundWindow( handle )) {
                }
            }

        }


        /// <summary> Find all windows that contain the given title text </summary>
        /// <param name="titleText"> The text that the window title must contain. </param>
        public IEnumerable<IntPtr> FindWindowsWithText(string titleText) {
            return FindWindows( delegate (IntPtr wnd, IntPtr param) {
                return GetWindowText( wnd ).Contains( titleText );
            } );
        }

        private  string GetWindowText(IntPtr hWnd) {
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
        private IEnumerable<IntPtr> FindWindows(EnumWindowsProc filter) {
            IntPtr found = IntPtr.Zero;
            List<IntPtr> windows = new List<IntPtr>();

            EnumWindows( delegate (IntPtr wnd, IntPtr param) {
                if (filter( wnd, param )) {
                    // only add the windows that pass the filter
                    windows.Add( wnd );
                }

                // but return true here so that we iterate all windows
                return true;
            }, IntPtr.Zero );

            return windows;
        }

        [DllImport( "user32.dll", CharSet = CharSet.Unicode )]
        private static extern int GetWindowTextLength(IntPtr hWnd);


        [DllImport( "user32.dll" )]
        private static extern IntPtr GetDesktopWindow();

        [DllImport( "user32.dll" )]
        static extern IntPtr GetWindow(IntPtr hWnd, GetWindow_Cmd uCmd);

        [DllImport( "user32.dll", CharSet = CharSet.Auto )]
        static extern int GetWindowText(IntPtr hWnd, [Out] StringBuilder lpString, int nMaxCount);


        [DllImport( "user32.dll" )]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
        // Delegate to filter which windows to include 
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);


        enum GetWindow_Cmd {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }

    }
}
