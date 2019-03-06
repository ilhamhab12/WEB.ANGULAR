using Angular.Microservice.DataAccess.Model;
using Angular.Microservice.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Microservice.Common.Interface
{
    public interface IItemRepository
    {
        bool Insert(ItemParam itemParam);
        bool Update(int? Id, ItemParam itemParam);
        bool Delete(int? Id);
        List<Item> Get();
        Item Get(int? Id);
    }
}
