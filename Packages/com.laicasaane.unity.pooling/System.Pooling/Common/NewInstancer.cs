namespace System.Pooling
{
    public static class NewInstancer<T> where T : new()
    {
        public static T Instantiate() => new T();
    }
}
