using Confiti.MoySklad.Remap.Client;
using System;
using System.Collections.Concurrent;
using System.Net.Http;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the MoySklad endpoints.
    /// </summary>
    public class MoySkladApi
    {
        #region Fields

        private readonly ConcurrentDictionary<string, Lazy<ApiAccessor>> _apiAccessors;
        private HttpClient _client;
        private MoySkladCredentials _credentials;
            
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="HttpClient"/>.
        /// </summary>
        public HttpClient Client
        {
            get => _client;
            set
            {
                _client = value;
                ConfigureAllActiveApi(api => api.Client = value);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="MoySkladCredentials"/>.
        /// </summary>
        public MoySkladCredentials Credentials
        {
            get => _credentials;
            set
            {
                _credentials = value;
                ConfigureAllActiveApi(api => api.Credentials = value);
            }
        }

        /// <summary>
        /// Gets the <see cref="AssortmentApi"/>.
        /// </summary>
        public AssortmentApi Assortment => GetApi<AssortmentApi>();

        /// <summary>
        /// Gets the <see cref="BundleApi"/>.
        /// </summary>
        public BundleApi Bundle => GetApi<BundleApi>();

        /// <summary>
        /// Gets the <see cref="CounterpartyApi"/>.
        /// </summary>
        public CounterpartyApi Counterparty => GetApi<CounterpartyApi>();

        /// <summary>
        /// Gets the <see cref="CustomerOrderApi"/>.
        /// </summary>
        public CustomerOrderApi CustomerOrder => GetApi<CustomerOrderApi>();

        /// <summary>
        /// Gets the <see cref="DemandApi"/>.
        /// </summary>
        public DemandApi Demand => GetApi<DemandApi>();

        /// <summary>
        /// Gets the <see cref="EnterApi"/>.
        /// </summary>
        public EnterApi Enter => GetApi<EnterApi>();

        /// <summary>
        /// Gets the <see cref="ExpenseItemApi"/>.
        /// </summary>
        public ExpenseItemApi ExpenseItem => GetApi<ExpenseItemApi>();

        /// <summary>
        /// Gets the <see cref="InvoiceOutApi"/>.
        /// </summary>
        public InvoiceOutApi InvoiceOut => GetApi<InvoiceOutApi>();

        /// <summary>
        /// Gets the <see cref="LossApi"/>.
        /// </summary>
        public LossApi Loss => GetApi<LossApi>();

        /// <summary>
        /// Gets the <see cref="MoveApi"/>.
        /// </summary>
        public MoveApi Move => GetApi<MoveApi>();

        /// <summary>
        /// Gets the <see cref="OAuthApi"/>.
        /// </summary>
        public OAuthApi OAuth => GetApi<OAuthApi>();

        /// <summary>
        /// Gets the <see cref="OrganizationApi"/>.
        /// </summary>
        public OrganizationApi Organization => GetApi<OrganizationApi>();

        /// <summary>
        /// Gets the <see cref="PaymentInApi"/>.
        /// </summary>
        public PaymentInApi PaymentIn => GetApi<PaymentInApi>();

        /// <summary>
        /// Gets the <see cref="PaymentOutApi"/>.
        /// </summary>
        public PaymentOutApi PaymentOut => GetApi<PaymentOutApi>();

        /// <summary>
        /// Gets the <see cref="PriceTypeApi"/>.
        /// </summary>
        public PriceTypeApi PriceType => GetApi<PriceTypeApi>();

        /// <summary>
        /// Gets the <see cref="ProductApi"/>.
        /// </summary>
        public ProductApi Product => GetApi<ProductApi>();

        /// <summary>
        /// Gets the <see cref="ProductFolderApi"/>.
        /// </summary>
        public ProductFolderApi ProductFolder => GetApi<ProductFolderApi>();

        /// <summary>
        /// Gets the <see cref="ProjectApi"/>.
        /// </summary>
        public ProjectApi Project => GetApi<ProjectApi>();

        /// <summary>
        /// Gets the <see cref="PurchaseReturnApi"/>.
        /// </summary>
        public PurchaseReturnApi PurchaseReturn => GetApi<PurchaseReturnApi>();

        /// <summary>
        /// Gets the <see cref="RetailDemandApi"/>.
        /// </summary>
        public RetailDemandApi RetailDemand => GetApi<RetailDemandApi>();

        /// <summary>
        /// Gets the <see cref="RetailSalesReturnApi"/>.
        /// </summary>
        public RetailSalesReturnApi RetailSalesReturn => GetApi<RetailSalesReturnApi>();

        /// <summary>
        /// Gets the <see cref="SalesChannelApi"/>.
        /// </summary>
        public SalesChannelApi SalesChannel => GetApi<SalesChannelApi>();

        /// <summary>
        /// Gets the <see cref="SalesReturnApi"/>.
        /// </summary>
        public SalesReturnApi SalesReturn => GetApi<SalesReturnApi>();

        /// <summary>
        /// Gets the <see cref="ServiceApi"/>.
        /// </summary>
        public ServiceApi Service => GetApi<ServiceApi>();

        /// <summary>
        /// Gets the <see cref="StoreApi"/>.
        /// </summary>
        public StoreApi Store => GetApi<StoreApi>();

        /// <summary>
        /// Gets the <see cref="SupplyApi"/>.
        /// </summary>
        public SupplyApi Supply => GetApi<SupplyApi>();

        /// <summary>
        /// Gets the <see cref="VariantApi"/>.
        /// </summary>
        public VariantApi Variant => GetApi<VariantApi>();

        /// <summary>
        /// Gets the <see cref="WebHookApi"/>.
        /// </summary>
        public WebHookApi WebHook => GetApi<WebHookApi>();
            
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="MoySkladApi" /> class
        /// with MoySklad credentials (optional) and the HTTP client (use defaults if not specified).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public MoySkladApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
        {
            _credentials = credentials;
            _client = httpClient ?? new HttpClient();
            _apiAccessors = new ConcurrentDictionary<string, Lazy<ApiAccessor>>
            {
                [GetApiKey<AssortmentApi>()] = CreateLazyApi<AssortmentApi>(),
                [GetApiKey<BundleApi>()] = CreateLazyApi<BundleApi>(),
                [GetApiKey<CounterpartyApi>()] = CreateLazyApi<CounterpartyApi>(),
                [GetApiKey<CustomerOrderApi>()] = CreateLazyApi<CustomerOrderApi>(),
                [GetApiKey<DemandApi>()] = CreateLazyApi<DemandApi>(),
                [GetApiKey<EnterApi>()] = CreateLazyApi<EnterApi>(),
                [GetApiKey<ExpenseItemApi>()] = CreateLazyApi<ExpenseItemApi>(),
                [GetApiKey<InvoiceOutApi>()] = CreateLazyApi<InvoiceOutApi>(),
                [GetApiKey<LossApi>()] = CreateLazyApi<LossApi>(),
                [GetApiKey<MoveApi>()] = CreateLazyApi<MoveApi>(),
                [GetApiKey<OAuthApi>()] = CreateLazyApi<OAuthApi>(),
                [GetApiKey<OrganizationApi>()] = CreateLazyApi<OrganizationApi>(),
                [GetApiKey<PaymentInApi>()] = CreateLazyApi<PaymentInApi>(),
                [GetApiKey<PaymentOutApi>()] = CreateLazyApi<PaymentOutApi>(),
                [GetApiKey<PriceTypeApi>()] = CreateLazyApi<PriceTypeApi>(),
                [GetApiKey<ProductApi>()] = CreateLazyApi<ProductApi>(),
                [GetApiKey<ProductFolderApi>()] = CreateLazyApi<ProductFolderApi>(),
                [GetApiKey<ProjectApi>()] = CreateLazyApi<ProjectApi>(),
                [GetApiKey<PurchaseReturnApi>()] = CreateLazyApi<PurchaseReturnApi>(),
                [GetApiKey<RetailDemandApi>()] = CreateLazyApi<RetailDemandApi>(),
                [GetApiKey<RetailSalesReturnApi>()] = CreateLazyApi<RetailSalesReturnApi>(),
                [GetApiKey<SalesChannelApi>()] = CreateLazyApi<SalesChannelApi>(),
                [GetApiKey<SalesReturnApi>()] = CreateLazyApi<SalesReturnApi>(),
                [GetApiKey<ServiceApi>()] = CreateLazyApi<ServiceApi>(),
                [GetApiKey<StoreApi>()] = CreateLazyApi<StoreApi>(),
                [GetApiKey<SupplyApi>()] = CreateLazyApi<SupplyApi>(),
                [GetApiKey<VariantApi>()] = CreateLazyApi<VariantApi>(),
                [GetApiKey<WebHookApi>()] = CreateLazyApi<WebHookApi>(),
            };
        }

        #endregion

        #region Utilities

        private void ConfigureAllActiveApi(Action<ApiAccessor> action)
        {
            foreach (var accessor in _apiAccessors)
            {
                if (accessor.Value.IsValueCreated)
                    action(accessor.Value.Value);
            }
        }

        private Lazy<ApiAccessor> CreateLazyApi<TApi>() where TApi : ApiAccessor
        {
            Func<ApiAccessor> factory = () => (TApi)Activator.CreateInstance(
                typeof(TApi), new object[] { _client, _credentials });

            return new Lazy<ApiAccessor>(factory);
        }

        private TApi GetApi<TApi>() where TApi : ApiAccessor
        {
            return (TApi)_apiAccessors[GetApiKey<TApi>()].Value;
        }

        private string GetApiKey<TApi>() where TApi : ApiAccessor
        {
            var apiName = typeof(TApi).Name;
            return apiName.Remove(apiName.IndexOf("Api"));
        }

        #endregion
    }
}