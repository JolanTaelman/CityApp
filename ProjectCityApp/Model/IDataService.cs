using System.Threading.Tasks;

namespace ProjectCityApp.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}