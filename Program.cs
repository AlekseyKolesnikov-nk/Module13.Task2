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

        // Группируем элементы по словам
        var res = words.GroupBy(x => x)
            // Из 156 тысяч слов текста не рассматриваем упоминающиеся менее 100 раз
            .Where(x => x.Count() > 1) 
                .Select(x => new { Word = x.Key, Frequency = x.Count() });

        foreach (var item in res)
        {
            if (item.Frequency > 1)
            {
                dictionary.Add(item.Word, item.Frequency);
            }
        }

        var numWords = dictionary.OrderByDescending(n => n.Value).Take(10);
        int i = 1;
        foreach (var item in numWords)
        {
            Console.WriteLine($"{i}.Слово \"{item.Key}\" \tвстречается в тексте {item.Value} раз");
            i++;
        }
    }
}