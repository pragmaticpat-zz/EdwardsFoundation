using System;
using System.Runtime.Serialization;

namespace JoanCEdwards.ExamLibrary
{
    /// <summary>
    /// An Exception that will be thrown in the event a bad configuration is detected. This bad configuration
    /// can be in a Template or the actual configuraiton files.
    /// </summary>
    [Serializable()]
    public class ConfigurationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PnDotNetConfigurationException"/> class.
        /// </summary>
        public ConfigurationException()
            : base("ConfigurationException: There is an error with the configuration." )
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PnDotNetConfigurationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ConfigurationException(string message)
            : base("ConfigurationException: " + message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PnDotNetConfigurationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innnerException">The innner exception.</param>
        public ConfigurationException(string message, Exception innnerException)
            : base("ConfigurationException: " + message, innnerException)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PnDotNetConfigurationException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        public ConfigurationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
