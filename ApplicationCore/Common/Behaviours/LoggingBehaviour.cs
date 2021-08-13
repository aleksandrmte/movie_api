using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger<LoggingBehaviour<TRequest>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest>> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogInformation("MonolithicArchitectureWeb Request: {Name} {@UserId} {@UserName} {@Request}",
                requestName, request);
        }
    }
}
