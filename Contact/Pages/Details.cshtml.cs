using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Contact.Models;

public class DetailsModel : PageModel
{
    [BindProperty]
    public Contact Contact { get; set; }

    public IActionResult OnGet(int id)
    {
        Contact = ContactDataStore.Contacts.FirstOrDefault(c => c.Id == id);
        if (Contact == null)
        {
            return NotFound();
        }
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var contact = ContactDataStore.Contacts.FirstOrDefault(c => c.Id == Contact.Id);
        if (contact != null)
        {
            contact.Name = Contact.Name;
            contact.JobTitle = Contact.JobTitle;
            contact.Address = Contact.Address;
            contact.PhoneNumber = Contact.PhoneNumber;
            contact.Birthday = Contact.Birthday;
            contact.Workplace = Contact.Workplace;

            return RedirectToPage("./Details", new { id = contact.Id });
        }

        return Page();
    }
}
