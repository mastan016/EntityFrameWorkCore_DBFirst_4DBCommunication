using EntityFrameWorkCore_DBFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_DBFirst_4DBCommunication.MidLandModels;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces
{
    public interface IOrderService
    {

        Task<List<OrderDto>> GetOrders();
        Task<OrderDto> GetOrderById(int orderid);
        Task<int> AddOrder(OrderDto orderdetail);
        Task<bool> DeleteOrdersById(int orderid);
        Task<bool> UpdateOrder(OrderDto orderdetails);

    }
}
