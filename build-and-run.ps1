Write-Host "Building Docker image..." -ForegroundColor Green
docker build -t honestit-expo:latest .

Write-Host "`nCreating and starting container..." -ForegroundColor Green
docker run -d -p 8080:80 --name honestit-expo-container honestit-expo:latest

Write-Host "`nContainer started successfully!" -ForegroundColor Green
Write-Host "Your site is available at: http://localhost:8080" -ForegroundColor Cyan
Write-Host "`nUseful commands:" -ForegroundColor Yellow
Write-Host "  Stop container: docker stop honestit-expo-container"
Write-Host "  Remove container: docker rm honestit-expo-container"
Write-Host "  View logs: docker logs honestit-expo-container"
Write-Host "  View running containers: docker ps"

