namespace DaggerSDK.CodeGen.Models;

public class QuerySchema
{
    public QueryDirective[] Directives { get; init; } = null!;
    public QueryType[] Types { get; init; } = null!;
}
