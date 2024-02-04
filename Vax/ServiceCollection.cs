﻿namespace Vax;

public class ServiceCollection : List<ServiceDescriptor>
{
    public ServiceCollection AddService(ServiceDescriptor serviceDescriptor)
    {
        Add(serviceDescriptor);
        return this;
    }

    public ServiceCollection AddSingleton<TService>(Func<ServiceProvider, TService> factory)
    where TService : class
    {
        var serviceDescriptor = new ServiceDescriptor
        {
            ServiceType = typeof(TService),
            ImplementationType = typeof(TService),
            ImplementationFactory = factory,
            Lifetime = ServiceLifetime.Singleton
        };
        
        Add(serviceDescriptor);

        return this;
    }
    
    public ServiceCollection AddSingleton(object implementation)
    {
        var serviceType = implementation.GetType();
        var serviceDescriptor = new ServiceDescriptor
        {
            ServiceType = serviceType,
            ImplementationType = serviceType,
            Implementation = implementation,
            Lifetime = ServiceLifetime.Singleton
        };
        
        Add(serviceDescriptor);

        return this;
    }
    
    public ServiceCollection AddSingleton<TService>()
        where TService : class
    {
        var serviceDescriptor = AddServiceDescriptorWithLifetime<TService, TService>(ServiceLifetime.Singleton);

        Add(serviceDescriptor);

        return this;
    }
    
    public ServiceCollection AddSingleton<TService, TImplementation>()
        where TService : class
        where TImplementation : class, TService
    {
        var serviceDescriptor = AddServiceDescriptorWithLifetime<TService, TImplementation>(ServiceLifetime.Singleton);

        Add(serviceDescriptor);

        return this;
    }
    
    public ServiceCollection AddTransient<TService>(Func<ServiceProvider, TService> factory)
        where TService : class
    {
        var serviceDescriptor = new ServiceDescriptor
        {
            ServiceType = typeof(TService),
            ImplementationType = typeof(TService),
            ImplementationFactory = factory,
            Lifetime = ServiceLifetime.Transient
        };
        
        Add(serviceDescriptor);

        return this;
    }
    
    public ServiceCollection AddTransient<TService>()
        where TService : class
    {
        var serviceDescriptor = AddServiceDescriptorWithLifetime<TService, TService>(ServiceLifetime.Transient);

        Add(serviceDescriptor);

        return this;
    }

    public ServiceCollection AddTransient<TService, TImplementation>()
        where TService : class
        where TImplementation : class, TService
    {
        var serviceDescriptor = AddServiceDescriptorWithLifetime<TService, TImplementation>(ServiceLifetime.Transient);

        Add(serviceDescriptor);

        return this;
    }

    public ServiceProvider BuilderServiceProvider()
    {
        return new ServiceProvider(this);
    }

    private static ServiceDescriptor AddServiceDescriptorWithLifetime<TService, TImplementation>(
        ServiceLifetime lifetime)
    {
        var serviceDescriptor = new ServiceDescriptor
        {
            ServiceType = typeof(TService),
            ImplementationType = typeof(TImplementation),
            Lifetime = lifetime
        };

        return serviceDescriptor;
    }
}