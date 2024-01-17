using bizland.business.Services.Interfaces;
using bizland.core.Models;
using bizland.core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.business.Services.Implementations
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamMemberRepository _teamMemberRepository;

        public TeamMemberService(ITeamMemberRepository teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }
        public Task CreateAsync(TeamMember teamMember)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TeamMember>> GetAllAsync()
        {
            return await _teamMemberRepository.GetAllAsync().ToListAsync();
        }

        public async Task<TeamMember> GetByIdAsync(int id)
        {
            var existmember=await _teamMemberRepository.GetByIdAsync(x=> x.Id == id);
            if(existmember == null)
            {
                throw new Exception()
            }
        }

        public Task UpdateAsync(TeamMember teamMember)
        {
            throw new NotImplementedException();
        }
    }
}
