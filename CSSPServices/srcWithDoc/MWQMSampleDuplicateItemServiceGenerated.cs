/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
    /// > [!NOTE]
    /// > 
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.MWQMSampleDuplicateItem](CSSPModels.MWQMSampleDuplicateItem.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class MWQMSampleDuplicateItemService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB MWQMSampleDuplicateItems table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public MWQMSampleDuplicateItemService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all MWQMSampleDuplicateItemService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSampleDuplicateItem mwqmSampleDuplicateItem = validationContext.ObjectInstance as MWQMSampleDuplicateItem;
            mwqmSampleDuplicateItem.HasErrors = false;

            if (string.IsNullOrWhiteSpace(mwqmSampleDuplicateItem.ParentSite))
            {
                mwqmSampleDuplicateItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ParentSite"), new[] { "ParentSite" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSampleDuplicateItem.ParentSite) && (mwqmSampleDuplicateItem.ParentSite.Length < 1 || mwqmSampleDuplicateItem.ParentSite.Length > 200))
            {
                mwqmSampleDuplicateItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "ParentSite", "1", "200"), new[] { "ParentSite" });
            }

            if (string.IsNullOrWhiteSpace(mwqmSampleDuplicateItem.DuplicateSite))
            {
                mwqmSampleDuplicateItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DuplicateSite"), new[] { "DuplicateSite" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSampleDuplicateItem.DuplicateSite) && (mwqmSampleDuplicateItem.DuplicateSite.Length < 1 || mwqmSampleDuplicateItem.DuplicateSite.Length > 200))
            {
                mwqmSampleDuplicateItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "DuplicateSite", "1", "200"), new[] { "DuplicateSite" });
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                mwqmSampleDuplicateItem.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
