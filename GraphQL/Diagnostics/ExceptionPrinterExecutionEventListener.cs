using HotChocolate.Execution;
using HotChocolate.Execution.Instrumentation;

namespace KnowCrow.GraphQL.Diagnostics
{
    public class ExceptionPrinterExecutionEventListener : ExecutionDiagnosticEventListener
    {
        public override void RequestError(IRequestContext context, Exception exception)
        {
            RecurseException(exception);
            void RecurseException(Exception? exception)
            {
                if (exception == null)
                    return;

                Console.WriteLine(exception.Message);
                RecurseException(exception.InnerException);
            }
        }
    }
}
