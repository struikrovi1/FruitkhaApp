using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactManager
    {
        List<Contact> GetAll();
        void Create(Contact contact);
        Contact GetById(int? id);
        void Update(Contact contact);

        void Delete(Contact contact);
    }
}
