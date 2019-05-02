using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoLL
{
    public partial class Form1 : Form
    {
        IntLinkedList ToDoLL;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToDoLL = new IntLinkedList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ToDoLL.InsertAtFront(Convert.ToInt32(textBoxValue.Text));
            textBoxValue.Text = "";
        }

        private void buttonGetNext_Click(object sender, EventArgs e)
        {
            try
            {
                 labelDataOutput.Text = ToDoLL.RemoveFromFront().ToString();
            }
            catch (Exception)
            {

                labelDataOutput.Text = "Nothing more to do.";
            }
          
        }

       
    }
}
