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
    public class CommentManager : ICommentManager
    {
        private readonly FruitkhaDbContext _context;

        public CommentManager(FruitkhaDbContext context)
        {
            _context = context;
        }
        public List<Comment> GetAll()
        {
            var comments = _context.Comments.ToList();
            return comments;
        }

        public News GetById(int? id)
        {
            var news = _context.News.FirstOrDefault(x => x.Id == id);

            return news;
        }
    }
}
