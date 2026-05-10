using EntityFrameWorkCore_DBFirst_4DBCommunication.Northwind_DbModels;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartments();        
        Task<Department> GetDepartmentById(int id);
        Task<int> AddDepartments(Department department);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(Department deptdetail);

    }
}
