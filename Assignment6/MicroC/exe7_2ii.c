void main(int n)
{
    int arr[20];
    squares(n, arr);

    int sum;
    arrsum(n, arr, &sum);
    print sum;
    println;
}

void squares(int n, int arr[])
{
    n = n - 1;
    while (n >= 0)
    {
        arr[n] = n * n;
        n = n - 1;
    }
}

void arrsum(int n, int arr[], int *sump)
{
    n = n - 1;
    int sum;
    sum = 0;
    
    while (n >= 0)
    {
        sum = sum + arr[n];
        n = n - 1;
    }
    
    *sump = sum;
}