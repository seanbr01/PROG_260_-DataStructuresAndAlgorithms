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
        WorkItemLinkedList ToDoLL;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToDoLL = new WorkItemLinkedList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            WorkItem newWorkItem = new WorkItem(); // create a new object
            newWorkItem.Value = Convert.ToInt32(textBoxValue.Text);  // set its values
            newWorkItem.What = textBoxWhat.Text;
            newWorkItem.Why = textBoxWhy.Text;
            ToDoLL.InsertAtFront(newWorkItem);  // insert it at front of LL  (first in, last out)
            // clear the text boxes
            textBoxValue.Text = "";
            textBoxWhat.Text= "";
            textBoxWhy.Text = "";
        }

        private void buttonGetNext_Click(object sender, EventArgs e)
        {
            try
            {
                WorkItem currentWorkItem;  // method will return one, so need appropriate variable type to refer to the return value
                currentWorkItem = ToDoLL.RemoveFromFront(); // call our LL and get the object on top
                // fill the text boxes with the values inside the object
                labelDataOutput.Text =  currentWorkItem.Value.ToString();
                labelWhatOutput.Text = currentWorkItem.What;
                labelWhyOutput.Text = currentWorkItem.Why;
            }
            catch (Exception)  // trying to read from enpty list
            {
                labelDataOutput.Text = "Nothing more to do.";
                labelWhatOutput.Text = "";
                labelWhyOutput.Text = "";
            }
          
        }

       
    }
}
