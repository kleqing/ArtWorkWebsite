using ArtworkDTO;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace ProductManagementWebClient.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly IUserRolesServices _userRolesService;

        public UserRolesController(IUserRolesServices userRolesService)
        {
            _userRolesService = userRolesService;
        }

        // GET: UserRolesController
        public async Task<ActionResult> Index()
        {
            var userRoles = await _userRolesService.GetAllUserRoles();
            return View(userRoles);
        }

        // GET: UserRolesController/Details/5
        public async Task<ActionResult> Details(int userId, int roleId)
        {
            var userRole = await _userRolesService.GetUserRoleById(userId, roleId);
            if (userRole == null)
            {
                return NotFound();
            }
            return View(userRole);
        }

        // GET: UserRolesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserRoleDTO userRole)
        {
            if (ModelState.IsValid)
            {
                await _userRolesService.Add(userRole);
                return RedirectToAction(nameof(Index));
            }
            return View(userRole);
        }

        // GET: UserRolesController/Edit/5
        public async Task<ActionResult> Edit(int userId, int roleId)
        {
            var userRole = await _userRolesService.GetUserRoleById(userId, roleId);
            if (userRole == null)
            {
                return NotFound();
            }
            return View(userRole);
        }

        // POST: UserRolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int userId, int roleId, UserRoleDTO userRole)
        {
            if (userId != userRole.UserId || roleId != userRole.RoleId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _userRolesService.Update(userRole);
                return RedirectToAction(nameof(Index));
            }
            return View(userRole);
        }

        // GET: UserRolesController/Delete/5
        public async Task<ActionResult> Delete(int userId, int roleId)
        {
            var userRole = await _userRolesService.GetUserRoleById(userId, roleId);
            if (userRole == null)
            {
                return NotFound();
            }
            return View(userRole);
        }

        // POST: UserRolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int userId, int roleId, UserRole userRole)
        {
            try
            {
                await _userRolesService.Delete(userId, roleId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(userRole);
            }
        }
    }
}
