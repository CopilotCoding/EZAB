namespace EZAB
{
    using System;

    public class GetNext
    {
        public static object Nxt(object current)
        {
            dynamic value = current;

            value++;

            return value;
        }

        public static void Nxt(object current, object end, object step)
        {
            dynamic value = current;
            dynamic stop = end;
            dynamic increment = step;

            while (value < stop)
            {
                Console.WriteLine(value);
                value += increment;
            }
        }
    }
}
