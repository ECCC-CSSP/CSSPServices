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
    ///     <para>bonjour SubsectorMWQMSampleYear</para>
    /// </summary>
    public partial class SubsectorMWQMSampleYearService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SubsectorMWQMSampleYearService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SubsectorMWQMSampleYear subsectorMWQMSampleYear = validationContext.ObjectInstance as SubsectorMWQMSampleYear;
            subsectorMWQMSampleYear.HasErrors = false;

            if (subsectorMWQMSampleYear.SubsectorTVItemID < 1)
            {
                subsectorMWQMSampleYear.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "SubsectorMWQMSampleYearSubsectorTVItemID", "1"), new[] { "SubsectorTVItemID" });
            }

            //Year has no Range Attribute

            if (subsectorMWQMSampleYear.EarliestDate.Year == 1)
            {
                subsectorMWQMSampleYear.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SubsectorMWQMSampleYearEarliestDate"), new[] { "EarliestDate" });
            }
            else
            {
                if (subsectorMWQMSampleYear.EarliestDate.Year < 1980)
                {
                subsectorMWQMSampleYear.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SubsectorMWQMSampleYearEarliestDate", "1980"), new[] { "EarliestDate" });
                }
            }

            if (subsectorMWQMSampleYear.LatestDate.Year == 1)
            {
                subsectorMWQMSampleYear.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SubsectorMWQMSampleYearLatestDate"), new[] { "LatestDate" });
            }
            else
            {
                if (subsectorMWQMSampleYear.LatestDate.Year < 1980)
                {
                subsectorMWQMSampleYear.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SubsectorMWQMSampleYearLatestDate", "1980"), new[] { "LatestDate" });
                }
            }

            if (subsectorMWQMSampleYear.EarliestDate > subsectorMWQMSampleYear.LatestDate)
            {
                subsectorMWQMSampleYear.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "SubsectorMWQMSampleYearLatestDate", "SubsectorMWQMSampleYearEarliestDate"), new[] { "SubsectorMWQMSampleYearLatestDate" });
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                subsectorMWQMSampleYear.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
