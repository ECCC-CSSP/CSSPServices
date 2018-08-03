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
    ///     <para>bonjour FileItem</para>
    /// </summary>
    public partial class FileItemService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public FileItemService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            FileItem fileItem = validationContext.ObjectInstance as FileItem;
            fileItem.HasErrors = false;

            if (string.IsNullOrWhiteSpace(fileItem.Name))
            {
                fileItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "FileItemName"), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(fileItem.Name) && (fileItem.Name.Length < 0 || fileItem.Name.Length > 255))
            {
                fileItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "FileItemName", "0", "255"), new[] { "Name" });
            }

            if (fileItem.TVItemID < 1)
            {
                fileItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "FileItemTVItemID", "1"), new[] { "TVItemID" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                fileItem.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
