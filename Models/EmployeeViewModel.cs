using System;
using System.ComponentModel.DataAnnotations;

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
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the email address for this user.
        /// </summary>
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a telephone number for the user.
        /// </summary>
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Represents the employee's first name.
        /// </summary>
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        /// <summary>
        /// Represents the employee's last name.
        /// </summary>
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        /// <summary>
        /// Represents the employee's tax ID.
        /// </summary>
        [Display(Name = "Tax ID Number")]
        public string TaxId { get; set; }

        /// <summary>
        /// Represents the employee's date of birth.
        /// </summary>
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Represents the date the employee joined.
        /// </summary>
        [Display(Name = "Join Date")]
        public DateTime DateJoined { get; set; }
    }
}