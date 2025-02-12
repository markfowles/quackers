﻿using System.Collections.Generic;
using System.Threading;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;
using static PeanutButter.RandomGenerators.RandomValueGen;

namespace QuackersTestHost
{
    [TestFixture]
    public class SomeTests
    {
        [Test]
        public void ShouldPass()
        {
            // Arrange
            // Act
            Expect(true)
                .To.Be.True();
            // Assert
        }

        [Test]
        public void ShouldFail()
        {
            // Arrange
            // Act
            Expect(true)
                .To.Be.False();
            // Assert
        }

        public static IEnumerable<int> SleepGenerator()
        {
            yield return 1;
            yield return 100;
            yield return 500;
            yield return 1500;
            yield return 1234;
        }

        [TestCaseSource(nameof(SleepGenerator))]
        public void LongerPasses(int sleepMs)
        {
            // Arrange
            Thread.Sleep(sleepMs);
            // Act
            Expect(true)
                .To.Be.True();
            // Assert
        }

        public static IEnumerable<int> MakeSomeNumbers()
        {
            for (var i = 0; i < 3; i++)
            {
                yield return GetRandomInt(1, 100);
            }
        }

        [TestCaseSource(nameof(MakeSomeNumbers))]
        public void ShouldBeLessThan50(int value)
        {
            // Arrange
            // Act
            Expect(value)
                .To.Be.Less.Than(50);
            // Assert
        }

        [Test]
        [Ignore("skipped because...")]
        public void SkippyTesty()
        {
            // Arrange
            // Act
            Expect(1)
                .To.Equal(2);
            // Assert
        }
    }
}
