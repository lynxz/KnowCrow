using KnowCrow.GraphQL.Data;
using KnowCrow.GraphQL.DataLoader;

namespace KnowCrow.GraphQL.Types;

public class ScoreType : ObjectType<Score>
{
    protected override void Configure(IObjectTypeDescriptor<Score> descriptor)
    {
        descriptor
            .ImplementsNode()
            .IdField(t => t.Id)
            .ResolveNode(async (ctx, id) => await ctx.DataLoader<ScoreByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

        descriptor
            .Field(t => t.Subject)
            .Resolve(context => context.Parent<Score>().Subject?.Name)
            .Name("subject");
    }
}