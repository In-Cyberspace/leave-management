using System;
using System.ComponentModel.DataAnnotations;

namespace leave_management.Models
{
    /// <summary>
    /// Represents the view model abstraction of the leave type data entity
    /// model. This model is used to display the details of the leave type to
    /// the end user.
    /// </summary>
    public class DetailsLeaveTypeViewModel
    {
        /// <summary>
        /// The unique identifier for the leave type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the name of the leave type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the time the leave was created.
        ///</summary>
        public DateTime DateCreated { get; set; }
    }

    /// <summary>
    /// A model representing the form an end user will use to create new leave
    /// type.
    /// </summary>
    public class CreateLeaveTypeViewModel
    {
        /// <summary>
        /// Represents the name of the leave type.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}