using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseQueries
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        double[,] opyt = { { 0, 0, 2, 5 }, { 3, 5, 10, 13 }, { 9, 14, 42, 42 } };
        double[,] vozrast = { { 18, 18, 26, 30 }, { 27, 31, 38, 41 }, { 39, 51, 60, 60 } };

        int[] age = { 29, 32, 34, 30 }; int[] experience = { 5, 10, 12, 1 };

        double min_opyt = 0; double max_opyt = 42;
        double min_vozrast = 18; double max_vozrast = 60;

        double MFTrap(double a, double b, double c, double d, double xmin, double xmax, double x)
        {
            if ((x >= xmin) && (x <= xmax))
            {
                if ((x >= a) && (x <= b)) return (1 - ((b - x) / (b - a)));
                if ((x > b) && (x <= c)) return 1;
                if ((x > c) && (x <= d)) return (1 - ((x - c) / (d - c)));
                else return 0;
            }
            else return 0;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 5;
            dataGridView1.ColumnCount = 9;
            dataGridView1.Rows[0].Cells[0].Value = "ID";
            dataGridView1.Rows[0].Cells[1].Value = "EXPERIENCE";
            dataGridView1.Rows[0].Cells[2].Value = "AGE";
            dataGridView1.Rows[0].Cells[3].Value = "μ(EXPERIENCE)1";
            dataGridView1.Rows[0].Cells[4].Value = "μ(EXPERIENCE)2";
            dataGridView1.Rows[0].Cells[5].Value = "μ(EXPERIENCE)3";
            dataGridView1.Rows[0].Cells[6].Value = "μ(AGE)1";
            dataGridView1.Rows[0].Cells[7].Value = "μ(AGE)2";
            dataGridView1.Rows[0].Cells[8].Value = "μ(AGE)3";

            for (int i = 1; i < 5; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i;
            }

            for (int i = 1; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    dataGridView1.Rows[i].Cells[1].Value = experience[j];
                    i++;
                }
            }

            for (int i = 1; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    dataGridView1.Rows[i].Cells[2].Value = age[j];
                    i++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[,] o = new double[4, 3];
            double[,] v = new double[4, 3];


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    o[i, j] = Math.Round(MFTrap(opyt[j, 0], opyt[j, 1], opyt[j, 2], opyt[j, 3], min_opyt, max_opyt, experience[i]), 2);
                    v[i, j] = Math.Round(MFTrap(vozrast[j, 0], vozrast[j, 1], vozrast[j, 2], vozrast[j, 3], min_vozrast, max_vozrast, age[i]), 2);
                }
            }
            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dataGridView1.Rows[1].Cells[i].Value = o[0, j];
                    dataGridView1.Rows[2].Cells[i].Value = o[1, j];
                    dataGridView1.Rows[3].Cells[i].Value = o[2, j];
                    dataGridView1.Rows[4].Cells[i].Value = o[3, j];
                    i++;
                }
            }

            for (int i = 6; i < 9; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dataGridView1.Rows[1].Cells[i].Value = v[0, j];
                    dataGridView1.Rows[2].Cells[i].Value = v[1, j];
                    dataGridView1.Rows[3].Cells[i].Value = v[2, j];
                    dataGridView1.Rows[4].Cells[i].Value = v[3, j];
                    i++;
                }
            }

        }
    }
}

