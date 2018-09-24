using SiteECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteECommerce.Classes
{
    public class CombosHelper : IDisposable
    {
        private static EcommerceContext db = new EcommerceContext();
        public static List<Departaments> GetDepartaments()
        {

            var dep = db.Departaments.ToList();
            dep.Add(new Departaments
            {
                DepartamentsId = 0,
                Name = "[ Selecione um Departamento ]"
            });

           return dep = dep.OrderBy(d => d.Name).ToList();
        }
        public static List<City> GetCities()
        {

            var dep = db.Cities.ToList();
            dep.Add(new City
            {
                DepartamentsId = 0,
                Name = "[ Selecione um Cidade ]"
            });

            return dep = dep.OrderBy(d => d.Name).ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public static List<Company> GetCompany()
        {

            var comp = db.Companies.ToList();
            comp.Add(new Company
            {
                CompanyId = 0,
                Name = "[ Selecione um Compania ]"
            });

            return comp = comp.OrderBy(d => d.Name).ToList();
        }
    }
}