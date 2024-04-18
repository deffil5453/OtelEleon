// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using OtelEleon.Models;

namespace OtelEleon.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }


        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                User identity = new User { UserName = Input.UserName };
                string roleName = "Manager";
                if (Input.UserName == "admin")
                {
                    roleName = "Admin";
                }
                bool roleExsist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExsist)
                {
                    IdentityRole role = new IdentityRole(roleName);
                    await _roleManager.CreateAsync(role);
                }
                var result = await _userManager.CreateAsync(identity, Input.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identity, roleName);
                    await _signInManager.SignInAsync(identity, false);
                    return RedirectToAction("~/Index");
                }
            }
            return Page();
        }
        public class InputModel
        {
            [Required(ErrorMessage = "Введите логин!")]
            public string UserName { get; set; }
            [Required(ErrorMessage = "Введите пароль!")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}