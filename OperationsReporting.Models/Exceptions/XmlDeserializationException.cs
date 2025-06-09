namespace OperationsReporting.Models.Exceptions
{
    public class XmlDeserializationException : Exception
    {
        public XmlDeserializationException() { }

        public XmlDeserializationException(string message)
            : base(message) { }

        public XmlDeserializationException(string message, Exception inner)
            : base(message, inner) { }
    }
}