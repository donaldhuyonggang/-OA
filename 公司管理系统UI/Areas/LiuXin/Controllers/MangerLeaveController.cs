﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;

namespace 公司管理系统UI.Areas.LiuXin.Controllers
{
    public class MangerLeaveController : Controller
    {
        // GET: LiuXin/MangerLeave
        public ActionResult Index()
        {
            LeaveManager lm = new LeaveManager();
            List<Leave> listleave= lm.GetBySome("未批准");
            return View(listleave);
        }
        public ActionResult JLagree(int id) {
            LeaveManager lm = new LeaveManager();
            string leaveover = "批准";
            //int id = Convert.ToInt32(Request.QueryString["id"]);
            bool pd=lm.UpdateL(id,leaveover);
            if (pd)
            {
                return Redirect("~/LiuXin/MangerLeave/Index");
            }
            else
            {
                return Content("不允许批准");
            }
        }
        public ActionResult JLdisagree(int id) {
            LeaveManager lm = new LeaveManager();
            string leaveover = "不批准";
            bool pdd = lm.UpdateL(id, leaveover);
            if (pdd)
            {
                return Redirect("~/LiuXin/MangerLeave/Index");
            }
            else
            {
                return Content("否定不批准失败");
            }
        }
        public ActionResult History() {
            LeaveManager lm = new LeaveManager();
            List<Leave> listhistory = lm.GetByother("未批准");
            return View(listhistory);
        }
    }
}