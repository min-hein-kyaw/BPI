using Newtonsoft.Json;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:7157/api/BurmeseRecipe/Ingredients").Result;
            if (response.IsSuccessStatusCode)
            {

                string json = response.Content.ReadAsStringAsync().Result;
                var recipes = JsonConvert.DeserializeObject<Recipes[]>(json);
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
            if(e.ColumnIndex == 0)
            {
                var id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();

            }
        }
    }
}
