docker login -u paim2021

docker images

docker tag doctorapp:latest paim2021/paim_proj_doctor_app:doctor_app_latest

docker rmi doctorapp:latest

docker rmi paim2021/paim_proj_doctor_app:doctor_app_latest

docker build -f Doctor.AppService.Rest/Dockerfile.prod -t paim2021/paim_proj_doctor_app:doctor_app_latest .

docker images

docker image ls --filter label=stage=webservicerest_build

docker image prune --filter label=stage=webservicerest_build

docker push paim2021/paim_proj_doctor_app:doctor_app_latest

docker images

pause
