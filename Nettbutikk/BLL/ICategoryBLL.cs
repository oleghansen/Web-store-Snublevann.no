using Nettbutikk.Model;
using System;
using System.Collections.Generic;

namespace Nettbutikk.BLL
{
    public interface ICategoryBLL
    {
        List<Category> getAll(int? id);
        List<Category> getResult(int? id, string sc);
    }
}
