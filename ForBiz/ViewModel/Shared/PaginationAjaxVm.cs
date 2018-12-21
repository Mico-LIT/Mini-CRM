using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utility.Business.Core.Page.Models;

namespace ForBiz.ViewModel.Shared
{
    public class PaginationAjaxVm
    {
        public PaginationModel Pagination { get; private set; }

        public string NextPageAction { get; private set; }

        public string PreviousPageAction { get; private set; }

        public string ChangePageNumberAction { get; private set; }

        public string ChangePageSizeAction { get; private set; }

        public PaginationAjaxVm(PaginationModel pagination, string nextPageAction, string previousPageAction,
            string changePageNumberAction, string changePageSizeAction)
        {
            Pagination = pagination;
            NextPageAction = nextPageAction;
            PreviousPageAction = previousPageAction;
            ChangePageNumberAction = changePageNumberAction;
            ChangePageSizeAction = changePageSizeAction;
        }
    }
}