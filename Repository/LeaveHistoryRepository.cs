using System.Collections.Generic;
using System.Linq;
using leave_management.Contracts;
using leave_management.Data;

namespace leave_management.Repository
{
    /// <summary>
    /// Implements CRUD operations related to the LeaveHistory data entity
    /// model.
    /// </summary>
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns true if the given leave history entity was successfully
        /// created in the database. The method returns false otherwise.
        /// </summary>
        public bool Create(LeaveHistory entity)
        {
            _db.LeaveHistories.Add(entity);
            return Save();
        }

        /// <summary>
        /// Returns true if the given leave history entity was successfully
        /// deleted from the database. The method returns false otherwise.
        /// </summary>
        public bool Delete(LeaveHistory entity)
        {
            _db.LeaveHistories.Remove(entity);
            return Save();
        }

        /// <summary>
        /// Returns all records from the LeaveHistories table in the database.
        /// </summary>
        public ICollection<LeaveHistory> FindAll()
        {
            List<LeaveHistory> leaveHistories = _db.LeaveHistories.ToList();
            return leaveHistories;
        }

        /// <summary>
        /// Returns the leave history record/row from the LeaveHistories table
        /// that corresponds with the given unique identifier.
        /// </summary>
        public LeaveHistory FindById(int Id)
        {
            LeaveHistory leaveHistory = _db.LeaveHistories.Find(Id);
            return leaveHistory;
        }

        /// <summary>
        /// Returns true if the database contains a record corresponding with
        /// the id input. Returns false otherwise.
        /// </summary>
        public bool isExists(int Id)
        {
            bool exists = _db.LeaveHistories.Any(
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
        /// Returns true if the leave history database record record was
        /// successfully updated. The method returns false otherwise.
        /// </summary>
        public bool Update(LeaveHistory entity)
        {
            _db.LeaveHistories.Update(entity);
            return Save();
        }
    }
}