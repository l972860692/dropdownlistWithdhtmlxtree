using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakeDropdownlist.model;
using MakeDropdownlist.Models;

namespace MakeDropdownlist.Controllers
{
    public class CorpsController : Controller
    {
        // GET: Corps
        DropdownlistDBEntities db = new DropdownlistDBEntities();
        public ActionResult Index()
        {
            return View();
        }
            public JsonResult GetCorpsAll(int id)
        {
            List<TreeViewModel> corpsData;
            TreeViewModel topNode = new TreeViewModel();
            topNode.id = 0;
            topNode.text = "全部";

            corpsData = new List<TreeViewModel>();
            topNode.item = corpsData;

           
            var nowNode = db.Corps.Where(n => n.ID == id).OrderBy(n => n.Sort);
            foreach (var n in nowNode)
            {
                TreeViewModel s = new TreeViewModel { id = n.ID, text = n.Name };
                corpsData.Add(s);
                NeedAll(n, s);
            }
            ////把全部加在前面
            //if (id == 1)
            //{
            //    TreeViewModel all = new TreeViewModel { id = 0, text = "全部" };
            //    topNode.id = -1;
            //    var allCorpsData = new List<TreeViewModel>();
            //    all.item = allCorpsData;
            //    all.item.Add(topNode);
            //    return Json(all, JsonRequestBehavior.AllowGet);
            //}
            return Json(topNode, JsonRequestBehavior.AllowGet);
        }
   

        #region 读出部门

        //递归读出部门
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nowCorp">当前部门实例</param>
        /// <param name="PrTVModel">当前部门的上一个节点模型对象<TreeViewModel></param>
        void NeedAll(Corps nowCorp, TreeViewModel PrTVModel)
        {

            var cc = db.Corps.Where(n => n.ParentID == nowCorp.ID).OrderBy(n => n.Sort);

            //结束条件当前部门无子部门
            if (cc.Count() != 0)
            {
                //构造当前节点的子节点模型
                List<TreeViewModel> sOfChildren = new List<TreeViewModel>();
                PrTVModel.item = sOfChildren;
                //读取当前部门的子部门实例来填充当前节点的子节点模型
                foreach (var n in cc)
                {
                    TreeViewModel sOfChild = new TreeViewModel { id = n.ID, text = n.Name };
                    sOfChildren.Add(sOfChild);
                    //如果此部门还有子部门那么继续读取
                    NeedAll(n, sOfChild);
                }
            }
        }
        #endregion
    }
}