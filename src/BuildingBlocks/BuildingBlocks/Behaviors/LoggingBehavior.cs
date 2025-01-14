using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors;

public class LoggingBehavior<TRequest, TRespopnse>
    (ILogger<LoggingBehavior<TRequest, TRespopnse>> logger)
    : IPipelineBehavior<TRequest, TRespopnse>
    where TRequest : notnull, IRequest<TRespopnse>
    where TRespopnse : notnull
{
    public async Task<TRespopnse> Handle(TRequest request, RequestHandlerDelegate<TRespopnse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("[START] Handle request={Request} - Response={Response} - RequestData{RequestData}",
            typeof(TRequest).Name, typeof(TRespopnse).Name, request);

        var timer = new Stopwatch();
        timer.Start();

        var response = await next();

        timer.Stop();
        var timeTaken = timer.Elapsed;
        if (timeTaken.Seconds > 3)
            logger.LogWarning("[PERFORMANCE] The request {Request} took {TimeTaken} seconds.",
                typeof(TRequest).Name, timeTaken.Seconds);

        logger.LogInformation("[END] Handled {Request} with {Response}", typeof(TRequest).Name, typeof(TRespopnse).Name);
        return response;
    }
}
