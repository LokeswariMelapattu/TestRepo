namespace DUC.CMS.CustomerService.DAL.Repository
{
    #region Namespaces

    using DUC.CMS.CustomerService.DAL.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;


    #endregion

    /// <summary>
    /// Repository Generic Implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        
        #region Private Members

        /// <summary>
        /// Holds object set
        /// </summary>
        private readonly IDbSet<T> _dbSet;

        /// <summary>
        /// Object context
        /// </summary>
        protected readonly UnitOfWork _dbContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        public Repository(IUnitOfWork dbContext)
        {
            _dbContext = dbContext as UnitOfWork;
            _dbSet = _dbContext.CreateDbSet<T>();
        }

        #endregion

        #region IRepository Implementation

        /// <summary>
        /// Executes the stored procedure.
        /// </summary>
        /// <param name="functionImportName">Name of the function import.</param>
        /// <returns></returns>
        public IEnumerable<T> ExecuteStoredProcedure(string functionImportName)
        {
            var methodInfo = typeof(Entities).GetMethod(functionImportName, new Type[0]);
            return methodInfo.Invoke(_dbContext.Context, null) as IEnumerable<T>;
        }

        #endregion
    }
}
