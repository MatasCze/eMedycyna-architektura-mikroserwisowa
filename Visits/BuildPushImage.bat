docker login -u paim2021

docker images

docker tag visitsweb:latest paim2021/paim_proj_visits:visits_latest

docker rmi visitsweb:latest

docker rmi paim2021/paim_proj_visits:visits_latest

docker build -f Visits.Rest/Dockerfile.prod -t paim2021/paim_proj_visits:visits_latest .

docker images

docker image ls --filter label=stage=webservicerest_build

docker image prune --filter label=stage=webservicerest_build

docker push paim2021/paim_proj_visits:visits_latest

docker images

pause
