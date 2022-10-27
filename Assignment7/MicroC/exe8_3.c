void main(int n)
{
    int arr[4];
    arr[0] = 0;
    arr[1] = 1;
    arr[2] = 2;
    arr[3] = 3;

    ++arr[++n];

    print n;
    print arr[n];
    println;
}