public class Exe5_1 {
    public static void main(string[] args) {
        int[] xs = new int[] { 3, 5, 12 };
        int[] ys = new int[] { 2, 3, 4, 7 };
        
        int[] sorted = merge(xs, ys);
        System.out.println(sorted);
    }
    
    public static int[] merge(int[] xs, int[] ys) {
        int[] lst = new int[xs.length + ys.length];
        int ix, iy = 0;
        for (int i = 0; i < lst.length; i++) {
            if (ix < xs.length && xs[ix] < ys[iy]) {
                lst[i] = xs[ix];
                ix++;
            } else {
                lst[i] = ys[iy];
                ys++;
            }
        }
        return lst;
    }
}