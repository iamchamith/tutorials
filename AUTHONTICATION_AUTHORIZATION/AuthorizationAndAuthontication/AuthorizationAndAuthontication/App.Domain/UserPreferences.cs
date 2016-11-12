using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class UserPreferences
    {
        [Key]
        public string UserId { get; set; }
        [StringLength(50)]
        public string DateTimeFormat { get; set; }
        [StringLength(50)]
        public string Language { get; set; }

        [ForeignKey("UserId")]
        public Users User { get; set; }

    }
}
