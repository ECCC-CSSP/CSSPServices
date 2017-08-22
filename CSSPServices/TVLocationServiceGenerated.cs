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
    public partial class TVLocationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVLocationService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVLocationError), new[] { "Error" });
            }

            //Error has no StringLength Attribute

            //TVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvLocation.TVItemID < 1)
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVLocationTVItemID, "1"), new[] { "TVItemID" });
            }

            if (string.IsNullOrWhiteSpace(tvLocation.TVText))
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVLocationTVText), new[] { "TVText" });
            }

            if (!string.IsNullOrWhiteSpace(tvLocation.TVText) && (tvLocation.TVText.Length < 1 || tvLocation.TVText.Length > 255))
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVLocationTVText, "1", "255"), new[] { "TVText" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvLocation.TVType);
            if (tvLocation.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVLocationTVType), new[] { "TVType" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvLocation.SubTVType);
            if (tvLocation.SubTVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVLocationSubTVType), new[] { "SubTVType" });
            }

            if (!string.IsNullOrWhiteSpace(tvLocation.TVTypeText) && tvLocation.TVTypeText.Length > 100)
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVLocationTVTypeText, "100"), new[] { "TVTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(tvLocation.SubTVTypeText) && tvLocation.SubTVTypeText.Length > 100)
            {
                tvLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVLocationSubTVTypeText, "100"), new[] { "SubTVTypeText" });
            }

            //HasErrors (bool) is required but no testing needed 

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
