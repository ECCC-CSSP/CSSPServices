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
    public partial class MWQMSampleDuplicateItemService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSampleDuplicateItemService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSampleDuplicateItem mwqmSampleDuplicateItem = validationContext.ObjectInstance as MWQMSampleDuplicateItem;
            mwqmSampleDuplicateItem.HasErrors = false;

            if (string.IsNullOrWhiteSpace(mwqmSampleDuplicateItem.ParentSite))
            {
                mwqmSampleDuplicateItem.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleDuplicateItemParentSite), new[] { "ParentSite" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSampleDuplicateItem.ParentSite) && (mwqmSampleDuplicateItem.ParentSite.Length < 1 || mwqmSampleDuplicateItem.ParentSite.Length > 200))
            {
                mwqmSampleDuplicateItem.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.MWQMSampleDuplicateItemParentSite, "1", "200"), new[] { "ParentSite" });
            }

            if (string.IsNullOrWhiteSpace(mwqmSampleDuplicateItem.DuplicateSite))
            {
                mwqmSampleDuplicateItem.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleDuplicateItemDuplicateSite), new[] { "DuplicateSite" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSampleDuplicateItem.DuplicateSite) && (mwqmSampleDuplicateItem.DuplicateSite.Length < 1 || mwqmSampleDuplicateItem.DuplicateSite.Length > 200))
            {
                mwqmSampleDuplicateItem.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.MWQMSampleDuplicateItemDuplicateSite, "1", "200"), new[] { "DuplicateSite" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmSampleDuplicateItem.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
