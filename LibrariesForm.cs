using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class LibrariesForm : Form
    {
        private LibraryContext context;
        private Library selectedLibrary;

        public LibrariesForm()
        {
            InitializeComponent();

            context = new LibraryContext(new BookLibraryContext());

            LoadLibraries();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedLibrary != null)
                {
                    MessageBox.Show("You can't create duplicated book!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ValidateData())
                {
                    string Name = textBoxName.Text;
                    string Address = textBoxAddress.Text;

                    Library library = new Library(Name, Address);

                    context.Create(library);
                    MessageBox.Show("Library created successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadLibraries();

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
                Library library = new Library(selectedLibrary.EIK, selectedLibrary.Name, selectedLibrary.Address);

                context.Update(library);

                MessageBox.Show("Library updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadLibraries();

                ClearData();
            }
            else
            {
                MessageBox.Show("All boxes are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedLibrary != null)
            {
                context.Delete(selectedLibrary.EIK);

                LoadLibraries();

                ClearData();

                MessageBox.Show("Library deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dataGridViewLibraries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                DataGridViewRow row = dataGridViewLibraries.Rows[e.RowIndex];

                selectedLibrary = row.DataBoundItem as Library;

                textBoxName.Text = selectedLibrary.Name;
                textBoxAddress.Text = selectedLibrary.Address;
        }

        private void LoadLibraries()
        {
            dataGridViewLibraries.DataSource = context.ReadAll();
        }

        private bool ValidateData()
        {
            if (textBoxName.Text != string.Empty && textBoxAddress.Text != string.Empty)
            {
                return true;
            }
            return false;
        }

        private void ClearData()
        {
            textBoxName.Text = string.Empty;
            textBoxAddress.Text = string.Empty;

            selectedLibrary = null;
        }
    }
}
