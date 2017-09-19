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
    ///     <para>bonjour LastUpdateAndContact</para>
    /// </summary>
    public partial class LastUpdateAndContactService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LastUpdateAndContactService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LastUpdateAndContact lastUpdateAndContact = validationContext.ObjectInstance as LastUpdateAndContact;
            lastUpdateAndContact.HasErrors = false;

            if (string.IsNullOrWhiteSpace(lastUpdateAndContact.Error))
            {
                lastUpdateAndContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LastUpdateAndContactError), new[] { "Error" });
            }

            //Error has no StringLength Attribute

            if (lastUpdateAndContact.LastUpdateDate_UTC.Year == 1)
            {
                lastUpdateAndContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LastUpdateAndContactLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (lastUpdateAndContact.LastUpdateDate_UTC.Year < 1980)
                {
                lastUpdateAndContact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LastUpdateAndContactLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (lastUpdateAndContact.LastUpdateContactTVItemID < 1)
            {
                lastUpdateAndContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.LastUpdateAndContactLastUpdateContactTVItemID, "1"), new[] { "LastUpdateContactTVItemID" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                lastUpdateAndContact.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
