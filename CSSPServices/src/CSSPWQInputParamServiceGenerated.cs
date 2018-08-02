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
    ///     <para>bonjour CSSPWQInputParam</para>
    /// </summary>
    public partial class CSSPWQInputParamService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CSSPWQInputParamService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            CSSPWQInputParam cSSPWQInputParam = validationContext.ObjectInstance as CSSPWQInputParam;
            cSSPWQInputParam.HasErrors = false;

            retStr = enums.EnumTypeOK(typeof(CSSPWQInputTypeEnum), (int?)cSSPWQInputParam.CSSPWQInputType);
            if (cSSPWQInputParam.CSSPWQInputType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                cSSPWQInputParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPWQInputParamCSSPWQInputType), new[] { "CSSPWQInputType" });
            }

            if (string.IsNullOrWhiteSpace(cSSPWQInputParam.Name))
            {
                cSSPWQInputParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPWQInputParamName), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(cSSPWQInputParam.Name) && (cSSPWQInputParam.Name.Length < 1 || cSSPWQInputParam.Name.Length > 200))
            {
                cSSPWQInputParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.CSSPWQInputParamName, "1", "200"), new[] { "Name" });
            }

            if (cSSPWQInputParam.TVItemID < 1)
            {
                cSSPWQInputParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.CSSPWQInputParamTVItemID, "1"), new[] { "TVItemID" });
            }

            if (!string.IsNullOrWhiteSpace(cSSPWQInputParam.CSSPWQInputTypeText) && cSSPWQInputParam.CSSPWQInputTypeText.Length > 100)
            {
                cSSPWQInputParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.CSSPWQInputParamCSSPWQInputTypeText, "100"), new[] { "CSSPWQInputTypeText" });
            }

                //Error: Type not implemented [sidList] of type [List`1]

            //sidList has no StringLength Attribute

                //Error: Type not implemented [MWQMSiteList] of type [List`1]

            //MWQMSiteList has no StringLength Attribute

                //Error: Type not implemented [MWQMSiteTVItemIDList] of type [List`1]

            //MWQMSiteTVItemIDList has no Range Attribute

                //Error: Type not implemented [DailyDuplicateMWQMSiteList] of type [List`1]

            //DailyDuplicateMWQMSiteList has no StringLength Attribute

                //Error: Type not implemented [DailyDuplicateMWQMSiteTVItemIDList] of type [List`1]

            //DailyDuplicateMWQMSiteTVItemIDList has no Range Attribute

                //Error: Type not implemented [InfrastructureList] of type [List`1]

            //InfrastructureList has no StringLength Attribute

                //Error: Type not implemented [InfrastructureTVItemIDList] of type [List`1]

            //InfrastructureTVItemIDList has no Range Attribute

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                cSSPWQInputParam.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
