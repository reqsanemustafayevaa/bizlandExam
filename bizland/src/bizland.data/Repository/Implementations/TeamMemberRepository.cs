using bizland.core.Models;
using bizland.core.Repositories.Interfaces;
using bizland.data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.data.Repository.Implementations
{
    public class TeamMemberRepository : GenericRepository<TeamMember>,ITeamMemberRepository
    {
        public TeamMemberRepository(AppDbContext context) : base(context)
        {
        }
    }
}
