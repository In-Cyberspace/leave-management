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
using Microsoft.AspNetCore.Mvc;

namespace leave_management.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;

        public LeaveTypesController(
            ILeaveTypeRepository repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<ActionResult> Index()
        {
            ICollection<LeaveType> leaveTypes = await _repo.FindAll();

            List<LeaveTypeViewModel> model = _mapper
                .Map<List<LeaveType>, List<LeaveTypeViewModel>>(
                    leaveTypes.ToList()
                );

            return View(model);
        }

        // GET: LeaveTypes/Details/5
        public async Task<ActionResult> Details(int id)
        {
            bool isExists = await _repo.isExists(id);

            if (!isExists)
            {
                return NotFound();
            }

            LeaveType leaveType = await _repo.FindById(id);

            LeaveTypeViewModel model;
            model = _mapper.Map<LeaveTypeViewModel>(leaveType);

            return View(model);
        }

        // GET: LeaveTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                LeaveType leavetype = _mapper.Map<LeaveType>(model);
                leavetype.DateCreated = DateTime.Now;
                bool isSuccess = await _repo.Create(leavetype);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            bool isExists = await _repo.isExists(id);

            if (!isExists)
            {
                return NotFound();
            }

            LeaveType leaveType = await _repo.FindById(id);

            LeaveTypeViewModel model;
            model = _mapper.Map<LeaveTypeViewModel>(leaveType);

            return View(model);
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                LeaveType leavetype = _mapper.Map<LeaveType>(model);
                bool isSuccess = await _repo.Update(leavetype);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");

                return View(model);
            }
        }

        // GET: LeaveTypes/Delete/5
        public async Task<ActionResult> Delete(int Id)
        {
            LeaveType leaveType = await _repo.FindById(Id);

            if (leaveType == null)
            {
                return NotFound();
            }

            bool isSuccess = await _repo.Delete(leaveType);
            if (!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int Id, LeaveTypeViewModel model)
        {
            try
            {
                LeaveType leaveType = await _repo.FindById(Id);

                if (leaveType == null)
                {
                    return NotFound();
                }

                bool isSuccess = await _repo.Delete(leaveType);
                if (!isSuccess)
                {
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}