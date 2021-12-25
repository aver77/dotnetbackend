using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3labBackEnd.Models;
using _3labBackEnd.Models.ViewModels;
using _3labBackEnd.Models.ViewModels.OrderViewModel;

namespace _3labBackEnd.Services
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(GetOrderByIdVM orderModel);
        bool SaveCreationOrder(CreateOrderVM orderModel);
        bool EditOrder(EditOrderVM orderModel);
        bool DeleteOrder(DeleteOrderVM orderModel);
        List<Order> GetOrdersByUser(GetOrdersByUserVM orderModel);
    }

    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _context;
        public OrderService(OrderDbContext context) 
        {
            _context = context;
        }
        public List<Order> GetAllOrders()
        {
            return _context.CurrentOrders.ToList();
        }
        public Order GetOrderById(GetOrderByIdVM orderModel)
        {
            return _context.CurrentOrders.First(id => id.Id == orderModel.Id);
        }
        public bool EditOrder(EditOrderVM orderModel)
        {
            try
            {
                var order = new Order() { Id = orderModel.Id, OrderName = orderModel.OrderName, OrderDescription = orderModel.OrderDescription};
                var entity = _context.CurrentOrders.First(l => l.Id == order.Id);
                _context.CurrentOrders.Remove(entity);
                _context.CurrentOrders.Add(order);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SaveCreationOrder(CreateOrderVM orderModel)
        {
            try
            {
                var order = new Order() { OrderName = orderModel.OrderName, OrderDescription = orderModel.OrderDescription, CreatedBy = orderModel.CreatedBy };
                _context.CurrentOrders.Add(order);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteOrder(DeleteOrderVM orderModel)
        {
            try
            {
                var entity = _context.CurrentOrders.First(id => id.Id == orderModel.Id);
                _context.CurrentOrders.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Order> GetOrdersByUser(GetOrdersByUserVM orderModel)
        {
            return _context.CurrentOrders.Where(order => order.CreatedBy == orderModel.UserId).ToList();
        }
    }
}
