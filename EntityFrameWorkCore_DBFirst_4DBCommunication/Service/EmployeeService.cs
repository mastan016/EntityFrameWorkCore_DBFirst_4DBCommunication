using EntityFrameWorkCore_DBFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_DBFirst_4DBCommunication.HotelManagementModels;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;   
        
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository= employeeRepository;
        }

        public async Task<int> AddEmployees(EmployeeDto empdetail)
        {
            Employee emp=new Employee();

            emp.Empid=empdetail.Empid;
            emp.Empsalary=empdetail.Empsalary;
            emp.Empname=empdetail.Empname;

            var res = await _employeeRepository.AddEmployees(emp);
            return res;
            
        }

        public async Task<bool> DeleteEmployeesById(int empid)
        {
            await _employeeRepository.DeleteEmployeesById(empid);
            return true;

        }
        public async Task<EmployeeDto> GetEmployeeById(int empid)
        {
            var res = await _employeeRepository.GetEmployeeById(empid);
            EmployeeDto empdto = new EmployeeDto();
            empdto.Empid = res.Empid;
            empdto.Empname = res.Empname;
            empdto.Empsalary = res.Empsalary;
            return empdto;
            
        }

        public async  Task<List<EmployeeDto>> GetEmployees()
        {

            List<EmployeeDto> lstempdto = new List<EmployeeDto>();
            var res = await _employeeRepository.GetEmployees();

            foreach (var emp in res)
            {
                EmployeeDto empdto = new EmployeeDto();

                empdto.Empid=emp.Empid;
                empdto.Empsalary =emp.Empsalary;
                empdto.Empname= emp.Empname;

                lstempdto.Add(empdto);
            }

            return lstempdto;
        }

        public async Task<bool> UpdateEmployee(EmployeeDto empdetail)
        {
            Employee emp = new Employee();

            emp.Empid = empdetail.Empid;
            emp.Empsalary=empdetail.Empsalary;
            emp.Empname = empdetail.Empname;

            await _employeeRepository.UpdateEmployee(emp);
            return true;
                        
        }
    }
}
