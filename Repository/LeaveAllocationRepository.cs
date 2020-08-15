using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<bool> CheckAllocation(int leavetypeId, string employeeId)
        {
            int period = DateTime.Now.Year;
            ICollection<LeaveAllocation> leaveAllocations = await FindAll();

            return leaveAllocations
                .Where(q
                    => q.EmployeeId == employeeId
                    && q.LeaveTypeId == leavetypeId
                    && q.Period == period)
                .Any();
        }

        /// <summary>
        /// Returns true if the given leave allocation entity was successfully
        /// created in the database. The method returns false otherwise.
        /// </summary>
        public async Task<bool> Create(LeaveAllocation entity)
        {
            await _db.LeaveAllocations.AddAsync(entity);

            return await Save();
        }

        /// <summary>
        /// Returns true if the given leave allocation entity was successfully
        /// deleted from the database. The method returns false otherwise.
        /// </summary>
        public async Task<bool> Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);

            return await Save();
        }

        /// <summary>
        /// Returns all records from the LeaveAllocation table in the database.
        /// </summary>
        public async Task<ICollection<LeaveAllocation>> FindAll()
        {
            List<LeaveAllocation> leaveAllocations = await _db.LeaveAllocations
            .Include(q => q.LeaveType)
            .ToListAsync();

            return leaveAllocations;
        }

        /// <summary>
        /// Returns the leave allocation record/row from the LeaveHistories
        /// table that corresponds with the given unique identifier.
        /// </summary>
        public async Task<LeaveAllocation> FindById(int id)
        {
            LeaveAllocation leaveAllocation = await _db.LeaveAllocations
            .Include(q => q.LeaveType)
            .Include(q => q.Employee)
            .FirstOrDefaultAsync(q => q.Id == id);

            return leaveAllocation;
        }

        public async Task<ICollection<LeaveAllocation>> GetLeaveAllocationsByEmployee(string employeeid)
        {
            int period = DateTime.Now.Year;
            ICollection<LeaveAllocation> leaveAllocations = await FindAll();

            return leaveAllocations
                .Where(q => q.EmployeeId == employeeid && q.Period == period)
                .ToList();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationsByEmployeeAndType(string employeeid, int leavetypeid)
        {
            int period = DateTime.Now.Year;
            ICollection<LeaveAllocation> leaveAllocations = await FindAll();

            return leaveAllocations
                .FirstOrDefault(q
                    => q.EmployeeId == employeeid
                    && q.Period == period
                    && q.LeaveTypeId == leavetypeid);
        }

        /// <summary>
        /// Returns true if the database contains a record corresponding with
        /// the id input. Returns false otherwise.
        /// </summary>
        public async Task<bool> isExists(int id)
        {
            bool exists = await _db.LeaveAllocations
                .AnyAsync(q => q.Id == id);

            return exists;
        }

        /// <summary>
        /// This method applies entity framework changes to the database records.
        /// If any changes have been made then it returns true. If no changes
        /// were made then it returns false.
        /// </summary>
        public async Task<bool> Save()
        {
            int changes = await _db.SaveChangesAsync();

            return changes > 0;
        }

        /// <summary>
        /// Returns true if the given leave allocation entity was successfully
        /// updated in the database. The method returns false otherwise.
        /// </summary>
        public async Task<bool> Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);

            return await Save();
        }
    }
}