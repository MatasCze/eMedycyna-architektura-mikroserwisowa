docker ps -a

docker start patients

docker ps 

docker images

docker pull paim2021/paim_proj_patients:patients_latest

docker run -d -p 8080:80 -p 44300:443 --name patients paim2021/paim_proj_patients:patients_latest

curl -X GET "http://localhost:8080/GetAllPatients" -H  "accept: text/plain"

curl -X GET "http://localhost:8080/GetPatientByPesel?pesel=00000000002" -H  "accept: text/plain"

docker stop patients

docker rm patients

pause
