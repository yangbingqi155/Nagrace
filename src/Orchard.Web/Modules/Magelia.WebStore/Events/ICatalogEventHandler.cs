using Magelia.WebStore.Client;
using Orchard.Events;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Magelia.WebStore.Events
{
    public interface ICatalogEventHandler : IEventHandler
    {
        IEnumerable<Expression<Func<ExtendedCatalog, Object>>> GetCatalogsInclusions();
        IEnumerable<Expression<Func<ReferenceProduct, Object>>> GetProductInclusions();
        IEnumerable<Expression<Func<ReferenceProduct, Object>>> GetProductsInclusions();
        IEnumerable<Expression<Func<CategoryHierarchy, Object>>> GetCategoriesInclusions();
    }
}
