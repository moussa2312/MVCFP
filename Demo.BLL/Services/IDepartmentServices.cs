using Demo.BLL.DTO;

namespace Demo.BLL.Services
{
    public interface IDepartmentServices
    {
        int AddDepartment(CreatedDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDTO> GetAllDepartment();
        DepartmentsDetailsDTO GetDepartmentById(int id);
        int UpdateDepartment(UpdateDeptDto departmentDto);
    }
}