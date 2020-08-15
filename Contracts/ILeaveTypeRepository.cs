using System.Collections.Generic;
using System.Threading.Tasks;
using leave_management.Data;

namespace leave_management.Contracts
{
    /// <summary>
    /// Defines methods to perform CRUD operations on the LeaveType data
    /// records.
    /// </summary>
    public interface ILeaveTypeRepository : IRepositoryBase<LeaveType>
    {
        /// <summary>
        /// Returns a collection of all employees associated with the type of
        /// leave corresponding to the Id input.
        /// </summary>
        Task<ICollection<LeaveType>> GetEmployeesByLeaveType(int id);
    }
}