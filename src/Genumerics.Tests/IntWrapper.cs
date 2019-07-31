﻿using System;
using System.Globalization;

#if BIG_INTEGER
using System.Numerics;
#endif

namespace Genumerics.Tests
{
    public struct IntWrapper
    {
        public int Value { get; }

        public IntWrapper(int value)
        {
            Value = value;
        }

        public static implicit operator IntWrapper(int value) => new IntWrapper(value);

        public static implicit operator int(IntWrapper value) => value.Value;
    }

    public struct IntWrapperOperations : INumericOperations<IntWrapper>
    {
        public IntWrapper Zero => Number<int>.Operations.Zero;

        public IntWrapper One => Number<int>.Operations.One;

        public IntWrapper MinusOne => Number<int>.Operations.MinusOne;

        public IntWrapper MaxValue => Number<int>.Operations.MaxValue;

        public IntWrapper MinValue => Number<int>.Operations.MinValue;

        public TypeCode TypeCode => Number<int>.Operations.TypeCode;

        public IntWrapper Abs(IntWrapper value) => Number<int>.Operations.Abs(value);
        public IntWrapper Add(IntWrapper left, IntWrapper right) => Number<int>.Operations.Add(left, right);
        public IntWrapper And(IntWrapper left, IntWrapper right) => Number<int>.Operations.And(left, right);
        public IntWrapper Ceiling(IntWrapper value) => Number<int>.Operations.Ceiling(value);
        public IntWrapper Clamp(IntWrapper value, IntWrapper min, IntWrapper max) => Number<int>.Operations.Clamp(value, min, max);
        public int Compare(IntWrapper left, IntWrapper right) => Number<int>.Operations.Compare(left, right);
        public IntWrapper Convert<TFrom>(TFrom value) => Number<int>.Operations.Convert(value);
        public IntWrapper Divide(IntWrapper dividend, IntWrapper divisor) => Number<int>.Operations.Divide(dividend, divisor);
        public bool Equals(IntWrapper left, IntWrapper right) => Number<int>.Operations.Equals(left, right);
        public IntWrapper Floor(IntWrapper value) => Number<int>.Operations.Floor(value);
        public bool GreaterThan(IntWrapper left, IntWrapper right) => Number<int>.Operations.GreaterThan(left, right);
        public bool GreaterThanOrEquals(IntWrapper left, IntWrapper right) => Number<int>.Operations.GreaterThanOrEquals(left, right);
        public bool IsEven(IntWrapper value) => Number<int>.Operations.IsEven(value);
        public bool IsOdd(IntWrapper value) => Number<int>.Operations.IsOdd(value);
        public bool IsPowerOfTwo(IntWrapper value) => Number<int>.Operations.IsPowerOfTwo(value);
        public IntWrapper LeftShift(IntWrapper value, int shift) => Number<int>.Operations.LeftShift(value, shift);
        public bool LessThan(IntWrapper left, IntWrapper right) => Number<int>.Operations.LessThan(left, right);
        public bool LessThanOrEquals(IntWrapper left, IntWrapper right) => Number<int>.Operations.LessThanOrEquals(left, right);
        public IntWrapper Max(IntWrapper left, IntWrapper right) => Number<int>.Operations.Max(left, right);
        public IntWrapper Min(IntWrapper left, IntWrapper right) => Number<int>.Operations.Min(left, right);
        public IntWrapper Multiply(IntWrapper left, IntWrapper right) => Number<int>.Operations.Multiply(left, right);
        public IntWrapper Negate(IntWrapper value) => Number<int>.Operations.Negate(value);
        public IntWrapper Not(IntWrapper value) => Number<int>.Operations.Not(value);
        public bool NotEquals(IntWrapper left, IntWrapper right) => Number<int>.Operations.NotEquals(left, right);
        public IntWrapper Or(IntWrapper left, IntWrapper right) => Number<int>.Operations.Or(left, right);
        public IntWrapper Parse(string value, NumberStyles? style, IFormatProvider provider) => Number<int>.Operations.Parse(value, style, provider);
#if SPAN
        public IntWrapper Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider) => Number<int>.Operations.Parse(value, style, provider);
#endif
        public IntWrapper Remainder(IntWrapper dividend, IntWrapper divisor) => Number<int>.Operations.Remainder(dividend, divisor);
        public IntWrapper RightShift(IntWrapper value, int shift) => Number<int>.Operations.RightShift(value, shift);
        public IntWrapper Round(IntWrapper value, int digits, MidpointRounding mode) => Number<int>.Operations.Round(value, digits, mode);
        public int Sign(IntWrapper value) => Number<int>.Operations.Sign(value);
        public IntWrapper Subtract(IntWrapper left, IntWrapper right) => Number<int>.Operations.Subtract(left, right);
#if BIG_INTEGER
        public BigInteger ToBigInteger(IntWrapper value) => Number<int>.Operations.ToBigInteger(value);
#endif
        public byte ToByte(IntWrapper value) => Number<int>.Operations.ToByte(value);
        public decimal ToDecimal(IntWrapper value) => Number<int>.Operations.ToDecimal(value);
        public double ToDouble(IntWrapper value) => Number<int>.Operations.ToDouble(value);
        public short ToInt16(IntWrapper value) => Number<int>.Operations.ToInt16(value);
        public int ToInt32(IntWrapper value) => Number<int>.Operations.ToInt32(value);
        public long ToInt64(IntWrapper value) => Number<int>.Operations.ToInt64(value);
        public sbyte ToSByte(IntWrapper value) => Number<int>.Operations.ToSByte(value);
        public float ToSingle(IntWrapper value) => Number<int>.Operations.ToSingle(value);
        public string ToString(IntWrapper value, string format, IFormatProvider provider) => Number<int>.Operations.ToString(value, format, provider);
        public ushort ToUInt16(IntWrapper value) => Number<int>.Operations.ToUInt16(value);
        public uint ToUInt32(IntWrapper value) => Number<int>.Operations.ToUInt32(value);
        public ulong ToUInt64(IntWrapper value) => Number<int>.Operations.ToUInt64(value);
        public IntWrapper Truncate(IntWrapper value) => Number<int>.Operations.Truncate(value);
        public bool TryParse(string value, NumberStyles? style, IFormatProvider provider, out IntWrapper result)
        {
            var success = Number<int>.Operations.TryParse(value, style, provider, out var intResult);
            result = intResult;
            return success;
        }
#if SPAN
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider, out IntWrapper result)
        {
            var success = Number<int>.Operations.TryParse(value, style, provider, out var intResult);
            result = intResult;
            return success;
        }
#endif
        public IntWrapper Xor(IntWrapper left, IntWrapper right) => Number<int>.Operations.Xor(left, right);
    }
}