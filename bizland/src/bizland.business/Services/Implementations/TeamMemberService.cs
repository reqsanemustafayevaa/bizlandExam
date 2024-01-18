using bizland.business.Exceptions;
using bizland.business.Extentions;
using bizland.business.Services.Interfaces;
using bizland.core.Models;
using bizland.core.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bizland.business.Services.Implementations
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IWebHostEnvironment _env;

        public TeamMemberService(ITeamMemberRepository teamMemberRepository
                                ,IWebHostEnvironment env)
        {
            _teamMemberRepository = teamMemberRepository;
           _env = env;
        }
        public async Task CreateAsync(TeamMember teamMember)
        {
            if(teamMember == null)
            {
                throw new MemberNotFoundException();
            }
            if(teamMember.ImageFile != null)
            {
                if(teamMember.ImageFile.ContentType!="image/jpeg" && teamMember.ImageFile.ContentType != "image/png")
                {
                    throw new ImageContentException("ImageFile","file must be .jpg or .png!");
                }
                if (teamMember.ImageFile.Length > 1048576)
                {
                    throw new InvalidImageSizeException("ImageFile","File must be lower than 1 mb!");
                }
                teamMember.ImageUrl = teamMember.ImageFile.SaveFile(_env.WebRootPath, "uploads/members");
                
            }
            teamMember.CreatedDate = DateTime.UtcNow;
            teamMember.UpdatedDate = DateTime.UtcNow;
            await _teamMemberRepository.CreateAsync(teamMember);
            await _teamMemberRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var existmember = await _teamMemberRepository.GetByIdAsync(x => x.Id == id);
            if (existmember == null)
            {
                throw new MemberNotFoundException();
            }
            _teamMemberRepository.Delete(existmember);
            await _teamMemberRepository.CommitAsync();
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
                throw new MemberNotFoundException();
            }
            return existmember;
        }

        public async Task UpdateAsync(TeamMember teamMember)
        {
            if (teamMember == null)
            {
                throw new NullReferenceException();
            }
            var existmember = await _teamMemberRepository.GetByIdAsync(x => x.Id == teamMember.Id && x.IsDeleted==false);
            if (existmember == null)
            {
                throw new MemberNotFoundException();
            }
            if (teamMember.ImageFile != null)
            {
                if (teamMember.ImageFile.ContentType != "image/jpeg" && teamMember.ImageFile.ContentType != "image/png")
                {
                    throw new ImageContentException("ImageFile", "file must be .jpg or .png!");
                }
                if (teamMember.ImageFile.Length > 1048576)
                {
                    throw new InvalidImageSizeException("ImageFile", "File must be lower than 1 mb!");
                }
                Helper.DeleteFile(_env.WebRootPath, "uploads/members", existmember.ImageUrl);
                teamMember.ImageUrl = teamMember.ImageFile.SaveFile(_env.WebRootPath, "uploads/members");
               
            }
            existmember.FullName = teamMember.FullName;
            existmember.Profession = teamMember.Profession;
            existmember .InstaUrl = teamMember.InstaUrl;
            existmember.FbUrl = teamMember.FbUrl;
            existmember.TwitterUrl = teamMember.TwitterUrl;
            existmember.LinkEdinUrl = teamMember.LinkEdinUrl;
            existmember.UpdatedDate = DateTime.UtcNow;
            await _teamMemberRepository.CommitAsync();

        }
    }
}
