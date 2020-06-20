using System;
using System.Collections.Generic;
using System.Linq;
using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;

namespace leave_management.Repository
{
    /// <summary>
    /// Implements CRUD operations related to the LeaveAllocation data entity
    /// model.
    /// </summary>
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CheckAllocation(int leavetypeId, string employeeId)
        {
            int period = DateTime.Now.Year;

            return FindAll().Where(
                q => q.EmployeeId == employeeId
                && q.LeaveTypeId == leavetypeId
                && q.Period == period
            ).Any();
        }

        /// <summary>
        /// Returns true if the given leave allocation entity was successfully
        /// created in the database. The method returns false otherwise.
        /// </summary>
        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);

            return Save();
        }

        /// <summary>
        /// Returns true if the given leave allocation entity was successfully
        /// deleted from the database. The method returns false otherwise.
        /// </summary>
        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);

            return Save();
        }

        /// <summary>
        /// Returns all records from the LeaveAllocation table in the database.
        /// </summary>
        public ICollection<LeaveAllocation> FindAll()
        {
            List<LeaveAllocation> leaveAllocations = _db.LeaveAllocations
            .Include(q => q.LeaveType)
            .ToList();

            return leaveAllocations;
        }

        /// <summary>
        /// Returns the leave allocation record/row from the LeaveHistories
        /// table that corresponds with the given unique identifier.
        /// </summary>
        public LeaveAllocation FindById(int Id)
        {
            LeaveAllocation leaveAllocation =_db.LeaveAllocations.Find(Id);
            return leaveAllocation;
        }

        public ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string Id)
        {
            int period = DateTime.Now.Year;

            return FindAll()
            .Where(q => q.EmployeeId == Id && q.Period == period)
            .ToList();
        }

        /// <summary>
        /// Returns true if the database contains a record corresponding with
        /// the id input. Returns false otherwise.
        /// </summary>
        public bool isExists(int Id)
        {
            bool exists = _db.LeaveAllocations.Any(
                q => q.Id == Id
            );

            return exists;
        }

        /// <summary>
        /// This method applies entity framework changes to the database records.
        /// If any changes have been made then it returns true. If no changes
        /// were made then it returns false.
        /// </summary>
        public bool Save()
        {
            int changes = _db.SaveChanges();

            return changes > 0;
        }

        /// <summary>
        /// Returns true if the given leave allocation entity was successfully
        /// updated in the database. The method returns false otherwise.
        /// </summary>
        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);

            return Save();
        }
    }
}