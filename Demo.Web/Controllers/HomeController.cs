using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Demo.Web.Enums;
using Demo.Web.Models;
using Demo.Web.Repositories;
using Demo.Web.ViewModels;
using DevExpress.Web.Mvc;
using static Demo.Web.Repositories.EmployeeRepository;
using static Demo.Web.Repositories.EmployeeTypeRepository;

namespace Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        //public async Task<ViewResult> Index()
        //{
        //    var viewModel = new HomeViewModel
        //    {
        //        Employees = await GetEmployeesAsync(),
        //        EmployeeTypes = await GetEmployeeTypeAsync()
        //    };
        //    return View(viewModel);
        //}

        //[ValidateInput(false)]
        //public async Task<PartialViewResult> EmployeesGridViewPartial()
        //{
        //    var viewModel = new HomeViewModel
        //    {
        //        Employees = await GetEmployeesAsync(),
        //        EmployeeTypes = await GetEmployeeTypeAsync()
        //    };
        //    return PartialView("_EmployeesGridViewPartial", viewModel);
        //}

        //[HttpPost]
        //public async Task<ActionResult> UpdateEmployeeGridViewPartial(HomeViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var model = new Employee
        //            {
        //                Id = viewModel.Id,
        //                FirstName = viewModel.FirstName,
        //                MiddleName = viewModel.MiddleName,
        //                LastName = viewModel.LastName,
        //                Gender = viewModel.Gender,
        //                DateOfBirth = viewModel.DateOfBirth,
        //                EmployeeTypeId = viewModel.EmployeeTypeId
        //            };
        //            await UpdateEmployeeAsync(model);
        //            TempData["ToastType"] = Toast.Success;
        //            TempData["ToastMessage"] = "Successfully update!";
        //            return RedirectToAction("Index");
        //        }
        //        catch (Exception e)
        //        {
        //            TempData["ToastType"] = Toast.Error;
        //            TempData["ToastMessage"] = e.Message;
        //        }
        //    }
        //    viewModel.Employees = await GetEmployeesAsync();
        //    viewModel.EmployeeTypes = await GetEmployeeTypeAsync();
        //    return PartialView("_EmployeesGridViewPartial", viewModel);
        //}

        //[HttpPost]
        //public async Task<ActionResult> DeleteEmployeeGridViewPartial(string id)
        //{
        //    try
        //    {
        //        await DeleteEmployeeAsync(id);
        //        TempData["ToastType"] = Toast.Success;
        //        TempData["ToastMessage"] = "Successfully delete!";
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception e)
        //    {
        //        TempData["ToastType"] = Toast.Error;
        //        TempData["ToastMessage"] = e.Message;
        //    }
        //    var viewModel = new HomeViewModel
        //    {
        //        Employees = await GetEmployeesAsync(),
        //        EmployeeTypes = await GetEmployeeTypeAsync()
        //    };
        //    return PartialView("_EmployeesGridViewPartial", viewModel);
        //}

        [HttpGet]
        public async Task<ViewResult> CreateEmployee()
        {
            var viewModel = new CreateEmployeeViewModel
            {
                EmployeeTypes = await GetEmployeeTypeAsync()
            };
            return View(viewModel);
        }

        //[HttpPost]
        //public async Task<ActionResult> CreateEmployee(CreateEmployeeViewModel viewModel)
        //{
        //    viewModel.Gender = EditorExtension.GetValue<string>("Gender");
        //    viewModel.EmployeeType = EditorExtension.GetValue<string>("EmployeeType");
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var model = new Employee
        //            {
        //                FirstName = viewModel.FirstName,
        //                MiddleName = viewModel.MiddleName,
        //                LastName = viewModel.LastName,
        //                Gender = viewModel.Gender,
        //                DateOfBirth = viewModel.DateOfBirth,
        //                EmployeeTypeId = viewModel.EmployeeType
        //            };
        //            await InsertEmployeeAsync(model);
        //            TempData["ToastType"] = Toast.Success;
        //            TempData["ToastMessage"] = "Successfully created!";
        //            return RedirectToAction("CreateEmployee");
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        TempData["ToastType"] = Toast.Error;
        //        TempData["ToastMessage"] = $"Error: {exception.Message}";
        //    }

        //    viewModel.EmployeeTypes = await GetEmployeeTypeAsync();
        //    return View(viewModel);
        //}
    }
}