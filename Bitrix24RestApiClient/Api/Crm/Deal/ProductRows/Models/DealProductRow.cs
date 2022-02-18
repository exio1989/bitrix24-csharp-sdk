using Bitrix24RestApiClient.Core.Models;
using Newtonsoft.Json;

#nullable enable

namespace Bitrix24ApiClient.src.Models
{
    public class DealProductRow: AbstractEntity
    {
        /// <summary>
        /// Тип: string	
        /// </summary>
        [JsonProperty(DealProductRowFields.OwnerId)]
        public int? OwnerId { get; set; }

		/// <summary>
		/// Тип: char	
		/// </summary>
		[JsonProperty(DealProductRowFields.OwnerType)]
		public string? OwnerType { get; set; }

		/// <summary>
		/// Тип: int	
		/// </summary>
		[JsonProperty(DealProductRowFields.ProductId)]
		public int? ProductId { get; set; }

		/// <summary>
		/// Тип: string	
		/// </summary>
		[JsonProperty(DealProductRowFields.ProductName)]
		public string? ProductName { get; set; }

		/// <summary>
		/// Тип: string	
		/// </summary>
		[JsonProperty(DealProductRowFields.OriginalProductName)]
		public string? OriginalProductName { get; set; }

		/// <summary>
		/// Тип: string	
		/// </summary>
		[JsonProperty(DealProductRowFields.ProductDescription)]
		public string? ProductDescription { get; set; }

		/// <summary>
		/// Тип: float	
		/// </summary>
		[JsonProperty(DealProductRowFields.Price)]
		public decimal? Price { get; set; }

		/// <summary>
		/// Тип: float	
		/// </summary>
		[JsonProperty(DealProductRowFields.PriceExclusive)]
		public decimal? PriceExclusive { get; set; }

		/// <summary>
		/// Тип: float	
		/// </summary>
		[JsonProperty(DealProductRowFields.PriceNetto)]
		public decimal? PriceNetto { get; set; }

		/// <summary>
		/// Тип: float	
		/// </summary>
		[JsonProperty(DealProductRowFields.PriceBrutto)]
		public decimal? PriceBrutto { get; set; }

		/// <summary>
		/// Тип: float	
		/// </summary>
		[JsonProperty(DealProductRowFields.PriceAccount)]
		public decimal? PriceAccount { get; set; }

		/// <summary>
		/// Тип: float	
		/// </summary>
		[JsonProperty(DealProductRowFields.Quantity)]
		public decimal? Quantity { get; set; }

		/// <summary>
		/// Тип: int	
		/// </summary>
		[JsonProperty(DealProductRowFields.DiscountTypeId)]
		public int? DiscountTypeId { get; set; }

		/// <summary>
		/// Тип: float	
		/// </summary>
		[JsonProperty(DealProductRowFields.DiscountRate)]
		public decimal? DiscountRate { get; set; }

		/// <summary>
		/// Тип: float	
		/// </summary>
		[JsonProperty(DealProductRowFields.DisountSum)]
		public decimal? DisountSum { get; set; }

		/// <summary>
		/// Тип: float	
		/// </summary>
		[JsonProperty(DealProductRowFields.TaxRate)]
		public decimal? TaxRate { get; set; }

		/// <summary>
		/// Тип: char	
		/// </summary>
		[JsonProperty(DealProductRowFields.TaxIncluded)]
		public string? TaxIncluded { get; set; }

		/// <summary>
		/// Тип: char	
		/// </summary>
		[JsonProperty(DealProductRowFields.Customized)]
		public string? Customized { get; set; }

		/// <summary>
		/// Тип: int	
		/// </summary>
		[JsonProperty(DealProductRowFields.MeasureCode)]
		public int? MeasureCode { get; set; }

		/// <summary>
		/// Тип: string	
		/// </summary>
		[JsonProperty(DealProductRowFields.MeasureName)]
		public string? MeasureName { get; set; }

		/// <summary>
		/// Тип: int	
		/// </summary>
		[JsonProperty(DealProductRowFields.Sort)]
		public int? Sort { get; set; }
	}
}
