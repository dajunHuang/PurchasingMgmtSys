using GameStoreSimple.ViewModelMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreSimple.Helper.CustomExtension
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> Paginate<T> (this IQueryable<T> source, IQueryCollection requireQueryString, Func<string, string> viewModelMappingMethod)
        {
            var skip = Convert.ToInt32(requireQueryString["start"].ToString());
            var take = Convert.ToInt32(requireQueryString["length"].ToString());

            StringValues tempOrder = new StringValues();

            if (requireQueryString.TryGetValue("order[0][column]", out tempOrder))
            {
                var columnIndex = requireQueryString["order[0][column]"].ToString();
                var sortDirection = requireQueryString["order[0][dir]"].ToString();
                tempOrder = new StringValues();
                if (requireQueryString.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                {
                    var columnName = viewModelMappingMethod(columnIndex);

                    if (take > 0)
                    {
                        var propInfo = Utility.GetProperty<T>(columnName);
                        if (sortDirection == "asc")
                        {
                            return source.OrderBy(t => propInfo.GetValue(t)).Skip(skip).Take(take);
                        }
                        else if (sortDirection == "desc")
                        {
                            return source.OrderByDescending(t => propInfo.GetValue(t)).Skip(skip).Take(take);
                        }
                    }
                }
            }

            return source;
        }
    }
}
