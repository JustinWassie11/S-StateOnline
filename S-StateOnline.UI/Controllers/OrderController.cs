using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S_StateOnline.Core.Contracts;
using S_StateOnline.Core.Models;

namespace S_StateOnline.UI.Controllers
{
    public class OrderController : Controller
    {
        IOrderService orderService;
        public OrderController(IOrderService OrderService)
        {
            this.orderService = OrderService;
        }
        // GET: Order
        public ActionResult Index()
        {
            List<Order> orders = orderService.GetOrderList();
            return View();
        }
        public ActionResult UpdateOrder(string Id)
        {
            Order order = orderService.GetOrder(Id);
            return View(order);
        }
        [HttpPost]
        public ActionResult UpdateOrder(Order updateOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);
            order.OrderStatus = updateOrder.OrderStatus;
            orderService.UpdateOrder(order);
            return RedirectToAction("Index");
        }
    }
}