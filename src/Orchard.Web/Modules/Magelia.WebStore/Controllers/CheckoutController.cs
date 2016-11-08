using Magelia.WebStore.Contracts;
using Magelia.WebStore.Events;
using Magelia.WebStore.Extensions;
using Magelia.WebStore.Models.ViewModels.Checkout;
using Magelia.WebStore.Models.ViewModels.User;
using Magelia.WebStore.MVC;
using Magelia.WebStore.Services.Contract.Data.Store;
using Orchard;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Customer = Magelia.WebStore.Services.Contract.Data.Customer;

namespace Magelia.WebStore.Controllers
{
    public class CheckoutController : Controller
    {
        private const String BillingAddressIdSessionKey = "billingaddressid";
        private const String RawBillingAddressSessionKey = "rawbillingaddress";
        private const String ShippingAddressIdSessionKey = "shippingaddressid";
        private const String RawShippingAddressSessionKey = "rawshippingaddress";
        private const String ShippingAddressIsDifferentSessionKey = "shippingaddressisdifferent";

        private Localizer _localizer;
        private dynamic _shapeFactory;
        private IOrchardServices _orchardServices;
        private IWebStoreServices _webStoreServices;
        private ISessionManagerServices _sessionManagerServices;
        private IEnumerable<IBasketEventHandler> _basketEventHandlers;

        private Nullable<Guid> ShippingAddressId
        {
            get
            {
                return this._sessionManagerServices.GetFromCommonContext<Nullable<Guid>>(CheckoutController.ShippingAddressIdSessionKey);
            }
            set
            {
                this._sessionManagerServices.SetInCommonContext<Nullable<Guid>>(CheckoutController.ShippingAddressIdSessionKey, value);
            }
        }

        private Nullable<Guid> BillingAddressId
        {
            get
            {
                return this._sessionManagerServices.GetFromCommonContext<Nullable<Guid>>(CheckoutController.BillingAddressIdSessionKey);
            }
            set
            {
                this._sessionManagerServices.SetInCommonContext<Nullable<Guid>>(CheckoutController.BillingAddressIdSessionKey, value);
            }
        }

        private Boolean ShippingAddressIsDifferent
        {
            get
            {
                return this._sessionManagerServices.GetFromCommonContext<Boolean>(CheckoutController.ShippingAddressIsDifferentSessionKey);
            }
            set
            {
                this._sessionManagerServices.SetInCommonContext<Boolean>(CheckoutController.ShippingAddressIsDifferentSessionKey, value);
            }
        }

        private Address RawShippingAddress
        {
            get
            {
                Address rawShippingAddress = this._sessionManagerServices.GetFromCommonContext<Address>(CheckoutController.RawShippingAddressSessionKey);

                if (rawShippingAddress == null)
                {
                    this.RawShippingAddress = rawShippingAddress = this.GetDefaultRawAddress();
                }

                return rawShippingAddress;
            }
            set
            {
                this._sessionManagerServices.SetInCommonContext<Address>(CheckoutController.RawShippingAddressSessionKey, value);
            }
        }

        private Address RawBillingAddress
        {
            get
            {
                Address rawBillingAddress = this._sessionManagerServices.GetFromCommonContext<Address>(CheckoutController.RawBillingAddressSessionKey);

                if (rawBillingAddress == null)
                {
                    this.RawBillingAddress = rawBillingAddress = this.GetDefaultRawAddress();
                }

                return rawBillingAddress;
            }
            set
            {
                this._sessionManagerServices.SetInCommonContext<Address>(CheckoutController.RawBillingAddressSessionKey, value);
            }
        }

        private Address GetDefaultRawAddress()
        {
            return new Address
            {
                RegionId = this._webStoreServices.CurrentRegionId,
                CountryId = this._webStoreServices.CurrentCountryId
            };
        }

        private AddressViewModel Initialize(AddressViewModel viewModel)
        {
            viewModel.Countries = this._webStoreServices.StoreContext.AvailableCountries.Select(ac => new SelectListItem { Text = ac.Name, Value = ac.CountryId.ToString() })
                                                                                        .ToArray();

            if (viewModel.CountryId.HasValue)
            {
                this._webStoreServices.UsingClient(
                    c => viewModel.Regions = c.StoreClient.GetRegions(viewModel.CountryId.Value, this._webStoreServices.CurrentCultureId).Select(
                        r => new SelectListItem
                        {
                            Text = r.Name,
                            Value = r.RegionId.ToString()
                        }
                    )
                    .ToArray()
                );

                if (
                    !viewModel.RegionId.HasValue && 
                    this._webStoreServices.CurrentRegionId.HasValue && 
                    viewModel.CountryId == this._webStoreServices.CurrentCountryId
                )
                {
                    viewModel.RegionId = this._webStoreServices.CurrentRegionId;
                }
            }
            return viewModel;
        }

        private AddressViewModel GetAddressViewModel(Address address)
        {
            Boolean isBillingAddress = address == this.RawBillingAddress;

            AddressViewModel viewModel = new AddressViewModel
            {
                AddressId = address.AddressId,
                City = address.City,
                Company = address.Company,
                CountryId = address.CountryId,
                DigiCode = address.DigiCode,
                Email = address.Email,
                FaxNumber = address.FaxNumber,
                FirstName = address.FirstName,
                Floor = address.Floor,
                LastName = address.LastName,
                Line1 = address.Line1,
                Line2 = address.Line2,
                Line3 = address.Line3,
                MiddleName = address.MiddleName,
                MobileNumber = address.MobileNumber,
                PhoneNumber = address.PhoneNumber,
                RegionId = address.RegionId,
                ZipCode = address.ZipCode,
                PromptShippingAddressIsDifferent = isBillingAddress,
                PromptEmail = isBillingAddress,
                ShippingAddressIsDifferent = this.ShippingAddressIsDifferent,
                DisplayNexButton = true,
                Named = false
            };

            this.Initialize(viewModel);

            return viewModel;
        }

        private AddressRecapViewModel GetAddressRecapViewModel(Customer.Address address)
        {
            if (address != null)
            {
                return new AddressRecapViewModel
                {
                    City = address.City,
                    Company = address.Company,
                    CountryName = address.CountryName,
                    DigiCode = address.DigiCode,
                    Email = address.Email,
                    FaxNumber = address.FaxNumber,
                    FirstName = address.FirstName,
                    Floor = address.Floor,
                    LastName = address.LastName,
                    Line1 = address.Line1,
                    Line2 = address.Line2,
                    Line3 = address.Line3,
                    MiddleName = address.MiddleName,
                    MobileNumber = address.MobileNumber,
                    Name = address.Name,
                    PhoneNumber = address.PhoneNumber,
                    RegionName = address.RegionName,
                    ZipCode = address.ZipCode,
                    ShippingAddressIsTheSame = address.AddressId == this.BillingAddressId && !this.ShippingAddressIsDifferent
                };
            }
            return null;
        }

        private AddressRecapViewModel GetAddressRecapViewModel(Address address)
        {
            if (address != null)
            {
                AddressRecapViewModel viewModel = new AddressRecapViewModel
                {
                    City = address.City,
                    Company = address.Company,
                    CountryName = this._webStoreServices.StoreContext.AvailableCountries.Where(ac => ac.CountryId == address.CountryId).Select(ac => ac.Name).FirstOrDefault(),
                    DigiCode = address.DigiCode,
                    Email = address.Email,
                    FaxNumber = address.FaxNumber,
                    FirstName = address.FirstName,
                    Floor = address.Floor,
                    LastName = address.LastName,
                    Line1 = address.Line1,
                    Line2 = address.Line2,
                    Line3 = address.Line3,
                    MiddleName = address.MiddleName,
                    MobileNumber = address.MobileNumber,
                    PhoneNumber = address.PhoneNumber,
                    ZipCode = address.ZipCode,
                    ShippingAddressIsTheSame = address == this.RawBillingAddress && !this.ShippingAddressIsDifferent
                };

                if (address.RegionId.HasValue)
                {
                    this._webStoreServices.UsingClient(
                        c => viewModel.RegionName = c.StoreClient.GetRegions(address.CountryId, this._webStoreServices.CurrentCultureId)
                                                                 .Where(r => r.RegionId == address.RegionId)
                                                                 .Select(r => r.Name)
                                                                 .FirstOrDefault()
                    );
                }

                return viewModel;
            }
            return null;
        }

        private ActionResult BuildAddressRecapShapeResult(AddressRecapViewModel viewModel)
        {
            return new ShapePartialResult(this, this._shapeFactory.DisplayTemplate(TemplateName: "Checkout/AddressRecap", Model: viewModel));
        }

        private ActionResult BuildCustomerAddressRecap(Nullable<Guid> addressId)
        {
            Customer.Address address = null;

            if (addressId.HasValue)
            {
                this._webStoreServices.UsingClient(
                    c => address = c.CustomerClient.GetAddresses(this._webStoreServices.CurrentUserName, this._webStoreServices.CurrentCultureId).FirstOrDefault(a => a.AddressId == addressId)
                );
            }

            return this.BuildAddressRecapShapeResult(this.GetAddressRecapViewModel(address));
        }

        private ActionResult BuildRawBillingAddressRecap()
        {
            return this.BuildAddressRecapShapeResult(this.GetAddressRecapViewModel(this.RawBillingAddress));
        }

        private ActionResult BuildRawShippingAddressRecap()
        {
            return this.BuildAddressRecapShapeResult(this.GetAddressRecapViewModel(this.RawShippingAddress));
        }

        private ActionResult BuildBillingAddressRecap()
        {
            return this.BuildCustomerAddressRecap(this.BillingAddressId);
        }

        private ActionResult BuildShippingAddressRecap()
        {
            return this.BuildCustomerAddressRecap(this.ShippingAddressId);
        }

        private ActionResult EditAddress(Boolean isBillingAddress)
        {
            dynamic addressEditor;

            if (this._webStoreServices.IsAnonymous)
            {
                addressEditor = this._shapeFactory.EditorTemplate(
                    TemplateName: "User/Address",
                    Model: this.GetAddressViewModel(isBillingAddress ? this.RawBillingAddress : this.RawShippingAddress)
                );
            }
            else
            {
                addressEditor = this._shapeFactory.EditorTemplate(
                    TemplateName: "User/AddressesManager",
                    Model: new AddressesManagerViewModel
                    {
                        CanSelect = true,
                        PromptShippingAddressIsDifferent = isBillingAddress,
                        ShippingAddressIsDifferent = this.ShippingAddressIsDifferent,
                        ExceptedAddressId = isBillingAddress ? null : this.BillingAddressId,
                        SelectedAddressId = isBillingAddress ? this.BillingAddressId : this.ShippingAddressId
                    }
                );
            }

            return new ShapePartialResult(this, addressEditor);
        }

        private void SetAddresses(Guid billingAddress, Nullable<Guid> shippingAddressId)
        {
            this._webStoreServices.UsingClient(
                c =>
                {
                    Guid finalShippingAddressId = shippingAddressId ?? billingAddress;

                    Customer.Address address = c.CustomerClient.GetAddresses(this._webStoreServices.CurrentUserName, this._webStoreServices.CurrentCultureId)
                                                               .FirstOrDefault(a => a.AddressId == finalShippingAddressId);

                    this._webStoreServices.CurrentRegionId = address.RegionId;
                    this._webStoreServices.CurrentCountryId = address.CountryId;

                    c.BasketClient.SetCustomerAddressToBasket(this._webStoreServices.CurrentUserName, this._webStoreServices.BasketName, billingAddress, shippingAddressId);
                }
            );
        }

        private void SetAddresses(Address rawBillingAddress, Address rawShippingAddress)
        {
            Address finalShippingAddress = rawShippingAddress ?? rawBillingAddress;

            this._webStoreServices.CurrentRegionId = finalShippingAddress.RegionId;
            this._webStoreServices.CurrentCountryId = finalShippingAddress.CountryId;

            this._webStoreServices.UsingClient(c => c.BasketClient.SetRawAddressToBasket(this._webStoreServices.CurrentUserName, this._webStoreServices.BasketName, rawBillingAddress, rawShippingAddress));
        }

        private void UpdateAddress(Address address, AddressViewModel viewModel)
        {
            address.City = viewModel.City;
            address.Company = viewModel.Company;
            address.CountryId = viewModel.CountryId.Value;
            address.DigiCode = viewModel.DigiCode;
            address.Email = viewModel.Email;
            address.FaxNumber = viewModel.FaxNumber;
            address.FirstName = viewModel.FirstName;
            address.Floor = viewModel.Floor;
            address.LastName = viewModel.LastName;
            address.Line1 = viewModel.Line1;
            address.Line2 = viewModel.Line2;
            address.Line3 = viewModel.Line3;
            address.MiddleName = viewModel.MiddleName;
            address.MobileNumber = viewModel.MobileNumber;
            address.PhoneNumber = viewModel.PhoneNumber;
            address.RegionId = viewModel.RegionId;
            address.ZipCode = viewModel.ZipCode;
        }

        private ActionResult RegisterAddress(Address address, AddressViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                Boolean success = false;

                this._webStoreServices.UsingClient(
                    c =>
                    {
                        if (viewModel.RegionId.HasValue || (!viewModel.RegionId.HasValue && !c.StoreClient.GetRegions(viewModel.CountryId.Value, this._webStoreServices.CurrentCultureId).Any()))
                        {
                            success = true;
                        }
                        else
                        {
                            success = false;
                            this.ModelState.AddModelError("RegionRequired", this._localizer("Region is required").ToString());
                        }
                    }
                );

                if (success)
                {
                    this.UpdateAddress(address, viewModel);
                    if (address == this.RawBillingAddress)
                    {
                        this.ShippingAddressIsDifferent = viewModel.ShippingAddressIsDifferent;
                        if (!this.ShippingAddressIsDifferent)
                        {
                            this.SetAddresses(this.RawBillingAddress, null);
                        }
                        return this.Json(new { shippingAddressIsDifferent = this.ShippingAddressIsDifferent });
                    }
                    else
                    {
                        this.SetAddresses(this.RawBillingAddress, this.RawShippingAddress);
                        return this.Json(new { success = true });
                    }
                }
            }

            this.Initialize(viewModel);

            return new ShapePartialResult(this, this._shapeFactory.EditorTemplate(TemplateName: "User/Address", Model: viewModel));
        }

        private void Initialize(ShippingRatesViewModel viewModel)
        {
            viewModel.NumberFormat = this._webStoreServices.NumberFormat;

            this._webStoreServices.UsingClient(
                c =>
                {
                    Basket basket = c.BasketClient.GetBasket(this._webStoreServices.CurrentUserName, this._webStoreServices.BasketName);
                    if (basket != null)
                    {
                        IEnumerable<OrderSubset> physicalOrderSubsets = basket.OrderSubsets.Where(os => !os.IsVirtual);

                        if (physicalOrderSubsets.Any())
                        {

                            Dictionary<Guid, IEnumerable<ShippingRateValue>> availableShippingRates = c.BasketClient.GetShippingRateValues(this._webStoreServices.CurrentUserName, this._webStoreServices.BasketName, this._webStoreServices.CurrentCultureId);

                            viewModel.ShippingRatesByOrderSubset = physicalOrderSubsets.ToDictionary(
                                                                                            os => os.OrderSubsetId,
                                                                                            os => availableShippingRates.Where(asr => asr.Key == os.OrderSubsetId)
                                                                                                                        .SelectMany(asr => asr.Value.OrderBy(srv => srv.PriceTaxIncluded))
                                                                                                                        .ToList()
                                                                                                                        .AsEnumerable()
                                                                                      );

                            viewModel.ShippingRateValueSelections = physicalOrderSubsets.Select(os => new ShippingRatesViewModel.ShippingRateValueSelection { OrderSubsetId = os.OrderSubsetId, ShippingRateCode = os.ShippingRateCode })
                                                                                        .ToList();
                        }
                    }
                }
            );
        }

        private ActionResult BuildShippingRatesShapeResult(ShippingRatesViewModel viewModel)
        {
            return new ShapePartialResult(this, this._shapeFactory.EditorTemplate(TemplateName: "Checkout/ShippingRates", Model: viewModel));
        }

        private ActionResult BuildPaymentShape(PaymentViewModel viewModel)
        {
            return new ShapePartialResult(this, this._shapeFactory.EditorTemplate(TemplateName: "Checkout/Payment", Model: viewModel));
        }

        private ActionResult BuildProceedToPaymentShape(ProceedToPaymentViewModel viewModel)
        {
            return new ShapePartialResult(this, this._shapeFactory.DisplayTemplate(TemplateName: "Checkout/ProceedToPayment", Model: viewModel));
        }

        public CheckoutController(IWebStoreServices webStoreServices, IOrchardServices orchardServices, ISessionManagerServices sessionManagerServices, IEnumerable<IBasketEventHandler> basketEventHandlers, IShapeFactory shapeFactory)
        {
            this._shapeFactory = shapeFactory;
            this._orchardServices = orchardServices;
            this._localizer = NullLocalizer.Instance;
            this._webStoreServices = webStoreServices;
            this._basketEventHandlers = basketEventHandlers;
            this._sessionManagerServices = sessionManagerServices;
        }

        [HttpGet]
        [NoCache]
        public ActionResult EditBillingAddress()
        {
            return this.EditAddress(true);
        }

        [HttpGet]
        [NoCache]
        public ActionResult EditShippingAddress()
        {
            return this.EditAddress(false);
        }

        [HttpPost]
        [Authorize]
        public ActionResult SelectBillingAddress(Guid billingAddressId, Boolean shippingAddressIsDifferent)
        {
            this.BillingAddressId = billingAddressId;
            this.ShippingAddressIsDifferent = shippingAddressIsDifferent;

            if (!this.ShippingAddressIsDifferent)
            {
                this.SetAddresses(billingAddressId, null);
            }

            return this.BuildBillingAddressRecap();
        }

        [HttpPost]
        [Authorize]
        public ActionResult SelectShippingAddress(Guid shippingAddressId)
        {
            this.ShippingAddressId = shippingAddressId;
            this.SetAddresses(this.BillingAddressId.Value, this.ShippingAddressId);

            return this.BuildShippingAddressRecap();
        }

        [HttpGet]
        [NoCache]
        public ActionResult GetBillingAddressRecap()
        {
            return this.BuildRawBillingAddressRecap();
        }

        [HttpGet]
        [NoCache]
        public ActionResult GetShippingAddressRecap()
        {
            return this.BuildRawShippingAddressRecap();
        }

        [HttpPost]
        public ActionResult RegisterBillingAddress(AddressViewModel viewModel)
        {
            return this.RegisterAddress(this.RawBillingAddress, viewModel);
        }

        [HttpPost]
        public ActionResult RegisterShippingAddress(AddressViewModel viewModel)
        {
            return this.RegisterAddress(this.RawShippingAddress, viewModel);
        }

        [HttpGet]
        [NoCache]
        public ActionResult EditShippingRates()
        {
            ShippingRatesViewModel viewModel = new ShippingRatesViewModel();

            this.Initialize(viewModel);

            return this.BuildShippingRatesShapeResult(viewModel);
        }

        [HttpPost]
        public ActionResult SetShippingRates(ShippingRatesViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                String basketHash = null;

                Exception exception = this._webStoreServices.UsingClient(
                    c =>
                    {
                        c.BasketClient.SetShippingRateValues(this._webStoreServices.CurrentUserName, this._webStoreServices.BasketName, viewModel.ShippingRateValueSelections.ToDictionary(srvs => srvs.OrderSubsetId, srvs => srvs.ShippingRateCode));
                        basketHash = c.BasketClient.GetBasketHash(this._webStoreServices.CurrentUserName, this._webStoreServices.BasketName);
                    }
                );

                return this.Json(new { success = exception == null, basketHash = basketHash });
            }
            else
            {
                this.Initialize(viewModel);
                return this.BuildShippingRatesShapeResult(viewModel);
            }
        }

        [HttpGet]
        [NoCache]
        public ActionResult GetShippingRatesRecap()
        {
            ShippingRatesRecapViewModel viewModel = new ShippingRatesRecapViewModel();

            viewModel.NumberFormat = this._webStoreServices.NumberFormat;

            this._webStoreServices.UsingClient(
                c =>
                {
                    Dictionary<Guid, IEnumerable<ShippingRateValue>> shippingRatesByOrderSubset = c.BasketClient.GetShippingRateValues(this._webStoreServices.CurrentUserName, this._webStoreServices.BasketName, this._webStoreServices.CurrentCultureId);

                    viewModel.AddRange(
                        c.BasketClient.GetBasket(this._webStoreServices.CurrentUserName, this._webStoreServices.BasketName)
                                      .OrderSubsets
                                      .Where(os => !os.IsVirtual)
                                      .Select(
                                            os => shippingRatesByOrderSubset.Where(srbos => srbos.Key == os.OrderSubsetId)
                                                                            .SelectMany(srbos => srbos.Value)
                                                                            .FirstOrDefault(srv => srv.ShippingRateCode.EqualsOrdinalIgnoreCase(os.ShippingRateCode))
                                      )
                    );
                }
            );

            return new ShapePartialResult(this, this._shapeFactory.DisplayTemplate(TemplateName: "Checkout/ShippingRatesRecap", Model: viewModel));
        }

        [HttpGet]
        [NoCache]
        public ActionResult EditPayment(String basketHash)
        {
            PaymentViewModel viewModel = new PaymentViewModel { BasketHash = basketHash };

            return this.BuildPaymentShape(viewModel);
        }

        [HttpPost]
        public ActionResult SaveAsOrder(PaymentViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                SaveAsOrderResult result = null;

                Exception exception = this._webStoreServices.UsingClient(c => result = c.BasketClient.SaveAsOrder(this._webStoreServices.CurrentUserName, this._webStoreServices.BasketName, viewModel.BasketHash, this.Request.UserHostAddress, null));

                if (exception != null || result == null)
                {
                    this.ModelState.AddModelError("UnexpectedError", this._localizer("An unexpected error has occured, please try again later").ToString());
                }
                else if (result.Success)
                {
                    SaveAsOrderSuccessResult successResult = (SaveAsOrderSuccessResult)result;

                    this._basketEventHandlers.Trigger(h => h.SavedAsOrder(successResult.Order));

                    return this.BuildProceedToPaymentShape(new ProceedToPaymentViewModel { Order = successResult.Order });
                }
                else
                {
                    SaveAsOrderErrorResult errorResult = (SaveAsOrderErrorResult)result;

                    switch (errorResult.Error)
                    {
                        case SaveAsOrderError.AddressMissing:
                            this.ModelState.AddModelError("AddressMissing", this._localizer("An address is missing in your basket, please proceed to checkout again").ToString());
                            break;
                        case SaveAsOrderError.EmptyBasket:
                        case SaveAsOrderError.BasketNotFound:
                            this.ModelState.AddModelError("BasketNotFound", this._localizer("Your basket is empty, it could has been emptied because products are not deliverable in your country").ToString());
                            break;
                        case SaveAsOrderError.InconsistentBasket:
                            this.ModelState.AddModelError("InconsistentBasket", this._localizer("Your basket contains errors, please refresh your basket and proceed to checkout again").ToString());
                            break;
                        case SaveAsOrderError.InvalidHash:
                            this.ModelState.AddModelError("InvalidHash", this._localizer("Your basket has changed during the checkout, please refresh your basket and proceed to checkout again").ToString());
                            break;
                        case SaveAsOrderError.ProductNotFound:
                            this.ModelState.AddModelError("ProductNotFound", this._localizer("A product in your basket is no more available, please refresh your basket and proceed to checkout again").ToString());
                            break;
                        case SaveAsOrderError.ShippingRateValueMissing:
                            this.ModelState.AddModelError("ShippingRateValueMissing", this._localizer("An OrderSubset in your basket couldn't not be delivered, please refresh your basket and proceed to checkout again").ToString());
                            break;
                        case SaveAsOrderError.UnavailableProducts:
                            SaveAsOrderProductsUnavailableErrorResult productsUnavailableResult = (SaveAsOrderProductsUnavailableErrorResult)result;

                            IEnumerable<Guid> unavailableProductIds = productsUnavailableResult.UnavailableProducts.Select(up => up.ProductId)
                                                                                                                   .Distinct()
                                                                                                                   .ToArray();
                            this._webStoreServices.UsingClient(
                                c =>
                                {
                                    Int32 count = 0;
                                    Basket basket = c.BasketClient.GetBasket(this._webStoreServices.CurrentUserName, this._webStoreServices.BasketName);


                                    foreach (UnavailableProductInfo unavailableProduct in productsUnavailableResult.UnavailableProducts)
                                    {
                                        Int32 orderSubsetNumber = basket.OrderSubsets.Select((os, i) => new { OrderSubsetId = os.OrderSubsetId, Index = i })
                                                                                     .Where(o => o.OrderSubsetId == unavailableProduct.OrderSubsetId)
                                                                                     .Select(o => o.Index)
                                                                                     .FirstOrDefault() + 1;

                                        String productName = basket.OrderSubsets.SelectMany(os => os.LineItems)
                                                                                .Where(li => li.ProductId == unavailableProduct.ProductId)
                                                                                .Select(li => String.IsNullOrEmpty(li.ProductName) ? li.SKU : li.ProductName)
                                                                                .FirstOrDefault();

                                        String errorMessage = (
                                            unavailableProduct.AvailableQuantity == 0 ?
                                                this._localizer(
                                                    "Product : '{0}' in OrderSubset #{1} is no more available, please refresh your basket and proceed to checkout again",
                                                    productName,
                                                    orderSubsetNumber
                                                ) :
                                                this._localizer(
                                                    "Product : '{0}' in OrderSubset #{1} is partially unavailable, only {2} unit(s) left, please refresh your basket and proceed to checkout again",
                                                    productName,
                                                    orderSubsetNumber,
                                                    unavailableProduct.AvailableQuantity
                                                )
                                        )
                                        .ToString();

                                        this.ModelState.AddModelError(String.Format("UnavailableProduct-{0}", count), errorMessage);

                                        count++;
                                    }
                                }
                            );
                            break;
                        case SaveAsOrderError.UnknownError:
                            this.ModelState.AddModelError("UnexpectedError", this._localizer("An unexpected error has occured, please try again later").ToString());
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                }
            }

            return this.BuildPaymentShape(viewModel);
        }
    }
}