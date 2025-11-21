using LeetCodeProblems.Interfaces.Medium;
using System.Text;

namespace LeetCodeProblems.CSharp.Unconventional
{
    public class SimplifyPathCSharpOptimizedSolution_71 : ISimplifyPath_71
    {
        // I cannot take credit for this solution...   I saw it on leetcode as the fastest algorithm, recognized that it did not use a stack, and thought it was noteworthy.
        // if anything, it should compel the reader to recognize that just because
        // it's easier to think of an algorithm with a specific DS in mind, it's not always going to be the fastest solution.
        public string SimplifyPath(string path)
        {
            var output = new StringBuilder();
            output.Append(path[0]); 

            var index = 0;
            var previousIndex = index;

            while ((index = path.IndexOf('/', previousIndex + 1)) != -1)
            {
                var betweenSlashes = path.AsSpan(previousIndex + 1, index - previousIndex);

                ProcessSegment(output, betweenSlashes);

                previousIndex = index;
            }

            var lastPart = path.AsSpan(previousIndex + 1, path.Length - previousIndex - 1);
            ProcessLastSegment(output, lastPart);
                        
            if (output.Length > 1 && output[output.Length - 1] == '/')
                output.Length--;

            return output.ToString();
        }

        private static void ProcessSegment(StringBuilder output, ReadOnlySpan<char> segment)
        {
            if (IsEmptyOrSingleSlash(segment)) return;
            if (IsCurrentDirectory(segment)) return;            
            if (IsParentDirectory(segment))
            {
                NavigateToParentDirectory(output);
                return;
            }

            output.Append(segment);
        }

        private static void ProcessLastSegment(StringBuilder output, ReadOnlySpan<char> lastPart)
        {
            if (lastPart.Length == 0) return;
            if (lastPart.Length == 1 && (lastPart[0] == '.' || lastPart[0] == '/')) return;

            if (IsParentDirectoryExact(lastPart))
            {
                NavigateToParentDirectory(output);
                return;
            }

            output.Append(lastPart);
        }

        private static bool IsEmptyOrSingleSlash(ReadOnlySpan<char> segment) => 
            segment.Length > 0 && segment[0] == '/';

        private static bool IsCurrentDirectory(ReadOnlySpan<char> segment) => 
            segment.Length == 2 &&
            segment[0] == '.' &&
            segment[1] == '/';

        private static bool IsParentDirectory(ReadOnlySpan<char> segment)
        {
            // Check for "../" pattern (with trailing slash)
            bool hasTrailingSlash = segment.Length == 3 && 
                                    segment[0] == '.' && 
                                    segment[1] == '.' && 
                                    segment[2] == '/';

            // Check for ".." pattern (without trailing slash)
            bool withoutSlash = segment.Length == 2 && 
                               segment[0] == '.' && 
                               segment[1] == '.';

            return hasTrailingSlash || withoutSlash;
        }

        private static bool IsParentDirectoryExact(ReadOnlySpan<char> segment) =>
            segment.Length == 2 &&
            segment[0] == '.' &&
            segment[1] == '.';

        private static void NavigateToParentDirectory(StringBuilder output)
        {
            if (output.Length <= 1) return;

            output.Length--;

            while (output.Length > 0 && output[output.Length - 1] != '/')
            {
                output.Length--;
            }
        }
    }
}
