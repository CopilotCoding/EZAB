namespace EZAB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DynamicExamples.RunDynamicExamples();
        }
    }

    public class DynamicExamples
    {
        public static void RunDynamicExamples()
        {
            dynamic input = new Dynamic(123);

            input.FirstName = "John";

            Console.WriteLine(input.FirstName);

            input.LastName = "Doe";

            Console.WriteLine(input.LastName);

            input.Age = 30; // Will not call TryConvert()

            Console.WriteLine(input.Age);

            input.PrintMethodInvocation("SomeMethod", new object[] { "arg1", "arg2" });

            input.SomeProperty = "Hello World!";

            var propertyValue = input.SomeProperty;

            Console.WriteLine(propertyValue);
        }
    }

    public class GetNextExamples
    {
        public static void RunGetNextExamples()
        {
            int start = 0;
            int end = 100000;
            int step = 1;

            GetNext.Nxt(end);
            // GetNext.Nxt(start, end, step);
        }
    }

    public class CustomForLoopExamples
    {
        public static void RunForExamples()
        {
            // Loop from int.MinValue to int.MaxValue by steps of 100001
            Loop.Do(int.MinValue, int.MaxValue, 100001L, i => Console.WriteLine(i));

            // Loop from 0 to 10 by steps of 2
            Loop.Do(0L, 10L, 2L, i => Console.WriteLine(i));

            // Loop from -5.5 to +5.5 by steps of 1.25
            Loop.Do(-5.5M, 5.5M, 1.25M, i => Console.WriteLine(i));
        }

        public class InfiniteCustomForLoopExamples
        {
            public static void RunInfForExamples()
            {
                // Example usage of IFor with int
                var loop = new InfFor<int>();
                loop.Do(int.MinValue, int.MaxValue, 100001, i => Console.WriteLine(i));

                // Example usage of IFor with double
                // var loopX2 = new For<double>();
                // loopX2.Do(double.MinValue, double.MaxValue, 0.1, d => Console.WriteLine(d));
                // Example usage of IFor with BigInteger
                // var loopBig = new For<BigInteger>();
                // loopBig.Do(0, 1, BigInteger.NextHighestPrime(BigInteger.GeneratePseudoPrime(10000)), big => Console.WriteLine(big));
            }
        }
    }
}