# HonestIT Expo Visitor Registration

Blazor Server app for visitor registration with QR scanning and admin data view.

## Prerequisites
- .NET 8 SDK
- PostgreSQL database

## Configure
Update `appsettings.json` (or environment variables in production):
```json
{
  "N8nWebhookUrl": "https://your-n8n-webhook",
  "ConnectionStrings": {
    "DefaultConnection": "Host=...;Database=Honestexpo;Username=...;Password=..."
  }
}
```

## Run locally
```bash
dotnet restore
dotnet run
# opens https://localhost:5001 or http://localhost:5000
```

## Publish (folder output)
```bash
dotnet publish -c Release -o ./publish
```
Copy the `publish` folder to your server and run:
- Framework-dependent: `dotnet HonestITExpo.dll`
- Self-contained (if built with `-r win-x64 --self-contained true`): `./HonestITExpo.exe`

## Key features
- QR scanner page (camera and handheld), optional image capture
- Admin data page with filtering/search and export
- Local logo assets for offline/publish scenarios
- n8n webhook integration for downstream processing

## Project layout
- `Pages/Index.razor` — visitor form
- `Pages/Scanner.razor` — scanner experience
- `Pages/Admin/Data.razor` — admin data view/export
- `wwwroot/` — static assets (CSS/JS/images)
- `Services/` — n8n/export/registration services

