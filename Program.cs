namespace Module13.Task2;

class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        string[] words;

        string path = "C:/Users/kolesnikov_aa/Desktop/УЧЕБА_Скиллфактори/Text1.txt";

        using (var streamreader = new StreamReader(path))
        {
            var text = streamreader.ReadToEnd().ToLower();
            text = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            char[] delimiters = new char[] { ' ', '\r', '\n' };
            words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        var res = words.GroupBy(x => x)
            .Where(x => x.Count() > 100)    // Рассматриваем слова, упоминающиеся более 100 раз
            .Select(x => new { Word = x.Key, Frequency = x.Count() });

        foreach (var item in res)
        {
            if (item.Frequency > 100)
            {
                dictionary.Add(item.Word, item.Frequency);
            }
        }

        Console.WriteLine("10 слов, встречающихся в тексте чаще всего:\n");

        var numberWords = dictionary.OrderByDescending(n => n.Value).Take(10);
        int i = 1;
        foreach (var item in numberWords)
        {
            var digit = Convert.ToString(item.Value);
            var lastDigit = digit.Substring(digit.Length - 1);
            if (lastDigit == "2" || lastDigit == "3" || lastDigit == "4")
            {
                Console.WriteLine($"{i}.Слово\"{item.Key}\" \t - {item.Value} раза;");
            }
            else
            {
                Console.WriteLine($"{i}.Слово\"{item.Key}\" \t - {item.Value} раз;");
            }
            i++;
        }
    }
}