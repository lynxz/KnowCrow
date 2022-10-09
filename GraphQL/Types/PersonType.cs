using KnowCrow.GraphQL.Data;
using KnowCrow.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace KnowCrow.GraphQL.Types;

public class PersonType : ObjectType<Person>
{
    protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
    {
        descriptor
            .ImplementsNode()
            .IdField(t => t.Id)
            .ResolveNode(async (ctx, id) => await ctx.DataLoader<PersonByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
    }
}