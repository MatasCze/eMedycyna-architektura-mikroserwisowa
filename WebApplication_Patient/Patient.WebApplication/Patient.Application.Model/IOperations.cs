namespace Patient.Application.Model
{
    public interface IOperations
    {
        void LoadPrescriptionList();

        void LoadVisitList();

        void AddVisit();

        void Login();

        void Logout();
    }
}
