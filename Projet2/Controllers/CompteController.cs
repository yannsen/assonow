using Projet2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Projet2.ViewModels;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using System;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;

namespace Projet2.Controllers
{
    public class CompteController : Controller
    {
        private IMemberService memberService;
        private IAuthentificationService authentificationService;
        private IAssociationService associationService;
        private IAssociationMemberService associationMemberService;
        private IContributionService contributionService;

        BddContext _bddContext;
        public CompteController()
        {
            this.memberService = new MemberService();
            this.contributionService = new ContributionService();
            this.authentificationService = new AuthentificationService();
            this.associationService = new AssociationService();
            this.associationMemberService = new AssociationMemberService();
            this._bddContext = new BddContext();
        }

        public IActionResult Creer()
        {
            MemberInfoViewModel viewModel = new MemberInfoViewModel();
            ViewBag.Legend = "Création de compte";
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Creer(MemberInfoViewModel viewModel)
        {
            ModelState.Remove("Member.Id");
            ModelState.Remove("Member.AddressId");
            ModelState.Remove("Address.Id");
            if (ModelState.IsValid)
            {
                memberService.CreateMember(viewModel);
                return RedirectToAction("CompteCree");
            }
            ViewBag.Legend = "Création de compte";
            return View(viewModel);
        }

        [Authorize]
        public IActionResult Modifier()
        {
            MemberInfoViewModel viewModel = new MemberInfoViewModel();
            viewModel.Member = memberService.GetMember(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            viewModel.Address = _bddContext.Address.Find(viewModel.Member.AddressId);
            ViewBag.Legend = "Modification du compte";
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Modifier(MemberInfoViewModel viewModel)
        {
            ViewBag.Legend = "Modification du compte";
            if (ModelState.IsValid)
            {
                viewModel.Member.Id = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                memberService.ModifyMember(viewModel);
                ViewBag.Modified = true;
                return View(viewModel);
            }
            return View(viewModel);
        }

        public IActionResult CompteCree()
        {
            return View();
        }

        public IActionResult Connexion()
        {
            MemberViewModel memberViewModel = new MemberViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                memberViewModel.Pseudonym = authentificationService.GetMember(userId).Pseudonym;
                memberViewModel.Password = authentificationService.GetMember(userId).Password;
                return Redirect("/home/index");
            }
            return View(memberViewModel);
        }

        [HttpPost]
        public IActionResult Connexion(MemberViewModel memberViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Member member = authentificationService.Authenticate(memberViewModel.Pseudonym, memberViewModel.Password);
                if (member != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, member.Pseudonym),
                        new Claim(ClaimTypes.NameIdentifier, member.Id.ToString()),
                        new Claim(ClaimTypes.Role, member.Role),
                    };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var memberPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                    HttpContext.SignInAsync(memberPrincipal);

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return Redirect("/");
                }
                ModelState.AddModelError("Pseudonym.Password", "Pseudo et/ou mot de passe incorrect(s)");
            }
            return View(memberViewModel);
        }

        public IActionResult Deconnexion()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Member,Representative")]
        public IActionResult Adhesions()
        {
            List<Association> associations = associationMemberService.GetAssociationsForMember(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            return View(associations);
        }

        [Authorize(Roles = "Member,Representative")]
        public IActionResult QuitAssociation(int id)
        {
            if (associationService.GetAssociation(id).Contribution > 0)
                contributionService.DeleteContribution(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)), id);
            associationMemberService.DeleteAssociationMember(associationMemberService.GetAssociationMember(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)), id).Id);
            return RedirectToAction("Adhesions");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
