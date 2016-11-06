using App.Util.Emails.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App.Util.Emails.ViewModel.EnumEmailType;

namespace App.Util.Emails.Template
{
    public class TemplateSender
    {
        public EmailViewModel GetTemplate(EEnumEmailType template) {

            var file = File.ReadAllText("");
            return new EmailViewModel
            {
                Body = file.Split('%')[0].Trim(),
                Subject = file.Split('%')[1].Trim()
            };
        }
    }
}
