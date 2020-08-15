using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<bool> Create(LeaveRequest entity)
        {
            await _db.LeaveRequests.AddAsync(entity);

            return await Save();
        }

        /// <summary>
        /// Returns true if the given leave history entity was successfully
        /// deleted from the database. The method returns false otherwise.
        /// </summary>
        public async Task<bool> Delete(LeaveRequest entity)
        {
            _db.LeaveRequests.Remove(entity);

            return await Save();
        }

        /// <summary>
        /// Returns all records from the LeaveRequests table in the database.
        /// </summary>
        public async Task<ICollection<LeaveRequest>> FindAll()
        {
            List<LeaveRequest> leaveRequests = await _db.LeaveRequests
                .Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .ToListAsync();

            return leaveRequests;
        }

        /// <summary>
        /// Returns the leave history record/row from the LeaveRequests table
        /// that corresponds with the given unique identifier.
        /// </summary>
        public async Task<LeaveRequest> FindById(int id)
        {
            LeaveRequest leaveRequest = await _db.LeaveRequests
                .Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return leaveRequest;
        }

        public async Task<ICollection<LeaveRequest>> GetLeaveRequestsByEmployee(string employeeId)
        {
            ICollection<LeaveRequest> leaveRequests = await FindAll();

            return leaveRequests
                .Where(q => q.RequestingEmployeeId == employeeId)
                .ToList();
        }

        /// <summary>
        /// Returns true if the database contains a record corresponding with
        /// the id input. Returns false otherwise.
        /// </summary>
        public async Task<bool> isExists(int id)
        {
            bool exists = await _db.LeaveRequests
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
        /// Returns true if the leave history database record record was
        /// successfully updated. The method returns false otherwise.
        /// </summary>
        public async Task<bool> Update(LeaveRequest entity)
        {
            _db.LeaveRequests.Update(entity);

            return await Save();
        }
    }
}