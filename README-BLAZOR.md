# HonestIT Expo Registration - .NET Blazor Server

A high-performance visitor registration application built with .NET Blazor Server, featuring QR code scanning and Google Sheets integration via n8n.

## Features

- ✅ **QR Code Scanning**: Scan QR codes using device camera and automatically populate form data
- ✅ **Visitor Registration Form**: Complete registration form with validation
- ✅ **n8n Integration**: Automatic data submission to Google Sheets via n8n webhook
- ✅ **Modern UI**: Beautiful, responsive design with orange corporate theme
- ✅ **Fast Performance**: Blazor Server architecture for optimal performance
- ✅ **Real-time Updates**: Server-side rendering with SignalR for instant updates

## Prerequisites

- .NET 8.0 SDK or later
- Camera access (for QR code scanning)
- n8n webhook URL configured

## Getting Started

### 1. Restore Dependencies

```bash
dotnet restore
```

### 2. Configure n8n Webhook

Update the n8n webhook URL in `appsettings.json`:

```json
{
  "N8nWebhookUrl": "https://your-n8n-instance.com/webhook/form-submission"
}
```

### 3. Run the Application

```bash
dotnet run
```

The application will be available at:
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`

### 4. Build for Production

```bash
dotnet build -c Release
dotnet publish -c Release
```

## Project Structure

```
HonestITExpo/
├── Pages/
│   ├── Index.razor          # Main registration page with QR scanner
│   └── _Host.cshtml         # Host page
├── Services/
│   └── N8nService.cs        # n8n webhook integration service
├── Models/
│   └── VisitorRegistration.cs  # Data model
├── wwwroot/
│   ├── css/
│   │   └── app.css          # Application styles
│   └── js/
│       └── qr-scanner.js    # QR code scanning JavaScript
├── Program.cs               # Application entry point
└── appsettings.json         # Configuration
```

## QR Code Scanning

1. Click the "📷 Scan QR Code" button
2. Allow camera access when prompted
3. Position the QR code within the camera view
4. The scanned data will automatically appear in the form
5. Click "Clear" to remove scanned data if needed

## n8n Integration

The application sends the following data to n8n webhook:

```json
{
  "fullName": "string",
  "email": "string",
  "mobile": "string",
  "company": "string",
  "industry": "string",
  "designation": "string",
  "interest": "string",
  "message": "string",
  "qrData": "string",
  "timestamp": "ISO 8601 date string"
}
```

### n8n Workflow Setup

1. Create a new n8n workflow
2. Add a **Webhook** node (POST method)
3. Copy the webhook URL
4. Add a **Google Sheets** node
5. Configure to append rows to your spreadsheet
6. Map the fields from webhook to spreadsheet columns

## Technology Stack

- **.NET 8.0**: Core framework
- **Blazor Server**: Server-side rendering with SignalR
- **jsQR**: JavaScript QR code scanning library
- **n8n**: Workflow automation for Google Sheets integration

## Browser Support

- Chrome/Edge (recommended for best QR scanning performance)
- Firefox
- Safari
- Mobile browsers with camera support

## Troubleshooting

### Camera Not Working
- Ensure HTTPS is enabled (required for camera access)
- Check browser permissions for camera access
- Try a different browser

### n8n Webhook Not Receiving Data
- Verify the webhook URL in `appsettings.json`
- Check n8n workflow is active
- Review browser console for errors

### Build Errors
- Ensure .NET 8.0 SDK is installed
- Run `dotnet restore` to restore packages
- Check for any missing dependencies

## License

MIT License - See LICENSE file for details

## Support

For issues or questions, contact: info@honestit.in

