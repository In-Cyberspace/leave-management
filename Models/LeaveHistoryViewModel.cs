using System;
using System.ComponentModel.DataAnnotations;

namespace leave_management.Models
{
    /// <summary>
    /// Represents an abstraction of the leave history data entity model.
    /// </summary>
    public class LeaveHistoryViewModel
    {
        /// <summary>
        /// Unique identifier associated with the leave record in the history.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the employee who's requesting the leave.
        /// </summary>
        public EmployeeViewModel RequestingEmployee { get; set; }

        /// <summary>
        /// The unique identifier for the employee who is requesting the leave.
        /// </summary>
        public string RequestingEmployeeId { get; set; }

        /// <summary>
        /// The starting date for the leave.
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The ending date for the leave.
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// The type of leave requested by the employee.
        /// </summary>
        public DetailsLeaveTypeViewModel LeaveType { get; set; }

        /// <summary>
        /// The unique identifier associated with the requested leave type.
        /// </summary>
        public int LeaveTypeId { get; set; }

        /// <summary>
        /// Represents the date the leave was requested.
        /// </summary>
        public DateTime DateRequested { get; set; }

        /// <summary>
        /// Represents the date the leave request was actioned.
        /// </summary>
        public DateTime DateActioned { get; set; }

        /// <summary>
        /// Indicates whether the actioned leave request was approved or not.
        /// </summary>
        public bool? Approved { get; set; }

        /// <summary>
        /// Represents the person who actioned the leave request.
        /// </summary>
        public EmployeeViewModel ApprovedBy { get; set; }

        /// <summary>
        /// The unique identifier of the person who actioned the leave request.
        /// </summary>
        public string ApprovedById { get; set; }

    }
}