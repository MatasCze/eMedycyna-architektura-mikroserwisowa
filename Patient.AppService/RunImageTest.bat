docker ps -a

docker start patient_app

docker ps 

docker images

docker pull paim2021/paim_proj_patient_app:patient_app_latest

docker run -d -p 8080:80 -p 44300:443 --name patient_app paim2021/paim_proj_patient_app:patient_app_latest

docker stop patient_app

docker rm patient_app

pause
