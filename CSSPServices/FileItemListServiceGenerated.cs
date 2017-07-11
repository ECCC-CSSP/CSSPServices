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
    public partial class FileItemListService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public FileItemListService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            FileItemList fileItemList = validationContext.ObjectInstance as FileItemList;

            if (string.IsNullOrWhiteSpace(fileItemList.Text))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.FileItemListText), new[] { ModelsRes.FileItemListText });
            }

            if (!string.IsNullOrWhiteSpace(fileItemList.Text) && (fileItemList.Text.Length < 1 || fileItemList.Text.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.FileItemListText, "1", "255"), new[] { ModelsRes.FileItemListText });
            }

            if (string.IsNullOrWhiteSpace(fileItemList.FileName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.FileItemListFileName), new[] { ModelsRes.FileItemListFileName });
            }

            if (!string.IsNullOrWhiteSpace(fileItemList.FileName) && (fileItemList.FileName.Length < 1 || fileItemList.FileName.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.FileItemListFileName, "1", "255"), new[] { ModelsRes.FileItemListFileName });
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
