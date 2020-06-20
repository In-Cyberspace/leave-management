using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace leave_management.Models
{
    /// <summary>
    /// Represents an abstraction of the leave allocation data entity model.
    /// </summary>
    public class LeaveAllocationViewModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the leave allocation.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the number of days allocated to the leave type.
        /// </summary>
        public int NumberOfDays { get; set; }

        /// <summary>
        /// Gets or sets the date that the date of creation of the leave 
        /// allocation.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the period/year during which the leave type applies.
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// Gets or sets the employee associated with the leave allocation.
        /// </summary>
        public EmployeeViewModel Employee { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the employee associated with
        /// the allocation.
        /// </summary>
        public string EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the leave type being allocated.
        /// </summary>
        public LeaveTypeViewModel LeaveType { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the allocated leave type.
        /// </summary>
        public int LeaveTypeId { get; set; }
    }

    public class CreateLeaveAllocationViewModel
    {
        /// <summary>
        /// Gets or sets the number of records that were updated by the
        /// parent method.
        /// </summary>
        public int NumberUpdated { get; set; }

        /// <summary>
        /// Gets or sets a list of leave types.
        /// </summary>
        public List<LeaveTypeViewModel> LeaveTypes { get; set; }
    }

    public class ViewAllocationsViewModel
    {
        /// <summary>
        /// Gets or sets the employee associated with the leave allocation.
        /// </summary>
        public EmployeeViewModel Employee { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the employee associated with
        /// the allocation.
        /// </summary>
        public string EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets a list of leave allocations associated with the
        /// employee.
        /// </summary>
        public List<LeaveAllocationViewModel> LeaveAllocations { get; set; }
    }
}