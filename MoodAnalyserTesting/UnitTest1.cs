using NUnit.Framework;
using MoodAnalyser;

namespace MoodAnalyserTesting
{
    public class Tests
    {
        MoodAnalyserClass moodAnalyser;
        [SetUp]
        public void Setup()
        {
            moodAnalyser = new MoodAnalyserClass();
        }

        [Test]
        public void Given_SadMessage_Expecting_Sad()
        {
            string expected = "SAD";
            string output = moodAnalyser.AnalyseMood("I am in Sad Mood");
            Assert.AreEqual(expected, output);
        }


        [Test]
        public void Given_HappyMessage_Expecting_Happy()
        {
            string expected = "HAPPY";
            string output = moodAnalyser.AnalyseMood("I am in Any Mood");
            Assert.AreEqual(expected, output);
        }
    }
}