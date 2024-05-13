using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorPagesContact.Models;
using System.Net;

namespace RazorPagesContact.Pages.Contacts
{
    public class DetailsModel : PageModel
    {
        private readonly IApiClient _httpClient;

        public DetailsModel(IApiClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Contact Contact { get; set; } = new Contact();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"api/contact/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Contact = JsonConvert.DeserializeObject<Contact>(responseContent);
                return Page();
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
