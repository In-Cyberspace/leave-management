using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Index()
        {
            List<LeaveType> leavetypes = _leavetyperepo.FindAll().ToList();
            
            List<LeaveTypeViewModel> mappedLeaveTypes = _mapper
            .Map<List<LeaveType>, List<LeaveTypeViewModel>>(leavetypes);
            
            CreateLeaveAllocationViewModel model =
            new CreateLeaveAllocationViewModel
            {
                LeaveTypes = mappedLeaveTypes,
                NumberUpdated = 0
            };

            return View(model);
        }

        public ActionResult SetLeave(int Id)
        {
            LeaveType leaveType = _leavetyperepo.FindById(Id);
            
            IList<Employee> employees =
            _userManager.GetUsersInRoleAsync("Employee").Result;

            foreach (Employee emp in employees)
            {
                if (_leaveallocationrepo.CheckAllocation(Id, emp.Id))
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

                _leaveallocationrepo.Create(leaveAllocation);
            }

                return RedirectToAction(nameof(Index));
        }

        public ActionResult ListEmployees()
        {
            IList<Employee> employees = _userManager
            .GetUsersInRoleAsync("Employee").Result;

            List<EmployeeViewModel> model = _mapper
            .Map<List<EmployeeViewModel>>(employees);

            return View(model);
        }

        // GET: LeaveAllocationController/Details/5
        public ActionResult Details(string Id)
        {
            EmployeeViewModel employee = _mapper
            .Map<EmployeeViewModel>(
                _userManager.FindByIdAsync(Id).Result
            );

            List<LeaveAllocationViewModel> allcations = _mapper
            .Map<List<LeaveAllocationViewModel>>(
                _leaveallocationrepo
                .GetLeaveAllocationsByEmployee(Id)
            );

            ViewAllocationsViewModel model =
            new ViewAllocationsViewModel
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
        public ActionResult Edit(int Id)
        {
            LeaveAllocation leaveAllocation = _leaveallocationrepo.FindById(Id);

            EditLeaveAllocationViewModel model = _mapper
            .Map<EditLeaveAllocationViewModel>(leaveAllocation);

            return View(model);
        }

        // POST: LeaveAllocationController/Edit/5
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
