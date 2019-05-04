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
        WorkItenLinkedList ToDoLL;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToDoLL = new WorkItenLinkedList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            WorkItem newWorkItem = new WorkItem();
            newWorkItem.Value = Convert.ToInt32(textBoxValue.Text);
            newWorkItem.What = textBoxWhat.Text;
            newWorkItem.Why = textBoxWhy.Text;
            
            //ToDoLL.InsertInOrder(newWorkItem);  // check the object going in to make sure it has correct values
            //replace that call with a call to the new  InsertAt(WorkItem pWorkItem, uint index), get the index value
            // from the new textBoxPrioity

            textBoxPrioity.Text = "";
            textBoxValue.Text = "";
            textBoxWhat.Text= "";
            textBoxWhy.Text = "";
        }

        private void buttonGetNext_Click(object sender, EventArgs e)
        {
            try
            {
                WorkItem currentWorkItem = new WorkItem();
                currentWorkItem = ToDoLL.RemoveFromFront();
                labelDataOutput.Text =  currentWorkItem.Value.ToString();
                labelWhatOutput.Text = currentWorkItem.What;
                labelWhyOutput.Text = currentWorkItem.Why;
            }
            catch (Exception)
            {
                labelDataOutput.Text = "Nothing more to do.";
                labelWhatOutput.Text = "";
                labelWhyOutput.Text = "";
            }
          
        }

       
    }
}
}
