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
    public partial class PolSourceInactiveReasonEnumTextAndIDService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceInactiveReasonEnumTextAndIDService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceInactiveReasonEnumTextAndID polSourceInactiveReasonEnumTextAndID = validationContext.ObjectInstance as PolSourceInactiveReasonEnumTextAndID;

            if (string.IsNullOrWhiteSpace(polSourceInactiveReasonEnumTextAndID.Text))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceInactiveReasonEnumTextAndIDText), new[] { ModelsRes.PolSourceInactiveReasonEnumTextAndIDText });
            }

            //Text has no StringLength Attribute

            //ID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (polSourceInactiveReasonEnumTextAndID.ID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceInactiveReasonEnumTextAndIDID, "1"), new[] { ModelsRes.PolSourceInactiveReasonEnumTextAndIDID });
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
