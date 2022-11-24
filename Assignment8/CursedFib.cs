namespace Assignment8;

using System;

public class CursedFib
{
    private readonly int _value;
    private readonly int _index;

    public static void Main(String[] args)
    {
        Console.WriteLine("\nPress return to continue...");
        Console.In.Read();

        var target = 50;
        var fib = new CursedFib(0, target);
        var foundFib = FindFib(fib);
        Console.WriteLine(foundFib._value);
    }
    
    private CursedFib(int value, int index)
    {
        this._value = value;
        this._index = index;
    }

    private CursedFib Merge(CursedFib that)
    {
        var sum = this._value + that._value;
        int newIndex;
        if (this._index > that._index) newIndex = this._index;
        else newIndex = that._index;
        newIndex++;
        return new CursedFib(sum, newIndex);
    }

    private static CursedFib FindFib(CursedFib fib)
    {
        var fibI = fib._index;
        if (fibI <= 0) return new CursedFib(0, 0);
        if (fibI <= 1 || fibI <= 2) return new CursedFib(1, fibI);
        
        var fib1 = new CursedFib(0, fib._index - 1);
        var fib2 = new CursedFib(0, fib._index - 2);

        var found1 = FindFib(fib1);
        var found2 = FindFib(fib2);
        
        return found1.Merge(found2);
    }
}