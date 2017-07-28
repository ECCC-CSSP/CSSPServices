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
    public partial class SubsectorMWQMSampleYearService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SubsectorMWQMSampleYearService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SubsectorMWQMSampleYear subsectorMWQMSampleYear = validationContext.ObjectInstance as SubsectorMWQMSampleYear;

            //SubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (subsectorMWQMSampleYear.SubsectorTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SubsectorMWQMSampleYearSubsectorTVItemID, "1"), new[] { "SubsectorTVItemID" });
            }

            //Year (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Year has no Range Attribute

            if (subsectorMWQMSampleYear.EarliestDate.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SubsectorMWQMSampleYearEarliestDate), new[] { "EarliestDate" });
            }
            else
            {
                if (subsectorMWQMSampleYear.EarliestDate.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.SubsectorMWQMSampleYearEarliestDate, "1980"), new[] { "EarliestDate" });
                }
            }

            if (subsectorMWQMSampleYear.LatestDate.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SubsectorMWQMSampleYearLatestDate), new[] { "LatestDate" });
            }
            else
            {
                if (subsectorMWQMSampleYear.LatestDate.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.SubsectorMWQMSampleYearLatestDate, "1980"), new[] { "LatestDate" });
                }
            }

            if (subsectorMWQMSampleYear.EarliestDate > subsectorMWQMSampleYear.LatestDate)
            {
                yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes.SubsectorMWQMSampleYearLatestDate, ModelsRes.SubsectorMWQMSampleYearEarliestDate), new[] { ModelsRes.SubsectorMWQMSampleYearLatestDate });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
