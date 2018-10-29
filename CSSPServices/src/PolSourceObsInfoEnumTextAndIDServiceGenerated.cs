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
    ///     <para>bonjour PolSourceObsInfoEnumTextAndID</para>
    /// </summary>
    public partial class PolSourceObsInfoEnumTextAndIDService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoEnumTextAndIDService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceObsInfoEnumTextAndID polSourceObsInfoEnumTextAndID = validationContext.ObjectInstance as PolSourceObsInfoEnumTextAndID;
            polSourceObsInfoEnumTextAndID.HasErrors = false;

            if (string.IsNullOrWhiteSpace(polSourceObsInfoEnumTextAndID.Text))
            {
                polSourceObsInfoEnumTextAndID.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceObsInfoEnumTextAndIDText"), new[] { "Text" });
            }

            //Text has no StringLength Attribute

            if (polSourceObsInfoEnumTextAndID.ID < 1)
            {
                polSourceObsInfoEnumTextAndID.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "PolSourceObsInfoEnumTextAndIDID", "1"), new[] { "ID" });
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                polSourceObsInfoEnumTextAndID.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
