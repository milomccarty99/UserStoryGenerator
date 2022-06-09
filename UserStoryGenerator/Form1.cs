using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserStoryGenerator;

namespace UserStoryGenerator
{
    public partial class Form1 : Form
    {
        Keyphrases kp = new Keyphrases();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kp.AddSituation(textBox1.Text);
            kp.AddGoal(textBox2.Text);
            kp.AddReason(textBox3.Text);
        }

        private void button2_Click(object sender, EventArgs e) // generate user story
        {
            kp.RandomizePhrases();
            textBox1.Text = kp.SituationsPhrase();
            textBox2.Text = kp.GoalsPhrase();
            textBox3.Text = kp.ReasonsPhrase(); 

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
