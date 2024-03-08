using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int operationsCount = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();
            Stack<string> undoStack = new Stack<string>();

            for (int i = 0; i < operationsCount; i++)
            {
                string[] commandInfo = Console.ReadLine().Split();

                switch (int.Parse(commandInfo[0]))
                {
                    case 1:
                        string textToAppend = commandInfo[1];
                        undoStack.Push(text.ToString());
                        text.Append(textToAppend);
                        break;

                    case 2:
                        int elementsToErase = int.Parse(commandInfo[1]);
                        undoStack.Push(text.ToString());
                        text.Remove(text.Length - elementsToErase, elementsToErase);
                        break;

                    case 3:
                        int index = int.Parse(commandInfo[1]);
                        Console.WriteLine(text[index - 1]);
                        break;

                    case 4:
                        if (undoStack.Count > 0)
                        {
                            text.Clear();
                            text.Append(undoStack.Pop());
                        }
                        break;
                }
            }
        }
    }
}
