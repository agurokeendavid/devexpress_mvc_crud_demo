using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Demo.Web.Enums;
using Demo.Web.Models;
using Demo.Web.ViewModels;
using DevExpress.Web.Mvc;
using static Demo.Web.Repositories.EmployeeRepository;
using static Demo.Web.Repositories.EmployeeTypeRepository;

namespace Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ViewResult> CreateEmployee()
        {
            var viewModel = new CreateEmployeeViewModel
            {
                EmployeeTypes = await GetEmployeeTypeAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee(CreateEmployeeViewModel viewModel)
        {
            viewModel.Gender = EditorExtension.GetValue<string>("Gender");
            viewModel.EmployeeType = EditorExtension.GetValue<string>("EmployeeType");
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new Employee
                    {
                        FirstName = viewModel.FirstName,
                        MiddleName = viewModel.MiddleName,
                        LastName = viewModel.LastName,
                        Gender = viewModel.Gender,
                        Dob = viewModel.Dob,
                        EmployeeTypeId = viewModel.EmployeeType
                    };
                    await InsertEmployeeAsync(model);
                    TempData["ToastType"] = Toast.Success;
                    TempData["ToastMessage"] = "Successfully created!";
                    return RedirectToAction("CreateEmployee");
                }
            }
            catch (Exception exception)
            {
                TempData["ToastType"] = Toast.Error;
                TempData["ToastMessage"] = $"Error: {exception.Message}";
            }

            viewModel.EmployeeTypes = await GetEmployeeTypeAsync();
            return View(viewModel);
        }
    }
}