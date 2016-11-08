
namespace Magelia.WebStore.Client
{
    public abstract partial class WebStoreContextBase : WebStoreContext<ICatalogServiceClient>
    {
        public WebStoreContextBase(WebStoreContextSettings settings)
            : base(settings)
        {
        }
    }
}
