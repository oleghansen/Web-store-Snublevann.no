using System;
namespace Nettbutikk.BLL
{
    public interface IProductBLL
    {
        System.Collections.Generic.List<Nettbutikk.Model.Product> getAll();
    }
}
