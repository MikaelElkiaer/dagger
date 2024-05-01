namespace Dagger.SDK.CodeGen.Models;

public class TypeDef
{
    public string? Kind { get; set; }
    public string? Name { get; set; }
    public TypeDef? OfType { get; set; }
}
