void main(int n)
{
    int x;
    x = 42;
    
    switch (n < 4 ? 1 : 0)
    {
    case 1:
        { x = 69; }
    case 3:
        { print 8; }
    }
    
    print x;
    println;
}