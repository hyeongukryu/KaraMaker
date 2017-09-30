using System;
using Contents;

namespace Game
{
    class ComputedStatus : IStatus
    {
        public ComputedStatus(Entity entity, Func<int> computeValue)
        {
            Entity = entity;
            ComputeValue = computeValue;
        }

        public int Value
        {
            get
            {
                var value = ComputeValue();
                value = Math.Max(Entity.Min, value);
                value = Math.Min(Entity.Max, value);
                return value;
            }
        }

        public Func<int> ComputeValue { get; }
        public Entity Entity { get; }
    }
}
