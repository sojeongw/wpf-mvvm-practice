using System.Threading.Tasks;
using TRM_data_manager_wpf.Library.Models;

namespace TRM_data_manager_wpf.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}