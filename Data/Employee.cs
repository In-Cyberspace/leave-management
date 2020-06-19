using System;
using Microsoft.AspNetCore.Identity;

namespace leave_management.Data
{
    /// <summary>
    /// Represents the employee data entity model which inherits
    /// the Employee class.
    /// </summary>
    public class Employee : IdentityUser
    {
        /// <summary>
        /// Represents the employee's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Represents the employee's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Represents the employee's tax ID.
        /// </summary>
        public string TaxId { get; set; }

        /// <summary>
        /// Represents the employee's date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Represents the date the employee joined.
        /// </summary>
        public DateTime DateJoined { get; set; }
    }
}
