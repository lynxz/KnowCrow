using HotChocolate.Types.Descriptors;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace KnowCrow.GraphQL.Attributes
{
    public class UseToUpperAttribute : ObjectFieldDescriptorAttribute
    {
        public UseToUpperAttribute([CallerLineNumber] int order = 0)
        {
            Order = order;
        }

        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseToUpper();
        }
    }
}
