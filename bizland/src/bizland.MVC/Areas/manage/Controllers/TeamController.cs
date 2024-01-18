using bizland.business.Exceptions;
using bizland.business.Services.Interfaces;
using bizland.core.Models;
using Microsoft.AspNetCore.Mvc;

namespace bizland.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class TeamController : Controller
    {
        private readonly ITeamMemberService _teamMemberService;

        public TeamController(ITeamMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _teamMemberService.GetAllAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(TeamMember teamMember)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                await _teamMemberService.CreateAsync(teamMember);
            }
            catch (MemberNotFoundException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (ImageContentException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();

            }
            return RedirectToAction("index");
        }
       
        public async Task<IActionResult> Update(int id)
        {
            var existmember = await _teamMemberService.GetByIdAsync(id);
            if (existmember == null)
            {
                throw new MemberNotFoundException();
            }
            return View(existmember);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(TeamMember teamMember)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                await _teamMemberService.UpdateAsync(teamMember);
            }
            catch (MemberNotFoundException ex)
            {
               
                return View();
            }
            catch(ImageContentException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            return RedirectToAction("index");
        }
  
        public async Task<IActionResult> Delete(int id)
        {
            await _teamMemberService.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
