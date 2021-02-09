using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    /// <summary>
    /// Create MoodAnalyseMethod to create object of MoodAnalyse Class.
    /// </summary>
    public class MoodAnalyserReflector
    {
        /// <summary>
        /// Creates the mood analyse.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalysisException">
        /// Class Not found
        /// or
        /// Constructor is Not found
        /// </exception>
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {

                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "Class Not found");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "Constructor is Not found");
            }
            
        }
        /// <summary>
        /// Creates the mood analyse using parameterized constructor.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalysisException">
        /// Constructor Not found
        /// or
        /// Class is Not found
        /// </exception>
        public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string constructorName,string message)
        {
            Type type = typeof(MoodAnalyserClass);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if(type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else 
                {

                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "Constructor Not found");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "Class is Not found");
            }

        }
        /// <summary>
        /// Invokes the analyse method.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalysisException">Method is Not found</exception>
        public static string InvokeAnalyseMethod(string message, string methodName)
        {
             try
                {
                Type type = Type.GetType("MoodAnalyser.MoodAnalyserClass");
                object moodAnalyseObject = MoodAnalyserReflector.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mood = methodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
                }
             catch (NullReferenceException)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "Method is Not found");
                }
         }
        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalysisException">
        /// Message should not be null
        /// or
        /// Field is not Found
        /// </exception>
        public static string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyserClass moodAnalyser = new MoodAnalyserClass();
                Type type = typeof(MoodAnalyserClass);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "Message should not be null");
                }
                field.SetValue(moodAnalyser, message);
                return moodAnalyser.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD,"Field is not Found");
            }
        }
    }
}
