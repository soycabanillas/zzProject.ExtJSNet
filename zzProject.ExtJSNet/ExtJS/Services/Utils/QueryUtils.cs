using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
//using Microsoft.QueryComposition.Server;

namespace zzProject.MVCExtender.ExtJS.Services.Utils
{
    public class QueryUtils
    {
        public class PaginableQueryResult<TEntity>
        {
            public IQueryable<TEntity> Query;
            public IQueryable<TEntity> QueryByPage;
        }

        public static PaginableQueryResult<TEntity> GetFilteredAndPaginableResult<TEntity>(IQueryable<TEntity> originalQuery, Uri url)
        {
            //NameValueCollection urlSplitted = QueryTranslator.GetQueryParameters(url.OriginalString);
            //urlSplitted.Remove("$top");
            //urlSplitted.Remove("$skip");
            //string filteredURL = string.Join("&", urlSplitted);
            //IQueryable<TEntity> query = (IQueryable<TEntity>)QueryTranslator.Translate(originalQuery, filteredURL);
            //IQueryable<TEntity> queryByPage = (IQueryable<TEntity>)QueryTranslator.Translate(originalQuery, url);

            IQueryable<TEntity> query = (IQueryable<TEntity>)zzProject.Utils.Linq.OData.Query.Translate(originalQuery, url, false);
            IQueryable<TEntity> queryByPage = (IQueryable<TEntity>)zzProject.Utils.Linq.OData.Query.Translate(originalQuery, url, true);



            return new PaginableQueryResult<TEntity>()
            {
                Query = query,
                QueryByPage = queryByPage
            };
        }

        public static IQueryable<TEntity> QueryComposedByURLQuery<TEntity>(IQueryable<TEntity> query, Uri uri)
        {
            return (IQueryable<TEntity>)zzProject.Utils.Linq.OData.Query.Translate(query, uri, true);
        }
    }
}