namespace Seed.Web.Uipc.ViewModels
{
    public class PagingVm
    {
        private const int DefaultPagenumber = 1;

        private const int DefaultpageSize = 10;

        private int _pageNumber;

        private int _pageSize;

        public int TotalCount { get; set; }

        public int PageNumber
        {
            get { return _pageNumber == 0 ? DefaultPagenumber : _pageNumber; }
            set { _pageNumber = value; }
        }

        public int PageSize
        {
            get { return _pageSize == 0 ? DefaultpageSize : _pageSize; }
            set { _pageSize = value; }
        }
    }
}