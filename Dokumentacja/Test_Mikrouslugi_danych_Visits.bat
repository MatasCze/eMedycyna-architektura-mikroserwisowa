@echo off

echo Pobranie wszystkich wizyt:
curl -X "GET" "https://localhost:44346/GetAllVisits" -H "accept: text/plain"
echo. 
echo.

echo Pobranie wizyty dla wybranego lekarza"
curl -X "GET" "https://localhost:44346/GetVisits?doctorId=2" -H "accept: text/plain"
echo.
echo.

echo Pobranie wizyty dla wybranego pacjenta"
curl -X "GET" "https://localhost:44346/GetVisitsPatient?patientId=1" -H "accept: text/plain"
echo.
echo

pause