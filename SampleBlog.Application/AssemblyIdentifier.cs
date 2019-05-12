using System.Reflection;
namespace SampleBlog.Application
{
    public static class AssemblyIdentifier
    {
        public static Assembly Get() =>
            typeof(AssemblyIdentifier).GetTypeInfo().Assembly;
    }
}
