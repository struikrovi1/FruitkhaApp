using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICountdownManager
    {

         List<Countdown> GetAll();
        void Create(Countdown Countdown);
        Countdown GetById(int? id);

      
        void Update(Countdown Countdown);

        void Delete(Countdown Countdown);
    }
}
