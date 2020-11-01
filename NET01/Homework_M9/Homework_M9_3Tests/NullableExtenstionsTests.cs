using Homework_M9_3;
using NUnit.Framework;

namespace Homework_M9_3Tests
{
    public class NullableExtenstionsTests
    {
        [Test]
        public void IsNullTests()
        {
            // - для переменной string name = "Kathy" =>  name.IsNull()-- > false
            // - для переменной string name = null    =>  name.IsNull()-- > true
            // - для переменной int? i = null         =>  i.IsNull()-- > true и т.д.

            // arrange
            string name1 = "Kathy";
            string name2 = null;
            int? i = null;

            // act
            var result1 = name1.IsNull();
            var result2 = name2.IsNull();
            var result3 = i.IsNull();

            Assert.That(result1 == false);
            Assert.That(result2 == true);
            Assert.That(result3 == true);
        }
    }
}