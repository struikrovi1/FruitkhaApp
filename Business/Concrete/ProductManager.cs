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
    public class ProductManager : IProductManager
    {

        private readonly FruitkhaDbContext _context;

        public ProductManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Product Product)
        {

            _context.Products.Add(Product);
            _context.SaveChanges();
        }

        public void Delete(Product Product)
        {
            _context.Products.Remove(Product);
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            var Product = _context.Products.Include(x=>x.Category).ToList();
            return Product;
        }

        public List<Product> GetFeatured()
        {
            var featuredproduct = _context.Products
                 .Where(x => x.IsFeatured == true && x.Available == true)
                .Take(3)
               
                .ToList();
            return featuredproduct;
        }

        public Product GetById(int? id)
        {
            var Product = _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);

            return Product;
        }

        public void Update(Product Product)
        {
            _context.Products.Update(Product);
            _context.SaveChanges();
        }

    }
}
