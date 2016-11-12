using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmailService.Service;
using EmailService.ViewModel;

namespace EmailService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                EmailService.Service.EmailService.WithTemplate(
              EmailType.ForgetPassword).Send(new ForgetPasswordEmailViewModel
              {
                  Emails = new List<string>() { "iamchamith@gmail.com", "iamchamith@yahoo.com" },
                  NewPassword = "123456789",
                  ReseverName = "Chamith"
              });

            });

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                EmailService.Service.EmailService.WithTemplate(
              EmailType.Registration).Send(new RegisterEmailViewModel()
              {
                  Emails = new List<string>() { "iamchamith@gmail.com", "iamchamith@yahoo.com" },
                  Link = "http://gmail.com/" + Guid.NewGuid().ToString(),
                  ReseverName = "Chamith"
              });

            });
        }
    }
}
