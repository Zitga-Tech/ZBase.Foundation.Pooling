using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public enum Timing
    {
        NextFrame,
        FixedUpdate,
        PreUpdate,
        Update,
    }

    public static class TimingExtensions
    {
        public static PlayerLoopTiming ToPlayerLoopTiming(this Timing value)
        {
            switch (value)
            {
                case Timing.FixedUpdate: return PlayerLoopTiming.FixedUpdate;
                case Timing.PreUpdate: return PlayerLoopTiming.PreUpdate;
                case Timing.Update: return PlayerLoopTiming.Update;
            }

            return PlayerLoopTiming.Update;
        }
    }
}
