using System;
namespace Nettbutikk.DAL
{
    interface IProductDAL
    {
        Nettbutikk.Model.Product get(int id);
        System.Collections.Generic.List<Nettbutikk.Model.Product> getAll(int? id, int? sort);
        System.Collections.Generic.List<Nettbutikk.Model.Product> getAll(int? id, string sc, int? sort);
        System.Collections.Generic.List<string> getAutoComplete(string term);
    }
}
