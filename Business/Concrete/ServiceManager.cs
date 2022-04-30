using Business.Abstract;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly FruitkhaDbContext _context;

        public ServiceManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Service service)
        {

            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void Delete(Service Service)
        {
            _context.Services.Remove(Service);
            _context.SaveChanges();
        }

        public List<Service> GetAll()
        {
            var Service = _context.Services.Take(4).ToList();
            return Service;
        }

        public Service GetById(int? id)
        {
            var Service = _context.Services.FirstOrDefault(x => x.Id == id);

            return Service;
        }

        public List<Service> HomeServices()
        {
            var Service = _context.Services.Where(x => x.IsIndex == true).Take(3).ToList();
            return Service;
        }

        public void Update(Service Service)
        {
            _context.Services.Update(Service);
            _context.SaveChanges();
        }
    }
}
