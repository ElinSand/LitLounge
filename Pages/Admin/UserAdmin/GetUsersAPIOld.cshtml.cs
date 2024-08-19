using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using LitLounge.Models;
using System.Text.Json;
using System.Net.Http.Json;





namespace LitLounge.Pages.Admin.UserAdmin
{
    //[Authorize(Roles = "Admin")]
    public class GetUserAPIOldModel(HttpClient httpClient) : PageModel
    {
        private readonly HttpClient _httpClient = httpClient;

       

        public List<User> Users { get; set; } = new List<User>();
        public string ErrorMessage { get; set; }


        public async Task OnGetAsync()
        {
            Users = await GetUsersAsync();
        }

        private async Task<List<User>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:44386/api/User");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<User>>() ?? new List<User>();
            }

           return new List<User>();
           
        }
    }
}
