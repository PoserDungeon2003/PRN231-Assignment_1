using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SilverPE_BOs.Models;

namespace SilverPE_RazorPage.Pages.SilverPage
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public List<SilverJewelry> SilverJewelry { get; set; } = new List<SilverJewelry>();

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var token = HttpContext.Session.GetString("token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToPage("/login/index");
            }

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"{Const.apiUrl}/api/SilverJewelry");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return RedirectToPage("/login/index");
            }
            else if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                SilverJewelry = JsonSerializer.Deserialize<List<SilverJewelry>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<SilverJewelry>();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error fetching data from API.");
            }
            return Page();
        }
    }
}
