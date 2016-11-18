using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvC_Lab6_Technician_Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void techniciansBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            //check if valid here
            if(isValidLength(techIDTextBox) && isValidLength(nameTextBox) && isValidLength(emailTextBox) && isValidLength(phoneTextBox))
            {
                try
                {
                    this.techniciansBindingSource.EndEdit();
                }
                catch (NoNullAllowedException)
                {
                    MessageBox.Show("Please enter valid data types!", "Database Error");
                }
                
            }
            else
            {
                MessageBox.Show("Input fields are incorrect!", "Error!");
            }
            
            this.tableAdapterManager.UpdateAll(this.techSupportDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'techSupportDataSet.Technicians' table. You can move, or remove it, as needed.
            this.techniciansTableAdapter.Fill(this.techSupportDataSet.Technicians);

        }


        //handel invalid lenghts
        private bool isValidLength(TextBox txt)
        {
            if (txt.Text.Length < 25)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
