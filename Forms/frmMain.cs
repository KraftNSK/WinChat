using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace WinChat
{
    public partial class frmMain : Form
    {
        private const int WM_VSCROLL = 0x115;
        private const int SB_BOTTOM = 7;

        private delegate void MessagesChat();
        private MessagesChat RefreshChat;       

        //временный список для новых сообщений
        private List<ServerMessage> msgs;

        //Фоновый поток для запроса новых сообщений у сервера
        private Thread RefreshGUI; 

        public frmMain()
        {
            InitializeComponent();

            RefreshChat = new MessagesChat(RefreshWindowChat);

            RefreshGUI = new Thread(new ThreadStart(ThreadRefreshGUI));
            RefreshGUI.Start();
        }

        /// <summary>
        /// Запрос новых сообщений чата
        /// </summary>
        private void RefreshWindowChat()
        {

            msgs = Chat.GetNewMessages();

            if (msgs == null) return;

            OutputMessages(msgs);


            ScrollToEnd(rtbChat.Handle, WM_VSCROLL, SB_BOTTOM, 0);

        }

        /// <summary>
        /// Вывод сообщений в окно из массива сообщений
        /// </summary>
        /// <param name="m"></param>
        private void OutputMessages(List<ServerMessage> m)
        {
            if(m!=null)
                foreach (ServerMessage sm in m)
                {
                    rtbChat.Text += sm.Name + ": " + sm.Text + '\n';
                }
        }

        /// <summary>
        /// Фоновый поток. Запрашивает новые данные на сервере каждые 250мс
        /// </summary>
        private void ThreadRefreshGUI()
        {
            while (true)
            {
                Thread.Sleep(250);

                if (Chat.IsAuth)
                    if (rtbChat.InvokeRequired)
                        rtbChat.Invoke(RefreshChat);
            }
        }


        private void mEnter_Click(object sender, EventArgs e)
        {
            Chat.AppPath = txtURL.Text;

            frmEnter f = new frmEnter();
            var ds = f.ShowDialog(this);

            if(Chat.IsAuth)
            {
                lblLogin.Text = "Вы работаете под " + Chat.Login;
                mEnter.Visible = !Chat.IsAuth;
                mExit.Visible = Chat.IsAuth;

                lbl1.Enabled = txtMessage.Enabled = btnSendMessage.Enabled = Chat.IsAuth;
                ScrollToEnd(rtbChat.Handle, WM_VSCROLL, SB_BOTTOM, 0);
                txtMessage.Focus();
            }
        }

        private void mRegistration_Click(object sender, EventArgs e)
        {
            frmRegistration f = new frmRegistration();
            f.Show();
        }

        private void mClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Length == 0) return;

            msgs = Chat.SendMessage(txtMessage.Text);

            if (msgs == null) return;

            OutputMessages(msgs);

            txtMessage.Text = "";

            ScrollToEnd(rtbChat.Handle, WM_VSCROLL, SB_BOTTOM, 0);
        }

        private void mExit_Click(object sender, EventArgs e)
        {
            Chat.SendMessage(Chat.Login + " вышел из чата...");
            Chat.Exit();
            if (!Chat.IsAuth)
            {
                lblLogin.Text = "Вы не авторизованы!";

                mEnter.Visible = !Chat.IsAuth;
                mExit.Visible = Chat.IsAuth;

                lbl1.Enabled = txtMessage.Enabled = btnSendMessage.Enabled = Chat.IsAuth;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Chat.SendMessage(Chat.Login+ " вышел из чата...");
            if (RefreshGUI != null)
                if (RefreshGUI.IsAlive)
                    RefreshGUI.Abort();
        }

        /// <summary>
        /// ОТправка сообщения элементу для скроллинга
        /// </summary>
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int ScrollToEnd(IntPtr handle, int msg, int wParam, int lParam);

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            mEnter.Enabled = mRegistration.Enabled =!(txtURL.Text.Length == 0);
        }

    }
}
