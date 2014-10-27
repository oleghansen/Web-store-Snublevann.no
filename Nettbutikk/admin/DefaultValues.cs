using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.admin
{
    public static class DefaultValues
    {

        public static SelectList ItemsPerPageList 
        { 
            get 
            { 
                return (new SelectList(new List<int> { 5, 10, 25, 50, 100 }, selectedValue: 10)); 
            } 
        }

    }
}
