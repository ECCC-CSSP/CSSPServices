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
    public partial class PolSourceObsInfoEnumTextAndIDService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoEnumTextAndIDService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceObsInfoEnumTextAndID polSourceObsInfoEnumTextAndID = validationContext.ObjectInstance as PolSourceObsInfoEnumTextAndID;

            if (string.IsNullOrWhiteSpace(polSourceObsInfoEnumTextAndID.Text))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObsInfoEnumTextAndIDText), new[] { ModelsRes.PolSourceObsInfoEnumTextAndIDText });
            }

            //Text has no StringLength Attribute

            //ID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (polSourceObsInfoEnumTextAndID.ID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObsInfoEnumTextAndIDID, "1"), new[] { ModelsRes.PolSourceObsInfoEnumTextAndIDID });
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
