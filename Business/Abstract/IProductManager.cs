using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductManager
    {
        List<Product> GetAll();
        void Create(Product Product);
        Product GetById(int? id);
        void Update(Product Product);

        void Delete(Product Product);

        List<Product> GetFeatured();

    }
}
