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
    public partial class Administration : Form
    {
        Database DB = new Database();
        int size = 0;
        public Administration(User us)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string error = "";
            DataTable dt = new DataTable();
            DB.readAllUsers(out dt, out error);
            dataGridView1.DataSource = dt;
            size = dataGridView1.RowCount;
        }

        private void DB_update_Click(object sender, EventArgs e)
        {
            List<User> users = new List<User>();
            string error = "";
            if (dataGridView1.DataSource != null)
            {
                if (dataGridView1.RowCount == size)
                {
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        User usr = new User();
                        Guid g = new Guid();
                        usr.id = (Guid)dataGridView1.Rows[i].Cells[0].Value;
                        usr.login = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        usr.name = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        usr.birthday = Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value);
                        usr.gender = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        usr.user_type = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        usr.passHash = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        users.Add(usr);
                    }
                    DB.UpDate(users, out error);

                    if (error != "")
                        MessageBox.Show(error);
                }
                else
                if(dataGridView1.RowCount > size)
                {
                    User usr = new User();
                    usr.login = dataGridView1.Rows[size - 1].Cells[1].Value.ToString();
                    usr.name = dataGridView1.Rows[size - 1].Cells[2].Value.ToString();
                    usr.birthday = Convert.ToDateTime(dataGridView1.Rows[size - 1].Cells[3].Value);
                    usr.gender = dataGridView1.Rows[size - 1].Cells[4].Value.ToString();
                    usr.user_type = dataGridView1.Rows[size - 1].Cells[5].Value.ToString();
                    usr.passHash = dataGridView1.Rows[size - 1].Cells[6].Value.ToString();
                    DB.registerNewUser(usr, out error);
                    if (error != "")
                        MessageBox.Show(error);
                }
            }
            else
            {
                MessageBox.Show("Данные для обновления отсутствуют.\n Пожалуйста, получить сначала данные.");
            }
        }

        private void Stat_all_Click(object sender, EventArgs e)
        {
            string error = "";
            DataTable dt = new DataTable();
            DB.LoadAllRes(out dt, out error);
            dataGridView2.DataSource = dt;
            if (error != "")
                MessageBox.Show(error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string error = "";
            DataTable dt = new DataTable();
            if (textBox2.Text != "")
            {
                DB.loadResultsUserAdmin(textBox2.Text, out dt, out error);
                dataGridView2.DataSource = dt;
                if (error != "")
                    MessageBox.Show(error);
            }
            else
                MessageBox.Show("Введите id пользователя");
        }
    }
}
