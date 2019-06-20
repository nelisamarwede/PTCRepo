using PTC.Domain.Entities;
using PTC.Domain.Queries.Providers;
using System.Collections.Generic;
using System.Linq;

namespace PTC.Domain.Queries
{
    public static class PostalCodeQueries
    {

        public static IQueryable<TaxType> TaxList
        {
            get
            {
                var list = new List<TaxType>();

                list.Add(new TaxType
                {
                    Id = 1,
                    TypeName = "Progressive"
                });

                list.Add(new TaxType
                {
                    Id = 2,
                    TypeName = "Flat Value"
                });
                list.Add(new TaxType
                {
                    Id = 1,
                    TypeName = "Flat Rate"
                });
                return list.AsQueryable();
            }
        }


        public static IEnumerable<PostalCode> GetPostalCodeTaxTypes(IQueryProvider<PostalCode> postalCodeQueryProvider, IQueryProvider<TaxType> taxCalculationTypesQueryProvider)
        {
            var test = postalCodeQueryProvider.Query.ToList();
            var p = (from m in postalCodeQueryProvider.Query.ToList()
                     select new PostalCode
                     {
                         Id = m.Id,
                         CodeName = m.CodeName,
                         TaxTypeId = m.TaxTypeId,
                         TaxType = TaxList.FirstOrDefault(i => i.Id == m.TaxTypeId)
                     }).ToList();
            return p;
        }
    }
}
