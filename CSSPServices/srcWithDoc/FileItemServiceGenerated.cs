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
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.FileItem](CSSPModels.FileItem.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class FileItemService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB FileItems table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public FileItemService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all FileItemService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            FileItem fileItem = validationContext.ObjectInstance as FileItem;
            fileItem.HasErrors = false;

            if (string.IsNullOrWhiteSpace(fileItem.Name))
            {
                fileItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Name"), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(fileItem.Name) && (fileItem.Name.Length < 0 || fileItem.Name.Length > 255))
            {
                fileItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "Name", "0", "255"), new[] { "Name" });
            }

            if (fileItem.TVItemID < 1)
            {
                fileItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "TVItemID", "1"), new[] { "TVItemID" });
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                fileItem.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
