using System.Collections.Generic;

namespace leave_management.Contracts
{
    /// <summary>
    /// Defines methods to perform generic CRUD operations on the records
    /// stored in the database.
    /// </summary>
    public interface IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Returns all records of the class type/all records from a table
        /// in the database.
        /// </summary>
        ICollection<T> FindAll();

        /// <summary>
        /// Returns a single record from the database that corresponds the Id
        /// input.
        /// </summary>
        T FindById(int Id);

        /// <summary>
        /// Returns true if the database record was created successfully or
        /// false otherwise.
        /// </summary>
        bool Create(T entity);

        /// <summary>
        /// Returns true if the database record was updated successfully or
        /// false otherwise.
        /// </summary>
        bool Update(T entity);

        /// <summary>
        /// Returns true if the database record was deleted successfully or
        /// false otherwise.
        /// </summary>
        bool Delete(T entity);

        /// <summary>
        /// Save changes made to the database records.
        /// </summary>
        bool Save();
    }
}