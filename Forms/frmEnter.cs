using System;
using System.Windows.Forms;

namespace WinChat
{
    public partial class frmEnter : Form
    {
        public frmEnter()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length == 0 || txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Заполните все поля!");
                this.DialogResult = DialogResult.None;
                return;
            }

            string r = Chat.Auth(this.txtLogin.Text, this.txtPassword.Text);
            if (r.Length > 0)
            {
                MessageBox.Show(r);
                this.DialogResult = DialogResult.None;
                return;
            }
            else
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
