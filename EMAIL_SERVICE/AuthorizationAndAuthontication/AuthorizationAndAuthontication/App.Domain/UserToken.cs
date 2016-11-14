using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    [Table("UserToken")]
    public class UserToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }
        [DefaultValue(0)]
        public int TokenType { get; set; }
        public DateTime CreatedTime { get; set; }
        [DefaultValue(false)]
        public bool IsChecked { get; set; }
    }
}
