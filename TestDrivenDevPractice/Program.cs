namespace TestDrivenDevPractice;

public static class StringExtensions
{
    public static int WordCount(this string str)
    {
        return str.Split(new char[] { ' ', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}

public static class IntExtensions
{
    public enum Digits
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9
    }

    public enum Teens
    {
        Ten = 0,
        Eleven = 1,
        Twelve = 2,
        Thirteen = 3,
        Fourteen = 4,
        Fifteen = 5,
        Sixteen = 6,
        Seventeen = 7,
        Eighteen = 8,
        Nineteen = 9
    }

    public enum Tens
    {
        Ten = 1,
        Twenty = 2,
        Thirty = 3,
        Fourty = 4,
        Fifty = 5,
        Sixty = 6,
        Seventy = 7,
        Eighty = 8,
        Ninety = 9
    }

    // Chunking algorithm,
    // modified from original algorithm:
    // https://www.techtalk7.com/split-list-into-sublists-with-linq/#comment-19041
    public static IEnumerable<List<T>> Chunk<T>(IEnumerable<T> source, int chunksize)
    {
        var list = source.Reverse().ToList();
        List<List<T>> result = new List<List<T>>();
        List<T> chunk = new List<T>();

        int count = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (i > 0 && i % chunksize == 0)
            {
                result.Insert(count / chunksize, chunk);
                count += chunksize;
                chunk = new List<T>();
            }
            chunk = chunk.Prepend(list.ElementAt(i)).ToList();
        }
        return result.Prepend(chunk).ToList();
    }

    public static string ToCardinal(this int num)
    {
        var result = "";

        if (Math.Abs(num) > 999)
            return "Too big!";

        var absValChars = Math.Abs(num).ToString();

        var chunks = Chunk(absValChars, 3);
        for (int k = 0; k < chunks.Count(); ++k)
        {
            bool finished = false;

            for (int i = chunks.ElementAt(k).Count, j = 0; i > 0 && !finished; i--, ++j)
            {
                int x = int.Parse(chunks.ElementAt(k)[j].ToString());
                switch (i)
                {
                    case 3:
                        if ((Digits)x == Digits.Zero)
                            finished = true;
                        else
                            result += ((Digits)x).ToString() + " Hundred ";
                        break;
                    case 2:
                        if ((Digits)x == Digits.Zero)
                            finished = true;
                        else if (x < 2)
                        {
                            var teen = int.Parse(chunks.ElementAt(k)[j + 1].ToString());
                            result += ((Teens)teen).ToString() + " ";
                            finished = true;
                        }
                        else if (x < 10)
                            result += ((Tens)x).ToString() + " ";
                        break;
                    case 1:
                        if (chunks.ElementAt(k).Count > 1 && (Digits)x == Digits.Zero)
                            finished = true;
                        else
                            result += ((Digits)x).ToString() + " ";
                        break;
                }
            }
        }

        if (num < 0)
            result = "Negative " + result;

        return result.Trim();
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Practice time: Test Driven Development (TDD) with NUnit and XUnit");
    }
}
