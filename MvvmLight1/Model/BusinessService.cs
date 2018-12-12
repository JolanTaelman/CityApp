using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight1.Model
{
    class BusinessService : IBusinessService
    {

        public Task<Business> GetData()
        {
            // Simulate by returning a DataItem
            var item = new Business();
            item.Category = "Restaurant";
            item.Name = "TestRestaurant";
            item.User = new User();

            return Task.FromResult(item);
        }

       
    }
}
