using System.Threading.Tasks;

namespace MvvmLight1.Model
{
    internal interface IBusinessService
    {
        Task<Business> GetData();
    }
}