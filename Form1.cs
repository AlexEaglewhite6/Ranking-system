using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ranking_system
{

    public partial class Form1 : Form
    {
        List<string> tasks = new List<string>() 
        {
            "Уничтожить лагерь бандитов",
            "Испытать снаряжение",
            "Приготовить еду",
            "Разборка с персонажем",
            "Сварить зелье",
            "Помочь персонажу с работой",
            "Уничтожить предмет",
            "Победить в дуэли",
            "Достать документ",
            "Украсть документ",
            "Поиск предмета",
            "Зачистить локацию",
            "Создать предмет"
        };
        Random rnd = new Random();
        User u = new User();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateTasks();
            updateLabels();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            updateTasks();
        }
        void updateTasks()
        {
            for (int i = 0; i < groupBox1.Controls.Count; i++)
            {
                groupBox1.Controls[i].Visible = true;
                string taskName = tasks[rnd.Next(0, tasks.Count)];
                int taskRank = u.Rank[rnd.Next(0, u.Rank.Length)];
                groupBox1.Controls[i].Controls[2].Text = $"Задание:\n{taskName}";
                groupBox1.Controls[i].Controls[0].Text = $"Ранг:\n{taskRank}";
            }
        }

        void updateLabels()
        {
            label1.Text = $"Ранг: {u.rank}";
            label2.Text = $"Прогресс: {u.progress} %";
        }

        void updateValues(int tRank) 
        {
            u.UpdateProgress(tRank);
            label19.Text = $"+{u.getAddedProgress()}";
            timer1.Interval = 500;
            timer1.Enabled = true;
            timer1.Start();
            updateLabels();
            progressBar1.Value = u.progress;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            panel1.Visible = false;
            int tRank = Convert.ToInt32(label4.Text.Substring(label4.Text.Length-2).Trim());
            updateValues(tRank);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            int tRank = Convert.ToInt32(label9.Text.Substring(label9.Text.Length - 2).Trim());
            updateValues(tRank);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
            int tRank = Convert.ToInt32(label17.Text.Substring(label17.Text.Length - 2).Trim());
            updateValues(tRank);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            int tRank = Convert.ToInt32(label11.Text.Substring(label11.Text.Length - 2).Trim());
            updateValues(tRank);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            int tRank = Convert.ToInt32(label5.Text.Substring(label5.Text.Length - 2).Trim());
            updateValues(tRank);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            int tRank = Convert.ToInt32(label7.Text.Substring(label7.Text.Length - 2).Trim());
            updateValues(tRank);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            int tRank = Convert.ToInt32(label15.Text.Substring(label15.Text.Length - 2).Trim());
            updateValues(tRank);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            int tRank = Convert.ToInt32(label13.Text.Substring(label13.Text.Length - 2).Trim());
            updateValues(tRank);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            u.rank= -8;
            u.progress= 0;
            updateLabels();
            label19.Text = string.Empty;
            timer1.Stop();
            progressBar1.Value = u.progress;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label19.Text = string.Empty;
            timer1.Stop();
        }
    }
}
