using System.Collections.Generic;
using leave_management.Data;

namespace leave_management.Contracts
{
    /// <summary>
    /// Defines methods to perform CRUD operations on the LeaveHistory data
    /// records.
    /// </summary>
    public interface ILeaveRequestRepository : IRepositoryBase<LeaveRequest>
    {
        /// <summary>
        /// Returns all of the given employee's leave requests.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>A collection of leave requests.</returns>
        public ICollection<LeaveRequest> GetLeaveRequestsByEmployee(string employeeId);
    }
}