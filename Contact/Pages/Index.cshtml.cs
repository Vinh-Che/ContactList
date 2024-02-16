// Pages/Index.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Contact.Models;

public class IndexModel : PageModel
{
    public List<Contact> Contacts { get; private set; }

    public void OnGet()
    {
        Contacts = HttpContext.Session.GetObjectFromJson<List<Contact>>("Contacts");
        if (Contacts == null)
        {
            Contacts = (List<Contact>?)ContactDataStore.Contacts;
            HttpContext.Session.SetObjectAsJson("Contacts", Contacts);
        }
    }
}