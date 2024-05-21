using baitapbuoi16.DataAccess.DBContext;
using baitapbuoi16.DataAccess.DTO;
using baitapbuoi16.Models;
using Microsoft.EntityFrameworkCore;

namespace baitapbuoi16.DataAccess.Services
{
    public class StudentServices : IServices.IStudentServices
    {
        private StudentDbcontext dbcontext = new StudentDbcontext();
        public ReturnData AddStudent(Student student)
        {
            ReturnData result = new ReturnData();
            try
            {
                if (student == null
                    ||student.StudentID<=0
                    ||student.StudentName==null
                    ||student.StudentClass==null
                    ||student.StudentEmail==null
                    ||student.StudentGender==null
                    ||student.StudentAge<=0)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                if(checkInput.CheckIsNullOrWhiteSpace(student.StudentName)==true
                    ||checkInput.ContainsNumber(student.StudentName)==true
                    || checkInput.CheckIsNullOrWhiteSpace(student.StudentEmail) == true
                    || checkInput.ContainsNumber(student.StudentGender)==true
                    || checkInput.CheckIsNullOrWhiteSpace(student.StudentGender) == true
                    || checkInput.CheckIsNullOrWhiteSpace(student.StudentClass) == true)
                    {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                if (dbcontext.students.Find(student.StudentID)!=null)
                {
                    result.ReturnCode=-1;
                    result.ReturnMsg = "học sinh vừa nhập đã có trên hệ thống!";
                    return result;
                }
                dbcontext.Add(student);
                dbcontext.SaveChanges();
                result.ReturnCode=1;
                result.ReturnMsg="Thêm học sinh thành công!";
                return result;
            }
            catch ( Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
        }

        public ReturnData DeleteStudent(int id)
        {
            ReturnData result= new ReturnData();
            try
            {
                if(id<=0)
                {
                    result.ReturnCode=-1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                if(dbcontext.students.Find(id)==null) 
                {
                    result.ReturnCode=-1;
                    result.ReturnMsg = "không có học sinh có ID "+id+" trên hệ thống!";
                    return result;
                }
                var student = dbcontext.students.Find(id);
                dbcontext.students.Remove(student);
                dbcontext.SaveChanges();
                result.ReturnCode=1;
                result.ReturnMsg = "Đã xóa học sinh có ID"+id;
                return result;
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
        }

        public ReturnDataReturnStudent GetStudent(int id)
        {
            ReturnDataReturnStudent result = new ReturnDataReturnStudent();
            try
            {
                if (id <= 0)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                if (dbcontext.students.Find(id) == null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "không có học sinh có ID " + id + " trên hệ thống!";
                    return result;
                }
                result.ReturnCode = 1;
                result.ReturnStudent = dbcontext.students.Find(id);
                result.ReturnMsg = "Đã tìm thấy học sinh có ID" + id;
                return result;
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return dbcontext.students.ToList();
        }

        public ReturnData UpdateStudent(Student student)
        {
            ReturnData result = new ReturnData();
            try
            {
                if (student == null
                    || student.StudentID <= 0
                    || student.StudentName == null
                    || student.StudentClass == null
                    || student.StudentEmail == null
                    || student.StudentGender == null
                    || student.StudentAge <= 0)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                if (checkInput.CheckIsNullOrWhiteSpace(student.StudentName) == true
                   || checkInput.ContainsNumber(student.StudentName) == true
                   || checkInput.CheckIsNullOrWhiteSpace(student.StudentEmail) == true
                   || checkInput.ContainsNumber(student.StudentGender) == true
                   || checkInput.CheckIsNullOrWhiteSpace(student.StudentGender) == true
                   || checkInput.CheckIsNullOrWhiteSpace(student.StudentClass) == true)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                if (dbcontext.students.Find(student.StudentID) == null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "không học sinh cần cập nhập đã có trên hệ thống!";
                    return result;
                }
                dbcontext.Update(student);
                dbcontext.SaveChanges();
                result.ReturnCode = 1;
                result.ReturnMsg = "Cập nhật học sinh thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
        }
    }
}
