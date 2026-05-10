using EntityFrameWorkCore_DBFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Northwind_DbModels;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _DepartmentRepository;
        
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _DepartmentRepository= departmentRepository;
        }

        public async Task<int> AddDepartments(DepartmentDto department)
        {
            Department dept=new Department();
            dept.Deptid=department.Deptid;
            dept.Deptname=department.Deptname;
            dept.Deptlocation=department.Deptlocation;

            var res=await _DepartmentRepository.AddDepartments(dept);
            return res;            
        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
           await _DepartmentRepository.DeleteDepartmentById(deptid);
            return true;
        }

        public async Task<DepartmentDto> GetDepartmentById(int deptid)
        {
            var res = await _DepartmentRepository.GetDepartmentById(deptid);
            DepartmentDto deptdto = new DepartmentDto();
            deptdto.Deptid= res.Deptid;
            deptdto.Deptname = res.Deptname;
            deptdto.Deptlocation = res.Deptlocation;
            return deptdto;
        }

        public async Task<List<DepartmentDto>> GetDepartments()
        {
            List<DepartmentDto> lstdeptdto = new List<DepartmentDto>();
            var res=await _DepartmentRepository.GetDepartments();

            foreach (Department dept in res)
            {
                DepartmentDto deptdto = new DepartmentDto();
                deptdto.Deptid = dept.Deptid;
                deptdto.Deptname = dept.Deptname;
                deptdto.Deptlocation = dept.Deptlocation;
                lstdeptdto.Add(deptdto);
            }
            return lstdeptdto;            
        }

        public async Task<bool> UpdateDepartment(DepartmentDto deptdetail)
        {
            Department dept = new Department();

            dept.Deptid = deptdetail.Deptid;
            dept.Deptname= deptdetail.Deptname;
            dept.Deptlocation= deptdetail.Deptlocation;

            await _DepartmentRepository.UpdateDepartment(dept);
            return true;            
        }
    }
}
