// Collatz Conjecture
public static int Collatz(float n, int count=1)
{
    if (n == 1)
        return count;

    if (n % 2 == 0)
        return Thing(n/2, count+1);

    return Thing((n*3)+1, count+1);
}
