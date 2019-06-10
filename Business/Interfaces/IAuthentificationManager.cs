using KickTask.Models;
using KickTask.Models.Extendet;

namespace KickTask.KickTask.Interfaces
{
    public interface IAuthentificationManager
    {

        void SignOut();

        Account SignedInAccount { get; set; }

        void SignIn(Account accountLogin);
    }
}