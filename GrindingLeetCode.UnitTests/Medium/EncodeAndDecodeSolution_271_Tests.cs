using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GrindingLeetCode.UnitTests.Medium
{
    [TestClass]
    public class EncodeAndDecodeSolution_271_Tests
    {
        private EncodeAndDecodeSolution _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new EncodeAndDecodeSolution();
        }

        [TestMethod]
        public void EncodeDecode_BasicStrings_RoundTrip()
        {
            var input = new List<string> { "hello", "world", "leet", "code" };
            var encoded = _solution.Encode(input);
            var decoded = _solution.Decode(encoded);
            CollectionAssert.AreEqual(input, decoded);
        }

        [TestMethod]
        public void EncodeDecode_EmptyStringElement_RoundTrip()
        {
            var input = new List<string> { "a", "", "b" };
            var encoded = _solution.Encode(input);
            var decoded = _solution.Decode(encoded);
            CollectionAssert.AreEqual(input, decoded);
        }

        [TestMethod]
        public void EncodeDecode_AllEmptyStrings_RoundTrip()
        {
            var input = new List<string> { "", "", "" };
            var encoded = _solution.Encode(input);
            var decoded = _solution.Decode(encoded);
            CollectionAssert.AreEqual(input, decoded);
        }

        [TestMethod]
        public void EncodeDecode_EmptyList_ReturnsNullAndEmptyList()
        {
            var input = new List<string>();
            var encoded = _solution.Encode(input);
            Assert.IsNull(encoded);
            var decoded = _solution.Decode(encoded);
            CollectionAssert.AreEqual(new List<string>(), decoded);
        }

        [TestMethod]
        public void Decode_NullInput_ReturnsEmptyList()
        {
            var decoded = _solution.Decode(null);
            CollectionAssert.AreEqual(new List<string>(), decoded);
        }
    }
}