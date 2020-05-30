using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace leave_management.Models
{
    /// <summary>
    /// Represents an abstraction of the leave allocation data entity model.
    /// </summary>
    public class LeaveAllocationViewModel
    {
        /// <summary>
        /// Unique identifier for the leave allocation.
        /// </summary>
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
        /// The period/year during which the leave type applies.
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// Represents the employee to whom the allocation are being made.
        /// </summary>
        public EmployeeViewModel Employee { get; set; }

        /// <summary>
        /// The unique identifier for the employee associated with the
        /// allocation.
        /// </summary>
        public string EmployeeId { get; set; }

        /// <summary>
        /// Represents the type of leave to the allocation is associated with.
        /// </summary>
        public LeaveTypeViewModel LeaveType { get; set; }

        /// <summary>
        /// The unique identifier for the leave type associated with the
        /// allocation.
        /// </summary>
        public int LeaveTypeId { get; set; }

        /// <summary>
        /// Represents a collection of employees in the database. This
        /// collection is to be displayed using a drop down list.
        /// </summary>
        public IEnumerable<SelectListItem> Employees { get; set; }

        /// <summary>
        /// Represents a collection of leave types in the database. This
        /// collection is to be displayed using a drop down list.
        /// </summary>
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
    }
}