void main(int n){
    int arr[7];
    arr[0] = 1;
    arr[1] = 2;
    arr[2] = 1;
    arr[3] = 1;
    arr[4] = 1;
    arr[5] = 2;
    arr[6] = 0;
    int freq[4];
    freq[0] = 0;
    freq[1] = 0;
    freq[2] = 0;
    freq[3] = 0;
    histogram(n, arr, 3, freq);
    
    println;
    print freq[0];
    print freq[1];
    print freq[2];
    print freq[3];
}
//if array is too small, compiler will execute exception of key  not found


// when done --> 
// 1. dublicate the file
// 2. rename to exe7_3iii.c
// 3. change while-loops to for-loops
void histogram(int n, int ns[], int max, int freq[])
{
    int i;
    i = 0;
    while (i < n)
    {
        int x;
        x = ns[i];
        freq[x] = freq[x] + 1;
        i = i + 1;
    }
}