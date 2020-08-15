using System.Collections.Generic;
using System.Threading.Tasks;

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
        Task<ICollection<T>> FindAll();

        /// <summary>
        /// Returns the class record/row from the relative database table that
        /// corresponds with the given unique identifier.
        /// </summary>
        Task<T> FindById(int id);

        /// <summary>
        /// Checks whether or not the database contains a record corresponding
        /// with the id input.
        /// </summary>
        Task<bool> isExists(int id);

        /// <summary>
        /// Returns true if the given entity was successfully created in the
        /// database. The method returns false otherwise.
        /// </summary>
        Task<bool> Create(T entity);

        /// <summary>
        /// Returns true if the given entity was successfully updated in the
        /// database. The method returns false otherwise.
        /// </summary>
        Task<bool> Update(T entity);

        /// <summary>
        /// Returns true if the given entity was successfully deleted from the
        /// database. The method returns false otherwise.
        /// </summary>
        Task<bool> Delete(T entity);

        /// <summary>
        /// This method applies entity framework changes to the database records.
        /// If any changes have been made then it returns true. If no changes
        /// were made then it returns false.
        /// </summary>
        Task<bool> Save();
    }
}