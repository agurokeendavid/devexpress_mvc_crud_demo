using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Demo.Web.Enums;
using Demo.Web.Models;
using Demo.Web.ViewModels;
using DevExpress.Web.Mvc;
using static Demo.Web.Repositories.EmployeeTypeRepository;
using static Demo.Web.Repositories.EmployeeRepository;
using static Demo.Web.Repositories.ReferenceRepository;
using static Demo.Web.Helpers.EncryptionHelper;

namespace Demo.Web.Controllers
{
    public class BatchCreateController : Controller
    {
        [HttpGet]
        public async Task<ViewResult> BatchList()
        {
            var viewModel = new BatchListViewModel
            {
                References = await GetAllReferenceAsync(IsDeleted.No)
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> BatchCreate(string referenceId, string referenceNo)
        {
            var employees = await GetEmployeesByReferenceIdAsync(referenceId, IsDeleted.No);
            if (referenceId == null && referenceNo == null)
            {
                string generatedCurrentYear = $"{DateTime.Now:yy}";
                string generatedGuid = Guid.NewGuid().ToString("N").Substring(0, 4).ToUpper();
                string generatedReferenceNoSequence = await GetReferenceNoSequenceAsync();
                int encryptedReferenceNo = EncryptReferenceNo($"BI{generatedCurrentYear}{generatedGuid}{generatedReferenceNoSequence}");
                referenceId = Guid.NewGuid().ToString("N");
                referenceNo = $"BI{generatedCurrentYear}{generatedGuid}{generatedReferenceNoSequence}{encryptedReferenceNo}";
            }
            else
            {
                if (!employees.Any())
                    return RedirectToAction("BatchCreate");
            }

            var viewModel = new BatchCreateViewModel()
            {
                ReferenceId = referenceId,
                ReferenceNo = referenceNo,
                EmployeeTypes = await GetEmployeeTypeAsync(),
                Employees = employees
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> BatchCreate(BatchCreateViewModel viewModel)
        {
            viewModel.Gender = EditorExtension.GetValue<string>("Gender");
            viewModel.EmployeeTypeId = EditorExtension.GetValue<string>("EmployeeTypeId");

            if (ModelState.IsValid)
            {
                try
                {
                    var employee = new Employee
                    {
                        ReferenceId = viewModel.ReferenceId,
                        FirstName = viewModel.FirstName,
                        MiddleName = viewModel.MiddleName,
                        LastName = viewModel.LastName,
                        Gender = viewModel.Gender,
                        DateOfBirth = viewModel.DateOfBirth,
                        EmployeeTypeId = viewModel.EmployeeTypeId
                    };

                    var reference = new Reference
                    {
                        ReferenceId = viewModel.ReferenceId,
                        ReferenceNo = viewModel.ReferenceNo
                    };
                    await InsertEmployeeAsync(employee);

                    if (!await HasExistingReferenceIdAsync(reference.ReferenceId)) 
                        await InsertReferenceAsync(reference);

                    TempData["ToastType"] = Toast.Success;
                    TempData["ToastMessage"] = "Successfully created!";
                    return RedirectToAction("BatchCreate", new { referenceId = viewModel.ReferenceId, referenceNo = viewModel.ReferenceNo});
                }
                catch (Exception exception)
                {
                    TempData["ToastType"] = Toast.Error;
                    TempData["ToastMessage"] = $"Error: {exception.Message}";
                }
            }
            viewModel.EmployeeTypes = await GetEmployeeTypeAsync();
            viewModel.Employees = await GetEmployeesByReferenceIdAsync(viewModel.ReferenceId, IsDeleted.No);
            return View(viewModel);
        }

        [ValidateInput(false)]
        public async Task<PartialViewResult> BatchListGridViewPartial()
        {
            var viewModel = new BatchListViewModel()
            {
                References = await GetAllReferenceAsync(IsDeleted.No)
            };
            return PartialView("_BatchListGridViewPartial", viewModel);
        }

        public async Task<PartialViewResult> BatchListMasterDetailGridViewPartial(string referenceId)
        {
            ViewData["ReferenceId"] = referenceId;
            var viewModel = new BatchListViewModel()
            {
                Employees = await GetEmployeesByReferenceIdAsync(referenceId, IsDeleted.No),
                EmployeeTypes = await GetEmployeeTypeAsync()
            };
            return PartialView("_BatchListMasterDetailGridViewPartial", viewModel);
        }

        [ValidateInput(false)]
        public async Task<PartialViewResult> BatchCreateGridViewPartial(string referenceId)
        {
            var viewModel = new BatchCreateViewModel()
            {
                Employees = await GetEmployeesByReferenceIdAsync(referenceId, IsDeleted.No),
                EmployeeTypes = await GetEmployeeTypeAsync()
            };
            return PartialView("_BatchCreateGridViewPartial", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteEmployeeGridViewPartial(string id, string referenceId)
        {
            try
            {
                await DeleteEmployeeAsync(id);
                TempData["ToastType"] = Toast.Success;
                TempData["ToastMessage"] = "Successfully delete!";
            }
            catch (Exception e)
            {
                TempData["ToastType"] = Toast.Error;
                TempData["ToastMessage"] = e.Message;
            }
            var viewModel = new BatchCreateViewModel()
            {
                Employees = await GetEmployeesByReferenceIdAsync(referenceId, IsDeleted.No),
                EmployeeTypes = await GetEmployeeTypeAsync()
            };
            return PartialView("_BatchCreateGridViewPartial", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateEmployeeGridViewPartial(BatchCreateViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee
                    {
                        Id = viewModel.Id,
                        FirstName = viewModel.FirstName,
                        MiddleName = viewModel.MiddleName,
                        LastName = viewModel.LastName,
                        Gender = viewModel.Gender,
                        DateOfBirth = viewModel.DateOfBirth,
                        EmployeeTypeId = viewModel.EmployeeTypeId
                    };
                    await UpdateEmployeeAsync(employee);
                    TempData["ToastType"] = Toast.Success;
                    TempData["ToastMessage"] = "Successfully update!";
                }
            }
            catch (Exception exception)
            {
                TempData["ToastType"] = Toast.Error;
                TempData["ToastMessage"] = exception.Message;
            }
            viewModel.Employees = await GetEmployeesByReferenceIdAsync(viewModel.ReferenceId, IsDeleted.No);
            viewModel.EmployeeTypes = await GetEmployeeTypeAsync();
            return PartialView("_BatchCreateGridViewPartial", viewModel);
        }
    }
}