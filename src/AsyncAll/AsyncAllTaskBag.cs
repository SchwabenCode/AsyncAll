using System;
using System.Threading.Tasks;

namespace SchwabenCode.AsyncAll
{
    /// <summary>
    /// Instance Cache
    /// </summary>
    internal class AsyncAllTaskBag
    {
        /// <summary>
        /// Creates new instance and sets default task factory
        /// </summary>
        private AsyncAllTaskBag( )
        {
            Factory = Task.Factory;
        }
        /// <summary>
        /// Holds data for AsyncAll
        /// </summary>
        public static readonly Lazy<AsyncAllTaskBag> Instance = new Lazy<AsyncAllTaskBag>( ( ) => new AsyncAllTaskBag( ) );

        /// <summary>
        /// Factory for AsyncAll
        /// </summary>
        public TaskFactory Factory { get; set; }
    }
}