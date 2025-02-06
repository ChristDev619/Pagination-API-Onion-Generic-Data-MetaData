namespace Pagination_API_Onion_Generic_Data_MetaData.API.Domain
{
    public class PaginatedResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
        public PaginationMetadata Metadata { get; set; }
    }
}
