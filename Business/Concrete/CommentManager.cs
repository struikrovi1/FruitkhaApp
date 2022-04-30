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
        public List<Comment> GetAllComment(int newsId)
        {
            var comments = _context.Comments.Where(x => x.NewsId == newsId).ToList();
            return comments;
        }

        public void AddComment(Comment comment)
        {
            comment.CreatedDate = DateTime.Now;
            _context.Add(comment);
            _context.SaveChanges();
        }

    }
}
