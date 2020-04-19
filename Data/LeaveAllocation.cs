using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace leave_management.Data
{
    /// <summary>
    /// Data entity model storring the number of days each employee has for
    /// each type of leave.
    /// </summary>
    public class LeaveAllocation
    {
        /// <summary>
        /// Unique identifier for the leave allocation.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Represents the number of days allocated to the leave type.
        /// </summary>
        public int NumberOfDays { get; set; }

        /// <summary>
        /// Represents the date the allocations were made. This date corresponds
        /// to the date the leave type was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Represents the employee to whom the allocation are being made.
        /// </summary>
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        /// <summary>
        /// The unique identifier for the employee associated with the allocation.
        /// </summary>
        public string EmployeeId { get; set; }

        /// <summary>
        /// Represents the type of leave to the allocation is associated with.
        /// </summary>
        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }

        /// <summary>
        /// The unique identifier for the leave type associated with the allocation.
        /// </summary>
        public int LeaveTypeId { get; set; }
    }
}