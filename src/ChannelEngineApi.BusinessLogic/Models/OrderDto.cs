namespace ChannelEngineApi.BusinessLogic.Models
{
    public class OrderContent
    {
        public List<OrderDto> Content { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int StatusCode { get; set; }
        public long? LogId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public ValidationError ValidationErrors { get; set; }
    }
    
    public record OrderDto
    {
        public long Id { get; set; }
        public string ChannelName { get; set; }
        public long ChannelId { get; set; }
        public string GlobalChannelName { get; set; }
        public long GlobalChannelId { get; set; }
        public string ChannelOrderNo { get; set; }
        public string MerchantOrderNo { get; set; }
        public string Status { get; set; } // todo enum
        public bool IsBusinessOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string MerchantComment { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public decimal SubTotalInclVat { get; set; }
        public decimal SubTotalVat { get; set; }
        public decimal ShippingCostsVat { get; set; }
        public decimal TotalInclVat { get; set; }
        public decimal TotalVat { get; set; }
        public decimal OriginalSubTotalInclVat { get; set; }
        public decimal OriginalSubTotalVat { get; set; }
        public decimal OriginalShippingCostsInclVat { get; set; }
        public decimal OriginalShippingCostsVat { get; set; }
        public decimal OriginalTotalInclVat { get; set; }
        public decimal OriginalTotalVat { get; set; }
        public List<Line> Lines { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CompanyRegistrationNo { get; set; }
        public string VatNo { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentReferenceNo { get; set; }
        public decimal ShippingCostsInclVat { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime OrderDate { get; set; }
        public string ChannelCustomerNo { get; set; }
        public ExtraData ExtraData { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Gender { get; set; } // todo enum
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNr { get; set; }
        public string HouseNrAddition { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string CountryIso { get; set; }
        public string Original { get; set; }
    }

    public class Line
    {
        public string Status { get; set; } // todo enum
        public bool IsFulfillmentByMarketplace { get; set; }
        public string Gtin { get; set; }
        public string Description { get; set; }
        public StockLocation StockLocation { get; set; }
        public decimal UnitVat { get; set; }
        public decimal LineTotalInclVat { get; set; }
        public decimal LineVat { get; set; }
        public decimal OriginalUnitPriceInclVat { get; set; }
        public decimal OriginalUnitVat { get; set; }
        public decimal OriginalLineTotalInclVat { get; set; }
        public decimal OriginalLineVat { get; set; }
        public decimal OriginalFeeFixed { get; set; }
        public string BundleProductMerchantProductNo { get; set; }
        public string JurisCode { get; set; }
        public string JurisName { get; set; }
        public decimal VatRate { get; set; }
        public List<LineExtraData> ExtraData { get; set; }
        public string ChannelProductNo { get; set; }
        public string MerchantProductNo { get; set; }
        public long Quantity { get; set; }
        public long CancellationRequestedQuantity { get; set; }
        public decimal UnitPriceInclVat { get; set; }
        public decimal FeeFixed { get; set; }
        public decimal FeeRate { get; set; }
        public string Condition { get; set; } // todo enum
        public DateTime ExpectedDeliveryDate { get; set; }
    }

    public class StockLocation
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class LineExtraData
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class ExtraData
    {
        public string additionalProp1 { get; set; }
        public string additionalProp2 { get; set; }
        public string additionalProp3 { get; set; }
    }
    
    public class ValidationError
    {
        public List<string> additionalProp1 { get; set; }
        public List<string> additionalProp2 { get; set; }
        public List<string> additionalProp3 { get; set; }
    }
}