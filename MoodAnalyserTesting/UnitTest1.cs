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
            object obj = MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass");
            expected.Equals(obj);
        }
        [Test]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterisedConstructor()
        {
            object expected = new MoodAnalyserClass("Happy");
            object obj = MoodAnalyserReflector.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass","Happy");
            expected.Equals(obj);
        }

        [Test]
        public void GivenHappyMood_ShouldReturnHappy()
        {
            object expected = "HAPPY";
            string mood = MoodAnalyserReflector.InvokeAnalyseMethod("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }

        [Test]
        //7.1
        public void GivenHappyMessage_WithReflector_ShouldReturnHappy()
        {
            string result = MoodAnalyserReflector.SetField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }
        [Test]
        //7.2
        public void GivenHappyMessage_WithImproperFieldReflector_ShouldThrowException()
        {
            Assert.Throws<MoodAnalysisException>(()=>MoodAnalyserReflector.SetField("HAPPY", "message2"));
        }
        [Test]
        //7.3
        public void GivenNullMessage_usingFieldReflector_ShouldReturnHappy()
        {
            Assert.Throws<MoodAnalysisException>(() => MoodAnalyserReflector.SetField(string.Empty, "message2"));    
        }
    }
}