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
    ///     <para>bonjour RTBStringPos</para>
    /// </summary>
    public partial class RTBStringPosService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RTBStringPosService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            RTBStringPos rTBStringPos = validationContext.ObjectInstance as RTBStringPos;
            rTBStringPos.HasErrors = false;

            if (rTBStringPos.StartPos < 0)
            {
                rTBStringPos.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.RTBStringPosStartPos, "0"), new[] { "StartPos" });
            }

            if (rTBStringPos.EndPos < 0)
            {
                rTBStringPos.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.RTBStringPosEndPos, "0"), new[] { "EndPos" });
            }

            if (string.IsNullOrWhiteSpace(rTBStringPos.Text))
            {
                rTBStringPos.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RTBStringPosText), new[] { "Text" });
            }

            //Text has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(rTBStringPos.TagText))
            {
                rTBStringPos.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RTBStringPosTagText), new[] { "TagText" });
            }

            //TagText has no StringLength Attribute

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                rTBStringPos.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
