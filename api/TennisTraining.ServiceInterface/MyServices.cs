using System;
using ServiceStack;
using TennisTraining.ServiceModel;

namespace TennisTraining.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}
