using System;
using System.Threading.Tasks;

namespace SchwabenCode.AsyncAll
{
    internal class AsyncAllBag : IDisposable
    {
        private TaskScheduler _scheduler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxConurrentTasks">if <see cref="maxConurrentTasks"/> is zero or lower than the default taskScheduler is used. Above 0 a limited task scheduler is used to realize max conurrency.</param>
        public AsyncAllBag( Int32 maxConurrentTasks = 0 )
        {
            _scheduler = maxConurrentTasks <= 0 ? TaskScheduler.Current : new LimitedConcurrencyLevelTaskScheduler( maxConurrentTasks );
        }

        /// <summary>
        /// Führt anwendungsspezifische Aufgaben durch, die mit der Freigabe, der Zurückgabe oder dem Zurücksetzen von nicht verwalteten Ressourcen zusammenhängen.
        /// </summary>
        public void Dispose( )
        {

        }
    }
}