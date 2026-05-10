using EntityFrameWorkCore_DBFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_DBFirst_4DBCommunication.HotelManagementModels;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetEmployees();

        Task<EmployeeDto> GetEmployeeById(int empId);

        Task<int> AddEmployees(EmployeeDto empdetail);

        Task<bool> DeleteEmployeesById(int empid);
        Task<bool> UpdateEmployee(EmployeeDto empdetail);

    }
}
