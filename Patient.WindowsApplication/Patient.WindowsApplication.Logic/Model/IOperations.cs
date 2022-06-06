namespace Patient.WindowsApplication.Model
{
    public interface IOperations
    {
        void LoadPrescriptionList();

        void LoadVisitList();

        void Login();

        void Logout();

        void AddVisit();
    }
}
