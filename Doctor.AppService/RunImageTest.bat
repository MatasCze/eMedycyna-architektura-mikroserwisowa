docker ps -a

docker start doctor_app

docker ps 

docker images

docker pull paim2021/paim_proj_doctor_app:doctor_app_latest

docker run -d -p 8080:80 -p 44300:443 --name doctor_app paim2021/paim_proj_doctor_app:doctor_app_latest

docker stop doctor_app

docker rm doctor_app

pause
