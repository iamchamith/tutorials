using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExternalClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static HttpClient client = new HttpClient();
        private void button1_Click(object sender, EventArgs e)
        {
            RunAsync().Wait();
        }
        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://foo.dev.com:7777/api/WindowsResponse/get?test=hi");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {

                var product = await GetProductAsync("http://foo.dev.com:7777/api/WindowsResponse/get?test=hi");

                foreach (var item in product)
                {
                    Console.WriteLine(item);
                }

            }
            catch (Exception) { throw; }

        }
        static async Task<List<string>> GetProductAsync(string path)
        {
            List<string> product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<List<string>>();
            }
            return product;
        }
    }
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
