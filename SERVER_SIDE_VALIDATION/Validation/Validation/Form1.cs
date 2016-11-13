using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChecked_Click(object sender, EventArgs e)
        {
            var model = new Person
            {
                Age = (int)txtAge.Value,
                Email = txtEmail.Text,
                EmailConfirm = txtConfirmEmail.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Password = txtPassword.Text,
                Price = (int)txtPrice.Value
            };

            // set default
            model.MyError = "abcdefghijklmnop";

            ValidationContext context = new ValidationContext(model, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            var errorList = new List<string>();
            if (!Validator.TryValidateObject(model, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                { 
                    errorList.Add(result.ErrorMessage);
                }

                MessageBox.Show(string.Join("\n", errorList));
            }
            else
            {
                MessageBox.Show("Validated");
            }

        }
    }
}
