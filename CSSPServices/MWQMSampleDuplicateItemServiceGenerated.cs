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

            if (string.IsNullOrWhiteSpace(mwqmSampleDuplicateItem.ParentSite))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleDuplicateItemParentSite), new[] { ModelsRes.MWQMSampleDuplicateItemParentSite });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSampleDuplicateItem.ParentSite) && (mwqmSampleDuplicateItem.ParentSite.Length < 1 || mwqmSampleDuplicateItem.ParentSite.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.MWQMSampleDuplicateItemParentSite, "1", "200"), new[] { ModelsRes.MWQMSampleDuplicateItemParentSite });
            }

            if (string.IsNullOrWhiteSpace(mwqmSampleDuplicateItem.DuplicateSite))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleDuplicateItemDuplicateSite), new[] { ModelsRes.MWQMSampleDuplicateItemDuplicateSite });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSampleDuplicateItem.DuplicateSite) && (mwqmSampleDuplicateItem.DuplicateSite.Length < 1 || mwqmSampleDuplicateItem.DuplicateSite.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.MWQMSampleDuplicateItemDuplicateSite, "1", "200"), new[] { ModelsRes.MWQMSampleDuplicateItemDuplicateSite });
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
