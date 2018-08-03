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
    ///     <para>bonjour FileItemList</para>
    /// </summary>
    public partial class FileItemListService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public FileItemListService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            FileItemList fileItemList = validationContext.ObjectInstance as FileItemList;
            fileItemList.HasErrors = false;

            if (string.IsNullOrWhiteSpace(fileItemList.Text))
            {
                fileItemList.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "FileItemListText"), new[] { "Text" });
            }

            if (!string.IsNullOrWhiteSpace(fileItemList.Text) && (fileItemList.Text.Length < 1 || fileItemList.Text.Length > 255))
            {
                fileItemList.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "FileItemListText", "1", "255"), new[] { "Text" });
            }

            if (string.IsNullOrWhiteSpace(fileItemList.FileName))
            {
                fileItemList.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "FileItemListFileName"), new[] { "FileName" });
            }

            if (!string.IsNullOrWhiteSpace(fileItemList.FileName) && (fileItemList.FileName.Length < 1 || fileItemList.FileName.Length > 255))
            {
                fileItemList.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "FileItemListFileName", "1", "255"), new[] { "FileName" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                fileItemList.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}