using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_StateOnline.Core.Models;
using S_StateOnline.Core.ViewModels;

namespace S_StateOnline.Core.Contracts
{
    public interface IOrderService
    {
        void CreateOrder(Order baseOrder, List<CartItemVM> cartItems);
        List<Order> GetOrderList();
        Order GetOrder(string Id);
        void UpdateOrder(Order updateOrder);
    }
}
