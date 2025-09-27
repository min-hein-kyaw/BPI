using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WinFormsApp1.Form1;

namespace WinFormsApp1
{
    public partial class FormDetail : Form
    {
        private string _receivedId;
        public FormDetail(string? id)
        {
            InitializeComponent();
            _receivedId = id;
        }

        private void FormDetail_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:7157/api/BurmeseRecipe/{_receivedId}").Result;
            if (response.IsSuccessStatusCode)
            {

                string json = response.Content.ReadAsStringAsync().Result;
                var recipes = JsonConvert.DeserializeObject<Recipes>(json);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = recipes;
            }
        }
        public class RecipesResponseModel
        {
            public Recipes[] Recipes { get; set; }
        }

        public class Recipes
        {
            public string Guid { get; set; }
            public string Name { get; set; }
            public string Ingredients { get; set; }
            public string CookingInstructions { get; set; }
            public string UserType { get; set; }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
