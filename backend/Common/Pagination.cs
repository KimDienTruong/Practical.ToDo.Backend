namespace backend.Abstracts
{
    public class Pagination
    {
        public int TotalCount { get; } = 0;
        public int PageIndex { get; } = 1;
        public int PageSize { get; } = 5;


        public Pagination(int totalCount, int pageIndex, int pageSize)
        {
            TotalCount = totalCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
