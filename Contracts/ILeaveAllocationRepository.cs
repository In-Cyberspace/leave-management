using System.Collections.Generic;
using System.Threading.Tasks;
using leave_management.Data;

namespace leave_management.Contracts
{
    /// <summary>
    /// Defines methods to perform CRUD operations on the LeaveAllocation data
    /// records.
    /// </summary>
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        /// <summary>
        /// Checks whether the given employee has been allocated the given leave
        /// type.
        /// </summary>
        /// <param name="leavetypeId"></param>
        /// <param name="employeeId"></param>
        /// <returns>A boolean.</returns>
        Task<bool> CheckAllocation(int leavetypeId, string employeeId);

        /// <summary>
        /// Returns a collection of leaves allocated to the given employee for
        /// the time period.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>A collection of leave allocations.</returns>
        Task<ICollection<LeaveAllocation>> GetLeaveAllocationsByEmployee(string employeeid);

        /// <summary>
        /// Returns a leave allocated to the given employee and given leave
        /// type for the time period.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="leavetypeid"></param>
        /// <returns>A leave allocation.</returns>
        Task<LeaveAllocation> GetLeaveAllocationsByEmployeeAndType(string employeeid, int leavetypeid);
    }
}