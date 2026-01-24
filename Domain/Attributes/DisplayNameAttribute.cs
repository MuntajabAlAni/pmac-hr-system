namespace Domain.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class DisplayNameAttribute(string name) : Attribute
{
    public string Name { get; } = name;
}