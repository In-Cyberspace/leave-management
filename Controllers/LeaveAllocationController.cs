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

namespace leave_management.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveTypeRepository _leavetyperepo;
        private readonly ILeaveAllocationRepository _leaveallocationrepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;

        public LeaveAllocationController(ILeaveTypeRepository leavetyperepo,
            ILeaveAllocationRepository leaveallocationrepo,
            IMapper mapper,
            UserManager<Employee> userManager)
        {
            _leavetyperepo = leavetyperepo;
            _leaveallocationrepo = leaveallocationrepo;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: LeaveAllocationController
        public async Task<ActionResult> Index()
        {
            ICollection<LeaveType> leavetypes = await _leavetyperepo.FindAll();

            List<LeaveTypeViewModel> mappedLeaveTypes = _mapper
                .Map<List<LeaveType>, List<LeaveTypeViewModel>>(
                    leavetypes.ToList()
                );

            CreateLeaveAllocationViewModel model =
            new CreateLeaveAllocationViewModel
            {
                LeaveTypes = mappedLeaveTypes,
                NumberUpdated = 0
            };

            return View(model);
        }

        public async Task<ActionResult> SetLeave(int Id)
        {
            LeaveType leaveType = await _leavetyperepo.FindById(Id);

            IList<Employee> employees =
            await _userManager.GetUsersInRoleAsync("Employee");

            foreach (Employee emp in employees)
            {
                bool hasAllocation = await _leaveallocationrepo.CheckAllocation(Id, emp.Id);

                if (hasAllocation)
                    continue;

                LeaveAllocationViewModel allocation =
                new LeaveAllocationViewModel
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = emp.Id,
                    LeaveTypeId = Id,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = DateTime.Now.Year
                };

                LeaveAllocation leaveAllocation = _mapper
                .Map<LeaveAllocation>(allocation);

                await _leaveallocationrepo.Create(leaveAllocation);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> ListEmployees()
        {
            IList<Employee> employees = await _userManager
                .GetUsersInRoleAsync("Employee");

            List<EmployeeViewModel> model = _mapper
            .Map<List<EmployeeViewModel>>(employees);

            return View(model);
        }

        // GET: LeaveAllocationController/Details/5
        public async Task<ActionResult> Details(string Id)
        {
            EmployeeViewModel employee = _mapper
                .Map<EmployeeViewModel>(
                    await _userManager.FindByIdAsync(Id)
                );

            List<LeaveAllocationViewModel> allcations = _mapper
                .Map<List<LeaveAllocationViewModel>>(
                    await _leaveallocationrepo.GetLeaveAllocationsByEmployee(Id)
                );

            ViewAllocationsViewModel model = new ViewAllocationsViewModel
            {
                Employee = employee,
                LeaveAllocations = allcations
            };

            return View(model);
        }

        // GET: LeaveAllocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveAllocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: LeaveAllocationController/Edit/5
        public async Task<ActionResult> Edit(int Id)
        {
            LeaveAllocation leaveAllocation = await _leaveallocationrepo.FindById(Id);

            EditLeaveAllocationViewModel model = _mapper
            .Map<EditLeaveAllocationViewModel>(leaveAllocation);

            return View(model);
        }

        // POST: LeaveAllocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditLeaveAllocationViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                LeaveAllocation record = await _leaveallocationrepo.FindById(model.Id);

                record.NumberOfDays = model.NumberOfDays;

                bool isSuccess = await _leaveallocationrepo.Update(record);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Error while saving.");

                    return View(model);
                }

                return RedirectToAction(nameof(Details), new { Id = model.EmployeeId });
            }
            catch
            {
                return View(model);
            }
        }

        // GET: LeaveAllocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveAllocationController/Delete/5
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
