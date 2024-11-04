using System;

namespace DUC.CMS.CustomerService.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// <c>trueC:\DUC\CMS\CMS.CustomerService.DAL\IUnitOfWork.cs</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        bool IsDisposed { get; }
    }
}
