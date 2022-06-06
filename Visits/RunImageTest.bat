docker ps -a

docker start visits

docker ps 

docker images

docker pull paim2021/paim_proj_visits:visits_latest

docker run -d -p 8080:80 -p 44300:443 --name visits paim2021/paim_proj_visits:visits_latest

curl -X "GET" "http://localhost:8080/GetAllVisits" -H "accept: text/plain"

curl -X "GET" "http://localhost:8080/GetVisits?doctorId=2" -H "accept: text/plain"

curl -X "GET" "http://localhost:8080/GetVisitsPatient?patientId=1" -H "accept: text/plain"

docker stop visits

docker rm visits

pause
