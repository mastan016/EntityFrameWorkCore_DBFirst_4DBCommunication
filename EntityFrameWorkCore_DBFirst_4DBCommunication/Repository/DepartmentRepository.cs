using EntityFrameWorkCore_DBFirst_4DBCommunication.HotelManagementModels;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Northwind_DbModels;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly NorthwindDbContext _northwindDbContext;

        public DepartmentRepository(NorthwindDbContext northwindDbContext)
        {
            _northwindDbContext = northwindDbContext;
        }
        public async Task<int> AddDepartments(Department department)
        {
            await _northwindDbContext.Departments.AddAsync(department);
            _northwindDbContext.SaveChanges();
            return 1;

        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            var result = await _northwindDbContext.Departments.Where(a => a.Deptid == deptid).FirstOrDefaultAsync();
            if (result != null)
            {
                _northwindDbContext.Departments.Remove(result);
                _northwindDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var result = await _northwindDbContext.Departments.Where(a => a.Deptid == id).FirstOrDefaultAsync();
            if (result != null){
                
                return result;
            }
            else
            {
                return null;
            }

        }

        public async Task<List<Department>> GetDepartments()
        {

            var result = await _northwindDbContext.Departments.ToListAsync();
            if (result.Count == 0)
            {               
                return null;
            }
            else
            {
                return result;
            }

        }
        public async Task<bool> UpdateDepartment(Department deptdetail)
        {
            //this is one way of update the data
           // _northwindDbContext.Departments.Update(deptdetail); // if we go for this approach data we need to insert while we sent dept id =0 in UI

           //so we go for second approach
            var departmentResult= await _northwindDbContext.Departments.Where(b=>b.Deptid==deptdetail.Deptid).FirstOrDefaultAsync();
            departmentResult.Deptid=deptdetail.Deptid;
            departmentResult.Deptname=deptdetail.Deptname;
            departmentResult.Deptlocation=deptdetail.Deptlocation;
            _northwindDbContext.Departments.Update(departmentResult);
            await _northwindDbContext.SaveChangesAsync();
            return true;
           
        }
    }
}
