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
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SubsectorMWQMSampleYearSubsectorTVItemID, "1"), new[] { ModelsRes.SubsectorMWQMSampleYearSubsectorTVItemID });
            }

            //Year (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Year has no Range Attribute

            if (subsectorMWQMSampleYear.EarliestDate == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SubsectorMWQMSampleYearEarliestDate), new[] { ModelsRes.SubsectorMWQMSampleYearEarliestDate });
            }

            if (subsectorMWQMSampleYear.LatestDate == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SubsectorMWQMSampleYearLatestDate), new[] { ModelsRes.SubsectorMWQMSampleYearLatestDate });
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
