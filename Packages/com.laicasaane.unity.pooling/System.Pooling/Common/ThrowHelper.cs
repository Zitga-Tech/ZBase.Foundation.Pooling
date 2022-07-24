using System.Diagnostics;
using System.Runtime.CompilerServices;

using EA = System.Pooling.ExceptionArgument;
using ER = System.Pooling.ExceptionResource;

namespace System.Pooling
{
    public static class ThrowHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowCountArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum()
        {
            throw GetArgumentOutOfRangeException(EA.count, ER.ArgOutOfRange_NeedNonNegNum);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count()
        {
            throw GetArgumentOutOfRangeException(EA.count, ER.ArgOutOfRange_Count);
        }

        private static ArgumentNullException GetArgumentNullException(EA argument)
        {
            return new ArgumentNullException(GetArgumentName(argument));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowArgumentNullException(EA argument)
        {
            throw GetArgumentNullException(argument);
        }

        public static void ThrowNotSupportedException(ER resource)
        {
            throw new NotSupportedException(GetResourceString(resource));
        }

        private static ArgumentOutOfRangeException GetArgumentOutOfRangeException(EA argument, ER resource)
        {
            return new ArgumentOutOfRangeException(GetArgumentName(argument), GetResourceString(resource));
        }

        private static string GetArgumentName(EA argument)
        {
            switch (argument)
            {
                case EA.key: return nameof(EA.key);
                case EA.index: return nameof(EA.index);
                case EA.item: return nameof(EA.item);
                case EA.count: return nameof(EA.count);
                case EA.keys: return nameof(EA.keys);
                case EA.pool: return nameof(EA.pool);
                case EA.output: return nameof(EA.output);
                case EA.prefab: return nameof(EA.prefab);
                case EA.source: return nameof(EA.source);
            }

            Debug.Fail("The enum value is not defined, please check the ExceptionArgument Enum.");
            return argument.ToString();
        }

        private static string GetResourceString(ER resource)
        {
            switch (resource)
            {
                case ER.ArgOutOfRange_Count:
                    return "Argument 'count' was out of the range of valid values.";

                case ER.ArgOutOfRange_NeedNonNegNum:
                    return "The number must be non-negative.";
            }

            Debug.Assert(false, "The enum value is not defined, please check the ExceptionResource Enum.");
            return resource.ToString();
        }
    }

    public enum ExceptionArgument
    {
        item,
        key,
        keys,
        count,
        index,
        pool,
        output,
        prefab,
        source,
    }

    public enum ExceptionResource
    {
        ArgOutOfRange_NeedNonNegNum,
        ArgOutOfRange_Count,
    }
}
