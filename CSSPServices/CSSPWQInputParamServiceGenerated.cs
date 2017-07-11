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
        public CSSPWQInputParamService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            CSSPWQInputParam cSSPWQInputParam = validationContext.ObjectInstance as CSSPWQInputParam;

                //Error: Type not implemented [CSSPWQInputType] of type [CSSPWQInputTypeEnum]

                //Error: Type not implemented [CSSPWQInputType] of type [CSSPWQInputTypeEnum]
            if (string.IsNullOrWhiteSpace(cSSPWQInputParam.Name))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPWQInputParamName), new[] { ModelsRes.CSSPWQInputParamName });
            }

            if (!string.IsNullOrWhiteSpace(cSSPWQInputParam.Name) && (cSSPWQInputParam.Name.Length < 1 || cSSPWQInputParam.Name.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.CSSPWQInputParamName, "1", "200"), new[] { ModelsRes.CSSPWQInputParamName });
            }

            //TVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (cSSPWQInputParam.TVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.CSSPWQInputParamTVItemID, "1"), new[] { ModelsRes.CSSPWQInputParamTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
