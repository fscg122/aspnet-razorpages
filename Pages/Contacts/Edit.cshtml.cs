using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorPagesContact.Models;
using System.Text;

namespace RazorPagesContact.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly IApiClient _httpClient;

        public EditModel(IApiClient httpClient)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var json = JsonConvert.SerializeObject(Contact);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            if (Contact.Id == 0)
            {
                var response = await _httpClient.PostAsync("api/contact", content);
                response.EnsureSuccessStatusCode();
            }
            else
            {
                var response = await _httpClient.PutAsync($"api/contact/{Contact.Id}", content);
                response.EnsureSuccessStatusCode();
            }

            return RedirectToPage("./Index");
        }
    }
}
