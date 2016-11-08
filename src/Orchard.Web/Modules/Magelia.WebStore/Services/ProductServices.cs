using Magelia.WebStore.Client;
using Magelia.WebStore.Client.Extensions;
using Magelia.WebStore.Contracts;
using Magelia.WebStore.Events;
using Magelia.WebStore.Models.Parts;
using Magelia.WebStore.Models.ViewModels.Product;
using Magelia.WebStore.Services.Contract.Parameters.Store;
using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Magelia.WebStore.Services
{
    public class ProductServices : IProductServices
    {
        private IOrchardServices _orchardServices;
        private IWebStoreServices _webStoreServices;
        private IEnumerable<ICatalogEventHandler> _catalogEventHandlers;

        private ProductViewModel GetProductReference(ProductPart part)
        {
            ProductViewModel viewModel = new ProductViewModel();

            if (part.FromUrl && !String.IsNullOrEmpty(part.CatalogCodeUrlParameterKey) && !String.IsNullOrEmpty(part.SKUUrlParameterKey))
            {
                viewModel.RequestedCatalogCode = this._orchardServices.WorkContext.HttpContext.Request.QueryString[part.CatalogCodeUrlParameterKey];
                viewModel.RequestedSKU = this._orchardServices.WorkContext.HttpContext.Request.QueryString[part.SKUUrlParameterKey];
            }
            else if (!part.FromUrl)
            {
                viewModel.RequestedSKU = part.SKU;
                viewModel.RequestedCatalogCode = part.CatalogCode;
            }

            return viewModel;
        }

        public ProductServices(IOrchardServices orchardServices, IWebStoreServices webStoreServices, IEnumerable<ICatalogEventHandler> catalogEventHandlers)
        {
            this._orchardServices = orchardServices;
            this._webStoreServices = webStoreServices;
            this._catalogEventHandlers = catalogEventHandlers;
        }

        public ProductViewModel GetModel(ProductPart part)
        {
            ProductViewModel viewModel = this.GetProductReference(part);

            if (!String.IsNullOrEmpty(viewModel.RequestedCatalogCode) && !String.IsNullOrEmpty(viewModel.RequestedSKU))
            {
                this._webStoreServices.UsingClient(
                    c =>
                    {
                        IQueryable<ReferenceProduct> productsQuery = c.CatalogClient.Products.OfType<ReferenceProduct>()
                                                                                             .Include(rp => rp.Brand)
                                                                                             .Include(rp => rp.AttributeValues.Select(av => av.Files))
                                                                                             .Include(rp => rp.AttributeValues.Select(av => av.Attribute))
                                                                                             .Include(rp => rp.PriceWithLowerQuantity.TaxDetails)
                                                                                             .Include(rp => rp.PriceWithLowerQuantity.DiscountDetails)
                                                                                             .Include(rp => (rp as VariantProduct).VariableProduct.AttributeValues.Select(av => av.Files))
                                                                                             .Include(rp => (rp as VariantProduct).VariableProduct.AttributeValues.Select(av => av.Attribute))
                                                                                             .Include(rp => (rp as VariantProduct).VariableProduct.VariantProducts.Select(vp => vp.Brand))
                                                                                             .Include(rp => (rp as VariantProduct).VariableProduct.VariantProducts.Select(vp => vp.AttributeValues.Select(av => av.Files)))
                                                                                             .Include(rp => (rp as VariantProduct).VariableProduct.VariantProducts.Select(vp => vp.AttributeValues.Select(av => av.Attribute)))
                                                                                             .Include(rp => (rp as VariantProduct).VariableProduct.VariantProducts.Select(vp => vp.PriceWithLowerQuantity.TaxDetails))
                                                                                             .Include(rp => (rp as VariantProduct).VariableProduct.VariantProducts.Select(vp => vp.PriceWithLowerQuantity.DiscountDetails));

                        foreach (ICatalogEventHandler catalogEventHandler in this._catalogEventHandlers)
                        {
                            foreach (Expression<Func<ReferenceProduct, Object>> include in catalogEventHandler.GetProductInclusions())
                            {
                                productsQuery = productsQuery.Include(include);
                            }
                        }

                        viewModel.ReferenceProduct = productsQuery.FirstOrDefault(rp => rp.Catalog.Code == viewModel.RequestedCatalogCode && rp.SKU == viewModel.RequestedSKU);

                        if (viewModel.ReferenceProduct != null)
                        {
                            viewModel.Inventories = c.StoreClient.GetInventory(
                                new[] { viewModel.ReferenceProduct.ProductId },
                                new Location
                                {
                                    RegionId = this._webStoreServices.CurrentRegionId,
                                    CountryId = this._webStoreServices.CurrentCountryId
                                }
                            );
                        }
                    }
                );
            }

            return viewModel;
        }
    }
}