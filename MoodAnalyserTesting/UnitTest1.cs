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
        //1.1
        public void Given_SadMessage_Expecting_Sad()
        {
            string expected = "SAD";
            moodAnalyser = new MoodAnalyserClass("I am in Sad Mood");
            string output = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, output);
        }


        [Test]
        //1.2
        public void Given_HappyMessage_Expecting_Happy()
        {
            string expected = "HAPPY";
            moodAnalyser = new MoodAnalyserClass("I am in Any Mood");
            string output = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, output);
        }

        [Test]
        //2.1
        public void Given_null_Expecting_ErrorMessage()
        {
            string expected = "Null value was passed!";
            moodAnalyser = new MoodAnalyserClass(null);
            string output = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, output);
        }


        [Test]
        //3.1
        public void Given_empty_Expecting_ErrorMessage()
        {
            string expected = "Empty value was passed!";
            moodAnalyser = new MoodAnalyserClass("");
            string output = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, output);
        }
        //4.1
        [Test]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            object expected = new MoodAnalyserClass();
            object obj = MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass");
            object obj2 = MoodAnalyserReflector.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass");
            expected.Equals(obj);
            expected.Equals(obj2);
        }
        //4.2
        [Test]
        public void GivenMoodAnalyseImproperClassName_ShouldReturnException()
        {
           Assert.Throws<MoodAnalysisException>(() => MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyser.MoodAnalyserClass2", "MoodAnalyserClass"));
        }

        //4.3
        [Test]
        public void GivenMoodAnalyseImproperConstructorName_ShouldReturnException()
        {
            Assert.Throws<MoodAnalysisException>(() => MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass2"));
        }

        //5.1
        [Test]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterisedConstructor()
        {
            object expected = new MoodAnalyserClass("Happy");
            object obj = MoodAnalyserReflector.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass","Happy");
            expected.Equals(obj);
        }

        //5.2
        [Test]
        public void GivenMoodAnalyseImproperClassName_UsingParameterisedConstructor_ShouldReturnException()
        {
            Assert.Throws<MoodAnalysisException>(() => MoodAnalyserReflector.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyser.MoodAnalyserClass2", "MoodAnalyserClass","Happy"));
        }


        //5.3
        [Test]
        public void GivenMoodAnalyseImproperConstructor_UsingParameterisedConstructor_ShouldReturnException()
        {
            Assert.Throws<MoodAnalysisException>(() => MoodAnalyserReflector.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass2", "Happy"));
        }


        //6.1
        [Test]
        public void GivenHappyMood_ShouldReturnHappy()
        {
            object expected = "HAPPY";
            string mood = MoodAnalyserReflector.InvokeAnalyseMethod("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }


        //6.2
        [Test]
        public void GivenWrongMethod_ShouldThrowException()
        {
            Assert.Throws<MoodAnalysisException>(() => MoodAnalyserReflector.InvokeAnalyseMethod("Happy", "AnalyseMood2"));
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
        public void GivenNullMessage_usingFieldReflector_ShouldReturnException()
        {
          MoodAnalysisException ex = Assert.Throws<MoodAnalysisException>(() => MoodAnalyserReflector.SetField(null, "message"));
          Assert.AreEqual(ex.Message, "Message should not be null");
          Assert.AreEqual(ex.type, MoodAnalysisException.ExceptionType.ENTERED_NULL);
        }
    }
}