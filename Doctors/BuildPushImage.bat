docker login -u paim2021

docker images

docker tag doctorsweb:latest paim2021/paim_proj_doctors:doctors_latest

docker rmi doctorsweb:latest

docker rmi paim2021/paim_proj_doctors:doctors_latest

docker build -f Doctors.Rest/Dockerfile.prod -t paim2021/paim_proj_doctors:doctors_latest .

docker images

docker image ls --filter label=stage=webservicerest_build

docker image prune --filter label=stage=webservicerest_build

docker push paim2021/paim_proj_doctors:doctors_latest

docker images

pause
