using System;
using System.ComponentModel.DataAnnotations;

namespace leave_management.Data
{
    /// <summary>
    /// Data entity model that describes the type of leave taken by the
    /// employee.
    /// </summary>
    public class LeaveType
    {
        /// <summary>
        /// The unique identifier for the leave type.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// A descriptive name of the type of leave.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The default/standard number of days for the leave type.
        /// </summary>
        public int DefaultDays { get; set; }

        /// <summary>
        /// Represents the time the leave was created.
        ///</summary>
        public DateTime DateCreated { get; set; }
    }
}