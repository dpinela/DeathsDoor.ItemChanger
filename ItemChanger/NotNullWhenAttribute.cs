// Targeting an older framework requires us to provide our own version of this.
namespace System.Diagnostics.CodeAnalysis;

internal class NotNullWhenAttribute : System.Attribute
{
    public bool ReturnValue { get; }

    public NotNullWhenAttribute(bool val)
    {
        ReturnValue = val;
    }
}