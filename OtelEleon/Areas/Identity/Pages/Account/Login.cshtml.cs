// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OtelEleon.Models;
using System.Security.Principal;

namespace OtelEleon.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;

        public LoginModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
			_userManager = userManager;
			_signInManager = signInManager;
		}

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModelLogin Input { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    Input.Login,
                    Input.Password,
                    isPersistent: false, lockoutOnFailure: false
                    );
                if (result.Succeeded)
                {
					return RedirectToAction("~/Index");
				}
            }
            return Page();
        }
        public class InputModelLogin
		{
			[Required]
			public string Login { get; set; }
			[Required]
			[DataType(DataType.Password)]
			public string Password { get; set; }
		}
	}
}
