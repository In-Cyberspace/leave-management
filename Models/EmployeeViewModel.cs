using System;
namespace leave_management.Models
{
    /// <summary>
    /// Represents an abstraction of the employee data entity model.
    /// </summary>
    public class EmployeeViewModel
    {
        /// <summary>
        /// Gets or sets the primary key for this user.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the user name for this user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the email address for this user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a telephone number for the user.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Represents the employee's first name.
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Represents the employee's last name.
        /// </summary>
        public string Lastname { get; set; }

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