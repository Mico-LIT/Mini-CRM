using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Business.Core.Page.Requests;

namespace Utility.Business.Core.Page.Models
{
    public class PaginationModel : PageRequest
    {
        public int TotalCount { get; private set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalCount/base.Size);

        public int NextPage => base.Page < TotalPages ? Page + 1 : TotalPages;

        public int PreviousPage => Page > 1 ? Page - 1 : 1;

        public PaginationModel(PageRequest pageRequest, int totalCount)
        {
            base.Page = pageRequest.Page;
            base.Size = pageRequest.Size;
            this.TotalCount = totalCount;
        }
    }
}
