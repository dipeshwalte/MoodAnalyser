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
            
        }

        [Test]
        public void Given_SadMessage_Expecting_Sad()
        {
            string expected = "SAD";
            moodAnalyser = new MoodAnalyserClass("I am in Sad Mood");
            string output = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, output);
        }


        [Test]
        public void Given_HappyMessage_Expecting_Happy()
        {
            string expected = "HAPPY";
            moodAnalyser = new MoodAnalyserClass("I am in Any Mood");
            string output = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, output);
        }
    }
}