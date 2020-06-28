using System;
using System.ComponentModel.DataAnnotations;

namespace leave_management.Models
{
    /// <summary>
    /// Generic leave requests view model.
    /// </summary>
    public class LeaveRequestViewModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the leave request.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the employee requesting the leave.
        /// </summary>
        public EmployeeViewModel RequestingEmployee { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for employee requesting the leave.
        /// </summary>
        public string RequestingEmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the request.
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date for the request.
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the type of leave being requested.
        /// </summary>
        public LeaveTypeViewModel LeaveType { get; set; }

        /// <summary>
        /// Gets or sets he unique identifier of the leave being requested.
        /// </summary>
        public int LeaveTypeId { get; set; }

        /// <summary>
        /// Gets or sets the date the leave was requested.
        /// </summary>
        public DateTime DateRequested { get; set; }

        /// <summary>
        /// Gets or sets the date the leave request was actioned.
        /// </summary>
        public DateTime DateActioned { get; set; }

        /// <summary>
        /// Gets or sets the approval status of the leave request.
        /// </summary>
        public bool? Approved { get; set; }

        /// <summary>
        /// Gets or sets the employee who approved/declined the leave request.
        /// </summary>
        public EmployeeViewModel ApprovedBy { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the employee who 
        /// approved/declined the leave request.
        /// </summary>
        public string ApprovedById { get; set; }
    }
}
