using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserClass
    {
        string message;
        public MoodAnalyserClass()
        {
            this.message = "I am so Happy!";
        }
        public MoodAnalyserClass(string message)
        {
            this.message = message;
        }

        public string AnalyseMood()
        {
            if (this.message.ToUpper().Contains("SAD"))
            {
                return "SAD";
            }
            return "HAPPY";
        }
    }
}
