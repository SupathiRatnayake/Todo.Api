namespace Todo.Application.Common
{
    public class PaginationParams
    {
        private const int MaxPageSize = 250;

        private int pageNumber;
        public int PageNumber 
        { 
            get => pageNumber; 
            set => pageNumber = (value < 1) ? 1 : value; 
        }
        private int pageSize = 10;

        public int PageSize
        {
            get => pageSize;
            set => pageSize = (value > MaxPageSize) || (value == 0) ? MaxPageSize : value;
        }
        public int Skip => (PageNumber - 1) * PageSize;

    }
}