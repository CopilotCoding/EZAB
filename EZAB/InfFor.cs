namespace EZAB
{
    using System.Linq.Expressions;

    /// <summary>
    /// Interface for a customizable for loop.
    /// </summary>
    /// <typeparam name="T">The type of the loop variable.</typeparam>
    interface IFor<T>
    {
        /// <summary>
        /// Executes a customizable for loop.
        /// </summary>
        /// <param name="start">The starting value of the loop variable.</param>
        /// <param name="end">The ending value of the loop variable.</param>
        /// <param name="step">The step size of the loop variable.</param>
        /// <param name="action">The action to perform in each iteration of the loop.</param>
        void Do(T start, T end, T step, Action<T> action);
    }

    /// <summary>
    /// Implementation of a customizable for loop using a standard for loop.
    /// </summary>
    /// <typeparam name="T">The type of the loop variable.</typeparam>
    class InfFor<T> : IFor<T>
    {
        private readonly Func<T, T, T> add;

        public InfFor()
        {
            // Create an expression tree representing addition between two values of type T
            var leftParam = Expression.Parameter(typeof(T), "left");
            var rightParam = Expression.Parameter(typeof(T), "right");
            var addExpr = Expression.AddChecked(leftParam, rightParam);
            var lambdaExpr = Expression.Lambda<Func<T, T, T>>(addExpr, leftParam, rightParam);

            // Compile the expression tree into a delegate that can be used to add two values of type T
            add = lambdaExpr.Compile();
        }

        public void Do(T start, T end, T step, Action<T> action)
        {
            var comparer = Comparer<T>.Default;
            var increment = (dynamic)step;

            for (T i = start; comparer.Compare(i, end) < 0; i = Increment(i, increment))
            {
                action(i);
            }
        }

        private static T Increment<T>(T value, dynamic increment)
        {
            return (T)((dynamic)value + increment);
        }
    }
}