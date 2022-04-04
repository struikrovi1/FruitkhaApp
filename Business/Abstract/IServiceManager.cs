using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceManager
    {

        List<Service> GetAll();
        void Create(Service service);
        Service GetById(int? id);
        void Update(Service service);

        void Delete(Service service);
    }
}
