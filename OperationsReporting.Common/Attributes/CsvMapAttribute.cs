namespace OperationsReporting.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class CsvMapAttribute : Attribute
    {
        public Type MapType { get; }

        public CsvMapAttribute(Type mapType)
        {
            MapType = mapType;
        }
    }
}