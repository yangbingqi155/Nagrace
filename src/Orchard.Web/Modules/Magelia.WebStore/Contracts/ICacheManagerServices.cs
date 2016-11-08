using Orchard;
using System;

namespace Magelia.WebStore.Contracts
{
    public interface ICacheManagerServices : IDependency
    {
        void Clear();
        T GetOrAdd<T>(Func<T> create, params Object[] keys);
    }
}
