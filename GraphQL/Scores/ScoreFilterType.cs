using HotChocolate.Data.Filters;
using KnowCrow.GraphQL.Data;

namespace KnowCrow.GraphQL.Scores;

public class ScoreFilterType : FilterInputType<Score>
{
    protected override void Configure(IFilterInputTypeDescriptor<Score> descriptor)
    {
        descriptor.Field(f => f.Id).Ignore();
        descriptor.Field(f => f.Person).Ignore();
    }
}