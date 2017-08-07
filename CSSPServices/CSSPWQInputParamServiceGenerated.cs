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
    public partial class CSSPWQInputParamService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CSSPWQInputParamService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            CSSPWQInputParam cSSPWQInputParam = validationContext.ObjectInstance as CSSPWQInputParam;

            retStr = enums.CSSPWQInputTypeOK(cSSPWQInputParam.CSSPWQInputType);
            if (cSSPWQInputParam.CSSPWQInputType == CSSPWQInputTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPWQInputParamCSSPWQInputType), new[] { "CSSPWQInputType" });
            }

            if (string.IsNullOrWhiteSpace(cSSPWQInputParam.Name))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPWQInputParamName), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(cSSPWQInputParam.Name) && (cSSPWQInputParam.Name.Length < 1 || cSSPWQInputParam.Name.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.CSSPWQInputParamName, "1", "200"), new[] { "Name" });
            }

            //TVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (cSSPWQInputParam.TVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.CSSPWQInputParamTVItemID, "1"), new[] { "TVItemID" });
            }

            if (!string.IsNullOrWhiteSpace(cSSPWQInputParam.CSSPWQInputTypeText) && cSSPWQInputParam.CSSPWQInputTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.CSSPWQInputParamCSSPWQInputTypeText, "100"), new[] { "CSSPWQInputTypeText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
