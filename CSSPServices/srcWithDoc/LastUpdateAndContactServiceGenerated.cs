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
        public LastUpdateAndContactService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateAndContactErr"), new[] { "Err" });
            }

            //Err has no StringLength Attribute

            if (lastUpdateAndContact.LastUpdateAndContactDate_UTC.Year == 1)
            {
                lastUpdateAndContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateAndContactLastUpdateAndContactDate_UTC"), new[] { "LastUpdateAndContactDate_UTC" });
            }
            else
            {
                if (lastUpdateAndContact.LastUpdateAndContactDate_UTC.Year < 1980)
                {
                lastUpdateAndContact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateAndContactLastUpdateAndContactDate_UTC", "1980"), new[] { "LastUpdateAndContactDate_UTC" });
                }
            }

            if (lastUpdateAndContact.LastUpdateAndContactTVItemID < 1)
            {
                lastUpdateAndContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "LastUpdateAndContactLastUpdateAndContactTVItemID", "1"), new[] { "LastUpdateAndContactTVItemID" });
            }

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
