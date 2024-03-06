internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Article> list = new List<Article>();

        for (int i = 0; i < n; i++)
        {
                string[] text = Console.ReadLine()
            .Split(", ")
            .ToArray();

            Article article = new Article();

            article.Title = text[0];
            article.Content = text[1];
            article.Author = text[2];

            list.Add(article);
        }
        foreach (Article article in list) 
        {
            Console.WriteLine(article);
        }
    }
}
public class Article
{
    public string Title;
    public string Content;
    public string Author;

    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}
