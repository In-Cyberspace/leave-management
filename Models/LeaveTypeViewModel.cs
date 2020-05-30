using System;
using System.ComponentModel.DataAnnotations;

namespace leave_management.Models
{
    /// <summary>
    /// Represents the view model abstraction of the leave type data entity
    /// model. This model is used to display the details of the leave type to
    /// the end user.
    /// </summary>
    public class LeaveTypeViewModel
    {
        /// <summary>
        /// The unique identifier for the leave type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the name of the leave type. This field is required.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The default/standard number of days for the leave type.
        /// </summary>
        [Required]
        [Display(Name = "Default Number of Days")]
        [Range(1,25, ErrorMessage = "Please enter a valid number.")]
        public int DefaultDays { get; set; }

        /// <summary>
        /// Represents the time the leave was created. This field is nullable. 
        ///</summary>
        [Display(Name="Date Created")]
        public DateTime? DateCreated { get; set; }
    }
}