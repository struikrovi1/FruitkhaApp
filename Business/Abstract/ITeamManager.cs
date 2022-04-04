using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITeamManager
    {
        List<Team> GetAll();
        void Create(Team Team);
        Team GetById(int? id);
        void Update(Team Team);

        void Delete(Team Team);
    }
}
