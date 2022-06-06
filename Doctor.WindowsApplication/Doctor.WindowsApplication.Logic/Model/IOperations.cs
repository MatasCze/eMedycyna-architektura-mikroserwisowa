namespace Doctor.WindowsApplication.Logic.Model
{
    public interface IOperations
    {
        void LoadPrescriptionList();

        void LoadVisitList();

        void Login();

        void Logout();
    }
}
