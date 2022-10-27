void main(int n)
{
    int i;
    i = 2;
    int arr[4];
    arr[0] = 0;
    arr[1] = 1;
    arr[2] = 2;
    arr[3] = 3;

    ++(arr[++i]);

    print i;
    print arr[i];
    println;
}