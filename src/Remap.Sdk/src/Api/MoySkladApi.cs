using Confiti.MoySklad.Remap.Client;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
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

		#endregion Fields

		#region Properties

		/// <summary>
		/// Gets the <see cref="AssortmentApi"/>.
		/// </summary>
		public AssortmentApi Assortment => GetApi<AssortmentApi>();

		/// <summary>
		/// Gets the <see cref="BundleApi"/>.
		/// </summary>
		public BundleApi Bundle => GetApi<BundleApi>();

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
		/// Gets the <see cref="CounterpartyApi"/>.
		/// </summary>
		public CounterpartyApi Counterparty => GetApi<CounterpartyApi>();

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
		/// Gets the <see cref="ReportProfitApi"/>.
		/// </summary>
		public ReportProfitApi ReportProfit => GetApi<ReportProfitApi>();

		/// <summary>
		/// Gets the <see cref="RetailDemandApi"/>.
		/// </summary>
		public RetailDemandApi RetailDemand => GetApi<RetailDemandApi>();

		/// <summary>
		/// Gets the <see cref="RetailSalesReturnApi"/>.
		/// </summary>
		public RetailSalesReturnApi RetailSalesReturn => GetApi<RetailSalesReturnApi>();

		/// <summary>
		/// Gets the <see cref="RetailShiftApi"/>.
		/// </summary>
		public RetailShiftApi RetailShift => GetApi<RetailShiftApi>();

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
		/// Gets the <see cref="TaskApi"/>.
		/// </summary>
		public TaskApi Task => GetApi<TaskApi>();

		/// <summary>
		/// Gets the <see cref="VariantApi"/>.
		/// </summary>
		public VariantApi Variant => GetApi<VariantApi>();

		/// <summary>
		/// Gets the <see cref="WebHookApi"/>.
		/// </summary>
		public WebHookApi WebHook => GetApi<WebHookApi>();

		#endregion Properties

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
			_apiAccessors = new ConcurrentDictionary<string, Lazy<ApiAccessor>>();

			if (httpClient != null)
				_client = httpClient;
			else
			{
				var httpClientHandler = new HttpClientHandler()
				{
					AutomaticDecompression = DecompressionMethods.GZip
				};

				_client = new HttpClient(httpClientHandler);
			}

			var typesToExclude = new[]
			{
				typeof(ImageApi),
				typeof(MetadataApi<>),
				typeof(MetadataApi<,>)
			};
			var availableTypes = typeof(MoySkladApi).Assembly.GetTypes().Where(type =>
			{
				return type.IsSubclassOf(typeof(ApiAccessor))
					&& !type.IsAbstract
						&& type.IsClass
							&& !typesToExclude.Contains(type);
			});

			foreach (var type in availableTypes)
				_apiAccessors[GetApiKey(type)] = CreateLazyApi(type);
		}

		#endregion Ctor

		#region Utilities

		private static string GetApiKey(Type apiType)
		{
			var apiName = apiType.Name;

			return apiName.Remove(apiName.IndexOf("Api", StringComparison.Ordinal));
		}

		private void ConfigureAllActiveApi(Action<ApiAccessor> action)
		{
			foreach (var accessor in _apiAccessors)
			{
				if (accessor.Value.IsValueCreated)
					action(accessor.Value.Value);
			}
		}

		private Lazy<ApiAccessor> CreateLazyApi(Type apiType)
		{
			ApiAccessor Factory() => (ApiAccessor)Activator.CreateInstance(apiType, _client, _credentials);

			return new Lazy<ApiAccessor>(Factory);
		}

		private TApi GetApi<TApi>() where TApi : ApiAccessor
		{
			return (TApi)_apiAccessors[GetApiKey(typeof(TApi))].Value;
		}

		#endregion Utilities
	}
}