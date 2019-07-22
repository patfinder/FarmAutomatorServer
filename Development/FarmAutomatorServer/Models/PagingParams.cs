using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisitMeServer.Models
{
    public class PagingParams
    {
        public int? PageIndex { get; set; }

        public int? PageSize { get; set; }
    }

    public class TypedPagingParams : PagingParams
    {
        public string Type { get; set; }
    }

}