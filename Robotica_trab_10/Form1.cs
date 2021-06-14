using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Robotica_trab_10
{
    public partial class Form1 : Form
    {
        double corrd_x;
        double corrd_y;
        double angulo;
        double l1, l2;
        double teta1, teta2, teta3;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_calcular_Click(object sender, EventArgs e)
        {
            corrd_x = 0;
            corrd_y = 0;
            angulo = 0;
            l1 = 0;
            l2 = 0;
            teta1 = teta2 = teta3 = 0;
            set_valores();
            calcula_tetas();
            retorna_angulos();
        }

        void set_valores()
        {
            corrd_x = Double.Parse(tb_co_x.Text);
            corrd_y = Double.Parse(tb_co_y.Text);
            angulo = Double.Parse(tb_co_angulo.Text);
            l1 = Double.Parse(tb_l1.Text);
            l2 = Double.Parse(tb_l2.Text);

        }
        void set_valores_toZero()
        {
            corrd_x = 0;
            corrd_y = 0;
            angulo = 0;
            l1 = 0;
            l2 = 0;
            teta1 = teta2 = teta3 = 0;
            tb_co_x.Text = corrd_x.ToString();
            tb_co_y.Text = corrd_y.ToString();
            tb_co_angulo.Text = angulo.ToString();
            tb_l1.Text = l1.ToString();
            tb_l2.Text = l2.ToString();
            retorna_angulos();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            set_valores_toZero();
        }

        void calcula_tetas()
        {
            teta2 = 180 * ((double)Math.Acos((Math.Pow(corrd_x, 2) + Math.Pow(corrd_y, 2) - Math.Pow(l1, 2) - Math.Pow(l2, 2)) / (2 * l1 * l2))) / Math.PI;
                        
            if (teta2 < 0)
            {
                teta1 = 180*( (double) Math.Atan2(corrd_y, corrd_x) + Math.Acos((Math.Pow(corrd_x, 2) + Math.Pow(corrd_y, 2) + Math.Pow(l1, 2) - Math.Pow(l2, 2)) / (2 * l1 * Math.Sqrt(Math.Pow(corrd_x, 2) + Math.Pow(corrd_y, 2)))))/Math.PI;
            }
            if(teta2 > 0)
            {
                teta1 = 180 * ((double)Math.Atan2(corrd_y, corrd_x) - Math.Acos((Math.Pow(corrd_x, 2) + Math.Pow(corrd_y, 2) + Math.Pow(l1, 2) - Math.Pow(l2, 2)) / (2 * l1 * Math.Sqrt(Math.Pow(corrd_x, 2) + Math.Pow(corrd_y, 2))))) / Math.PI;
            }

            teta3 = angulo - (teta1 + teta2);
        }

        void retorna_angulos()
        {
            lb_t1.Text = teta1.ToString("F");
            lb_t2.Text = teta2.ToString("F");
            lb_t3.Text = teta3.ToString("F");
        }

    }
}
