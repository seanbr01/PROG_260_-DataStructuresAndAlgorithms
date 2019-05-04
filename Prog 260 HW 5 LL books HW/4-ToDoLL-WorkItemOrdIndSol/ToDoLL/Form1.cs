using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Book newBook = new Book();
            var rating = Convert.ToInt32(textBoxRating.Text);
            newBook.Rating = rating < 1 ? 1 : rating > 5 ? 5 : rating;

            newBook.Title = textBoxTitle.Text;
            newBook.Author = textBoxAuthor.Text;
            
            // This program will store either by the priority text box, using this method to Insert
            //ToDoLL.InsertAt(newBook, Convert.ToInt32(newBook.Rating)); // get the index value from the new textBoxPrioity
            
            // or it will store them based on the value of the value text box.
            ToDoLL.InsertInOrder(newBook);  // 


            //textBoxPrioity.Text = "";
            textBoxRating.Text = "";
            textBoxTitle.Text= "";
            textBoxAuthor.Text = "";
        }

        private void buttonGetNext_Click(object sender, EventArgs e)
        {
            try
            {
                Book currentBook = new Book();
                currentBook = ToDoLL.RemoveFromFront();
                labelRatingOutput.Text =  currentBook.Rating.ToString();
                labelTitleOutput.Text = currentBook.Title;
                labelAuthorOutput.Text = currentBook.Author;
            }
            catch (Exception)
            {
                labelRatingOutput.Text = "Nothing more to do.";
                labelTitleOutput.Text = "";
                labelAuthorOutput.Text = "";
            }
          
        }

        private void textBoxRating_TextChanged(object sender, EventArgs e)
        {
            var input = textBoxRating.Text;
            if (!Regex.IsMatch(input, @"^\d+$") && input != string.Empty)
            {
                MessageBox.Show("Input must best a nume 1 - 5");
                textBoxRating.Text = string.Empty;
            }
        }
    }
}
