using KnowCrow.GraphQL.Data;

namespace KnowCrow.GraphQL.Subjects;

[ExtendObjectType("Subscription")]
public class SubjectSubscriptions
{
    [Subscribe]
    public Subject SubjectAdded([EventMessage] Subject subject) => subject;

    [Subscribe]
    [Topic("SubjectDeletion")]
    public Subject SubjectRemoved([EventMessage] Subject subject) => subject;
}
