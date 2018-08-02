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
    ///     <para>bonjour TVLocation</para>
    /// </summary>
    public partial class TVLocationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVLocationService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVLocation tvLocation = validationContext.ObjectInstance as TVLocation;
            tvLocation.HasErrors = false;

            if (string.IsNullOrWhiteSpace(tvLocation.Error))
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVLocationError), new[] { "Error" });
            }

            //Error has no StringLength Attribute

            if (tvLocation.TVItemID < 1)
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.TVLocationTVItemID, "1"), new[] { "TVItemID" });
            }

            if (string.IsNullOrWhiteSpace(tvLocation.TVText))
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVLocationTVText), new[] { "TVText" });
            }

            if (!string.IsNullOrWhiteSpace(tvLocation.TVText) && (tvLocation.TVText.Length < 1 || tvLocation.TVText.Length > 255))
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.TVLocationTVText, "1", "255"), new[] { "TVText" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvLocation.TVType);
            if (tvLocation.TVType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVLocationTVType), new[] { "TVType" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvLocation.SubTVType);
            if (tvLocation.SubTVType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVLocationSubTVType), new[] { "SubTVType" });
            }

            if (!string.IsNullOrWhiteSpace(tvLocation.TVTypeText) && tvLocation.TVTypeText.Length > 100)
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVLocationTVTypeText, "100"), new[] { "TVTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(tvLocation.SubTVTypeText) && tvLocation.SubTVTypeText.Length > 100)
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVLocationSubTVTypeText, "100"), new[] { "SubTVTypeText" });
            }

                //Error: Type not implemented [MapObjList] of type [List`1]

                //Error: Type not implemented [MapObjList] of type [MapObj]
            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
