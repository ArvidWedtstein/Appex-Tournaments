using Autofac;
using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: TestFramework("Tournament.Tests.ConfigureTestFramework", "Tournament.Tests")]

namespace Tournament.Tests
{
    public class ConfigureTestFramework : AutofacTestFramework
    {
        public ConfigureTestFramework(IMessageSink diagnosticMessageSink)
            : base(diagnosticMessageSink)
        {
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            // builder.RegisterType<CurrentTestInfo>().AsSelf().InstancePerTest();
            // builder.RegisterType<CurrentTheoryInfo>().AsSelf().InstancePerTheory();
            // builder.RegisterType<CurrentTestClassInfo>().AsSelf().InstancePerTestClass();
            // builder.RegisterType<CurrentTestCollectionInfo>().AsSelf().InstancePerTestCollection();

            builder.RegisterSource(new NSubstituteRegistrationSource()); // https://gist.github.com/dabide/57c5279894383d8f0ee4ed2069773907

            // builder.RegisterType<Foo>().As<IFoo>();

            // configure your container
            // e.g. builder.RegisterModule<TestOverrideModule>();
        }
    }
}