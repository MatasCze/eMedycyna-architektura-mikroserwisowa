@echo off

echo Pobranie wszystkich pacjentów:
curl -X GET "https://localhost:44391/GetAllPatients" -H  "accept: text/plain"
echo. 
echo.

echo Pobranie wszystkich recept"
curl -X GET "https://localhost:44391/GetAllPrescriptions" -H  "accept: text/plain"
echo.
echo.

echo Pobranie recepty dla pacjenta o numerze pesel = 00000000001"
curl -X GET "https://localhost:44391/GetPrescriptions?pesel=00000000001" -H  "accept: text/plain"
echo.
echo.

echo Pobranie wizyt dla danego lekarza o id = 1"
curl -X GET "https://localhost:44391/GetVisits?doctorId=1" -H  "accept: text/plain"
echo.
echo.

echo Dodanie nowej recepty o id=8
curl -X POST "https://localhost:44391/AddPrescription" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"id\":8,\"patientId\":1,\"doctorId\":1,\"expiryDate\":\"29.04.2021\",\"medicines\":[{\"id\":1,\"name\":\"apap\"}]}"
echo.
echo.

echo Pobranie wszystkich recept (w celu sprawdzenia poprawnego dodania nowej wizyty):
curl -X GET "https://localhost:44391/GetAllPrescriptions" -H  "accept: text/plain"
echo.
echo.

pause