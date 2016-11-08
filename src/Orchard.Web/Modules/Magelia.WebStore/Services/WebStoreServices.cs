using Magelia.WebStore.Client;
using Magelia.WebStore.Contracts;
using Magelia.WebStore.Events;
using Magelia.WebStore.Extensions;
using Magelia.WebStore.Models.Parts;
using Magelia.WebStore.Services.Contract.Data.Customer;
using Magelia.WebStore.Services.Contract.Data.Store;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Logging;
using Orchard.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Magelia.WebStore.Services
{
    public class WebStoreServices : IWebStoreServices
    {
        private class StoreConfiguration
        {
            public Int32 CountryId { get; private set; }
            public Int32 CultureId { get; private set; }
            public Int32 CurrencyId { get; private set; }

            public StoreConfiguration(DataStoreConfiguration configuration)
            {
                this.CultureId = configuration.Culture.LCID;
                this.CountryId = configuration.Country.CountryId;
                this.CurrencyId = configuration.Currency.CurrencyId;
            }
        }

        private const String StoreContextCacheKey = "StoreContext";
        private const String CurrentRegionIdSessionKey = "CurrentRegionId";
        private const String StoreConfigurationSessionKey = "StoreConfiguration";
        private const String AnonymousUserNameCookieKey = "mageliaanonymoususername";
        private const String DefaultStoreConfigurationCacheKey = "DefaultStoreConfiguration";

        private Lazy<SettingsPart> _settings;
        private Orchard.Logging.ILogger _logger;
        private Lazy<String> _anonymousUserName;
        private Lazy<StoreContext> _storeContext;
        private IOrchardServices _orchardServices;
        private Lazy<NumberFormatInfo> _numberFormat;
        private Lazy<StoreContext> _defaultStoreContext;
        private ICacheManagerServices _cacheManagerServices;
        private ISessionManagerServices _sessionManagerServices;
        private WebStoreServices.StoreConfiguration _checkedStoreConfiguration;
        private Lazy<WebStoreServices.StoreConfiguration> _defaultConfiguration;

        private IEnumerable<DataStoreConfiguration> _dataStoreConfigurations
        {
            get
            {
                if (!this._defaultStoreContext.Value.Configurations.Any())
                {
                    throw new Exception("No store configuration available. Please configure and generate appropriated store configurations in the PRODUCTS > Data update screen on the Magelia WebStore Administration Console");
                }

                return this._defaultStoreContext.Value.Configurations;
            }
        }

        private WebStoreServices.StoreConfiguration _storeConfiguration
        {
            get
            {
                if (this._checkedStoreConfiguration == null)
                {
                    this._checkedStoreConfiguration = this._sessionManagerServices.GetFromCommonContext<WebStoreServices.StoreConfiguration>(WebStoreServices.StoreConfigurationSessionKey);

                    if (this._checkedStoreConfiguration == null || !this.CheckStoreConfiguration(this._checkedStoreConfiguration))
                    {
                        this._storeConfiguration = null;
                        this._checkedStoreConfiguration = this._defaultConfiguration.Value;
                    }
                }

                return _checkedStoreConfiguration;
            }
            set
            {
                Boolean isNull = value == null;

                if (
                    isNull ||
                    !(
                        value.CountryId == this._storeConfiguration.CountryId &&
                        value.CultureId == this._storeConfiguration.CultureId &&
                        value.CurrencyId == this._storeConfiguration.CurrencyId
                     )
                )
                {
                    WebStoreServices.StoreConfiguration storeConfiguration = isNull ||
                                                                             (
                                                                                 value.CountryId == this._defaultConfiguration.Value.CountryId &&
                                                                                 value.CultureId == this._defaultConfiguration.Value.CultureId &&
                                                                                 value.CurrencyId == this._defaultConfiguration.Value.CurrencyId
                                                                             ) ?
                                                                             null :
                                                                             value;

                    this._checkedStoreConfiguration = null;
                    this._sessionManagerServices.SetInCommonContext<WebStoreServices.StoreConfiguration>(WebStoreServices.StoreConfigurationSessionKey, value);
                }
            }
        }

        public String BasketName
        {
            get
            {
                return "Default";
            }
        }

        public Boolean IsAnonymous
        {
            get
            {
                return this._orchardServices.WorkContext.CurrentUser == null;
            }
        }

        public String CurrentUserName
        {
            get
            {
                return this.IsAnonymous ?
                            this.AnonymousUserName :
                            this._orchardServices.WorkContext.CurrentUser.UserName;
            }
        }

        public String AnonymousUserName
        {
            get
            {
                return this._anonymousUserName.Value;
            }
        }

        public StoreContext StoreContext
        {
            get
            {
                return this._storeContext.Value;
            }
        }

        public Int32 CurrentCultureId
        {
            get
            {
                return this._storeConfiguration.CultureId;
            }
        }

        public Int32 CurrentCurrencyId
        {
            get
            {
                return this._storeConfiguration.CurrencyId;
            }
            set
            {
                this.SetCurrentCurrencyId(value);
            }
        }

        public Int32 CurrentCountryId
        {
            get
            {
                return this._storeConfiguration.CountryId;
            }
            set
            {
                this.SetCurrentCountryId(value);
            }
        }

        public Nullable<Guid> CurrentRegionId
        {
            get
            {
                return this._sessionManagerServices.GetFromCommonContext<Nullable<Guid>>(WebStoreServices.CurrentRegionIdSessionKey);
            }
            set
            {
                this._sessionManagerServices.SetInCommonContext<Nullable<Guid>>(WebStoreServices.CurrentRegionIdSessionKey, value);
            }
        }

        public NumberFormatInfo NumberFormat
        {
            get
            {
                return this._numberFormat.Value;
            }
        }

        private void SetCurrentCountryId(Int32 countryId)
        {
            WebStoreServices.StoreConfiguration storeConfiguration = this._dataStoreConfigurations.OrderByDescending(c => c.Country.CountryId == countryId)
                                                                                                  .ThenByDescending(c => c.Country.IsDefault)
                                                                                                  .ThenByDescending(c => c.Culture.LCID == this.CurrentCultureId)
                                                                                                  .ThenByDescending(c => c.Country.CultureId == c.Culture.LCID)
                                                                                                  .ThenByDescending(c => c.Culture.IsDefault)
                                                                                                  .ThenByDescending(c => c.Currency.CurrencyId == this.CurrentCurrencyId)
                                                                                                  .ThenByDescending(c => c.Country.CurrencyId == c.Currency.CurrencyId)
                                                                                                  .ThenByDescending(c => c.Currency.IsDefault)
                                                                                                  .Select(c => new WebStoreServices.StoreConfiguration(c))
                                                                                                  .FirstOrDefault();

            this._storeConfiguration = storeConfiguration;
        }

        private void SetCurrentCurrencyId(Int32 currencyId)
        {
            WebStoreServices.StoreConfiguration storeConfiguration = this._dataStoreConfigurations.Where(c => c.Country.CountryId == this.CurrentCountryId && c.Currency.CurrencyId == currencyId)
                                                                                                  .OrderByDescending(c => c.Culture.LCID == this.CurrentCultureId)
                                                                                                  .Select(c => new WebStoreServices.StoreConfiguration(c))
                                                                                                  .FirstOrDefault();

            this._storeConfiguration = storeConfiguration;
        }

        private String EnsureAnonymousUserName()
        {
            HttpCookie cookie;

            if (this._orchardServices.WorkContext.HttpContext.Request.Cookies.AllKeys.Contains(WebStoreServices.AnonymousUserNameCookieKey))
            {
                cookie = this._orchardServices.WorkContext.HttpContext.Request.Cookies[WebStoreServices.AnonymousUserNameCookieKey];
            }
            else
            {
                cookie = new HttpCookie(WebStoreServices.AnonymousUserNameCookieKey, Guid.NewGuid().ToString());

                this._orchardServices.WorkContext.HttpContext.Response.Cookies.Add(cookie);

                this.UsingClient(c => c.CustomerClient.CreateAnonymousCustomer(cookie.Value));
            }

            cookie.Expires = DateTime.Now.AddYears(1);

            return cookie.Value;
        }

        private NumberFormatInfo GetNumberFormat()
        {
            NumberFormatInfo numberFormat = (NumberFormatInfo)CultureInfo.GetCultureInfo(this._orchardServices.WorkContext.CurrentCulture).NumberFormat.Clone();

            numberFormat.CurrencySymbol = this.StoreContext.AvailableCurrencies.Where(ac => ac.CurrencyId == this.CurrentCurrencyId)
                                                                               .Select(c => c.Symbol)
                                                                               .FirstOrDefault();

            return numberFormat;
        }

        private StoreContext GetStoreContext()
        {
            return this._defaultConfiguration.Value.CultureId == this.CurrentCultureId ?
                        this._defaultStoreContext.Value :
                        this.GetStoreContext(this.CurrentCultureId);
        }

        private Boolean CheckStoreConfiguration(WebStoreServices.StoreConfiguration storeConfiguration)
        {
            return this._defaultStoreContext.Value.Configurations.Any(
                c => c.Culture.LCID == storeConfiguration.CultureId &&
                     c.Country.CountryId == storeConfiguration.CountryId &&
                     c.Currency.CurrencyId == storeConfiguration.CurrencyId
            );
        }

        private WebStoreServices.StoreConfiguration GetDefaultConfiguration()
        {
            return this._cacheManagerServices.GetOrAdd<WebStoreServices.StoreConfiguration>(
                () => this._dataStoreConfigurations.OrderByDescending(c => c.Country.IsDefault)
                                                   .ThenByDescending(c => c.Culture.NetName.EqualsOrdinalIgnoreCase(this._orchardServices.WorkContext.CurrentCulture))
                                                   .ThenByDescending(c => c.Country.CultureId == c.Culture.LCID)
                                                   .ThenByDescending(c => c.Culture.IsDefault)
                                                   .ThenByDescending(c => c.Currency.CurrencyId == c.Country.CurrencyId)
                                                   .ThenByDescending(c => c.Currency.IsDefault)
                                                   .Select(c => new WebStoreServices.StoreConfiguration(c))
                                                   .FirstOrDefault(),
                WebStoreServices.DefaultStoreConfigurationCacheKey
            );
        }

        private StoreContext GetDefaultStoreContext()
        {
            return this.GetStoreContext(new Nullable<Int32>());
        }

        private StoreContext GetStoreContext(Nullable<Int32> cultureId)
        {
            return this._cacheManagerServices.GetOrAdd<StoreContext>(
                () =>
                {
                    StoreContext storeContext = null;

                    this.UsingClient(c => storeContext = c.StoreClient.GetContext(cultureId), false);

                    return storeContext;
                },
                WebStoreServices.StoreContextCacheKey,
                cultureId
            );
        }

        private SettingsPart GetSettings()
        {
            return this._orchardServices.WorkContext.CurrentSite.As<SettingsPart>();
        }

        private WebStoreContext NewClient(Boolean contextualize)
        {
            return this.NewClient(this._settings.Value.StoreId, this._settings.Value.ServicesPath, contextualize);
        }

        private WebStoreContext NewClient(Guid storeId, String servicesPath, Boolean contextualize)
        {
            WebStoreContextSettings settings = new WebStoreContextSettings(storeId, new Uri(servicesPath));

            return contextualize ?
                        new WebStoreContext(settings, this.CurrentCultureId, this.CurrentCurrencyId, this.CurrentCountryId, this.CurrentRegionId) :
                        new WebStoreContext(settings);
        }

        private Exception Execute(Func<WebStoreContext> clientBuilder, Action<WebStoreContext> action)
        {
            try
            {
                Stopwatch watch = Stopwatch.StartNew();

                using (WebStoreContext client = clientBuilder())
                {
                    action(client);
                }

                watch.Stop();

                this._logger.Debug(String.Format("Magelia Client : {0} ms", watch.ElapsedMilliseconds));
            }
            catch (Exception exception)
            {
                this._logger.Error(exception, null);

                return exception;
            }

            return null;
        }

        public WebStoreServices(IOrchardServices orchardServices, ICacheManagerServices cacheManagerServices, ISessionManagerServices sessionManagerServices)
        {
            this._orchardServices = orchardServices;
            this._cacheManagerServices = cacheManagerServices;
            this._logger = Orchard.Logging.NullLogger.Instance;
            this._sessionManagerServices = sessionManagerServices;
            this._settings = new Lazy<SettingsPart>(this.GetSettings);
            this._storeContext = new Lazy<StoreContext>(this.GetStoreContext);
            this._numberFormat = new Lazy<NumberFormatInfo>(this.GetNumberFormat);
            this._anonymousUserName = new Lazy<String>(this.EnsureAnonymousUserName);
            this._defaultStoreContext = new Lazy<StoreContext>(this.GetDefaultStoreContext);
            this._defaultConfiguration = new Lazy<WebStoreServices.StoreConfiguration>(this.GetDefaultConfiguration);
        }

        public void EnsureUser(IUser user)
        {
            this.UsingClient(
                c =>
                {
                    if (c.CustomerClient.GetCustomer(user.UserName, true) == null)
                    {
                        MembershipCreateStatus status;

                        Customer customer = c.CustomerClient.CreateCustomer
                        (
                            user.UserName,
                            Guid.NewGuid().ToString(),
                            String.IsNullOrEmpty(user.Email) ? null : user.Email,
                            null,
                            null,
                            true,
                            out status
                        );

                        if (status == MembershipCreateStatus.Success && customer != null)
                        {
                            this._orchardServices.WorkContext.Resolve<System.Collections.Generic.IEnumerable<ICustomerEventHandler>>().Trigger(h => h.Created(customer));
                        }
                    }
                }
            );
        }

        public Exception UsingClient(Action<WebStoreContext> action)
        {
            return this.UsingClient(action, true);
        }

        public Exception UsingClient(Action<WebStoreContext> action, Boolean contextualize)
        {
            return this.Execute(() => this.NewClient(contextualize), action);
        }

        public Exception UsingClient(Guid storeId, String servicesPath, Action<WebStoreContext> action)
        {
            return this.Execute(() => this.NewClient(storeId, servicesPath, false), action);
        }
    }
}