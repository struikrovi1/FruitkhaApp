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
    public class TeamManager : ITeamManager
    {
        private readonly FruitkhaDbContext _context;

        public TeamManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Team Team)
        {

            _context.Teams.Add(Team);
            _context.SaveChanges();
        }

        public void Delete(Team Team)
        {
            _context.Teams.Remove(Team);
            _context.SaveChanges();
        }

        public List<Team> GetAll()
        {
            var Team = _context.Teams.ToList();
            return Team;
        }

        public Team GetById(int? id)
        {
            var Team = _context.Teams.FirstOrDefault(x => x.Id == id);

            return Team;
        }

        public void Update(Team Team)
        {
            _context.Teams.Update(Team);
            _context.SaveChanges();
        }
    }
}
