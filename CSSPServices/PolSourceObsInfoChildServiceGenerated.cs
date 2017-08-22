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
    public partial class PolSourceObsInfoChildService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoChildService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceObsInfoChild polSourceObsInfoChild = validationContext.ObjectInstance as PolSourceObsInfoChild;
            polSourceObsInfoChild.HasErrors = false;

            retStr = enums.EnumTypeOK(typeof(PolSourceObsInfoEnum), (int?)polSourceObsInfoChild.PolSourceObsInfo);
            if (polSourceObsInfoChild.PolSourceObsInfo == PolSourceObsInfoEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                polSourceObsInfoChild.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObsInfoChildPolSourceObsInfo), new[] { "PolSourceObsInfo" });
            }

            retStr = enums.EnumTypeOK(typeof(PolSourceObsInfoEnum), (int?)polSourceObsInfoChild.PolSourceObsInfoChildStart);
            if (polSourceObsInfoChild.PolSourceObsInfoChildStart == PolSourceObsInfoEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                polSourceObsInfoChild.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObsInfoChildPolSourceObsInfoChildStart), new[] { "PolSourceObsInfoChildStart" });
            }

            if (!string.IsNullOrWhiteSpace(polSourceObsInfoChild.PolSourceObsInfoText) && polSourceObsInfoChild.PolSourceObsInfoText.Length > 100)
            {
                polSourceObsInfoChild.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.PolSourceObsInfoChildPolSourceObsInfoText, "100"), new[] { "PolSourceObsInfoText" });
            }

            if (!string.IsNullOrWhiteSpace(polSourceObsInfoChild.PolSourceObsInfoChildStartText) && polSourceObsInfoChild.PolSourceObsInfoChildStartText.Length > 100)
            {
                polSourceObsInfoChild.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.PolSourceObsInfoChildPolSourceObsInfoChildStartText, "100"), new[] { "PolSourceObsInfoChildStartText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                polSourceObsInfoChild.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
