// Task 3
// Create Polynomial class for working with polynomials of degree n > 0 of one real variable(as an internal structure for 
// storing coefficients use the sz - array).Override the necessary methods of the System.Object Type and also overload 
// base operations for working with polynomials. Develop unit-tests.
//
// Tests are based on article: https://saylordotorg.github.io/text_intermediate-algebra/s04-06-polynomials-and-their-operatio.html


namespace NET_02_Task01_03
{
    using System;
    using System.Collections;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET-02 Task01 - 02. Geometric shapes classes.\n");

            var A = new Polynomial(6, 13, -9, -1, 6); // 111
            var B = new Polynomial(3, 2);

            // check methods
            var C = A.Sum(B);
            var D = C.Subtract(B);
            var E = A.Multiply(B);
            var F = A.Divide(B);
            var G = A.DivisionRemainder(B);
            Polynomial remainder;
            var H = A.DivisionRemainder(B, out remainder);

            Console.WriteLine($"Polynomial A: {A}");
            Console.WriteLine($"Polynomial B: {B}");
            Console.WriteLine($"Polynomial C = A + B: {C}"); // Sum
            Console.WriteLine($"Polynomial D = C - B: {D}"); // Subtraction
            Console.WriteLine($"Polynomial E = A*B: {E}"); // Multiplication
            Console.WriteLine($"Polynomial F = A/B: {F}"); // Division without remainder
            Console.WriteLine($"Polynomial G = A%B: {G}"); // Division remainder
            Console.WriteLine($"Polynomial H = A%B: {H}, remainder: {remainder}"); // Division result and remainder

            // check operators
            C = A + B;
            D = C - B;
            E = A * B;
            F = A / B;
            G = A % B;
            H = A.DivisionRemainder(B, out remainder);

            Console.WriteLine($"Polynomial A: {A}");
            Console.WriteLine($"Polynomial B: {B}");
            Console.WriteLine($"Polynomial C = A + B: {C}"); // Sum
            Console.WriteLine($"Polynomial D = C - B: {D}"); // Subtraction
            Console.WriteLine($"Polynomial E = A*B: {E}"); // Multiplication
            Console.WriteLine($"Polynomial F = A/B: {F}"); // Division without remainder
            Console.WriteLine($"Polynomial G = A%B: {G}"); // Division remainder
            Console.WriteLine($"Polynomial H = A%B: {H}, remainder: {remainder}"); // Division result and remainder
        }

    }
}


/* TO DO
1. Add method A.DivisionRemainder(B) = A % B - remainder is already there, just uncomment and check
1.1. Add A.DivisionRemainder(B, out remainder)

2. Add unit tests with results from the link (see above)

3. Profit.
*/