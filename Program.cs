using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using HonestITExpo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();

// Add Entity Framework with PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<HonestITExpo.Services.N8nService>();
builder.Services.AddScoped<HonestITExpo.Services.RegistrationService>();
builder.Services.AddScoped<HonestITExpo.Services.ExportService>();

var app = builder.Build();

// Ensure database is created and migrated
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        // Use EnsureCreated which will create tables if they don't exist
        // This will also add the QrImage column if the table exists but column doesn't
        var created = context.Database.EnsureCreated();
        if (created)
        {
            logger.LogInformation("Database and tables created successfully.");
        }
        else
        {
            logger.LogInformation("Database already exists. Checking for schema updates...");
            // Try to add QrImage column if it doesn't exist
            try
            {
                context.Database.ExecuteSqlRaw(@"
                    DO $$ 
                    BEGIN 
                        IF NOT EXISTS (
                            SELECT 1 FROM information_schema.columns 
                            WHERE table_name = 'VisitorRegistrations' 
                            AND column_name = 'QrImage'
                        ) THEN
                            ALTER TABLE ""VisitorRegistrations"" ADD COLUMN ""QrImage"" text;
                        END IF;
                    END $$;
                ");
                logger.LogInformation("Schema check completed.");
            }
            catch (Exception schemaEx)
            {
                logger.LogWarning(schemaEx, "Could not update schema. This is normal if column already exists.");
            }
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred creating/updating the database.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

