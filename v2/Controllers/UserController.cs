using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using v2.Models;

namespace v2.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Connexion()
        { return View(); }
        public ActionResult CreateAccount()
        { return View(); }


        public ActionResult Autherize(T_User model)
        {
            using(DB_YnovEntities db = new DB_YnovEntities())
            {
                var userInfos = db.T_User.Where(x => x.mail_user == model.mail_user && x.pword_user == model.pword_user).FirstOrDefault();
                if (userInfos == null)
                {
                    model.loginErrorMessage = "Mail ou mot de passe incorrect.";
                    return View("Connexion", model);
                }
                else
                {
                    Session["CurrentUser"] = userInfos.id_user;
                    Session["CurrentNameUser"] = userInfos.name_user;
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
    }
}