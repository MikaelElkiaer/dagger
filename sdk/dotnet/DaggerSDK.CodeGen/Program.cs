using DaggerSDK.GraphQL.Client;
using DaggerSDK.CodeGen;
using DaggerSDK.CodeGen.Models;
using System.Runtime.CompilerServices;
using System.Text.Json;

var opt = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true,
};

var client = new GraphQLClient();
var resp = await client.RequestAsync(IntrospectionQuery.Query);

var body = await resp.Content.ReadAsStringAsync();
var doc = JsonDocument.Parse(body);
var schema = doc.RootElement.GetProperty("data").GetProperty("__schema");

var model = JsonSerializer.Deserialize<QuerySchema>(schema, opt) ?? throw new Exception("Failed to deserialize directives");

Console.WriteLine("Writing introspect-api.json");
File.WriteAllText("introspect-api.json", JsonSerializer.Serialize(schema, opt));

Console.WriteLine("Writing introspect-resparsedult.json");
File.WriteAllText("introspect-parsed.json", JsonSerializer.Serialize(model, opt));

Console.WriteLine("Directives extracted: {0}", model.Directives.Count());
Console.WriteLine("Types extracted: {0}", model.Types.Count());
