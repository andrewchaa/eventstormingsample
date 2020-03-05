using System.Buffers;
using System.Collections.Generic;
using EventStormingSample.Controllers;

namespace EventStormingSample.Infrastructure
{
    public class OpResult<T>
    {
        public OpStatus Status { get; }
        public T Value { get; }
        public IList<string> Errors { get; }

        public OpResult(IList<string> errors)
        {
            Status = OpStatus.Error;
            Errors = errors;
        }
        
        public OpResult(T value)
        {
            Status = OpStatus.Success;
            Value = value;
        }
    }

    public class OpResult
    {
        public OpStatus Status { get; }
        public IList<string> Errors { get; }

        public OpResult()
        {
            Status = OpStatus.Success;
        }
    }
}