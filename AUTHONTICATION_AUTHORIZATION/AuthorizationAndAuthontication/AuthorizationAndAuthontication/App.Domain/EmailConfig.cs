using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain
{
    [Table("EmailConfig")]
    public class EmailConfig
    {
        [Key]
        public string SendEmail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string SmtpAddress { get; set; }
        [Required]
        public int PortNumber { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool EnableSSL { get; set; }
    }
}
