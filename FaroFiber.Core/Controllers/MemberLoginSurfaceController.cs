using FaroFiber.Core.Models.ViewModels;
using System;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;
using Umbraco.Core.Models;
using System.Linq;
using Umbraco.Web;

namespace FaroFiber.Core.Controllers
{
    public class MemberLoginSurfaceController : SurfaceController
    {
        [HttpGet]
        [ActionName("MemberLogout")]
        public ActionResult MemberLogout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        [HttpPost]
        [ActionName("MemberLogin")]
        public ActionResult MemberLoginPost(MemberLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Username, model.Password))
                {
                        FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);

                    return Redirect("/");
                }
            }

            TempData["Status"] = "Felaktigt användarnamn eller lösenord";
            return RedirectToCurrentUmbracoPage();
        }

        //[HttpPost]
        //[ActionName("ChangePassword")]
        //public ActionResult ChangePassword(ResetPasswordModel model)
        //{
        //    var memberService = ApplicationContext.Services.MemberService;
        //    var member = memberService.GetByEmail(model.ResetEmail);
        //    if (member == null)
        //    {
        //        TempData["ResetStatus"] = "Ingen medlem med den epostadressen hittades";
        //        return RedirectToCurrentUmbracoPage();
        //    }

        //    // set timestamp
        //    member.SetValue("resetPasswordTimestamp", DateTime.Now);
        //    memberService.Save(member);

        //    // send email
        //    var path1 = HostingEnvironment.MapPath("~\\App_Data") + "\\ResetEmailTemplate\\index1.txt";
        //    var content1 = System.IO.File.ReadAllText(path1);
        //    var path2 = HostingEnvironment.MapPath("~\\App_Data") + "\\ResetEmailTemplate\\index2.txt";
        //    var content2 = System.IO.File.ReadAllText(path2);

        //    var url = "https://skrubben.hrak.se/aterstall-losenord?id=" + member.Id;
        //    if (CoreHelpers.IsDeveloperMode())
        //        url = Request.Url.Host + ":" + Request.Url.Port + "/aterstall-losenord?id=" + member.Id;

        //    var content = content1 + url + content2;

        //    var mailHelper = new HrakMailHelper();
        //    mailHelper.SendEmail("Skrubben - Återställ lösenord", content, true, new[] { model.ResetEmail });
        //    TempData["EmailSent"] = true;

        //    return RedirectToCurrentUmbracoPage();
        //}

        //[HttpPost]
        //[ActionName("ResetPassword")]
        //public ActionResult ResetPassword(ResetPasswordModel model)
        //{
        //    // set new password
        //    var memberService = ApplicationContext.Services.MemberService;
        //    var member = memberService.GetById(model.MemberId);
        //    if (member != null)
        //    {
        //        memberService.SavePassword(member, model.Password);
        //        member.SetValue("resetPasswordTimestamp", null);
        //        memberService.Save(member);
        //    }

        //    return Redirect("/");
        //}
    }
}
