namespace Unity.Pooling
{
    public static class NameOf<T>
    {
        public static readonly string Value;

        static NameOf()
        {
            Value = typeof(T).Name;
        }
    }
}
