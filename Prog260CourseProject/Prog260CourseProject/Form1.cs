using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog260CourseProject
{
    public partial class Form1 : Form
    {
        Book_BST myBook_BST;
        public Form1()
        {
            InitializeComponent();
            myBook_BST = new Book_BST();
        }

        private void btnAddNewBook_Click(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                ISBN = Convert.ToInt32(txbISBN.Text),
                Title = txbTitle.Text,
                Author = txbAuthor.Text,
                Rating = Convert.ToInt32(txbRating.Text),
                PubYear = Convert.ToInt32(txbYear.Text)
            };
            myBook_BST.AddRec(book);
            clearForm();
        }

        private void btnFindFromISBN_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = myBook_BST.FindRec(Convert.ToInt32(txbISBN.Text));
                txbTitle.Text = book.Title;
                txbAuthor.Text = book.Author;
                txbRating.Text = book.Rating.ToString();
                txbYear.Text = book.PubYear.ToString();
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveFromISBN_Click(object sender, EventArgs e)
        {
            removeBook(Convert.ToInt32(txbISBN.Text));
        }

        private void btnGetAllISBNs_Click(object sender, EventArgs e)
        {
            fillDataGrid();
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            foreach (Book book in myBook_BST.GetTestData())
            {
                myBook_BST.AddRec(book);
            }
            fillDataGrid();
        }

        private void clearForm()
        {
            txbISBN.Text = string.Empty;
            txbTitle.Text = string.Empty;
            txbAuthor.Text = string.Empty;
            txbRating.Text = string.Empty;
            txbYear.Text = string.Empty;
        }

        private void fillDataGrid()
        {
            dgvISBN.DataSource = myBook_BST.GetAll();
        }

        private void removeBook(int isbn)
        {
            try
            {
                myBook_BST.Remove(isbn);
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            clearForm();
            fillDataGrid();
        }

    }
}
