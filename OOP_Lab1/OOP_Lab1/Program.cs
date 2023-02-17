namespace Program
{
    class Program
    {
        delegate int IntGetter();
        delegate int AverageGetters(IntGetter[] valueGetter);
        delegate int Average(int a, int b, int c, int d, int e);

        public static void Main()
        {
            var Add = (int a, int b) => a + b;
            var Div = (int a, int b) => a / b;
            var Mul = (int a, int b) => a * b;
            var Sub = (int a, int b) => a - b;
            

            Console.WriteLine(Add(8, 3));
            Console.WriteLine(Sub(2, 1));
            Console.WriteLine(Mul(5, 4));
            Console.WriteLine(Div(25, 5));

            IntGetter getter = () => Random.Shared.Next();

            AverageGetters averageGetters = (items) =>
            {
                var sum = 0;

                foreach (var getter in items)
                {
                    sum += getter();
                }

                return sum / items.Length;
            };

            Average average = (a, b, c, d, e) => (a + b + c + d + e) / 5;

            IntGetter[] getters = { getter, getter, getter, getter, getter };

            Console.WriteLine(averageGetters(getters));
            Console.WriteLine(average(4, 8, 10, 12, 7));
        }
    }
}