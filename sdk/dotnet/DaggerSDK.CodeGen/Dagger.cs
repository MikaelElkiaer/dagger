using CodegenCS;
using DaggerSDK.CodeGen.Models;

namespace DaggerSDK.CodeGen;

public class Dagger
{
    private readonly string className = $"{nameof(Dagger)}";
    private readonly string classNamespace = "DaggerSDK.Client";
    private readonly ICodegenContext context;

    public Dagger(ICodegenContext context, QuerySchema model)
    {
        if (string.IsNullOrEmpty(context.DefaultOutputFile.RelativePath))
            context.DefaultOutputFile.RelativePath = $"{className}.generated.cs";

        // Allow the following types to be injected into delegates
        context.DependencyContainer.RegisterSingleton(this);
        context.DependencyContainer.RegisterSingleton(model);

        this.context = context;
    }

    public void Template()
    {
        context.DefaultOutputFile.Write($$"""
            using System = global::System;

            namespace {{classNamespace}};

            {{GenerateClass}}
            """);
    }

    Func<ICodegenContext, Dagger, QuerySchema, FormattableString> GenerateClass = (ctx, template, model) => $$"""
        public partial class {{template.className}}
        {

        }
        """;
}
