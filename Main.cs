using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApplicationShulte
{
    public partial class Main : Form
    {
        User user = new User();
        Database DB = new Database();
        public Main()
        {
            InitializeComponent();
            PassBox.UseSystemPasswordChar = true;
            Error.Visible = false;
        }

        private void input_Click(object sender, EventArgs e)
        {
            string error = "";
            DB.authorization(LoginBox.Text, PassBox.Text, out error, out user);
            if (error == "" && user.user_type == "user")
            {
                Error.Visible = false;
                Test_form t_form = new Test_form(user);
                t_form.Show();
            }
            if (error == "" && user.user_type == "admin")
            {
                Error.Visible = false;
                Administration t_form = new Administration(user);
                t_form.Show();
            }
            if (error != "")
            {
                Error.Visible = true;
                Error.Text = "Не верный логин или пароль.";
            }
        }

        private void registr_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
        }
    }
}
