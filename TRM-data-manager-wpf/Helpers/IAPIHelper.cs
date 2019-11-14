using System.Threading.Tasks;
using TRM_data_manager_wpf.Models;

namespace TRM_data_manager_wpf.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}