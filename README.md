# Genumerics
Genumerics is a high-performance .NET library for generic numeric operations. It is compatible with .NET Framework 4.5+ and .NET Standard 2.0+.

## The Problem
You may have come across while working in .NET where you would like to perform numeric operations over a generic numeric type. Unfortunately .NET doesn't provide a way to do that natively.

This library fills that gap by providing most standard numeric operations for the following built-in numeric types and their nullable equivalents with the ability to add support for other numeric types.

`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, `decimal`, and `BigInteger`

## Genumerics Demo
Below is a demo of some basic uses of Genumerics in the form of unit tests.
```c#
using Genumerics;
using NUnit.Framework;

public class GenumericsDemo
{
    [TestCase(4, 5, 9)]
    [TestCase(2.25, 6.75, 9.0)]
    public void Add<T>(T left, T right, T expected)
    {
        Assert.AreEqual(expected, Number.Add(left, right));
        Assert.AreEqual(expected, AddWithOperator<T>(left, right));
    }

    private T AddWithOperator<T>(Number<T> left, Number<T> right) => left + right;

    [TestCase(9, 6, true)]
    [TestCase(3.56, 4.07, false)]
    public void GreaterThan<T>(T left, T right, bool expected)
    {
        Assert.AreEqual(expected, Number.GreaterThan(left, right));
        Assert.AreEqual(expected, GreaterThanWithOperator<T>(left, right));
    }

    private bool GreaterThanWithOperator<T>(Number<T> left, Number<T> right) => left > right;

    [TestCase(4, 4.0)]
    [TestCase(27.0, 27)]
    public void Convert<TFrom, TTo>(TFrom value, TTo expected)
    {
        Assert.AreEqual(expected, Number.Convert<TFrom, TTo>(value));
        Assert.AreEqual(expected, Number.Create(value).To<TTo>());
    }

    [TestCase("98765", 98765)]
    [TestCase("12.3456789", 12.3456789)]
    public void Parse<T>(string value, T expected)
    {
        Assert.AreEqual(expected, Number.Parse<T>(value));
    }

    [TestCase(123, null, "123")]
    [TestCase(255, "X", "FF")]
    public void ToString<T>(T value, string format, string expected)
    {
        Assert.AreEqual(expected, Number.ToString(value, format));
    }

    [TestCase(sbyte.MaxValue)]
    [TestCase(float.MaxValue)]
    public void MaxValue<T>(T expected)
    {
        Assert.AreEqual(expected, Number.MaxValue<T>());
    }
}
```

## Performance Comparison
The summation algorithms below were benchmarked in .NET Core to determine the relative performance of the library compared with an `int` specific algorithm. As can be seen in the results, the performance is equivalent when using the numeric operations as a `struct` interface generic type argument constraint but is almost an order of magnitude slower when only using the numeric type due to the interface method dispatch. In order to reach performance parity with the `int` specific algorithm the library makes use of an optimization for `struct` interface generic type argument constraints described in this [generic calculations article](https://www.codeproject.com/articles/8531/using-generics-for-calculations) that prevents the interface method dispatch.

### Results
|     Method |       Mean |     Error |     StdDev | Ratio | RatioSD |
|----------- |-----------:|----------:|-----------:|------:|--------:|
|        Sum |   419.9 ns |  1.120 ns |  0.8746 ns |  1.00 |    0.00 |
|  SumNumber | 3,906.8 ns | 67.803 ns | 60.1055 ns |  9.34 |    0.13 |
| SumNumber2 |   571.8 ns |  1.802 ns |  1.6852 ns |  1.36 |    0.01 |
|     SumAdd | 3,962.1 ns | 38.933 ns | 36.4176 ns |  9.46 |    0.04 |
|    SumAdd2 |   418.4 ns |  3.095 ns |  2.8952 ns |  1.00 |    0.00 |

### Code
```c#
using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Genumerics;

public class Program
{
    static void Main() => BenchmarkRunner.Run<SumBenchmarks<int, DefaultNumericOperations>>();
}

public class SumBenchmarks<T, TNumericOperations>
    where TNumericOperations : struct, INumericOperations<T>
{
    private int[] _intItems;
    private T[] _items;

    [Benchmark(Baseline = true)]
    public int Sum()
    {
        int sum = 0;
        foreach (int item in _intItems)
        {
            sum += item;
        }
        return sum;
    }

    [Benchmark]
    public T SumNumber()
    {
        Number<T> sum = default;
        foreach (T item in _items)
        {
            sum += item;
        }
        return sum;
    }

    [Benchmark]
    public T SumNumber2()
    {
        Number<T, TNumericOperations> sum = default;
        foreach (T item in _items)
        {
            sum += item;
        }
        return sum;
    }

    [Benchmark]
    public T SumAdd()
    {
        T sum = default;
        foreach (T item in _items)
        {
            sum = Number.Add(sum, item);
        }
        return sum;
    }

    [Benchmark]
    public T SumAdd2()
    {
        T sum = default;
        TNumericOperations operations = default;
        foreach (T item in _items)
        {
            sum = operations.Add(sum, item);
        }
        return sum;
    }

    [GlobalSetup]
    public void Setup()
    {
        _intItems = new int[1000];
        _items = new T[1000];
        Random rand = new Random();
        for (int i = 0; i < 1000; ++i)
        {
            int value = rand.Next(10);
            _intItems[i] = value;
            _items[i] = Number.Create(value).To<T>();
        }
    }
}
```
