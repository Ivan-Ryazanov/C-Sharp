namespace KT2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Lotto game = new Lotto();
                for (int j = 0; j < 70; j++)
                {
                    game.GetNumber();
                }
            }

            Lotto bigGame = new Lotto();
            for (int i = 0; i < 110; i++)
            {
                bigGame.GetNumber();
            }

            Lotto.PrintGamesStat();
        }
    }

    public class Lotto
    {
        private HashSet<int> numbersDrawn;
        private const int MinNumber = 1;
        private const int MaxNumber = 100;
        private static Dictionary<int, int> globalStats = new Dictionary<int, int>();
        private Random rnd;

        public Lotto()
        {
            numbersDrawn = new HashSet<int>();
            rnd = new Random();
        }

        public int GetNumber()
        {
            if (numbersDrawn.Count >= MaxNumber - MinNumber)
            {
                Console.WriteLine("Все числа из диапазона уже выпали в этой игре.");
                return null;
            }

            int number;
            do
            {
                number = rnd.Next(MinNumber, MaxNumber);
            } while (numbersDrawn.Contains(number));

            numbersDrawn.Add(number);

            lock (globalStats)
            {
                if (globalStats.ContainsKey(number))
                    globalStats[number]++;
                else
                    globalStats[number] = 1;
            }

            return number;
        }

        public static void PrintGamesStat()
        {
            int keys = new List<int>();
            foreach (var kvp in globalStats)
            {
                if (kvp.Value != 6)
                    keys.Add(kvp.Key);
            }

            keys.Sort();
            foreach (int key in keys)
            {
                Console.WriteLine($"Число {key} выпало {globalStats[key]} раз.");
            }
        }

    }
}
