using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp_.NetCore3._1_with_custom_identity.Data;
using WebApp_.NetCore3._1_with_custom_identity.Models;

namespace WebApp_.NetCore3._1_with_custom_identity.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;


        //private readonly
        public RolesController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        // GET: Roles
        public ActionResult Index()
        {
            var role = _roleManager.Roles.ToList();
            var vm = new List<RoleViewModel>();
            role.ForEach(item => vm.Add(
                new RoleViewModel()
                {
                    Id=item.Id,
                    Name=item.Name
                }
                ));
            return View(vm);
        }

        // GET: Roles/Details/5
        public async Task <ActionResult> Details(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return View("NotFound");
            }
            var model = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name
            };
            return View(model);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name=model.Name
                };
                IdentityResult result =await _roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Roles");
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        
        }

        // GET: Roles/Edit/5
        public async Task <ActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return View("NotFound");
            }
            var model = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name
            };

            return View(model);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                return View("NotFound");
            }
            else
            {
                role.Name = model.Name;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Roles");
                }
                return View(model);
            }
           

            
        }

        // GET: Roles/Delete/5
        public async Task <ActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return View("NotFound");
            }
            var model = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name
            };

            return View(model);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Delete(RoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                return View("NotFound");
            }
            else
            {

                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Roles");
                }
                return View(model);
            }
        }
    }
}