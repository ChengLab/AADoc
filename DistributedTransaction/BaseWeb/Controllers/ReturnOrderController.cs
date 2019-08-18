using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AA.AspNetCore.Results;
using AABase.ApplicationService;
using AABase.Common.Util;
using AABase.Dto;
using AABase.EntityEnum;
using AABase.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Base.Web.Controllers
{
    public class ReturnOrderController : Controller
    {

        #region Fields
        private readonly IReturnOrderService _returnOrderService;
        #endregion
        public ReturnOrderController()
        {
            _returnOrderService = new ReturnOrderService();
        }
        /// <summary>
        /// 退货单视图
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 审核退货单
        /// </summary>
        /// <param name = "input" ></ param >
        /// < returns ></ returns >
        [HttpPost]
        public ActionResult AuditReturnOrder(string id)
        {
            _returnOrderService.Update(new UpdateReturnOrderInput() {
                Id=new Guid(id),
                GmtModified=DateTime.Now,
            });
            return Json(Result.Success("审核成功"));
            
        }
        /// <summary>
        /// 获取退货单列表
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="start"></param>
        /// <param name="page"></param>
        /// <param name="draw"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetListReturnOrder(int limit, int start, int page, int draw)
        {
            var result = _returnOrderService.GetList(new GetListReturnOrderInput
            {
                PageIndex = page,
                PageSize = limit
            });

            object objResult = new
            {
                draw = draw,
                recordsTotal = result.TotalCount,
                recordsFiltered = result.TotalCount,
                data = result.Items
            };

            return Json(objResult);
        }
        /// <summary>
        /// 模拟创建退货单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MockAddReturnOrder()
        {
            _returnOrderService.Save(new SaveReturnOrderInput()
            {
                BillNum = CodeGeneratorUtil.GetInt32UniqueCode().ToString(),
                GmtCreate = DateTime.Now,
                Status = (int)ReturnOrderStatus.待审核,
                GmtModified = DateTime.Now,
            });
            return Json(Result.Success("创建成功"));
        }
    }

}