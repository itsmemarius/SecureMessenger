
using System;
using System.Collections.Generic;

public class RSA_Key_Generator
{
    public static List<int> GeneratePrimesNaive(int n)
    {
        List<int> primes = new List<int>();
        primes.Add(2);
        int nextPrime = 3;
        while (primes.Count < n)
        {
            int sqrt = (int)Math.Sqrt(nextPrime);
            bool isPrime = true;
            for (int i = 0; i < primes.Count && primes[i] <= sqrt; i++)
            {
                if (nextPrime % primes[i] == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                primes.Add(nextPrime);
            }
            nextPrime += 2;
        }
        return primes;
    }

    public static void Main(string[] args)
    {
        int n = 10; // Change this to the desired number of prime numbers you want to generate
        List<int> primeList = GeneratePrimesNaive(n);

        Console.WriteLine("First " + n + " prime numbers:");
        foreach (int prime in primeList)
        {
            Console.Write(prime + " ");
        }
    }
}
