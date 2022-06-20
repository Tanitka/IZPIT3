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
    public partial class CustomersForm : Form
    {
        private CustomerContext context;
        private Customers selectedCustomer;

        public CustomersForm()
        {
            InitializeComponent();

            context = new CustomerContext(new BookLibraryContext());

            LoadCustomers();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCustomer != null)
                {
                    MessageBox.Show("You can't create duplicated book!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ValidateData())
                {
                    string FirstName = textBoxFirstName.Text;
                    string LastName = textBoxLastName.Text;
                    int Age = int.Parse(textBoxAge.Text);

                    Customers customers = new Customers(FirstName, LastName, Age);

                    context.Create(customers);
                    MessageBox.Show("Customer created successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadCustomers();

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
                Customers customer = new Customers(selectedCustomer.ID, textBoxFirstName.Text, textBoxLastName.Text, Convert.ToInt32(textBoxAge.Text));

                context.Update(customer);

                MessageBox.Show("Customer updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCustomers();

                ClearData();
            }
            else
            {
                MessageBox.Show("All boxes are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomer != null)
            {
                context.Delete(selectedCustomer.ID);

                LoadCustomers();

                ClearData();

                MessageBox.Show("Customer deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You must select a customer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewCustomers.Rows[e.RowIndex];

            selectedCustomer = row.DataBoundItem as Customers;

            textBoxFirstName.Text = selectedCustomer.FirstName;
            textBoxLastName.Text = selectedCustomer.SecondName;
            textBoxAge.Text = selectedCustomer.Age.ToString();
        }

        private void LoadCustomers()
        {
            dataGridViewCustomers.DataSource = context.ReadAll();
        }

        private bool ValidateData()
        {
            if (textBoxFirstName.Text != string.Empty && textBoxAge.Text != string.Empty && textBoxLastName.Text != string.Empty)
            {
                return true;
            }
            return false;
        }

        private void ClearData()
        {
            textBoxFirstName.Text = string.Empty;
            textBoxAge.Text = string.Empty;
            textBoxLastName.Text = string.Empty;

            selectedCustomer = null;
        }
    }
}
