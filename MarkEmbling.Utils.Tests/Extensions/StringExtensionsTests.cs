using System;
using MarkEmbling.Utils.Extensions;
using NUnit.Framework;

namespace MarkEmbling.Utils.Tests.Extensions {
    [TestFixture]
    public class StringExtensionsTests {
        [Test]
        public void Different_case_strings_are_equal() {
            const string upperVersion = "MARKEMBLING.INFO";
            const string lowerVersion = "markembling.info";

            Assert.IsTrue(upperVersion.EqualsWithoutCase(lowerVersion));
        }

        [Test]
        public void Non_matching_strings_are_not_equal() {
            const string foo = "Foo";
            const string bar = "Bar";

            Assert.IsFalse(foo.EqualsWithoutCase(bar));
        }

        [Test]
        public void Null_and_a_string_instance_are_not_equal() {
            const string foo = "Foo";
            const string bar = null;

            Assert.IsFalse(foo.EqualsWithoutCase(bar));
        }

        [Test]
         public void First_returns_first_5_characters() {
            const string testString = "1234567890";
            var result = testString.First(5);
            Assert.AreEqual("12345", result);
        }

        [Test]
        public void First_returns_first_character() {
            const string testString = "1234567890";
            var result = testString.First();
            Assert.AreEqual("1", result);
        }

        [Test]
        public void First_throws_on_shorter_string_than_character_count() {
            const string testString = "12345";
            Assert.Throws<ArgumentOutOfRangeException>(
                () => testString.First(8));
        }

        [Test]
        public void Last_returns_last_5_characters() {
            const string testString = "1234567890";
            var result = testString.Last(5);
            Assert.AreEqual("67890", result);
        }

        [Test]
        public void Last_returns_last_character() {
            const string testString = "1234567890";
            var result = testString.Last();
            Assert.AreEqual("0", result);
        }

        [Test]
        public void Last_throws_on_shorter_string_than_character_count() {
            const string testString = "12345";
            Assert.Throws<ArgumentOutOfRangeException>(
                () => testString.Last(8));
        }
    }
}