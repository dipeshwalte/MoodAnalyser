using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserClass
    {
        public string AnalyseMood(string message)
        {
            if (message.ToUpper().Contains("SAD"))
            {
                return "SAD";
            }
            return "HAPPY";
        }
    }
}
