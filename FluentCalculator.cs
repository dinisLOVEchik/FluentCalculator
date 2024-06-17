namespace Calculator
{
    public class FluentCalculator
    {
        private readonly List<int> values = new List<int>();
        private readonly List<string> operations = new List<string>();
        private bool waitingForOperation = true;

        private static Dictionary<string, int> valueMap = new Dictionary<string, int>
        {
            {"zero", 0}, {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4},
            {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9},
            {"ten", 10}
        };

        public FluentCalculator() { }

        public FluentCalculator Value(string value)
        {
            if (!waitingForOperation)
            {
                throw new Exception("Invalid method call sequence");
            }
            waitingForOperation = false;
            values.Add(valueMap[value]);
            return this;
        }

        public FluentCalculator Operation(string operation)
        {
            if (waitingForOperation)
            {
                throw new Exception("Invalid method call sequence");
            }
            waitingForOperation = true;
            operations.Add(operation);
            return this;
        }

        public decimal Result()
        {
            decimal result = values[0];
            for (int i = 0; i < operations.Count; i++)
            {
                switch (operations[i])
                {
                    case "plus":
                        result += values[i + 1];
                        break;
                    case "minus":
                        result -= values[i + 1];
                        break;
                    case "times":
                        result *= values[i + 1];
                        break;
                    case "dividedBy":
                        result /= values[i + 1];
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }
            }
            return result;
        }
    }
}
