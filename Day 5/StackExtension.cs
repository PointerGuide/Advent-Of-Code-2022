using System.Runtime.CompilerServices;

namespace Day_5
{
    public static class StackExtension
    {
        public static void MoveTo<T>(this Stack<T> from, Stack<T> to, int count)
        {
            for (int i = 0; i < count; i++)
                to.Push(from.Pop());
        }
        public static void TryMoveTo<T>(this Stack<T> from, Stack<T> to, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (from.TryPop(out T result))
                    to.Push(result);
            }
        }

        public static void MoveAsStackTo<T>(this Stack<T> from, Stack<T> to, int count)
        {
            Stack<T> temp = new Stack<T>(count);
            from.MoveTo(temp, count);
            temp.MoveTo(to, count);
        }
    }
}
