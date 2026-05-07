using EntityFrameWorkCore_DBFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_DBFirst_4DBCommunication.MidLandModels;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Service
{
    public class Orderservice : IOrderService
    {
        private readonly IOrdersRepository _orderrepository;
        public Orderservice(IOrdersRepository orderrepository)
        {
            _orderrepository = orderrepository;
        }

        public async Task<int> AddOrder(OrderDto orderdetail)
        {
            Order order = new Order();
            order.Orderid = orderdetail.Orderid;
            order.Ordername = orderdetail.Ordername;
            order.Orderlocation = orderdetail.Orderlocation;
            var res = await _orderrepository.AddOrder(order);
            return res;
        }

        public async Task<bool> DeleteOrdersById(int orderid)
        {
            await _orderrepository.DeleteOrdersById(orderid);
            return true;      
        }

        public async Task<OrderDto> GetOrderById(int orderid)
        {
            var res = await _orderrepository.GetOrderById(orderid);
            OrderDto orderdto = new OrderDto();

            orderdto.Orderid = res.Orderid;
            orderdto.Ordername = res.Ordername;
            orderdto.Orderlocation = res.Orderlocation;

            return orderdto;

        }

        public async Task<List<OrderDto>> GetOrders()
        {
            List<OrderDto> lstorderdto = new List<OrderDto>();
            var res = await _orderrepository.GetOrders();

            foreach(Order order in res)
            {
                OrderDto orderDto=new OrderDto();

                orderDto.Orderid = order.Orderid;
                orderDto.Ordername= order.Ordername;
                orderDto.Orderlocation = order.Orderlocation;
                lstorderdto.Add(orderDto);  //Added the orders to list here

            }

            return lstorderdto;
        }

        public async Task<bool> UpdateOrder(OrderDto orderdetails)
        {
            
            Order obj=new Order();

            obj.Orderid = orderdetails.Orderid;
            obj.Ordername = orderdetails.Ordername;
            obj.Orderlocation = orderdetails.Orderlocation;
           
            await _orderrepository.UpdateOrder(obj);

            return true;            

        }
    }
}
