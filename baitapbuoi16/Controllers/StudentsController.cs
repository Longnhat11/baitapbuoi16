using baitapbuoi16.DataAccess.DBContext;
using baitapbuoi16.DataAccess.DTO;
using baitapbuoi16.DataAccess.IServices;
using baitapbuoi16.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace baitapbuoi16.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentServices _studentServices;
        public StudentsController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        // Hiển thị danh sách học sinh
        public IActionResult Index()
        {
            var students = _studentServices.GetAllStudents();
            return View(students);
        }
        // Hiển thị chi tiết một học sinh
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = _studentServices.GetStudent(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        // Hiển thị form để thêm học sinh mới
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý dữ liệu từ form thêm học sinh mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentServices.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // Hiển thị form để chỉnh sửa thông tin học sinh
        public IActionResult Edit(int id)
        {
            var student = _studentServices.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        // Xử lý dữ liệu từ form chỉnh sửa thông tin học sinh
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _studentServices.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // Xóa một học sinh
        public IActionResult Delete(int id)
        {
            _studentServices.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
