namespace DUC.CMS.CustomerService.DAL.Repository
{
    #region Importing Namespaces

    using System.Collections.Generic;
    using System.Data.Entity;

    #endregion Importing Namespaces

    /// <summary>
    /// Unit of work pattern implementation.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {

        #region Private Members

        /// <summary>
        /// Holds the object context
        /// </summary>
        private readonly DbContext _context;

        private bool _isDisposed;

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        internal Entities Context
        {
            get
            {
                return _context as Entities;
            }
        }

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        public UnitOfWork()
        {
            _context = new Entities(DUC.Utilities.CryptoEngine.CryptoEngine.Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings["Entities"].ConnectionString, true));
        }

        #endregion Constructors

        #region Internal Methods

        /// <summary>
        /// Creates the object set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal IDbSet<T> CreateDbSet<T>() where T : class
        {
            return _context.Set<T>();
        }

        #endregion Internal Methods

        #region Public Methods

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Execute function.
        /// </summary>
        public IEnumerable<T> ExecuteFuntion<T>(string functionName, string parameter) where T : class
        {
            return _context.Database.SqlQuery<T>(string.Format("EXEC {0} {1}", functionName, parameter));
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
            _isDisposed = true;
        }

        #endregion Public Methods

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed
        {
            get { return this._isDisposed; }
        }
    }
}