using NUnit.Framework;
using NET03_03_1;
using System;

namespace NET03_03_1_BinarySearch_Tests

{
    public class Tests
    {
        [TestCase]
        public void BinarySearch_StringItems()
        {
            var myCollection = new string[] { "bc", "abc", "klm", "fgh" };
            var target = "fgh";
            var collectionOperations = new CollectionOperations();
            var foundPosition = collectionOperations.BinarySearch<string>(myCollection, target);
            Assert.That(foundPosition == 2);
        }

        [TestCase]
        public void BinarySearch_IntItems()
        {
            var myCollection = new int[] { 6, 3, 89, 70 };
            var target = 89;
            var collectionOperations = new CollectionOperations();
            var foundPosition = collectionOperations.BinarySearch<int>(myCollection, target);
            Assert.That(foundPosition == 3);
        }

        [TestCase]
        public void BinarySearch_IntItems_NotFound()
        {
            var myCollection = new int[] { 6, 3, 89, 70 };
            var target = 88;
            var collectionOperations = new CollectionOperations();
            var foundPosition = collectionOperations.BinarySearch<int>(myCollection, target);
            Assert.That(foundPosition == -1);
        }

        [TestCase]
        public void BinarySearch_NotComparable_Exception()
        {
            var myCollection = new A[] { new A(), new A(), new A()};
            var target = new A();
            var collectionOperations = new CollectionOperations();
            //var foundPosition = collectionOperations.BinarySearch<A>(myCollection, target);
            Assert.Throws<Exception>(delegate { collectionOperations.BinarySearch<A>(myCollection, target); });
        }

        public class A { };
    }
}