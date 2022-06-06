docker login -u paim2021

docker images

docker tag patientapp:latest paim2021/paim_proj_patient_app:patient_app_latest

docker rmi patientapp:latest

docker rmi paim2021/paim_proj_patient_app:patient_app_latest

docker build -f Patient.AppService.Rest/Dockerfile.prod -t paim2021/paim_proj_patient_app:patient_app_latest .

docker images

docker image ls --filter label=stage=webservicerest_build

docker image prune --filter label=stage=webservicerest_build

docker push paim2021/paim_proj_patient_app:patient_app_latest

docker images

pause
