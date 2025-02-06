namespace Pagination_API_Onion_Generic_Data_MetaData.API.Domain
{
    public class PaginationMetadata //Pagination Metadata Model
    {
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    }
}
