using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.BLL
{
    public class CategoryBLL : BLL.ICategoryBLL
    {
        private ICategoryDAL _catecory;

        public CategoryBLL()
        {
            _catecory = new CategoryDAL();
        }

        public CategoryBLL(ICategoryDAL stub)
        {
            _catecory = stub;
        }
    }
}
