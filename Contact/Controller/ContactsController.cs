namespace Contact.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ContactsController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Contact> Get()
    {
        return ContactDataStore.Contacts;
    }

    [HttpGet("{id}")]
    public ActionResult<Contact> Get(int id)
    {
        var contact = ContactDataStore.Contacts.FirstOrDefault(c => c.Id == id);
        if (contact == null) return NotFound();
        return contact;
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] Contact updatedContact)
    {
        var contact = ContactDataStore.Contacts.FirstOrDefault(c => c.Id == id);
        if (contact == null) return NotFound();


        contact.Name = updatedContact.Name;
        contact.JobTitle = updatedContact.JobTitle;

        HttpContext.Session.SetObjectAsJson("Contacts", ContactDataStore.Contacts);


        return RedirectToAction("Index");
    }

}
