docker login -u paim2021

docker images

docker tag prescriptionsweb:latest paim2021/paim_proj_prescriptions:prescriptions_latest

docker rmi prescriptionsweb:latest

docker rmi paim2021/paim_proj_prescriptions:prescriptions_latest

docker build -f Prescriptions.Rest/Dockerfile.prod -t paim2021/paim_proj_prescriptions:prescriptions_latest .

docker images

docker image ls --filter label=stage=webservicerest_build

docker image prune --filter label=stage=webservicerest_build

docker push paim2021/paim_proj_prescriptions:prescriptions_latest

docker images

pause
