using X.PagedList;

namespace ECommerceSysCore.Models.DTO
{
    public class MenuDTO
    {
        public string txtSearch { get; set; } = "";
        public int categoryId { get; set; } = 0;
        public List<Category> categoryLst { get; set; }
        public IPagedList<Product> productLst { get; set; }
    }
}
