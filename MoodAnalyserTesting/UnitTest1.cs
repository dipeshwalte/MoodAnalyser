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

        [Test]
        public void Given_null_Expecting_ErrorMessage()
        {
            string expected = "Null value was passed!";
            moodAnalyser = new MoodAnalyserClass(null);
            string output = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, output);
        }


        [Test]
        public void Given_empty_Expecting_ErrorMessage()
        {
            string expected = "Empty value was passed!";
            moodAnalyser = new MoodAnalyserClass("");
            string output = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            object expected = new MoodAnalyserClass();
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass");
            expected.Equals(obj);
        }

    }
}