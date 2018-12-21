using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Business.Core.Page.Requests
{
    public class PageRequest
    {
        protected static int DefaultPageSize = 10;
        protected static int MaxPageSize= 100;

        private int _page = 1;
        public int Page
        {
            get
            {
                return _page;
            }
            set
            {
                _page = value <= 0 ? 1 : value;
            }
        }

        private int _size = DefaultPageSize;
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size =
                    value <= 0 ? DefaultPageSize :
                    value > MaxPageSize ? MaxPageSize :
                    value;
            }
        }
    }
}
