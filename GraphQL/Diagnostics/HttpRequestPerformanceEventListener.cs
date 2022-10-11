using HotChocolate.AspNetCore.Instrumentation;
using System.Diagnostics;

namespace KnowCrow.GraphQL.Diagnostics
{
    public class HttpRequestPerformanceEventListener : ServerDiagnosticEventListener
    {
        public override IDisposable ExecuteHttpRequest(HttpContext context, HttpRequestKind kind)
        {
            return new TimedRequestScope();
        }
    }

    public class TimedRequestScope : IDisposable
    {
        private readonly Stopwatch _stopwatch;

        public TimedRequestScope()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            Console.WriteLine($"Request finished after {_stopwatch.Elapsed.TotalMilliseconds}ms");
        }
    }
}
