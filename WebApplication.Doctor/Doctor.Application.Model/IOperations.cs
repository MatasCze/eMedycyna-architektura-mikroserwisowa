namespace Doctor.Application.Model
{
    public interface IOperations
    {
        void LoadPrescriptionList();

        void LoadVisitList();

        void AddPrescription();

        void Login();

        void Logout();
    }
}
