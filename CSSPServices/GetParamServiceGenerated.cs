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
    ///     <para>bonjour GetParam</para>
    /// </summary>
    public partial class GetParamService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public GetParamService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            GetParam getParam = validationContext.ObjectInstance as GetParam;
            getParam.HasErrors = false;

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)getParam.Language);
            if (getParam.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                getParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.GetParamLanguage), new[] { "Language" });
            }

            if (getParam.Skip < 0)
            {
                getParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.GetParamSkip, "0"), new[] { "Skip" });
            }

            if (getParam.Take < 0)
            {
                getParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.GetParamTake, "0"), new[] { "Take" });
            }

                //Error: Type not implemented [EntityQueryDetailType] of type [EntityQueryDetailTypeEnum]

                //Error: Type not implemented [EntityQueryDetailType] of type [EntityQueryDetailTypeEnum]
                //Error: Type not implemented [EntityQueryType] of type [EntityQueryTypeEnum]

                //Error: Type not implemented [EntityQueryType] of type [EntityQueryTypeEnum]
            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                getParam.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
