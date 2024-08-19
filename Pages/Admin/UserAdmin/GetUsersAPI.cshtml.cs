using LitLounge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;

namespace LitLounge.Pages.Admin.UserAdmin
{
    [Authorize(Roles = "Admin")]
    public class GetUsersAPIModel(HttpClient httpClient) : PageModel
    {
        private readonly HttpClient _httpClient = httpClient;
        public List<User> Users { get; set; } = new List<User>();


        private async Task<List<User>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync("https://litloungeapi-h5hza3ebcxgtgzda.northeurope-01.azurewebsites.net/api/User/");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<User>>() ?? new List<User>();
            }

            return new List<User>();

        }
        public async Task OnGetAsync()
        {
            Users = await GetUsersAsync();
        }
    }
}
