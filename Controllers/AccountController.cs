using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Doska.Models;
using Doska.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Doska.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private readonly ILogger logger;
        private IMapper mapper;

        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr, IMapper _mapper, ILogger<AccountController> _logger)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            logger = _logger;
            mapper = _mapper;

        }
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        logger.LogInformation($"Login succeeded {user.Id}");
                        //TempData["UserId"] = user.Id;
                        string strUrl = loginModel?.ReturnUrl ?? "/";
                        return Redirect(strUrl);

                    }
                }
            }
            ModelState.AddModelError("", "Неверное имя пользователя или пароль");
            logger.LogInformation($"Неверное имя пользователя или пароль: {loginModel.Name}:{loginModel.Password}");

            return View(loginModel);
        }
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
        [AllowAnonymous]
        public ViewResult Index() => View(userManager.Users);

        [AllowAnonymous]
        public IActionResult Create() => View();

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { UserName = model.Name, Email = model.Email, PhoneNumber = model.PhoneNumber };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    TempData["message"] = $"Пользователь: {user.UserName} успешно создан.";
                    logger.LogInformation($"Create Login succeeded {user.Id}");

                    return Redirect("/Home/Index/");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(model);
        }

        public async Task<IActionResult> Details()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(id);
            ViewModel userview = mapper.Map<ViewModel>(user);
            logger.LogInformation($"View detailes profile user: {user.Id}");

            return View(userview);
        }
        public async Task<IActionResult> Edit()
        {

            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(id);
            EditModel userview = mapper.Map<EditModel>(user);
            logger.LogInformation($"Edit profile user: {user.Id}");

            return View(userview);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditModel useredit)
        {

            if (ModelState.IsValid)
            {
                string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await userManager.FindByIdAsync(id);
                user.PhoneNumber = useredit.PhoneNumber;
                user.Email = useredit.Email;

                IdentityResult result = await userManager.UpdateAsync(user);
                TempData["message"] = $"Данные пользователя обновлены";
                logger.LogInformation($"User id:{useredit.Id} update profile");
                return RedirectToAction("Details", "Account");

            }
            else
            {
                return View();
            }
        }
    }
}
