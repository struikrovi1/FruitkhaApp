using Business.Abstract;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CountdownManager : ICountdownManager
    {

        private readonly FruitkhaDbContext _context;

        public CountdownManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Countdown Countdown)
        {
            
            _context.Countdowns.Add(Countdown);
            _context.SaveChanges();
        }

        public void Delete(Countdown Countdown)
        {
            _context.Countdowns.Remove(Countdown);
            _context.SaveChanges();
        }


        public Countdown GetById(int? id)
        {
            var Countdown = _context.Countdowns
              
                .FirstOrDefault(x => x.Id == id);

      
    

            return Countdown;
        }

        public void Update(Countdown Countdown)
        {
            _context.Countdowns.Update(Countdown);
            _context.SaveChanges();
        }

        public List<Countdown> GetAll()
        {
            var Countdown = _context.Countdowns.ToList();

            return Countdown;

        }

    }
}
