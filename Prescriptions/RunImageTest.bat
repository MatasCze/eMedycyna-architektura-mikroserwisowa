docker ps -a

docker start prescriptions

docker ps 

docker images

docker pull paim2021/paim_proj_prescriptions:prescriptions_latest

docker run -d -p 8080:80 -p 44300:443 --name prescriptions paim2021/paim_proj_prescriptions:prescriptions_latest

curl -X GET "http://localhost:8080/GetPrescription?patientId=1" -H  "accept: text/plain"

curl -X POST "http://localhost:8080/AddPrescription" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"id\":1001,\"patientId\":101,\"doctorId\":101,\"expiryDate\":\"25.09.2021\",\"medicines\":[{\"id\":1,\"name\":\"test2\"}]}"

curl -X GET "http://localhost:8080/GetAllPrescriptions" -H  "accept: text/plain"

docker stop prescriptions

docker rm prescriptions

pause
