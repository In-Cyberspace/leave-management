using System.Collections.Generic;
using System.Linq;
using leave_management.Contracts;
using leave_management.Data;

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
            return _db.LeaveAllocations.ToList();
        }

        /// <summary>
        /// Returns the leave allocation record/row from the LeaveHistories
        /// table that corresponds with the given unique identifier.
        /// </summary>
        public LeaveAllocation FindById(int Id)
        {
            return _db.LeaveAllocations.Find(Id);
        }

        /// <summary>
        /// This method applies entity framework changes to the database records.
        /// If any changes have been made then it returns true. If no changes
        /// were made then it returns false.
        /// </summary>
        public bool Save()
        {
            return _db.SaveChanges() > 0;
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