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
    public class NewsManager : INewsManager
    {
        private readonly FruitkhaDbContext _context;

        public NewsManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(News News)
        {

            _context.News.Add(News);
            _context.SaveChanges();
        }

        public void Delete(News News)
        {
            _context.News.Remove(News);
            _context.SaveChanges();
        }

        public List<News> GetAll()
        {
            var News = _context.News.Include(x => x.MyUser).ToList();
            return News;
        }

        public News GetById(int? id)
        {
            var News = _context.News.Include(x => x.MyUser).FirstOrDefault(x => x.Id == id);

            return News;
        }

        public void Update(News News)
        {
            _context.News.Update(News);
            _context.SaveChanges();
        }
    }
}
