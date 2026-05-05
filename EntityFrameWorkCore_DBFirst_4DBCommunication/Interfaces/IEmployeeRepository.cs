using EntityFrameWorkCore_DBFirst_4DBCommunication.HotelManagementModels;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces
{
    public interface IEmployeeRepository
    {

        Task<List<Employee>> GetEmployees();

        Task<Employee> GetEmployeeById(int empId);

        Task<int> AddEmployees(Employee empdetail);

        Task<bool> DeleteEmployeesById(int empid);
        Task<bool> UpdateEmployee(Employee empdetail);

    }
}
