using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac.Core;
using Autofac.Core.Activators.Delegate;
using Autofac.Core.Lifetime;
using Autofac.Core.Registration;
using NSubstitute;

public class NSubstituteRegistrationSource : IRegistrationSource
{
    private readonly Func<Type, bool> _filter;

    public NSubstituteRegistrationSource(Func<Type, bool> filter = null)
    {
        _filter = filter ?? (_ => true);
    }

    /// <inheritdoc />
    public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<ServiceRegistration>> registrationAccessor)
    {
        if (registrationAccessor == null)
        {
            throw new ArgumentNullException(nameof(registrationAccessor));
        }

        TypedService ts = service as TypedService;
        if (ts == null || ts.ServiceType == typeof(string) || _filter?.Invoke(ts.ServiceType) != true)
        {
            return Enumerable.Empty<IComponentRegistration>();
        }

        TypeInfo typeInfo = ts.ServiceType.GetTypeInfo();
        if (typeInfo.IsSubclassOf(typeof(Delegate)) ||
            typeInfo.IsGenericTypeDefinition ||
            registrationAccessor(service).Any())
        {
            return Enumerable.Empty<IComponentRegistration>();
        }

        ComponentRegistration registration = new(
            Guid.NewGuid(),
            new DelegateActivator(ts.ServiceType, (_, _) => Substitute.For(new[] { ts.ServiceType }, new object[] { })),
            new CurrentScopeLifetime(),
            InstanceSharing.Shared,
            InstanceOwnership.OwnedByLifetimeScope,
            new[] { service },
            new Dictionary<string, object>());

        return new IComponentRegistration[] { registration };
    }

    /// <inheritdoc />
    public bool IsAdapterForIndividualComponents => false;

    /// <summary>
    ///     Returns a <see cref="System.String" /> that represents the current <see cref="System.Object" />.
    /// </summary>
    /// <returns>
    ///     A <see cref="System.String" /> that represents the current <see cref="System.Object" />.
    /// </returns>
    /// <filterpriority>2</filterpriority>
    public override string ToString()
    {
        return "A registration source that returns NSubstitute substitutes for unregistered types";
    }
}
