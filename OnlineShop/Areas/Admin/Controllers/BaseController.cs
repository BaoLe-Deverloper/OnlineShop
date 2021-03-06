﻿using OnlineShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
      
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            
            if (Session["Admin"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Login", Action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
        public ActionResult _Header()
        {
            var Account = new UserAdminDAO().GetAccountByName((string)Session["Admin"]);
            ViewBag.Avata = Account.UserImage;
            return PartialView();
        }
    }
}