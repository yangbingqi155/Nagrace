using Orchard;
using System;

namespace Magelia.WebStore.Contracts
{
    public interface ISessionManagerServices : IDependency
    {
        void FlushUserContext();
        void FlushCommerceContext();
        T GetFromCommonContext<T>(String key);
        void SetInCommonContext<T>(String key, T value);
        T GetFromUserContext<T>(String key, Int32 id) where T : new();
        T GetFromCommerceContext<T>(String key, Int32 id) where T : new();
    }
}
