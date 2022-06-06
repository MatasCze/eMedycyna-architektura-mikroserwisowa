docker ps -a

docker start doctors

docker ps 

docker images

docker pull paim2021/paim_proj_doctors:doctors_latest

docker run -d -p 8080:80 -p 44300:443 --name doctors paim2021/paim_proj_doctors:doctors_latest

curl -X "GET" "http://localhost:8080/GetAllDoctors" -H "accept: text/plain"

curl -X "GET" "http://localhost:8080/GetDoctor?lastName=Wysocki" -H "accept: text/plain"

docker stop doctors

docker rm doctors

pause
