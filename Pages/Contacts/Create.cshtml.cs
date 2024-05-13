using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorPagesContact.Models;
using System.Text;

namespace RazorPagesContact.Pages.Contacts
{
    public class CreateModel : PageModel
    {
        private readonly IApiClient _httpClient;

        public CreateModel(IApiClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Contact Contact { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var json = JsonConvert.SerializeObject(Contact);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/contact", content);
            response.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}
