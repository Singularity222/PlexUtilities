using System;
using System.IO;
using System.Linq;

namespace PlexUtilities
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string BasePath = @"\\typhon\f\Cleaned Movies\";
            string[] directories = Directory.GetDirectories(BasePath);

            foreach (string directory in directories)
            {
                if (!ContainsPosterImage(directory))
                {
                    Console.WriteLine(directory);
                }
            }
        }

        public static bool ContainsPosterImage(string directory)
        {
            string[] files = Directory.GetFiles(directory);

            return files.Any(file => file.Contains("poster"));
        }
    }
}