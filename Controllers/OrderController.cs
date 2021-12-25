// методы из сервисов!
using _3labBackEnd.Models.ViewModels.OrderViewModel;
using _3labBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3labBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //used
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var listOrder = _orderService.GetAllOrders();
            return Ok(listOrder);
        }

        //used maybe
        [HttpGet]
        //экземпляр класса VM
        public IActionResult GetOrderById(GetOrderByIdVM orderModel)
        {
            if (orderModel.Id == Guid.Empty) return BadRequest();
            // методы из сервисов!
            var order = _orderService.GetOrderById(orderModel);
            return Ok(order);
        }

        //useless
        [HttpPut]
        //экземпляр класса VM
        public IActionResult EditOrder(EditOrderVM orderModel)
        {
            // методы из сервисов!
            var isSuccess = _orderService.EditOrder(orderModel);
            return Ok(isSuccess);
        }

        //used
        [HttpPost]
        public IActionResult SaveCreationOrder(CreateOrderVM orderModel)
        {
            var isSuccess = _orderService.SaveCreationOrder(orderModel);
            return Ok(isSuccess);
        }

        //used maybe
        public IActionResult Delete(DeleteOrderVM orderModel)
        {
            var isSuccess = _orderService.DeleteOrder(orderModel);
            return Ok(isSuccess);
        }

        //used maybe
        [HttpGet]
        public IActionResult GetOrdersByCreator(GetOrdersByUserVM orderModel)
        {
            var isSuccess = _orderService.GetOrdersByUser(orderModel);
            return Ok(isSuccess);
        }
    }
}
