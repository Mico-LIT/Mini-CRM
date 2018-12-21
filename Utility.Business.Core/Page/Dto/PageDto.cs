namespace Utility.Business.Core.Page.Dto
{
    using System.Collections.Generic;
    using Utility.Business.Core.Page.Models;
    using Utility.Business.Core.Page.Requests;

    public class PageDto<T>
    {
        public List<T> Items { get; set; }

        public PaginationModel Pagination { get; private set; }

        public PageDto(List<T> items, PageRequest pageRequest, int totalCount)
        {
            this.Items = items;
            Pagination = new PaginationModel(pageRequest, totalCount);

        }
    }
}
