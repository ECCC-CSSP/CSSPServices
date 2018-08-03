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
    ///     <para>bonjour WhereInfo</para>
    /// </summary>
    public partial class WhereInfoService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public WhereInfoService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            WhereInfo whereInfo = validationContext.ObjectInstance as WhereInfo;
            whereInfo.HasErrors = false;

            if (string.IsNullOrWhiteSpace(whereInfo.PropertyName))
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "WhereInfoPropertyName"), new[] { "PropertyName" });
            }

            if (!string.IsNullOrWhiteSpace(whereInfo.PropertyName) && whereInfo.PropertyName.Length > 100)
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "WhereInfoPropertyName", "100"), new[] { "PropertyName" });
            }

            retStr = enums.EnumTypeOK(typeof(PropertyTypeEnum), (int?)whereInfo.PropertyType);
            if (whereInfo.PropertyType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "WhereInfoPropertyType"), new[] { "PropertyType" });
            }

            retStr = enums.EnumTypeOK(typeof(WhereOperatorEnum), (int?)whereInfo.WhereOperator);
            if (whereInfo.WhereOperator == null || !string.IsNullOrWhiteSpace(retStr))
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "WhereInfoWhereOperator"), new[] { "WhereOperator" });
            }

            if (string.IsNullOrWhiteSpace(whereInfo.Value))
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "WhereInfoValue"), new[] { "Value" });
            }

            if (!string.IsNullOrWhiteSpace(whereInfo.Value) && whereInfo.Value.Length > 100)
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "WhereInfoValue", "100"), new[] { "Value" });
            }

            if (whereInfo.ValueInt < -1 || whereInfo.ValueInt > -1)
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "WhereInfoValueInt", "-1", "-1"), new[] { "ValueInt" });
            }

            if (whereInfo.ValueDouble < -1 || whereInfo.ValueDouble > -1)
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "WhereInfoValueDouble", "-1", "-1"), new[] { "ValueDouble" });
            }

            if (whereInfo.ValueDateTime.Year == 1)
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "WhereInfoValueDateTime"), new[] { "ValueDateTime" });
            }
            else
            {
                if (whereInfo.ValueDateTime.Year < 1900)
                {
                whereInfo.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "WhereInfoValueDateTime", "1900"), new[] { "ValueDateTime" });
                }
            }

            if (string.IsNullOrWhiteSpace(whereInfo.ValueEnumText))
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "WhereInfoValueEnumText"), new[] { "ValueEnumText" });
            }

            if (!string.IsNullOrWhiteSpace(whereInfo.ValueEnumText) && whereInfo.ValueEnumText.Length > 100)
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "WhereInfoValueEnumText", "100"), new[] { "ValueEnumText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
