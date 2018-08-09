using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPServices
{
    /// <summary>
    ///     <para>bonjour Query</para>
    /// </summary>
    public partial class QueryService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public QueryService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Query query = validationContext.ObjectInstance as Query;
            query.HasErrors = false;

                //Error: Type not implemented [ModelType] of type [Type]

                //Error: Type not implemented [ModelType] of type [Type]
            if (query.Language != null)
            {
                retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)query.Language);
                if (query.Language == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    query.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "QueryLanguage"), new[] { "Language" });
                }
            }

            if (string.IsNullOrWhiteSpace(query.Lang))
            {
                query.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "QueryLang"), new[] { "Lang" });
            }

            if (!string.IsNullOrWhiteSpace(query.Lang) && query.Lang.Length > 2)
            {
                query.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "QueryLang", "2"), new[] { "Lang" });
            }

            if (query.Skip < 0 || query.Skip > 1000000)
            {
                query.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "QuerySkip", "0", "1000000"), new[] { "Skip" });
            }

            if (query.Take < 1 || query.Take > 1000000)
            {
                query.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "QueryTake", "1", "1000000"), new[] { "Take" });
            }

            if (string.IsNullOrWhiteSpace(query.Order))
            {
                query.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "QueryOrder"), new[] { "Order" });
            }

            if (!string.IsNullOrWhiteSpace(query.Order) && query.Order.Length > 200)
            {
                query.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "QueryOrder", "200"), new[] { "Order" });
            }

            if (string.IsNullOrWhiteSpace(query.Where))
            {
                query.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "QueryWhere"), new[] { "Where" });
            }

            if (!string.IsNullOrWhiteSpace(query.Where) && query.Where.Length > 200)
            {
                query.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "QueryWhere", "200"), new[] { "Where" });
            }

            if (string.IsNullOrWhiteSpace(query.Detail))
            {
                query.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "QueryDetail"), new[] { "Detail" });
            }

            if (!string.IsNullOrWhiteSpace(query.Detail) && query.Detail.Length > 1)
            {
                query.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "QueryDetail", "1"), new[] { "Detail" });
            }

                //Error: Type not implemented [OrderList] of type [List`1]

            //OrderList has no StringLength Attribute

                //Error: Type not implemented [WhereInfoList] of type [List`1]

                //Error: Type not implemented [WhereInfoList] of type [WhereInfo]
            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                query.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
