@echo off
echo Building Docker image...
docker build -t honestit-expo:latest .

echo.
echo Creating and starting container...
docker run -d -p 8080:80 --name honestit-expo-container honestit-expo:latest

echo.
echo Container started successfully!
echo Your site is available at: http://localhost:8080
echo.
echo To stop the container, run: docker stop honestit-expo-container
echo To remove the container, run: docker rm honestit-expo-container
echo To view logs, run: docker logs honestit-expo-container

pause

