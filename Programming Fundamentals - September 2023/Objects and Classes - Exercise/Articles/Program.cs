    internal class Program
    {
        static void Main(string[] args)
        {
        string[] text = Console.ReadLine()
            .Split(", ")
            .ToArray();
        int n = int.Parse(Console.ReadLine());


        Article article = new Article();

        article.Title = text[0];
        article.Content = text[1];
        article.Author = text[2];

        for (int i = 0; i < n; i++)
        {
            string[] command= Console.ReadLine().Split(": ");
            
            switch (command[0]) 
            {
                case "Edit":
                    article.ChangeContent(command[1]);
                    break;
                case "ChangeAuthor":
                    article.ChangeAuthor(command[1]);
                    break;
                case "Rename":
                    article.ChangeTitle(command[1]);
                    break;
            }
        }
        Console.WriteLine(article);
        }
    }
public class Article
{
    public string Title;
    public string Content;
    public string Author;

    public void ChangeTitle(string newTitle)
    {
        Title = newTitle;
    }
    public void ChangeContent(string newContent)
    {
        Content = newContent;
    }
    public void ChangeAuthor(string newAuthor)
    {
        Author = newAuthor;
    }
    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}
