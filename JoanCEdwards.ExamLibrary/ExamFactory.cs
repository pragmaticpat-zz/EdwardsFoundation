using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace JoanCEdwards.ExamLibrary
{
    /// <summary>
    /// Factory For Retrieving Exams
    /// </summary>
    public class ExamFactory
    {
        /// <summary>
        /// Gets the exam.
        /// </summary>
        /// <param name="examName">Name of the exam.</param>
        /// <returns></returns>
        public static Exam GetExam(string examName)
        {
            try
            {
                Exam value = null;
                XmlSerializer ser = new XmlSerializer(typeof(Exam));
                using (System.IO.FileStream stream = System.IO.File.Open(GetExamPath(examName), System.IO.FileMode.Open))
                {
                    value = (Exam)ser.Deserialize(stream);
                }
                return value;

            }
            catch (System.Runtime.Serialization.SerializationException se)
            {
                throw new ConfigurationException("XML File cannot be serialized", se);
            }
            catch (System.IO.IOException ioe)
            {
                throw new ConfigurationException("The system cannot open the exam", ioe);
            }
        }

        /// <summary>
        /// Gets the exam path.
        /// </summary>
        /// <param name="examName">Name of the exam.</param>
        /// <returns></returns>
        private static string GetExamPath(string examName)
        {
            return string.Format(@"C:\dev.net\JoanCEdwards\JoanCEdwards.ExamLibrary\{0}.xml", examName);
        }
        
        
    }
}
