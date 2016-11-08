using System;

[assembly: Magelia.WebStore.Client.RegisterDependencyModule(typeof(Magelia.WebStore.Client.DependencyModule))]

namespace Magelia.WebStore.Client
{
    public class DependencyModule : IDependencyModule
    {
        public String Key
        {
            get
            {
                return typeof(DependencyModule).FullName;
            }
        }

        public void Load(IDependencyResolver dependencyResolver)
        {
            dependencyResolver.RegisterFactory<IServiceClientFactory>(c => new ServiceClientFactory(c.DependencyResolver.Resolve<IBindingFactory>(), c.DependencyResolver.Resolve<IServiceUriResolver>()));
            dependencyResolver.RegisterFactory<IWebStoreContext>(c => c.DependencyResolver.Resolve<WebStoreContext>());
        }
    }

    public class ServiceClientFactory : DefaultServiceClientFactory
    {

        public ServiceClientFactory(IBindingFactory bindingFactory, IServiceUriResolver serviceUriResolver)
            : base(bindingFactory, serviceUriResolver)
        { 
        }

        protected override ICatalogServiceClientBase CreateCatalogServiceClient(Lazy<IStoreServiceClient> storeServiceClient, ICatalogContext catalogContext)
        {
            return new EnhancedCatalogServiceClient(storeServiceClient, catalogContext);
        }

    }

    public class WebStoreContext : WebStoreContextBase
    {
        private Nullable<Guid> _regionId;
        private Nullable<Int32> _cultureId;
        private Nullable<Int32> _countryId;
        private Nullable<Int32> _currencyId;
        private ICatalogServiceClient _catalogClient;

        public ICatalogServiceClient CatalogClient
        {
            get
            {
                if (this._catalogClient == null)
                {
                    this._catalogClient = this.GetCatalogClient(this._cultureId, this._currencyId, this._countryId, this._regionId, null);
                }

                return this._catalogClient;
            }
        }

        public WebStoreContext(WebStoreContextSettings settings)
            : base(settings)
        { }

        public WebStoreContext(WebStoreContextSettings settings, Nullable<Int32> cultureId, Nullable<Int32> currencyId, Nullable<Int32> countryId, Nullable<Guid> regionId)
            : this(settings)
        {
            this._regionId = regionId;
            this._cultureId = cultureId;
            this._countryId = countryId;
            this._currencyId = currencyId;
        }
    }
}