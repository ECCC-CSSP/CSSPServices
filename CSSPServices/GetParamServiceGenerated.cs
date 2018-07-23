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

                //Error: Type not implemented [ModelType] of type [Type]

                //Error: Type not implemented [ModelType] of type [Type]
            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)getParam.Language);
            if (getParam.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                getParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.GetParamLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(getParam.Lang))
            {
                getParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.GetParamLang), new[] { "Lang" });
            }

            if (!string.IsNullOrWhiteSpace(getParam.Lang) && getParam.Lang.Length > 2)
            {
                getParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.GetParamLang, "2"), new[] { "Lang" });
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

            if (string.IsNullOrWhiteSpace(getParam.OrderByNames))
            {
                getParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.GetParamOrderByNames), new[] { "OrderByNames" });
            }

            if (!string.IsNullOrWhiteSpace(getParam.OrderByNames) && getParam.OrderByNames.Length > 200)
            {
                getParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.GetParamOrderByNames, "200"), new[] { "OrderByNames" });
            }

            if (string.IsNullOrWhiteSpace(getParam.Where))
            {
                getParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.GetParamWhere), new[] { "Where" });
            }

            if (!string.IsNullOrWhiteSpace(getParam.Where) && getParam.Where.Length > 200)
            {
                getParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.GetParamWhere, "200"), new[] { "Where" });
            }

            retStr = enums.EnumTypeOK(typeof(EntityQueryDetailTypeEnum), (int?)getParam.EntityQueryDetailType);
            if (getParam.EntityQueryDetailType == EntityQueryDetailTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                getParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.GetParamEntityQueryDetailType), new[] { "EntityQueryDetailType" });
            }

            retStr = enums.EnumTypeOK(typeof(EntityQueryTypeEnum), (int?)getParam.EntityQueryType);
            if (getParam.EntityQueryType == EntityQueryTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                getParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.GetParamEntityQueryType), new[] { "EntityQueryType" });
            }

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
