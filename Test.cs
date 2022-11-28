using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationShulte
{
    class Test
    {
        public int[] mass = new int[25] { 1, 2, 3, 4, 5,
                                          6, 7, 8, 9, 10,
                                          11, 12, 13, 14, 15,
                                          16, 17, 18, 19, 20,
                                          21, 22, 23, 24, 25};


        public int[] corr_mass = new int[25];

        public int cur;

        public int bef;

        public int[,] test_mass = new int[5, 25];

        public double eff;

        public int num_of_tab = 0;

        public double[] test_time = new double[5];

        public double workability;

        public double mental_stab;

        public int[,] get_test_mass()
        {
            return test_mass;
        }
        public int[] Shuffle(int[] arr)
        {
            // создаем экземпляр класса Random для генерирования случайных чисел
            Random rand = new Random();
            int[] buf = new int[25];
            buf = arr;
            for (int i = buf.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                int tmp = buf[j];
                buf[j] = buf[i];
                buf[i] = tmp;
            }
            return buf;
        }

        public void creat_test_mass()
        {
            Test T = new Test();
            int[] buf = new int[25];
            for (int i = 0; i < test_mass.GetLength(0); i++)
            {
                buf = Shuffle(mass);
                for (int j = 0; j < test_mass.GetLength(1); j++)
                    test_mass[i, j] = buf[j];
            }
        }

        public bool correct_seq(int i, int[] arr)
        {
            if(i > 1)
            {
                if (arr[i - 2] == 0)
                    return false;
            }
            return true;
        }

        public double[] calc_stat()
        {
            double[] res = new double[2];
            for (int i = 0; i < test_time.Length; i++)
            {
                eff += test_time[i];
                eff /= 5;
            }
            workability = test_time[0] / eff;
            mental_stab = test_time[3] / eff;
            res[0] = workability;
            res[1] = mental_stab;
            return res;
        }

        public string interpitation(double[] res)
        {
            string a = "";
            if (res[0] > 1)
                a += "Вырабатываемость выше 1.0, что говорит о том, что вы долго сосредотачиваетесь\n";
            if (res[0] < 1)
                a += "Вырабатываемость ниже 1.0, что говорит о том, что вы быстро сосредотачиваетесь\n";

            if (res[1] > 1)
                a += "Психическая устойчивость выше 1.0, что говорит о низкой устойчивости психики к работе\n";
            if (res[1] < 1)
                a += "Психическая устойчивость ниже 1.0, что говорит о высокой устойчивости психики к работе\n";

            return a;
        }
    }
}
