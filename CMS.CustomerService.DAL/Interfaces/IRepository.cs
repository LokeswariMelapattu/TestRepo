namespace DUC.CMS.CustomerService.DAL.Interfaces
{
    using System.Collections.Generic;

    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Executes the stored procedure.
        /// </summary>
        /// <param name="functionImportName">Name of the function import.</param>
        /// <returns></returns>
        IEnumerable<T> ExecuteStoredProcedure(string functionImportName);
    }
}
