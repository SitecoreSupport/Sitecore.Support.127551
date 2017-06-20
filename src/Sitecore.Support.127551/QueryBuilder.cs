using Sitecore.ContentSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Support
{
    class QueryBuilder : Sitecore.ContentSearch.Utilities.QueryBuilder
    {
        protected override Type ResolveFieldTypeByName(string fieldName, IProviderSearchContext context)
        {
            string str;
            if (context == null)
            {
                return null;
            }
            if (context.Index == null)
            {
                return null;
            }
            if (context.Index.Configuration == null)
            {
                return null;
            }
            IFieldMap fieldMap = context.Index.Configuration.FieldMap;
            if (fieldMap == null)
            {
                return null;
            }
            AbstractSearchFieldConfiguration fieldConfiguration = fieldMap.GetFieldConfiguration(fieldName);
            if (fieldConfiguration == null)
            {
                return null;
            }
            if (!fieldConfiguration.Attributes.TryGetValue("type", out str))
            {
                return null;
            }
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            return Type.GetType(str, false);
        }

    }
}
