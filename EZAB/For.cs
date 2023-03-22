namespace EZAB
{
    class Loop
    {
        public static void Do<T>(T start, T end, T step, Action<T> action) where T : IComparable<T>
        {
            if (step.CompareTo(default(T)) == 0)
            {
                throw new ArgumentException("Step cannot be zero.");
            }

            if (start.CompareTo(end) > 0 && step.CompareTo(default(T)) > 0)
            {
                throw new ArgumentException("Step must be negative when start is greater than end.");
            }

            if (start.CompareTo(end) < 0 && step.CompareTo(default(T)) < 0)
            {
                throw new ArgumentException("Step must be positive when start is less than end.");
            }

            for (T i = start; Comparer<T>.Default.Compare(i, end) < 0; dynamicAdd(ref i, step))
            {
                action(i);
            }
        }

        private static void dynamicAdd<T>(ref T value1, T value2)
        {
            dynamic d1 = value1;
            dynamic d2 = value2;

            value1 = d1 + d2;
        }
    }
}