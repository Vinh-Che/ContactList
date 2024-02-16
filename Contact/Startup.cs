namespace Contact.Models; // Adjust this using directive based on your actual namespace

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Enable CORS with specified policy
        services.AddCors(options =>
        {
            options.AddPolicy("AllowWebApp",
                builder => builder.WithOrigins("http://localhost:3000") // Adjust this if your client is served from a different origin
                                  .AllowAnyMethod()
                                  .AllowAnyHeader());
        });

        // Add services and session for controllers
        services.AddControllers();
        services.AddSession();
        services.AddHttpContextAccessor();


        // Initialize your contact data store here if applicable
        // Assuming ContactDataStore is a static class you've defined to hold your contacts
        InitializeContactDataStore();


    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
    {
        // Use CORS policy
        app.UseCors("AllowWebApp");

        // Enable routing and use MVC controllers (without views)
        app.UseRouting();
        app.UseSession();
        ContactDataStore.Initialize(httpContextAccessor);

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); // Map attribute-routed API controllers
        });

        // Other middleware configurations can be added here as needed
    }

    private void InitializeContactDataStore()
    {
        // Clear existing contacts to avoid duplicates when the application restarts
        ContactDataStore.Contacts.Clear();

        // Initialize with 50 contacts
        for (int i = 1; i <= 50; i++)
        {
            ContactDataStore.Contacts.Add(new Contact
            {
                Id = i,
                Name = $"Contact {i}",
                JobTitle = $"Job Title {i}",
                Address = $"Address {i}",
                PhoneNumber = $"Phone Number {i}",
                Birthday = DateTime.Now.AddYears(-i),
                Workplace = $"Workplace {i}"
            });
        }
    }
}
