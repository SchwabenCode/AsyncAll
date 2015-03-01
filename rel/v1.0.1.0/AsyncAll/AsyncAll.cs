// <copyright file="AsyncAll.cs" project="AsyncAll" company="Benjamin Abt ( http://www.benjamin-abt.com )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>07/12/2014</date>
// <summary>Extensions to provide several methods for all .NET Framework verions</summary>

using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace SchwabenCode.AsyncAll
{
    /// <summary>
    /// Extensions to provide several methods for all .NET Framework verions for async/await Pattern
    /// </summary>
    public static class AsyncAll
    {

        /// <summary>
        /// Sets the factory, the tasks are created with.
        /// </summary>
        /// <param name="taskFactory">TaskFactory to set.</param>
        public static void SetTaskFactory( TaskFactory taskFactory )
        {
            AsyncAllTaskBag.Instance.Value.Factory = taskFactory;
        }

        /// <summary>
        /// Gets the factory, the tasks are created with.
        /// </summary>
        /// <returns>The factory, the tasks are created with.</returns>
        public static TaskFactory GetTaskFactory( )
        {
            return AsyncAllTaskBag.Instance.Value.Factory;
        }


        /// <summary>
        /// Executes the action in a wrapped task to use async operation
        /// </summary>
        /// <typeparam name="T">Result Type</typeparam>
        /// <param name="action">Action to execute in wrapped task</param>
        /// <param name="resultValue">Returns this value if finished</param>
        /// <returns><see cref="Task"/></returns>
        public static Task<T> ExecuteAsyncResult<T>( Action action, T resultValue )
        {
            Contract.Requires( action != null );
            Contract.Ensures( Contract.Result<Task<T>>( ) != null );

            var tcs = new TaskCompletionSource<T>( );

            GetTaskFactory( ).StartNew( ( ) =>
            {
                try
                {
                    action( );
                    tcs.SetResult( resultValue );
                }
                catch ( Exception ex )
                {
                    tcs.SetException( ex );
                }
            } );

            return tcs.Task;
        }

        /// <summary>
        /// Executes the action in a wrapped task to use async operation and gets the result
        /// </summary>
        /// <typeparam name="T">Result Type</typeparam>
        /// <param name="action">Action to execute in wrapped task</param>
        /// <returns><see cref="Task"/> with result value</returns>
        public static Task<T> GetAsyncResult<T>( Func<T> action )
        {
            Contract.Requires( action != null );
            Contract.Ensures( Contract.Result<Task<T>>( ) != null );

            var tcs = new TaskCompletionSource<T>( );

            GetTaskFactory( ).StartNew( ( ) =>
            {
                try
                {
                    tcs.SetResult( action( ) );
                }
                catch ( Exception ex )
                {
                    tcs.SetException( ex );
                }
            } );

            return tcs.Task;
        }

        /// <summary>
        /// Executes the action in a wrapped task to use async operation
        /// </summary>
        /// <param name="action">Action to execute in wrapped task</param>
        /// <returns><see cref="Task"/></returns>
        public static Task ExecuteAsync( Action action )
        {
            Contract.Requires( action != null );
            Contract.Ensures( Contract.Result<Task>( ) != null );

            return GetTaskFactory( ).StartNew( action );
        }
    }
}
