namespace MVC.Helper
{
    interface IPagedList
    {
        int TotalCount { get; }     //source result 
        int TotalPageCount { get; }
        int CurrentPageNum { get; }    // = how many pages needed to skip, default is 0 at the beginning
        int PageSize { get; }       //how many elements in one page
    }
}