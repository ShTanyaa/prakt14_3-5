using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace queue
{
    public partial class Form1 : Form
    {
        List<People> people = new List<People>();
        Stack<int> stack = new Stack<int>();
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("inf.txt"))
            {
                string[] peoples = File.ReadAllLines("inf.txt");
                foreach (string i in peoples)
                {
                    string[] infoPerson = i.Split(' ');
                    people.Add(new People(infoPerson[0], infoPerson[1], infoPerson[2], int.Parse(infoPerson[3]), double.Parse(infoPerson[4])));
                }
                foreach (People i in people)
                {
                    listBox1.Items.Add(i.Info());
                }
                foreach (People i in people)
                {
                    listBox3.Items.Add(i.Info());
                }
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDown1.Value;
            Queue q = new Queue();
            for (int i = 1; i <= n; i++)
            {
                q.Enqueue(i);
            }
            while (q.Count > 0)
            {
                int numb = (int)q.Dequeue();
                listBox1.Items.Add(numb);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            var sortedPeople = people.OrderBy(p => p.Age);
            foreach (People i in sortedPeople)
            {
                listBox3.Items.Add(i.Info());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            var ages = from i in people
                       where i.Age < 40
                       select i;
            foreach (People i in ages)
            {
                listBox2.Items.Add(i.Info());
            }
        }
    }
}
