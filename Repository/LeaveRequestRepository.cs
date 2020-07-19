using System.Collections.Generic;
using System.Linq;
using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;

namespace leave_management.Repository
{
    /// <summary>
    /// Implements CRUD operations related to the LeaveHistory data entity
    /// model.
    /// </summary>
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveRequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns true if the given leave history entity was successfully
        /// created in the database. The method returns false otherwise.
        /// </summary>
        public bool Create(LeaveRequest entity)
        {
            _db.LeaveRequests.Add(entity);
            return Save();
        }

        /// <summary>
        /// Returns true if the given leave history entity was successfully
        /// deleted from the database. The method returns false otherwise.
        /// </summary>
        public bool Delete(LeaveRequest entity)
        {
            _db.LeaveRequests.Remove(entity);
            return Save();
        }

        /// <summary>
        /// Returns all records from the LeaveRequests table in the database.
        /// </summary>
        public ICollection<LeaveRequest> FindAll()
        {
            List<LeaveRequest> leaveRequests = _db.LeaveRequests
            .Include(q => q.RequestingEmployee)
            .Include(q => q.ApprovedBy)
            .Include(q => q.LeaveType)
            .ToList();

            return leaveRequests;
        }

        /// <summary>
        /// Returns the leave history record/row from the LeaveRequests table
        /// that corresponds with the given unique identifier.
        /// </summary>
        public LeaveRequest FindById(int id)
        {
            LeaveRequest leaveRequest = _db.LeaveRequests
            .Include(q => q.RequestingEmployee)
            .Include(q => q.ApprovedBy)
            .Include(q => q.LeaveType)
            .FirstOrDefault(q => q.Id == id);

            return leaveRequest;
        }

        /// <summary>
        /// Returns true if the database contains a record corresponding with
        /// the id input. Returns false otherwise.
        /// </summary>
        public bool isExists(int id)
        {
            bool exists = _db.LeaveRequests.Any(
                q => q.Id == id
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
        /// Returns true if the leave history database record record was
        /// successfully updated. The method returns false otherwise.
        /// </summary>
        public bool Update(LeaveRequest entity)
        {
            _db.LeaveRequests.Update(entity);
            return Save();
        }
    }
}