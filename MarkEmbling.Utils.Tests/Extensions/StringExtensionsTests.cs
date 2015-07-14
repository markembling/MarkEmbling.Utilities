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

        [Test]
        public void Truncate_shortens_a_long_string_to_target_length() {
            const string testString = "One two three four five.";
            var result = testString.Truncate(10);
            Assert.AreEqual(10, result.Length);
        }

        [Test]
        public void Truncate_returns_same_string_if_target_is_longer_than_string() {
            const string testString = "One two.";
            var result = testString.Truncate(10);
            Assert.AreEqual("One two.", result);
        }

        [Test]
        public void Truncate_can_append_suffix_if_provided_and_stay_within_character_limit() {
            const string testString = "One two three four five.";
            var result = testString.Truncate(10, "...");

            Assert.AreEqual(10, result.Length);
            Assert.AreEqual("One two...", result);
        }

        [Test]
        public void Truncate_does_not_add_suffix_if_string_is_shorter_than_target() {
            const string testString = "One two three four five.";
            var result = testString.Truncate(30, "...");

            Assert.AreEqual(testString, result);
        }

        [Test]
        public void Truncate_ignores_suffix_if_suffix_is_longer_than_limit() {
            const string testString = "One two three four five.";
            var result = testString.Truncate(6, "XXXXXXXXXX");

            Assert.AreEqual(6, result.Length);
            Assert.AreEqual("One tw", result);
        }

        [Test]
        public void Truncate_ignores_suffix_if_suffix_is_same_length_as_limit() {
            const string testString = "One two three four five.";
            var result = testString.Truncate(6, "XXXXXX");

            Assert.AreEqual(6, result.Length);
            Assert.AreEqual("One tw", result);
        }

        [Test]
        public void TruncateOnSpace_truncates_on_last_space_before_limit() {
            const string testString = "One two three four five.";
            var result = testString.TruncateOnWhitespace(12);
            Assert.AreEqual(7, result.Length);
        }

        [Test]
        public void TruncateOnWhitespace_cuts_off_word_if_no_whitespace_found() {
            const string testString = "Onetwothreefourfive.";
            var result = testString.TruncateOnWhitespace(8);

            Assert.AreEqual(8, result.Length);
            Assert.AreEqual("Onetwoth", result);
        }

        [Test]
        public void TruncateOnWhitespace_can_append_suffix_if_provided_and_stay_within_character_limit() {
            const string testString = "One two three four five.";
            var result = testString.TruncateOnWhitespace(12, "...");

            Assert.AreEqual(10, result.Length);
            Assert.AreEqual("One two...", result);
        }

        [Test]
        public void TruncatOnWhitespace_does_not_add_suffix_if_string_is_shorter_than_target() {
            const string testString = "One two three four five.";
            var result = testString.TruncateOnWhitespace(30, "...");

            Assert.AreEqual(testString, result);
        }

        [Test]
        public void TruncateOnWhitespace_ignores_suffix_if_suffix_is_longer_than_limit() {
            const string testString = "One two three four five.";
            var result = testString.TruncateOnWhitespace(6, "XXXXXXXXXX");

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("One", result);
        }

        [Test]
        public void TruncateOnWhitespace_ignores_suffix_if_suffix_is_same_length_as_limit() {
            const string testString = "One two three four five.";
            var result = testString.TruncateOnWhitespace(6, "XXXXXX");

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("One", result);
        }
    }
}