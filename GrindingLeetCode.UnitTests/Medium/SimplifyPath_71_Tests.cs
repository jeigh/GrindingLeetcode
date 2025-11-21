using LeetCodeProblems.CSharp.Stack;
using LeetCodeProblems.CSharp.Unconventional;
using LeetCodeProblems.Interfaces.Medium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class SimplifyPath_71_Tests
    {
        public static IEnumerable<object[]> GetImplementations()
        {
            yield return new object[] { new SimplifyPathCSharpStackSolution_71() };
            yield return new object[] { new SimplifyPathCSharpOptimizedSolution_71() };
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_Example1_ReturnsHome(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/home/";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/home", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_Example2_ReturnsRoot(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/home//foo/";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/home/foo", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_Example3_WithParentDirectory(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/home/user/Documents/../Pictures";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/home/user/Pictures", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_Example4_MultipleParentDirectories(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/../";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_Example5_ComplexPath(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/.../a/../b/c/../d/./";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/.../b/d", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_RootOnly_ReturnsRoot(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_MultipleSlashes_CollapsesToSingleSlash(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "///";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_CurrentDirectoryOnly_ReturnsRoot(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/./";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_ParentDirectoryFromRoot_StaysAtRoot(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/../../../";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_SimpleAbsolutePath_ReturnsSimplified(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a/b/c";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/b/c", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_PathWithCurrentDirectory_RemovesCurrentDirectory(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a/./b/./c";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/b/c", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_PathWithParentDirectory_NavigatesUp(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a/b/../c";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/c", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_MultipleConsecutiveSlashes_CollapsesToSingle(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a//b////c";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/b/c", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_TrailingSlash_RemovedExceptRoot(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a/b/c/";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/b/c", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_ThreeDotsValidDirectory_Preserved(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a/.../b";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/.../b", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_FourDotsValidDirectory_Preserved(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a/..../b";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/..../b", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_MixedCurrentAndParent_SimplifiesCorrectly(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a/./b/../c/./d";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/c/d", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_AllParentDirectories_ReturnsRoot(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a/b/../../..";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_ComplexWithMultipleParents_SimplifiesCorrectly(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a/b/c/../../d";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/d", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_AlternatingDirectoriesAndParents_SimplifiesCorrectly(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a/../a/../a/../a";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_DirectoryNamedDots_PreservedAsValid(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/...";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/...", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_SingleLetterDirectories_Preserved(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a/b/c/d/e/f";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/b/c/d/e/f", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_ParentAtEnd_NavigatesUp(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a/b/c/..";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/b", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_CurrentAtEnd_Removed(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a/b/c/.";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/b/c", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_OnlyCurrentDirectories_ReturnsRoot(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/./././.";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_LongPath_SimplifiesCorrectly(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/home/user/Documents/work/project/../archive/./old/../../current";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/home/user/Documents/work/current", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_DirectoryWithSpecialCharacters_Preserved(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a-b/c_d/e.f";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a-b/c_d/e.f", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_MixedSlashesAndDots_SimplifiesCorrectly(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "//a/./b///../c///";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/c", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_BackToRootThenForward_SimplifiesCorrectly(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a/../../b";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/b", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_NestedParents_SimplifiesCorrectly(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a/b/c/d/../../../e";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/e", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_EmptySegments_IgnoredCorrectly(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/a//b///c////d";
            
            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/b/c/d", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_RealWorldExample_HomeDirectory(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/home/user/../guest/./documents";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/home/guest/documents", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_RealWorldExample_WebPath(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/var/www/html/../../log/./apache";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/var/log/apache", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_DirectoryNamedDotDot_NotParent(ISimplifyPath_71 solution)
        {
            // Arrange - This would be an unusual but valid directory name
            string path = "/a/b/c";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/a/b/c", result);
        }

        [TestMethod]
        [DynamicData(nameof(GetImplementations), DynamicDataSourceType.Method)]
        public void SimplifyPath_OnlyDots_MixedValidAndSpecial(ISimplifyPath_71 solution)
        {
            // Arrange
            string path = "/./.././.../..../";

            // Act
            string result = solution.SimplifyPath(path);

            // Assert
            Assert.AreEqual("/.../....", result);
        }
    }
}