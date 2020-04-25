using System.Collections.Generic;
using leave_management.Data;

namespace leave_management.Contracts
{
    /// <summary>
    /// Defines methods to perform CRUD operations on the LeaveAllocation data
    /// records.
    /// </summary>
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
    }
}