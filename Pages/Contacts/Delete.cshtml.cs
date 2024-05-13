using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorPagesContact.Models;

namespace RazorPagesContact.Pages.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly IApiClient _httpClient;

        public DeleteModel(IApiClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public Contact Contact { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"api/contact/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            Contact = JsonConvert.DeserializeObject<Contact>(responseContent);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.DeleteAsync($"api/contact/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
