using baitapbuoi16.DataAccess.DTO;
using baitapbuoi16.Models;

namespace baitapbuoi16.DataAccess.IServices
{
    public interface IStudentServices
    {
        IEnumerable<Student> GetAllStudents();
        ReturnDataReturnStudent GetStudent(int id);
        ReturnData AddStudent(Student student);
        ReturnData UpdateStudent(Student student);
        ReturnData DeleteStudent(int id);
    }
}
