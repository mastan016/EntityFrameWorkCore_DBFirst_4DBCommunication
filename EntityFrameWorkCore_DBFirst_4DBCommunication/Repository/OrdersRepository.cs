using Azure.Core;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_DBFirst_4DBCommunication.MidLandModels;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly MidlandContext _context;
        public OrdersRepository(MidlandContext context)
        {
            _context = context;

        }

        public async Task<int> AddOrder(Order orderdetail)
        {
            await _context.Orders.AddAsync(orderdetail);
            _context.SaveChanges();
            return 1;

        }

        public async Task<bool> DeleteOrdersById(int orderid)
        {
            var rm = await _context.Orders.Where(e => e.Orderid==orderid).FirstOrDefaultAsync();

            if (rm != null)
            {
                //Here Remove() method is used for removing the data from database.

                _context.Orders.Remove(rm);
                _context.SaveChanges() ;
                return true;
            }
            else
                return false;

        }

        public async Task<Order> GetOrderById(int orderid)
        {
            var rm = await _context.Orders.Where(e => e.Orderid == orderid).FirstOrDefaultAsync();

            if(rm==null)
            {
                return null;
            }
            else
            {
                return rm;
            }

        }

        public async Task<List<Order>> GetOrders()
        {
            var result = _context.Orders.ToList();

            if(result.Count==0)
            {
                return null;
            }
            else
            {
                return result;
            }

        }

        public async Task<bool> UpdateOrder(Order orderdetails)
        {
            _context.Update(orderdetails);
            await _context.SaveChangesAsync();
            return true;                

        }
    }
}
