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
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.TVLocation](CSSPModels.TVLocation.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [TVTypeEnum](CSSPEnums.TVTypeEnum.html), [TVTypeEnum](CSSPEnums.TVTypeEnum.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class TVLocationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB TVLocations table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public TVLocationService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all TVLocationService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVLocation tvLocation = validationContext.ObjectInstance as TVLocation;
            tvLocation.HasErrors = false;

            if (tvLocation.TVItemID < 1)
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "TVItemID", "1"), new[] { "TVItemID" });
            }

            if (string.IsNullOrWhiteSpace(tvLocation.TVText))
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVText"), new[] { "TVText" });
            }

            if (!string.IsNullOrWhiteSpace(tvLocation.TVText) && (tvLocation.TVText.Length < 1 || tvLocation.TVText.Length > 255))
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "TVText", "1", "255"), new[] { "TVText" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvLocation.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVType"), new[] { "TVType" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvLocation.SubTVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SubTVType"), new[] { "SubTVType" });
            }

            if (!string.IsNullOrWhiteSpace(tvLocation.TVTypeText) && tvLocation.TVTypeText.Length > 100)
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "TVTypeText", "100"), new[] { "TVTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(tvLocation.SubTVTypeText) && tvLocation.SubTVTypeText.Length > 100)
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "SubTVTypeText", "100"), new[] { "SubTVTypeText" });
            }

                //CSSPError: Type not implemented [MapObjList] of type [List`1]

                //CSSPError: Type not implemented [MapObjList] of type [MapObj]
            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
