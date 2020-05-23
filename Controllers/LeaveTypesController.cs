using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using leave_management.Contracts;
using leave_management.Data;
using leave_management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leave_management.Controllers
{
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
        public ActionResult Index()
        {
            return View(
                _mapper.Map<List<LeaveType>,
                List<LeaveTypeViewModel>>(_repo.FindAll().ToList())
            );
        }

        // GET: LeaveTypes/Details/5
        public ActionResult Details(int Id)
        {
            if (!_repo.isExists(Id))
            {
                return NotFound();
            }
            
            LeaveType leaveType = _repo.FindById(Id);

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
        public ActionResult Create(LeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                LeaveType leavetype = _mapper.Map<LeaveType>(model);
                leavetype.DateCreated = DateTime.Now;
                bool isSuccess = _repo.Create(leavetype);
                
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
        public ActionResult Edit(int Id)
        {
            if (!_repo.isExists(Id))
            {
                return NotFound();
            }

            LeaveType leaveType = _repo.FindById(Id);
            
            LeaveTypeViewModel model;
            model =_mapper.Map<LeaveTypeViewModel>(leaveType);

            return View(model);
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                LeaveType leavetype = _mapper.Map<LeaveType>(model);
                bool isSuccess = _repo.Update(leavetype);
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
        public ActionResult Delete(int Id)
        {
             LeaveType leaveType = _repo.FindById(Id);
                
                if (leaveType == null)
                {
                    return NotFound();
                }

                bool isSuccess = _repo.Delete(leaveType);
                if (!isSuccess)
                {
                    return BadRequest();
                }
                
                return RedirectToAction(nameof(Index));
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, LeaveTypeViewModel model)
        {
            try
            {
                LeaveType leaveType = _repo.FindById(Id);
                
                if (leaveType == null)
                {
                    return NotFound();
                }

                bool isSuccess = _repo.Delete(leaveType);
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