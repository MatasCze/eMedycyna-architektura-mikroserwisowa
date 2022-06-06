@echo off

echo Pobranie wszystkich wizyt:
curl -X "GET" "https://localhost:44346/GetAllVisits" -H "accept: text/plain"
echo. 
echo.

echo Pobranie wizyty dla wybranego lekarza o id = 2"
curl -X "GET" "https://localhost:44346/GetVisits?doctorId=2" -H "accept: text/plain"
echo.
echo.

echo Pobranie wizyty dla wybranego pacjenta o id = 1"
curl -X "GET" "https://localhost:44346/GetVisitsPatient?patientId=1" -H "accept: text/plain"
echo.
echo.

echo Dodanie nowej wizyty"
curl -X "POST" "https://localhost:44346/AddVisit" -H "accept: */*" -H "Content-Type: application/json" -d "{\"id\": 1000,\"doctorId\": 1,\"patientId\": 1,\"problem\": \"nos\",\"date\": \"01.05.2021\",\"room\": \"10a\"}"
echo.
echo

echo Pobranie wszystkich wizyt (w celu sprawdzenia poprawnego dodania nowej wizyty):
curl -X "GET" "https://localhost:44346/GetAllVisits" -H "accept: text/plain"
echo. 
echo.

pause