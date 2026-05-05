using EntityFrameWorkCore_DBFirst_4DBCommunication.HotelManagementModels;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HotelmanagementContext _hotelManagementContext;
        
         public EmployeeRepository(HotelmanagementContext hotelManagementcontext)
        {
            _hotelManagementContext = hotelManagementcontext;
        }

        public async Task<int> AddEmployees(Employee empdetail)
        {
            await _hotelManagementContext.Employees.AddAsync(empdetail);
            _hotelManagementContext.SaveChanges();
            return 1;
        }

        public async Task<bool> DeleteEmployeesById(int empid)
        {
            var result = await _hotelManagementContext.Employees.Where(a => a.Empid == empid).FirstOrDefaultAsync();
            
            if(result != null)
            {
                _hotelManagementContext.Employees.Remove(result);
                _hotelManagementContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

           
        }

        public async Task<Employee> GetEmployeeById(int empId)
        {
           var result=await _hotelManagementContext.Employees.Where(b=>b.Empid == empId).FirstOrDefaultAsync();

            if(result!=null)
            {
                return result;
            }
            else
            {
                return null;
            }

        }

        public async Task<List<Employee>> GetEmployees()
        {

            var result = await _hotelManagementContext.Employees.ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }

        }

        public async Task<bool> UpdateEmployee(Employee empdetail)
        {
         //  this is one way of update the data.
            // _hotelManagementContext.Employees.Update(empdetail);


           //second way of update the data
           var employeeResult=await _hotelManagementContext.Employees.Where(b=>b.Empid==empdetail.Empid).FirstOrDefaultAsync();
            employeeResult.Empid=empdetail.Empid;
            employeeResult.Empname=empdetail.Empname;
            employeeResult.Empsalary=empdetail.Empsalary;
            _hotelManagementContext.Employees.Update(employeeResult);
            await _hotelManagementContext.SaveChangesAsync();
            return true;          

        }
    }
}
