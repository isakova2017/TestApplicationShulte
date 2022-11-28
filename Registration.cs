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
    public partial class Registration : Form
    {
        Database DB = new Database();
        string[] gen = { "male", "female" };
        public Registration()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string error = "";
            User user = new User();
            user.login = login.Text;
            user.name = name.Text;
            if(date.Text != "")
                user.birthday = Convert.ToDateTime(date.Text);
            user.gender = gender.Text;
            user.user_type = "user";
            user.passHash = pass.Text;
            if (login.Text != "" && name.Text != "" && gender.Text != "" && date.Text != "" && pass.Text != "" && pass.Text == pass2.Text)
            {
                DB.registerNewUser(user, out error);
                MessageBox.Show("Регистрация успешна.");
                Close();
            }
            else
            {                
                if(login.Text == "" || name.Text == "" || gender.Text == "" || date.Text == "" || pass.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                    MessageBox.Show("Пароли не совпадают");
            }
            if (error != "")
                MessageBox.Show(error);
        }

    }
}
