// Collatz Conjecture
//    If the number is even, divide it by two.
//    If the number is odd, triple it and add one.
//
//    The conjecture is that these sequences always reach 1, no matter which positive integer is chosen to start the sequence. 
public static int Collatz(float n, int count=1)
{
    if (n == 1)
        return count;

    if (n % 2 == 0)
        return Thing(n/2, count+1);

    return Thing((n*3)+1, count+1);
}
