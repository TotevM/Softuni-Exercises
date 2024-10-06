using System;
using System.Collections.Generic;

namespace WordCruncher
{
    public class Program
    {
        public static string target;
        private static Dictionary<int, List<string>> wordsByIdx;
        private static Dictionary<string, int> wordsCount;
        private static LinkedList<string> usedWords;

        public static void Main()
        {
            var words = Console.ReadLine().Split(", ");
            target = Console.ReadLine();

            wordsByIdx = new Dictionary<int, List<string>>();
            wordsCount = new Dictionary<string, int>();
            usedWords = new LinkedList<string>();

            foreach (var word in words)
            {
                var idx = target.IndexOf(word);

                if (idx == -1)
                {
                    continue;
                }

                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word] += 1;
                }
                else
                {
                    wordsCount[word] = 1;
                }

                while (idx != -1)
                {
                    if (!wordsByIdx.ContainsKey(idx))
                    {
                        wordsByIdx[idx] = new List<string>();
                    }

                    wordsByIdx[idx].Add(word);

                    idx = target.IndexOf(word, idx + 1);
                }
            }

            GenSolutions(0);
        }

        private static void GenSolutions(int ind)
        {
            if (ind == target.Length)
            {
                Console.WriteLine(string.Join(" ", usedWords));
                return;
            }

            if (!wordsByIdx.ContainsKey(ind))
            {
                return;
            }

            foreach (var word in wordsByIdx[ind])
            {
                if (wordsCount[word] == 0)
                {
                    continue;
                }

                wordsCount[word] -= 1;
                usedWords.AddLast(word);

                GenSolutions(ind + word.Length);

                wordsCount[word] += 1;
                usedWords.RemoveLast();
            }
        }
    }
}
