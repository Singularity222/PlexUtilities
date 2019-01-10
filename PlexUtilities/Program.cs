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
            var directories = Directory.GetDirectories(BasePath);

            foreach (var directory in directories)
            {
                if (!MoviePath.ContainsPosterImage(directory))
                {
                    Console.WriteLine(directory);
                }
            }

            //foreach (var directory in directories)
            //{
            //    var images = GetImages(directory);
            //    foreach (var image in images)
            //    {
            //        Console.WriteLine(image);
            //    }
            //}

            //foreach (var directory in directories)
            //{
            //    if (MoviePath.HasImagesNotNamedPoster(directory))
            //    {
            //        Console.WriteLine(directory);
            //    }
            //}

            //foreach (var directory in directories)
            //{
            //    if (HasMultiplePosterImages(directory))
            //    {
            //        Console.WriteLine(directory);
            //    }
            //}
        }
    }

    public static class MoviePath
    {
        /// <summary>
        /// Given a directory this method returns the names
        /// of all the image files (without file extension)
        /// found in the directory.
        /// </summary>
        /// <param name="directory">The directory to search for image files.</param>
        /// <returns>An array of image file names.</returns>
        public static string[] GetImages(string directory)
        {
            var files = Directory.GetFiles(directory);

            var imagePaths = new[] { ".jpg", ".png" };

            // Filter out files that don't have the specified extension and return just the file name without extension:
            var imageFileNames = files.Where(file => imagePaths.Contains(Path.GetExtension(file))).Select(Path.GetFileNameWithoutExtension);

            return imageFileNames.ToArray();
        }

        /// <summary>
        /// Determines whether a poster image exists within a specified directory.
        /// </summary>
        /// <param name="directory">The directory to check for a poster image.</param>
        /// <returns>A boolean value indicating whether the directory had a poster image.</returns>
        public static bool ContainsPosterImage(string directory)
        {
            var imageFileNames = GetImages(directory);

            return imageFileNames.Any(file => file.Contains("poster"));
        }

        public static bool HasImagesNotNamedPoster(string directory)
        {
            var imageFileNames = GetImages(directory);

            var result = imageFileNames.Any(image => image != "poster" && image != "poster-1");

            return result;
        }

        public static bool HasMultiplePosterImages(string directory)
        {
            var imageFileNames = GetImages(directory);

            var filesThatContainTheSubstringPoster = imageFileNames.Where(image => image.Contains("poster")).ToList();

            return filesThatContainTheSubstringPoster.Count > 1;
        }
    }
}