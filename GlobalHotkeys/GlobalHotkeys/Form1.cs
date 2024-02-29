using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GlobalHotkeys
{
    public partial class Form1 : Form
    {
        Keys key = Keys.X;

        public Form1()
        {
            InitializeComponent();

            FormClosing += (s, e) => { UnregisterHotKey(Handle, HOTKEY_ID); };

            RegisterHotKey(Handle, HOTKEY_ID, MOD_CONTROL, (int)key);
        }


        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);


        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int MOD_NONE = 0x0000;
        private const int MOD_ALT = 0x0001;
        private const int MOD_XBUTTON1 = 0x0006;
        private const int MOD_CONTROL = 0x0002;
        private const int MOD_SHIFT = 0x0004;
        private const int MOD_WIN = 0x0008;

        private const int WM_HOTKEY = 0x0312;
        private const int HOTKEY_ID = 1;



        private void Form1_Load(object sender, EventArgs e)
        {
        }

        bool label2Bool = false;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                int id = m.WParam.ToInt32();

                if (id == HOTKEY_ID)
                {
                    label2Bool = !label2Bool;
                    label1.Text = "bind: " + key;
                    label2.Text = "bool: " + label2Bool.ToString();
                }
            }
            base.WndProc(ref m);
        }
    }
}
