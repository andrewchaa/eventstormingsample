using System;

namespace EventStormingSample.Infrastructure
{
    public class Id<T>
    {
        public Guid Value { get; }

        public Id(Guid value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}