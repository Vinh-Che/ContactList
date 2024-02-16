// Data/ContactDataStore.cs
namespace Contact.Models

{
    public static class ContactDataStore
    {
        internal static IEnumerable<Contact> Contacts;
        private static IHttpContextAccessor _httpContextAccessor;
        public static List<Contact> GetContacts(HttpContext httpContext)
        {
            var session = httpContext.Session;
            var contacts = session.GetObjectFromJson<List<Contact>>("Contacts");
            if (contacts == null)
            {
                contacts = GenerateContacts();
                session.SetObjectAsJson("Contacts", contacts);
            }
            return contacts;
        }


        public static void Initialize(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private static List<Contact> GenerateContacts()
        {
            var contacts = new List<Contact>();
            for (int i = 1; i <= 50; i++)
            {
                contacts.Add(new Contact
                {
                    Id = i,
                    Name = $"Contact {i}",
                    JobTitle = $"JobTitle {i}",
                    Address = $"Address {i}",
                    PhoneNumber = $"555-1234-{i.ToString("D4")}",
                    Birthday = DateTime.Now.AddYears(-20).AddDays(i * 20),
                    Workplace = $"Workplace {i}"
                });
            }
            return contacts;
        }
    }
}
