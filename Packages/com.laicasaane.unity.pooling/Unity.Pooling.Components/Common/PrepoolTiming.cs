using Cysharp.Threading.Tasks;

namespace Unity.Pooling.Components
{
    public enum PrepoolTiming
    {
        NextFrame,
        FixedUpdate,
        PreUpdate,
        Update,
    }

    public static class PrepoolTimingExtensions
    {
        public static PlayerLoopTiming ToPlayerLoopTiming(this PrepoolTiming value)
        {
            switch (value)
            {
                case PrepoolTiming.FixedUpdate: return PlayerLoopTiming.FixedUpdate;
                case PrepoolTiming.PreUpdate: return PlayerLoopTiming.PreUpdate;
                case PrepoolTiming.Update: return PlayerLoopTiming.Update;
            }

            return PlayerLoopTiming.Update;
        }
    }
}
