﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IOS_PROJECT3.Models;
using IOS_PROJECT3.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace IOS_PROJECT3.Controllers
{
    public class RolesController : Controller
    {
        private DBMergedContext DBContext;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<EUser> userManager;

        public RolesController(DBMergedContext DBContext, RoleManager<IdentityRole> roleManager, UserManager<EUser> userManager)
        {
            this.DBContext = DBContext;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var model = new RolesViewModel(DBContext)
            {
                allRoles = roleManager.Roles.ToList()
            };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string roleName)
        {
            if (!String.IsNullOrWhiteSpace(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (result.Succeeded)
                {
                    // return View(roleName);//возможно стоит изменить на редирект
                    return RedirectToAction("Index");
                }
                else
                {
                    var Errors = result.Errors;
                    foreach (var err in Errors)
                    {
                        ModelState.AddModelError(string.Empty, err.Description);
                    }
                }
            }
            return View(roleName);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if(role!=null)
            await roleManager.DeleteAsync(role);
            
            return RedirectToAction("Index");
        }

        public IActionResult UserList()
        {
            return View(userManager.Users.ToList());
        }

        public async Task<IActionResult> Edit(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if(user!=null)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var allRoles = roleManager.Roles.ToList();
                var viewModel = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    AllRoles = allRoles,
                    UserRoles = userRoles
                };
                return View(viewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            
            EUser user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await userManager.GetRolesAsync(user);              
                var allRoles = roleManager.Roles.ToList();
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await userManager.AddToRolesAsync(user, addedRoles);

                await userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("Index", "UsersAdmin");
            }

            return NotFound();
        }
    }
}