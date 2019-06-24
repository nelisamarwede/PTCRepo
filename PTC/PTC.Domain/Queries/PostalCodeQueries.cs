using PTC.Domain.Entities;
using PTC.Domain.Queries.Providers;
using System.Collections.Generic;
using System.Linq;

namespace PTC.Domain.Queries
{
    public static class PostalCodeQueries
    {
        public static IEnumerable<PostalCode> GetPostalCodeTaxTypes(IQueryProvider<PostalCode> postalCodeQueryProvider, IQueryProvider<TaxType> taxCalculationTypesQueryProvider)
        {
            var taxTypes = taxCalculationTypesQueryProvider.Query.ToList();

            return (from m in postalCodeQueryProvider.Query.ToList()
                     select new PostalCode
                     {
                         Id = m.Id,
                         CodeName = m.CodeName,
                         TaxTypeId = m.TaxTypeId,
                         TaxType = taxTypes.FirstOrDefault(i => i.Id == m.TaxTypeId)
                     }).ToList();
            
        }
    }
}
