docker login -u paim2021

docker images

docker tag patientsweb:latest paim2021/paim_proj_patients:patients_latest

docker rmi patientsweb:latest

docker rmi paim2021/paim_proj_patients:patients_latest

docker build -f Patients/Dockerfile.prod -t paim2021/paim_proj_patients:patients_latest .

docker images

docker image ls --filter label=stage=webservicerest_build

docker image prune --filter label=stage=webservicerest_build

docker push paim2021/paim_proj_patients:patients_latest

docker images

pause
