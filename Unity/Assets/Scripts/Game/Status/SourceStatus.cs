using System;
using Contents;

namespace Game
{
    class SourceStatus : IWritableStatus
    {
        public SourceStatus(Entity entity)
        {
            Entity = entity;
            Value = entity.Init;
        }

        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                value = Math.Max(Entity.Min, value);
                value = Math.Min(Entity.Max, value);
                _value = value;
            }
        }

        public Entity Entity { get; }
    }
}
