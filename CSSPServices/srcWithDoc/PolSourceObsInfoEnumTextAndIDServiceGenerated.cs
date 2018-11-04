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
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.PolSourceObsInfoEnumTextAndID](CSSPModels.PolSourceObsInfoEnumTextAndID.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class PolSourceObsInfoEnumTextAndIDService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB PolSourceObsInfoEnumTextAndIDs table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public PolSourceObsInfoEnumTextAndIDService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all PolSourceObsInfoEnumTextAndIDService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
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
