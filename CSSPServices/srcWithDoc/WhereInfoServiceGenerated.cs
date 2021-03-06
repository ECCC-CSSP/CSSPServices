/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
    /// > [!NOTE]
    /// > 
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.WhereInfo](CSSPModels.WhereInfo.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [PropertyTypeEnum](CSSPEnums.PropertyTypeEnum.html), [WhereOperatorEnum](CSSPEnums.WhereOperatorEnum.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class WhereInfoService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB WhereInfos table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public WhereInfoService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all WhereInfoService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            WhereInfo whereInfo = validationContext.ObjectInstance as WhereInfo;
            whereInfo.HasErrors = false;

            if (string.IsNullOrWhiteSpace(whereInfo.PropertyName))
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PropertyName"), new[] { "PropertyName" });
            }

            if (!string.IsNullOrWhiteSpace(whereInfo.PropertyName) && whereInfo.PropertyName.Length > 100)
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "PropertyName", "100"), new[] { "PropertyName" });
            }

            retStr = enums.EnumTypeOK(typeof(PropertyTypeEnum), (int?)whereInfo.PropertyType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PropertyType"), new[] { "PropertyType" });
            }

            retStr = enums.EnumTypeOK(typeof(WhereOperatorEnum), (int?)whereInfo.WhereOperator);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "WhereOperator"), new[] { "WhereOperator" });
            }

            if (string.IsNullOrWhiteSpace(whereInfo.Value))
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Value"), new[] { "Value" });
            }

            if (!string.IsNullOrWhiteSpace(whereInfo.Value) && whereInfo.Value.Length > 100)
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "Value", "100"), new[] { "Value" });
            }

            if (whereInfo.ValueInt < -1 || whereInfo.ValueInt > -1)
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ValueInt", "-1", "-1"), new[] { "ValueInt" });
            }

            if (whereInfo.ValueDouble < -1 || whereInfo.ValueDouble > -1)
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ValueDouble", "-1", "-1"), new[] { "ValueDouble" });
            }

            if (whereInfo.ValueDateTime.Year == 1)
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ValueDateTime"), new[] { "ValueDateTime" });
            }
            else
            {
                if (whereInfo.ValueDateTime.Year < 1900)
                {
                whereInfo.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ValueDateTime", "1900"), new[] { "ValueDateTime" });
                }
            }

            if (string.IsNullOrWhiteSpace(whereInfo.ValueEnumText))
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ValueEnumText"), new[] { "ValueEnumText" });
            }

            if (!string.IsNullOrWhiteSpace(whereInfo.ValueEnumText) && whereInfo.ValueEnumText.Length > 100)
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ValueEnumText", "100"), new[] { "ValueEnumText" });
            }

                //CSSPError: Type not implemented [EnumType] of type [Type]

                //CSSPError: Type not implemented [EnumType] of type [Type]
            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                whereInfo.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
