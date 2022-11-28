using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApplicationShulte
{
    public partial class Test_form : Form
    {
        Test T = new Test();
        bool stat_flag = false;
        Database DB = new Database();
        User user = new User();
        public Test_form(User us)
        {           
            InitializeComponent();
            Width = 547;
            T.creat_test_mass();
            user = us;

            for (int i = 0; i < T.corr_mass.Length; i++)
                T.corr_mass[i] = 0;

            for (int i = 0; i < T.test_mass.GetLength(1); i++)
            {
                string str = "b";
                str += (i + 1).ToString();
                (Controls[str] as Button).Visible = false;
            }
            (Controls["Next"] as Button).Visible = false;
        }

        private void Run_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < T.test_mass.GetLength(1); i++)
            {
                string str = "b";
                str += (i + 1).ToString();
                (Controls[str] as Button).Visible = true;
                (Controls[str] as Button).BackColor = System.Drawing.Color.White;
                (Controls[str] as Button).Text = T.test_mass[T.num_of_tab, i].ToString();
            }
            (Controls["Next"] as Button).Visible = true;
            T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds;
            Run.Visible = false;
        }

        private void Next_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < T.test_mass.GetLength(1); i++)
            {
                T.corr_mass[i] = 0;
                string str = "b";
                str += (i + 1).ToString();
                (Controls[str] as Button).BackColor = Color.White;
                (Controls[str] as Button).Enabled = true;
            }
            if (T.num_of_tab < 4)
            {                
                T.num_of_tab++;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds;
                for (int i = 0; i < T.test_mass.GetLength(1); i++)
                {
                    string str = "b";
                    str += (i + 1).ToString();
                    (Controls[str] as Button).Visible = true;
                    (Controls[str] as Button).Text = T.test_mass[T.num_of_tab, i].ToString();
                }
            }
            else
            { 
                Next.Text = "Завершить тест";                
                T.num_of_tab++;
            }
            if (T.num_of_tab == 5)
            {
                for (int i = 0; i < 25; i++)
                {
                    string str = "b";
                    str += (i + 1).ToString();
                    (Controls[str] as Button).Visible = false;
                }
                string error = "";
                double[] stat = T.calc_stat();

                Result res = new Result();
                res.id = user.id;
                res.login = user.login;
                res.dateCreated = DateTime.Now;
                res.workability = stat[0];
                res.mental_stab = stat[1];
                DB.saveResult(res, out error);
            }
        }


        private void b1_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b1.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b1.Enabled = false;
            }

            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b1.Enabled = false;
                b1.BackColor = Color.Green;
            }
            else
                b1.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b1.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }

        }

        private void b2_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b2.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b2.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b2.Enabled = false;
                b2.BackColor = Color.Green;
            }
            else
                b2.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b2.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b3_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b3.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b3.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b3.Enabled = false;
                b3.BackColor = Color.Green;
            }
            else
                b3.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b3.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b4_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b4.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b4.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b4.Enabled = false;
                b4.BackColor = Color.Green;
            }
            else
                b4.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b4.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b5_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b5.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b5.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b5.Enabled = false;
                b5.BackColor = Color.Green;
            }
            else
                b5.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b5.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b6_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b6.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b6.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b6.Enabled = false;
                b6.BackColor = Color.Green;
            }
            else
                b6.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b6.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b7_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b7.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b7.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b7.Enabled = false;
                b7.BackColor = Color.Green;
            }
            else
                b7.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b7.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b8_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b8.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b8.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b8.Enabled = false;
                b8.BackColor = Color.Green;
            }
            else
                b8.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b8.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b9_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b9.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b9.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b9.Enabled = false;
                b9.BackColor = Color.Green;
            }
            else
                b9.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b9.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b10_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b10.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b10.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b10.Enabled = false;
                b10.BackColor = Color.Green;
            }
            else
                b10.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b10.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b11_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b11.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b11.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b11.Enabled = false;
                b11.BackColor = Color.Green;
            }
            else
                b11.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b11.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b12_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b12.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b12.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b12.Enabled = false;
                b12.BackColor = Color.Green;
            }
            else
                b12.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b12.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b13_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b13.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b13.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b13.Enabled = false;
                b13.BackColor = Color.Green;
            }
            else
                b13.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b13.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b14_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b14.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b14.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b14.Enabled = false;
                b14.BackColor = Color.Green;
            }
            else
                b14.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b14.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b15_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b15.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b15.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b15.Enabled = false;
                b15.BackColor = Color.Green;
            }
            else
                b15.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b15.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b16_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b16.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b16.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b16.Enabled = false;
                b16.BackColor = Color.Green;
            }
            else
                b16.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b16.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b17_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b17.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b17.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b17.Enabled = false;
                b17.BackColor = Color.Green;
            }
            else
                b17.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b17.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b18_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b18.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b18.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b18.Enabled = false;
                b18.BackColor = Color.Green;
            }
            else
                b18.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b18.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b19_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b19.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b19.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b19.Enabled = false;
                b19.BackColor = Color.Green;
            }
            else
                b19.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b19.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b20_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b20.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b20.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b20.Enabled = false;
                b20.BackColor = Color.Green;
            }
            else
                b20.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b20.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b21_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b21.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b21.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b21.Enabled = false;
                b21.BackColor = Color.Green;
            }
            else
                b21.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b21.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b22_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b22.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b22.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b22.Enabled = false;
                b22.BackColor = Color.Green;
            }
            else
                b22.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b22.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b23_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b23.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b23.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b23.Enabled = false;
                b23.BackColor = Color.Green;
            }
            else
                b23.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b23.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b24_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b24.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b24.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b24.Enabled = false;
                b24.BackColor = Color.Green;
            }
            else
                b24.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b24.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void b25_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(b25.Text);
            if (num == 1)
            {
                T.corr_mass[num - 1] = num;
                b25.Enabled = false;
            }
            if (T.correct_seq(num, T.corr_mass))
            {
                T.corr_mass[num - 1] = num;
                b25.Enabled = false;
                b25.BackColor = Color.Green;
            }
            else
                b25.BackColor = Color.Red;

            if (num == 25 && T.correct_seq(num, T.corr_mass))
            {
                b25.Enabled = false;
                T.test_time[T.num_of_tab] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds - T.test_time[T.num_of_tab];
            }
        }

        private void Stat_Click(object sender, EventArgs e)
        {            
            string error = "";
            List<Result> listRes; 
            DB.loadResultsUser(user.id, out listRes, out error);

            for (int i = 0; i < listRes.Count; i++)
            {
                string[] str = new string[4];
                str[0] = "Пользователь " + listRes[i].login;
                str[1] = "Дата тестирования " + listRes[i].dateCreated.ToString();
                str[2] = "Вырабатываемость " + listRes[i].workability.ToString();
                str[3] = "Ментальная стабильность " + listRes[i].mental_stab.ToString(); 
                listBox1.Items.AddRange(str);
            }
            if (!stat_flag)
            {
                Stat.Text = "Скрыть статистику";
                for(int i = Width; i < 1013; i+=10)
                    Width = i;
                stat_flag = true;
            }
            else
            {
                Stat.Text = "Получить статистику";
                for (int i = Width; i > 547; i -= 10)
                    Width = i;
                stat_flag = false;
            }
        }
    }
}
