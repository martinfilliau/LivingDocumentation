namespace LivingDocumentation.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class EntityAttribute(string friendlyName, string description, Type? parentType = null) : Attribute
{
    public string FriendlyName { get; set; } = friendlyName;
    public string Description { get; set; } = description;
    public Type? ParentType { get; set; }
}