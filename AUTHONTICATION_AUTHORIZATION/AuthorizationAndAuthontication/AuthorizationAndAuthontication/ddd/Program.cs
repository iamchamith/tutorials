using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ddd
{
    class Program
    {
        static void Main(string[] args)
        {
            //create the DataTable that will hold the data
            XmlDocument doc = new XmlDocument();
            doc.Load(@"E:\EDUCATION\THREADS\EmailService\AuthorizationAndAuthontication\AuthorizationAndAuthontication\ddd\test.xml");
            // doc.LoadXml(stringXml);

            DataTable dt = new DataTable();

            if (doc.ChildNodes[1] != null)
                dt.Columns.Add(doc.ChildNodes[1].Name); //Assuming you want the rood node to be the only column of the datatable

            //iterate through all the childnodes of your root i.e. Category
            foreach (XmlNode node in doc.ChildNodes[1].ChildNodes)
            {
                dt.Rows.Add(node.Name);
            }
            Console.Read();
        }
    }
}
