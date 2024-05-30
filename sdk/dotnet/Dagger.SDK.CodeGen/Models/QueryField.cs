namespace Dagger.SDK.CodeGen.Models;

public class QueryField
{
    public QueryArg[]? Args { get; set; }
    public string? DeprecationReason { get; set; }
    public string? Description { get; set; }
    public bool IsDeprecated { get; set; }
    public string? Name { get; set; }
    public TypeDef? Type { get; set; }
}
