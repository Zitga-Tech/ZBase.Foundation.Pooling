using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using EA = ZBase.Foundation.Pooling.ExceptionArgument;
using ER = ZBase.Foundation.Pooling.ExceptionResource;

namespace ZBase.Foundation.Pooling
{
    public static class ThrowHelper
    {
        public static InvalidCastException GetInvalidCastException<TDest>(Type source)
        {
            return new InvalidCastException($"Cannot cast {source} into {typeof(TDest)}");
        }

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowArgumentNullException(EA argument)
        {
            throw GetArgumentNullException(argument);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowNullReferenceException(EA argument)
        {
            throw GetNullReferenceException(argument);
        }

        public static void ThrowNotSupportedException(ER resource)
        {
            throw new NotSupportedException(GetResourceString(resource));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ArgumentNullException GetArgumentNullException(EA argument)
        {
            return new ArgumentNullException(GetArgumentName(argument));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static NullReferenceException GetNullReferenceException(EA argument)
        {
            return new NullReferenceException(GetArgumentName(argument));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ArgumentOutOfRangeException GetArgumentOutOfRangeException(EA argument, ER resource)
        {
            return new ArgumentOutOfRangeException(GetArgumentName(argument), GetResourceString(resource));
        }

        private static string GetArgumentName(EA argument)
        {
            switch (argument)
            {
                case EA.key: return nameof(EA.key);
                case EA.value: return nameof(EA.value);
                case EA.index: return nameof(EA.index);
                case EA.item: return nameof(EA.item);
                case EA.count: return nameof(EA.count);
                case EA.keys: return nameof(EA.keys);
                case EA.pool: return nameof(EA.pool);
                case EA.output: return nameof(EA.output);
                case EA.prefab: return nameof(EA.prefab);
                case EA._source: return nameof(EA._source);
                case EA.source: return nameof(EA.source);
                case EA.Source: return nameof(EA.Source);
                case EA.assetName: return nameof(EA.assetName);
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
        value,
        keys,
        count,
        index,
        pool,
        output,
        prefab,
        _source,
        source,
        Source,
        assetName
    }

    public enum ExceptionResource
    {
        ArgOutOfRange_NeedNonNegNum,
        ArgOutOfRange_Count,
    }
}
