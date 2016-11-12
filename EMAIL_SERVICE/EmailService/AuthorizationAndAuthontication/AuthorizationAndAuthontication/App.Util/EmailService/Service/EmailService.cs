using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using App.Util.EmailService.ViewModel;
using System.Collections.ObjectModel;
using App.Bo.Enums;

namespace App.Util.EmailService.Service
{
    public class EmailService
    {
        private static EmailType Type { get; set; }

        public static EmailService WithTemplate(EmailType type)
        {
            return new EmailService(type);
        }

        protected EmailService(EmailType type)
        {
            Type = type;
        }

        public void Send<T>(T view) where T : class
        {
            try
            {
                switch (Type)
                {
                    case EmailType.Registration:
                        SendRegisterEmail(view as RegisterEmailViewModel);
                        break;
                    case EmailType.ForgetPassword:
                        SendForgetPasswordEmail(view as ForgetPasswordEmailViewModel);
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
      
        }
        static void SendRegisterEmail(RegisterEmailViewModel items)
        {
            // access template
            // apply data to placeholder
            var template = Data.RegisterTemplate();
            var subject = TemplateStringWithValue(template[1], GetPropertyValues(items));
            var body = TemplateStringWithValue(template[0], GetPropertyValues(items));
            var collection = new MailAddressCollection();
            foreach (var email in items.Emails)collection.Add(new MailAddress(email, email));
            Task.Factory.StartNew(() => new Send(collection, subject, body));
        }

        static void SendForgetPasswordEmail(ForgetPasswordEmailViewModel items)
        {
            // access template
            // apply data to please holder
            // access template
            // apply data to placeholder
            var template = Data.ForgetPasswordTemplate();
            var subject = TemplateStringWithValue(template[1], GetPropertyValues(items));
            var body = TemplateStringWithValue(template[0], GetPropertyValues(items));
            var collection = new MailAddressCollection();
            foreach (var email in items.Emails) collection.Add(new MailAddress(email, email));
            Task.Factory.StartNew(() => new Send(collection, subject, body));
        }


        public static string TemplateStringWithValue(string content, Dictionary<string, string> values)
        {
            return values.Aggregate(content, (current, value) => current.Replace($"#{value.Key}#", value.Value));
        }
        public static Dictionary<string, string> GetPropertyValues<T>(T source)
        {
            var result = new Dictionary<string, string>();
            var properties = source.GetType().GetProperties();
            foreach (var property in properties)
            {
                var name = property.Name;
                var value = property.GetValue(source)?.ToString();
                result.Add(name, value);
            }
            return result;
        }

    }



}
