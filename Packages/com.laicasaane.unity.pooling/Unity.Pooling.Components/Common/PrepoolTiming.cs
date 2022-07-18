using Cysharp.Threading.Tasks;

namespace Unity.Pooling.Components
{
    public enum PrepoolTiming
    {
        Initialization,
        LastInitialization,
        EarlyUpdate,
        LastEarlyUpdate,
        FixedUpdate,
        LastFixedUpdate,
        PreUpdate,
        LastPreUpdate,
        Update,
        LastUpdate,
        PreLateUpdate,
        LastPreLateUpdate,
        PostLateUpdate,
        LastPostLateUpdate,
        TimeUpdate,
        LastTimeUpdate
    }

    public static class PrepoolTimingExtensions
    {
        public static PlayerLoopTiming ToPlayerLoopTiming(this PrepoolTiming value)
        {
            switch (value)
            {
                case PrepoolTiming.Initialization: return PlayerLoopTiming.Initialization;
                case PrepoolTiming.LastInitialization: return PlayerLoopTiming.LastInitialization;
                case PrepoolTiming.EarlyUpdate: return PlayerLoopTiming.EarlyUpdate;
                case PrepoolTiming.LastEarlyUpdate: return PlayerLoopTiming.LastEarlyUpdate;
                case PrepoolTiming.FixedUpdate: return PlayerLoopTiming.FixedUpdate;
                case PrepoolTiming.LastFixedUpdate: return PlayerLoopTiming.LastFixedUpdate;
                case PrepoolTiming.PreUpdate: return PlayerLoopTiming.PreUpdate;
                case PrepoolTiming.LastPreUpdate: return PlayerLoopTiming.LastPreUpdate;
                case PrepoolTiming.Update: return PlayerLoopTiming.Update;
                case PrepoolTiming.LastUpdate: return PlayerLoopTiming.LastUpdate;
                case PrepoolTiming.PreLateUpdate: return PlayerLoopTiming.PreLateUpdate;
                case PrepoolTiming.LastPreLateUpdate: return PlayerLoopTiming.LastPreLateUpdate;
                case PrepoolTiming.PostLateUpdate: return PlayerLoopTiming.PostLateUpdate;
                case PrepoolTiming.LastPostLateUpdate: return PlayerLoopTiming.LastPostLateUpdate;
                case PrepoolTiming.TimeUpdate: return PlayerLoopTiming.TimeUpdate;
                case PrepoolTiming.LastTimeUpdate: return PlayerLoopTiming.LastTimeUpdate;
            }

            return PlayerLoopTiming.Update;
        }
    }
}
