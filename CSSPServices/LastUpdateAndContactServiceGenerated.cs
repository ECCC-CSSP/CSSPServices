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

            if (string.IsNullOrWhiteSpace(lastUpdateAndContact.Err))
            {
                lastUpdateAndContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LastUpdateAndContactErr), new[] { "Err" });
            }

            //Err has no StringLength Attribute

            if (lastUpdateAndContact.LastUpdateAndContactDate_UTC.Year == 1)
            {
                lastUpdateAndContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LastUpdateAndContactLastUpdateAndContactDate_UTC), new[] { "LastUpdateAndContactDate_UTC" });
            }
            else
            {
                if (lastUpdateAndContact.LastUpdateAndContactDate_UTC.Year < 1980)
                {
                lastUpdateAndContact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LastUpdateAndContactLastUpdateAndContactDate_UTC, "1980"), new[] { "LastUpdateAndContactDate_UTC" });
                }
            }

            //LastUpdateAndContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (lastUpdateAndContact.LastUpdateAndContactTVItemID < 1)
            {
                lastUpdateAndContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.LastUpdateAndContactLastUpdateAndContactTVItemID, "1"), new[] { "LastUpdateAndContactTVItemID" });
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
