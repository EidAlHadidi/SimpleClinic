using BL.Models;
using System.Net.Http.Json;

namespace UI
{
    public partial class Form1 : Form
    {
        static readonly HttpClient client = new HttpClient();

        private async Task GetAllPeople()
        {
            client.BaseAddress = new Uri("https://localhost:7000/api/People/GetAllPeople");
            var people = await client.GetFromJsonAsync<List<Person>>("GetAllPeople");
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetAllPeople_Click(object sender, EventArgs e)
        {

        }
    }
}
