using System;
using System.Windows.Forms;

namespace WinChat
{
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if(this.txtPassword.Text != this.txtPassword2.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            string r = Chat.Register(this.txtLogin.Text, this.txtFirstName.Text, this.txtLastName.Text, this.txtEmail.Text, this.txtPassword.Text);
            if (r.Length > 0)
            {
                MessageBox.Show(r);
                return;
            }

            MessageBox.Show("Пользователь "+ this.txtLogin.Text + " успешно создан!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
