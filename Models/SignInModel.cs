using KickTask.KickTask.Interfaces;

namespace KickTask.Models
{
    public class SignInModel
    {
        private readonly IDatabaseHandler _databaseHandler;

        public SignInModel(IDatabaseHandler databaseHandler)
        {
            _databaseHandler = databaseHandler;
        }
    }
}
