using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class BooksForm : Form
    {
        private BookContext context;
        private Books selectedBook;

        public BooksForm()
        {
            InitializeComponent();

            context = new BookContext(new BookLibraryContext());
            
            LoadBooks();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedBook != null)
                {
                    MessageBox.Show("You can't create duplicated book!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ValidateData())
                {
                    string Name = textBoxName.Text;
                    int Pages = int.Parse(textBoxPages.Text);
                    string Author = textBoxAuthor.Text;

                    Books book = new Books(Name, Pages, Author);

                    context.Create(book);
                    MessageBox.Show("Book created successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadBooks();

                    ClearData();
                }
                else
                {
                    MessageBox.Show("All boxes are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                Books book = new Books(selectedBook.ID, selectedBook.Name, Convert.ToInt32(textBoxPages.Text), selectedBook.Author);

                context.Update(book);

                MessageBox.Show("Book updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadBooks();

                ClearData();
            }
            else
            {
                MessageBox.Show("All boxes are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedBook != null)
            {
                context.Delete(selectedBook.ID);

                LoadBooks();

                ClearData();

                MessageBox.Show("Book deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You must select a book!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewBooks.Rows[e.RowIndex];

            selectedBook = row.DataBoundItem as Books;

            textBoxName.Text = selectedBook.Name;
            textBoxPages.Text = selectedBook.Pages.ToString();
            textBoxAuthor.Text = selectedBook.Author;
        }

        private void LoadBooks()
        {
            dataGridViewBooks.DataSource = context.ReadAll();
        }

        private bool ValidateData()
        {
            if (textBoxName.Text != string.Empty && textBoxAuthor.Text != string.Empty && textBoxPages.Text != string.Empty)
            {
                return true;
            }
            return false;
        }

        private void ClearData()
        {
            textBoxName.Text = string.Empty;
            textBoxAuthor.Text = string.Empty;
            textBoxPages.Text = string.Empty;

            selectedBook = null;
        }
    }
}
