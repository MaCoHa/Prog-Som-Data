using System;

public class Exe5_1 {
    public static void Main(string[] args) {
        int[] xs = new int[] { 3, 5, 12 };
        int[] ys = new int[] { 2, 3, 4, 7 };
        
        int[] sorted = Merge(xs, ys);

        PrintLists(xs, ys, sorted);
    }
    
    public static int[] Merge(int[] xs, int[] ys) {
        int[] lst = new int[xs.Length + ys.Length];
        int ix = 0;
        int iy = 0;
        for (int i = 0; i < lst.Length; i++) {
            if ((ix < xs.Length - 1 && xs[ix] < ys[iy]) || iy >= ys.Length) {
                lst[i] = xs[ix];
                ix++;
            } else
            {
                lst[i] = ys[iy];
                iy++;
            }
        }
        return lst;
    }

    public static void PrintLists(int[] xs, int[] ys, int[] sorted)
    {
        Console.Write("Merge(");
        Console.Write("[{0}]", string.Join(", ", xs));
        Console.Write(", ");
        Console.Write("[{0}]", string.Join(", ", ys));
        Console.WriteLine(") =>");
        Console.WriteLine("[{0}]", string.Join(", ", sorted));
    }
}