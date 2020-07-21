using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using leave_management.Contracts;
using leave_management.Data;
using leave_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace leave_management.Controllers
{
    [Authorize]
    public class LeaveRequestController : Controller
    {
        private readonly ILeaveRequestRepository _leaveRequestRepo;
        private readonly ILeaveTypeRepository _leaveTypeRepo;
        private readonly ILeaveAllocationRepository _leaveAllocationRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;

        public LeaveRequestController(
            ILeaveRequestRepository leaveRequestRepo,
            ILeaveTypeRepository leaveTypeRepo,
            ILeaveAllocationRepository leaveAllocationRepo,
            IMapper mapper,
            UserManager<Employee> userManager
        )
        {
            _leaveRequestRepo = leaveRequestRepo;
            _leaveTypeRepo = leaveTypeRepo;
            _leaveAllocationRepo = leaveAllocationRepo;
            _mapper = mapper;
            _userManager = userManager;
        }

        [Authorize(Roles = "Administrator")]
        // GET: LeaveRequestController
        public ActionResult Index()
        {
            ICollection<LeaveRequest> leaveRequests = _leaveRequestRepo.FindAll();

            List<LeaveRequestViewModel> leaveRequestModel = _mapper
                .Map<List<LeaveRequestViewModel>>(leaveRequests);

            AdminLeaveRequestViewViewModel model =
            new AdminLeaveRequestViewViewModel
            {
                ApprovedRequests = leaveRequestModel
                    .Count(q => q.Approved == true),

                PendingRequests = leaveRequestModel
                    .Count(q => q.Approved == null),

                RejectedRequests = leaveRequestModel
                    .Count(q => q.Approved == false),

                TotalRequests = leaveRequestModel.Count,
                LeaveRequests = leaveRequestModel
            };

            return View(model);
        }

        // GET: LeaveRequestController/Details/5
        public ActionResult Details(int id)
        {
            LeaveRequest leaveRequest = _leaveRequestRepo.FindById(id);
            LeaveRequestViewModel model = _mapper.Map<LeaveRequestViewModel>(leaveRequest);

            return View(model);
        }

        // GET: LeaveRequestController/Create
        public ActionResult Create()
        {
            ICollection<LeaveType> leaveTypes = _leaveTypeRepo.FindAll();

            IEnumerable<SelectListItem> leaveTypeItems = leaveTypes
                .Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                });

            CreateLeaveRequestViewModel model = new CreateLeaveRequestViewModel
            {
                LeaveTypes = leaveTypeItems
            };

            return View(model);
        }

        // POST: LeaveRequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLeaveRequestViewModel model)
        {
            try
            {
                DateTime startDate = Convert.ToDateTime(model.StartDate);
                DateTime endDate = Convert.ToDateTime(model.StartDate);

                ICollection<LeaveType> leaveTypes = _leaveTypeRepo.FindAll();

                IEnumerable<SelectListItem> leaveTypeItems = leaveTypes
                    .Select(q => new SelectListItem
                    {
                        Text = q.Name,
                        Value = q.Id.ToString()
                    });

                model.LeaveTypes = leaveTypeItems;

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (DateTime.Compare(startDate, endDate) > 1)
                {
                    ModelState.AddModelError("", "The start date may not be futher"
                    + " in the future than the end date.");

                    return View(model);
                }

                Employee employee = _userManager.GetUserAsync(User).Result;

                LeaveAllocation allocation = _leaveAllocationRepo
                    .GetLeaveAllocationsByEmployeeAndType(employee.Id, model.LeaveTypeId);

                int daysRequested = (int)(endDate.Date - startDate).TotalDays;

                if (daysRequested > allocation.NumberOfDays)
                {
                    ModelState.AddModelError("", "You do not have sufficient days for this request.");

                    return View(model);
                }

                LeaveRequestViewModel leaveRequestModel = new LeaveRequestViewModel
                {
                    RequestingEmployeeId = employee.Id,
                    StartDate = startDate,
                    EndDate = endDate,
                    Approved = null,
                    DateRequested = DateTime.Now,
                    DateActioned = DateTime.Now,
                    LeaveTypeId = model.LeaveTypeId
                };

                LeaveRequest leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestModel);
                bool isSuccess = _leaveRequestRepo.Create(leaveRequest);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong with submitting your record.");

                    return View(model);
                }

                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        // GET: LeaveRequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveRequestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveRequestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveRequestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
