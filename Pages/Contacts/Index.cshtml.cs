using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesContact.Models;

namespace RazorPagesContact.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly IApiClient _httpClient;

        public IndexModel(IApiClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IList<Contact> Contact { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var response = await _httpClient.GetAsync("api/contact");

            var contacts = await response.Content.ReadFromJsonAsync<IEnumerable<Contact>>();

            if (!string.IsNullOrEmpty(SearchString) && !string.IsNullOrEmpty(SearchString.Trim()))
            {
                SearchString = SearchString.Trim();
                Contact = contacts.Where(contact =>
                    contact.FirstName.Contains(SearchString) ||
                    contact.LastName.Contains(SearchString) ||
                    contact.CompanyName.Contains(SearchString) ||
                    contact.Email.Contains(SearchString) ||
                    contact.PhoneNumber.Contains(SearchString)).ToList();
            }
            else
            {
                Contact = contacts.ToList();
            }

        }
    }
}
