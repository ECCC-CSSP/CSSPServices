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
    ///     <para>bonjour PolSourceInactiveReasonEnumTextAndID</para>
    /// </summary>
    public partial class PolSourceInactiveReasonEnumTextAndIDService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceInactiveReasonEnumTextAndIDService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceInactiveReasonEnumTextAndID polSourceInactiveReasonEnumTextAndID = validationContext.ObjectInstance as PolSourceInactiveReasonEnumTextAndID;
            polSourceInactiveReasonEnumTextAndID.HasErrors = false;

            if (string.IsNullOrWhiteSpace(polSourceInactiveReasonEnumTextAndID.Text))
            {
                polSourceInactiveReasonEnumTextAndID.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceInactiveReasonEnumTextAndIDText), new[] { "Text" });
            }

            //Text has no StringLength Attribute

            if (polSourceInactiveReasonEnumTextAndID.ID < 1)
            {
                polSourceInactiveReasonEnumTextAndID.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.PolSourceInactiveReasonEnumTextAndIDID, "1"), new[] { "ID" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                polSourceInactiveReasonEnumTextAndID.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
