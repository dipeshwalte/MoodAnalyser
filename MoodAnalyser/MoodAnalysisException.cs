﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    /// <summary>
    /// Custom exception class for mood analysis
    /// </summary>
    /// <seealso cref="System.Exception" />
    class MoodAnalysisException : Exception
    {
        ExceptionType type;
        public enum ExceptionType {
        ENTERED_NULL,ENTERED_EMPTY
        }
        public MoodAnalysisException()
        { 

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalysisException"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="name">The name.</param>
        public MoodAnalysisException(ExceptionType type,string name) : base(name)
        {
            this.type = type;
        }
    }
}
