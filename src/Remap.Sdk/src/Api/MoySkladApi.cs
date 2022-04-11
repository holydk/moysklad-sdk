using Confiti.MoySklad.Remap.Client;
using System;
using System.Net.Http;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the MoySklad endpoints.
    /// </summary>
    public class MoySkladApi
    {
        #region Fields

        private readonly Lazy<AssortmentApi> _assortmentApi;
        private readonly Lazy<BundleApi> _bundleApi;
        private readonly Lazy<CounterpartyApi> _counterpartyApi;
        private readonly Lazy<CustomerOrderApi> _customerOrderApi;
        private readonly Lazy<DemandApi> _demandApi;
        private readonly Lazy<EnterApi> _enterApi;
        private readonly Lazy<ExpenseItemApi> _expenseItemApi;
        private readonly Lazy<InvoiceOutApi> _invoiceOutApi;
        private readonly Lazy<LossApi> _lossApi;
        private readonly Lazy<MoveApi> _moveApi;
        private readonly Lazy<OAuthApi> _oAuthApi;
        private readonly Lazy<OrganizationApi> _organizationApi;
        private readonly Lazy<PaymentInApi> _paymentInApi;
        private readonly Lazy<PaymentOutApi> _paymentOutApi;
        private readonly Lazy<PriceTypeApi> _priceTypeApi;
        private readonly Lazy<ProductApi> _productApi;
        private readonly Lazy<ProductFolderApi> _productFolderApi;
        private readonly Lazy<ProjectApi> _projectApi;
        private readonly Lazy<PurchaseReturnApi> _purchaseReturnApi;
        private readonly Lazy<RetailDemandApi> _retailDemandApi;
        private readonly Lazy<RetailSalesReturnApi> _retailSalesReturnApi;
        private readonly Lazy<SalesChannelApi> _salesChannelApi;
        private readonly Lazy<SalesReturnApi> _salesReturnApi;
        private readonly Lazy<ServiceApi> _serviceApi;
        private readonly Lazy<StoreApi> _storeApi;
        private readonly Lazy<SupplyApi> _supplyApi;
        private readonly Lazy<VariantApi> _variantApi;
        private readonly Lazy<WebHookApi> _webHookApi;
            
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="HttpClient"/>.
        /// </summary>
        public HttpClient Client { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="MoySkladCredentials"/>.
        /// </summary>
        public MoySkladCredentials Credentials { get; set; }

        /// <summary>
        /// Gets the <see cref="AssortmentApi"/>.
        /// </summary>
        public AssortmentApi Assortment => _assortmentApi.Value;

        /// <summary>
        /// Gets the <see cref="BundleApi"/>.
        /// </summary>
        public BundleApi Bundle => _bundleApi.Value;

        /// <summary>
        /// Gets the <see cref="CounterpartyApi"/>.
        /// </summary>
        public CounterpartyApi Counterparty => _counterpartyApi.Value;

        /// <summary>
        /// Gets the <see cref="CustomerOrderApi"/>.
        /// </summary>
        public CustomerOrderApi CustomerOrder => _customerOrderApi.Value;

        /// <summary>
        /// Gets the <see cref="DemandApi"/>.
        /// </summary>
        public DemandApi Demand => _demandApi.Value;

        /// <summary>
        /// Gets the <see cref="EnterApi"/>.
        /// </summary>
        public EnterApi Enter => _enterApi.Value;

        /// <summary>
        /// Gets the <see cref="ExpenseItemApi"/>.
        /// </summary>
        public ExpenseItemApi ExpenseItem => _expenseItemApi.Value;

        /// <summary>
        /// Gets the <see cref="InvoiceOutApi"/>.
        /// </summary>
        public InvoiceOutApi InvoiceOut => _invoiceOutApi.Value;

        /// <summary>
        /// Gets the <see cref="LossApi"/>.
        /// </summary>
        public LossApi Loss => _lossApi.Value;

        /// <summary>
        /// Gets the <see cref="MoveApi"/>.
        /// </summary>
        public MoveApi Move => _moveApi.Value;

        /// <summary>
        /// Gets the <see cref="OAuthApi"/>.
        /// </summary>
        public OAuthApi OAuth => _oAuthApi.Value;

        /// <summary>
        /// Gets the <see cref="OrganizationApi"/>.
        /// </summary>
        public OrganizationApi Organization => _organizationApi.Value;

        /// <summary>
        /// Gets the <see cref="PaymentInApi"/>.
        /// </summary>
        public PaymentInApi PaymentIn => _paymentInApi.Value;

        /// <summary>
        /// Gets the <see cref="PaymentOutApi"/>.
        /// </summary>
        public PaymentOutApi PaymentOut => _paymentOutApi.Value;

        /// <summary>
        /// Gets the <see cref="PriceTypeApi"/>.
        /// </summary>
        public PriceTypeApi PriceType => _priceTypeApi.Value;

        /// <summary>
        /// Gets the <see cref="ProductApi"/>.
        /// </summary>
        public ProductApi Product => _productApi.Value;

        /// <summary>
        /// Gets the <see cref="ProductFolderApi"/>.
        /// </summary>
        public ProductFolderApi ProductFolder => _productFolderApi.Value;

        /// <summary>
        /// Gets the <see cref="ProjectApi"/>.
        /// </summary>
        public ProjectApi Project => _projectApi.Value;

        /// <summary>
        /// Gets the <see cref="PurchaseReturnApi"/>.
        /// </summary>
        public PurchaseReturnApi PurchaseReturn => _purchaseReturnApi.Value;

        /// <summary>
        /// Gets the <see cref="RetailDemandApi"/>.
        /// </summary>
        public RetailDemandApi RetailDemand => _retailDemandApi.Value;

        /// <summary>
        /// Gets the <see cref="RetailSalesReturnApi"/>.
        /// </summary>
        public RetailSalesReturnApi RetailSalesReturn => _retailSalesReturnApi.Value;

        /// <summary>
        /// Gets the <see cref="SalesChannelApi"/>.
        /// </summary>
        public SalesChannelApi SalesChannel => _salesChannelApi.Value;

        /// <summary>
        /// Gets the <see cref="SalesReturnApi"/>.
        /// </summary>
        public SalesReturnApi SalesReturn => _salesReturnApi.Value;

        /// <summary>
        /// Gets the <see cref="ServiceApi"/>.
        /// </summary>
        public ServiceApi Service => _serviceApi.Value;

        /// <summary>
        /// Gets the <see cref="StoreApi"/>.
        /// </summary>
        public StoreApi Store => _storeApi.Value;

        /// <summary>
        /// Gets the <see cref="SupplyApi"/>.
        /// </summary>
        public SupplyApi Supply => _supplyApi.Value;

        /// <summary>
        /// Gets the <see cref="VariantApi"/>.
        /// </summary>
        public VariantApi Variant => _variantApi.Value;

        /// <summary>
        /// Gets the <see cref="WebHookApi"/>.
        /// </summary>
        public WebHookApi WebHook => _webHookApi.Value;
            
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="MoySkladApi" /> class
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public MoySkladApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
        {
            Credentials = credentials;

            Client = httpClient ?? new HttpClient();

            if (Client.BaseAddress == null)
                Client.BaseAddress = new Uri(ApiDefaults.DEFAULT_BASE_PATH);

            if (!Client.DefaultRequestHeaders.Contains("UserAgent"))
                Client.DefaultRequestHeaders.Add("UserAgent", ApiDefaults.DEFAULT_USER_AGENT);

            if (!Client.DefaultRequestHeaders.Contains("Accept"))
                Client.DefaultRequestHeaders.Add("Accept", "*/*");
            
            _assortmentApi = new Lazy<AssortmentApi>(CreateApi<AssortmentApi>);
            _bundleApi = new Lazy<BundleApi>(CreateApi<BundleApi>);
            _counterpartyApi = new Lazy<CounterpartyApi>(CreateApi<CounterpartyApi>);
            _customerOrderApi = new Lazy<CustomerOrderApi>(CreateApi<CustomerOrderApi>);
            _demandApi = new Lazy<DemandApi>(CreateApi<DemandApi>);
            _enterApi = new Lazy<EnterApi>(CreateApi<EnterApi>);
            _expenseItemApi = new Lazy<ExpenseItemApi>(CreateApi<ExpenseItemApi>);
            _invoiceOutApi = new Lazy<InvoiceOutApi>(CreateApi<InvoiceOutApi>);
            _lossApi = new Lazy<LossApi>(CreateApi<LossApi>);
            _moveApi = new Lazy<MoveApi>(CreateApi<MoveApi>);
            _oAuthApi = new Lazy<OAuthApi>(CreateApi<OAuthApi>);
            _organizationApi = new Lazy<OrganizationApi>(CreateApi<OrganizationApi>);
            _paymentInApi = new Lazy<PaymentInApi>(CreateApi<PaymentInApi>);
            _paymentOutApi = new Lazy<PaymentOutApi>(CreateApi<PaymentOutApi>);
            _priceTypeApi = new Lazy<PriceTypeApi>(CreateApi<PriceTypeApi>);
            _productApi = new Lazy<ProductApi>(CreateApi<ProductApi>);
            _productFolderApi = new Lazy<ProductFolderApi>(CreateApi<ProductFolderApi>);
            _projectApi = new Lazy<ProjectApi>(CreateApi<ProjectApi>);
            _purchaseReturnApi = new Lazy<PurchaseReturnApi>(CreateApi<PurchaseReturnApi>);
            _retailDemandApi = new Lazy<RetailDemandApi>(CreateApi<RetailDemandApi>);
            _retailSalesReturnApi = new Lazy<RetailSalesReturnApi>(CreateApi<RetailSalesReturnApi>);
            _salesChannelApi = new Lazy<SalesChannelApi>(CreateApi<SalesChannelApi>);
            _salesReturnApi = new Lazy<SalesReturnApi>(CreateApi<SalesReturnApi>);
            _serviceApi = new Lazy<ServiceApi>(CreateApi<ServiceApi>);
            _storeApi = new Lazy<StoreApi>(CreateApi<StoreApi>);
            _supplyApi = new Lazy<SupplyApi>(CreateApi<SupplyApi>);
            _variantApi = new Lazy<VariantApi>(CreateApi<VariantApi>);
            _webHookApi = new Lazy<WebHookApi>(CreateApi<WebHookApi>);
        }

        #endregion

        #region Utilities

        private TApi CreateApi<TApi>() where TApi : ApiAccessor
        {
            return (TApi)Activator.CreateInstance(
                typeof(TApi), new object[] { (Func<MoySkladCredentials>)(() => Credentials), (Func<HttpClient>)(() => Client) });
        }
            
        #endregion
    }
}