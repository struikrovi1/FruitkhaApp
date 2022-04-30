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
            var Product = _context.Products.Include(x=>x.Category).Where(x=>x.Discount==null).ToList();
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

        public List<Product> GetDiscount()
        {
            var discount = _context.Products.
                Where(x => x.Discount !=null).ToList();
            return discount;
        }

        public Product GetById(int? id)
        {
            var Product = _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);

            return Product;
        }


        public Product GetByDisc(int? id)
        {
            var Product = _context.Products.Include(x => x.Category).Where(x=>x.isDiscount==true).FirstOrDefault(x => x.Id == id);

            return Product;
        }

        public void Update(Product Product)
        {
            _context.Products.Update(Product);
            _context.SaveChanges();
        }

        public List<Product> Similar(int catId, int proId)
        {
            var pros = _context.Products
                .Include(x=>x.Category)
                .Where(x=>x.CategoryId==catId&x.Id != proId)
                .ToList();

            return pros;
        }

        public async Task<List<Product>>? GetByIds(IEnumerable<int> ids)
        {
            return await _context.Products
           .Include(c => c.Category)
               .Where(c => ids.Contains(c.Id))
               .ToListAsync();
        }
    }
}
