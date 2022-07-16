namespace System.Pooling
{
    public static class DefaultInstantiator<T> where T : class
    {
        private static readonly Type s_type = typeof(T);
        private static Func<T> s_default = Instantiate;

        private static T Instantiate() => (T)Activator.CreateInstance(s_type);

        public static void Set(Func<T> instantiator)
            => s_default = instantiator ?? throw new ArgumentNullException(nameof(instantiator));

        public static Func<T> Get()
            => s_default ?? Instantiate;
    }
}
