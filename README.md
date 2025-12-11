# HonestIT Expo Visitor Registration

Visitor registration form for HonestIT Expo events.

## Docker Deployment on Render

This project uses Docker for containerized deployment.

### Prerequisites

- Docker installed locally (for testing)
- GitHub account
- Render account

### Local Testing with Docker

1. **Build the Docker image:**
   ```bash
   docker build -t honestit-expo .
   ```

2. **Run the container:**
   ```bash
   docker run -d -p 8080:80 --name honestit-expo honestit-expo
   ```

3. **Or use Docker Compose:**
   ```bash
   docker-compose up -d
   ```

4. **Access the site:**
   - Open browser: `http://localhost:8080`

5. **Stop the container:**
   ```bash
   docker-compose down
   # or
   docker stop honestit-expo
   ```

### Deploy to Render with Docker

#### Step 1: Push to GitHub

1. Create a GitHub repository
2. Push your code:
   ```bash
   git init
   git add .
   git commit -m "Initial commit"
   git branch -M main
   git remote add origin https://github.com/your-username/honestit-expo-registration.git
   git push -u origin main
   ```

#### Step 2: Deploy on Render

1. Go to [Render Dashboard](https://dashboard.render.com)
2. Click "New +" → "Web Service"
3. Connect GitHub:
   - Click "Connect GitHub"
   - Authorize Render
   - Select your repository
4. Configure the service:
   - **Name**: `honestit-expo-registration`
   - **Region**: Choose closest to you
   - **Branch**: `main`
   - **Root Directory**: (leave empty)
   - **Environment**: `Docker`
   - **Dockerfile Path**: `Dockerfile` (or leave empty if in root)
   - **Docker Context**: (leave empty)
5. Click "Create Web Service"
6. Wait for deployment (2-5 minutes)
7. Your site will be live at: `https://your-service-name.onrender.com`

### Render Configuration

Render will automatically:
- Detect the Dockerfile
- Build the Docker image
- Deploy the container
- Provide HTTPS automatically
- Handle restarts and scaling

## Features

- Visitor registration form
- Data storage in browser localStorage
- n8n webhook integration for Google Sheets
- Mobile responsive design
- Modern UI with orange corporate theme

## Configuration

Update the n8n webhook URL in `index.html`:
```javascript
const N8N_WEBHOOK_URL = 'https://your-n8n-instance.com/webhook/form-submission';
```

