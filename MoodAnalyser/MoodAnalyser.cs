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
            try
            {
                if (this.message == null)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.ENTERED_NULL, "Null value was passed!");
                }
                else if (this.message == string.Empty)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.ENTERED_EMPTY, "Empty value was passed!");
                }
                else if (this.message.ToUpper().Contains("SAD"))
                {
                    return "SAD";
                }
                return "HAPPY";
            }
            catch(MoodAnalysisException ex) 
            {
                return ex.Message;
            }
            
        }
    }
}
