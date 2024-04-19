namespace App.Domain.Core._1_CustomAttributes
{
    public class StringValueAttribute : Attribute
    {
        public string Value { get; }
        public StringValueAttribute(string value)
        {
            Value = value;
        }
    }
}
