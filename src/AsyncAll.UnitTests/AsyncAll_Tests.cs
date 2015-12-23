using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace SchwabenCode.AsyncAll.UnitTests
{
    public class AsyncAllTests
    {
        Int32 TestAdd( int a, int b )
        {
            return a + b;
        }

        void TestException( string message )
        {
            throw new Exception( message );
        }

        [Fact]
        public void GetAsyncResult()
        {
            Task<int> result = AsyncAll.GetAsyncResult( () => TestAdd( 1, 2 ) );
            result.Wait();
            // Test

            result.Result.Should().Be( 3 );
        }

        [Fact]
        public void ExecuteAsync()
        {
            Task result = AsyncAll.ExecuteAsync( () => TestAdd( 1, 2 ) );
            result.Wait();
        }

        [Fact]
        public void ExecuteAsync_Exception()
        {
            string actualMessage = "Test";
            Func<Task> act = async () => { await Task.Run( () => TestException( actualMessage ) ); };

            // Test
            act.ShouldThrow<Exception>().WithMessage( actualMessage );
        }
    }
}
