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
            testAdd();
            fillDataGrid();
        }

        private void btnTestRemove_Click(object sender, EventArgs e)
        {
            testRemove();
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
        
        private void testAdd()
        {
            Random random = new Random();
            List<Book> books = new List<Book>()
            {
                new Book(){ ISBN = 6, Title = "Eternal Spring", Author = "Mandy Fletcher", PubYear = 1909, Rating = random.Next(6) },
                new Book(){ ISBN = 3, Title = "Dream Boat", Author = "Kellie Franklin", PubYear = 1938, Rating = random.Next(6) },
                new Book(){ ISBN = 4, Title = "2619: Rigel", Author = "Mable Henry", PubYear = 1958, Rating = random.Next(6) },
                new Book(){ ISBN = 5, Title = "Unleash The Truth", Author = "Noel Pearson", PubYear = 2014, Rating = random.Next(6) },
                new Book(){ ISBN = 8, Title = "Sean Bruce, The Book", Author = "Sean Bruce", PubYear = 1980, Rating = random.Next(6) },
                new Book(){ ISBN = 7, Title = "2015: Pollux", Author = "Beatrice Barber", PubYear = 2016, Rating = random.Next(6) }
            };

            foreach (Book book in books)
            {
                myBook_BST.AddRec(book);
            }
        }

        private void testRemove()
        {
            int[] remove = new int[] { 4, 3, 8, 7 };
            foreach (int item in remove)
            {
                removeBook(item);
            }
        }
    }
}
