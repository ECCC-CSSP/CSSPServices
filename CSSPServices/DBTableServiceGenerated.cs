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
    public partial class DBTableService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DBTableService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            DBTable dBTable = validationContext.ObjectInstance as DBTable;

            if (string.IsNullOrWhiteSpace(dBTable.TableName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.DBTableTableName), new[] { ModelsRes.DBTableTableName });
            }

            if (!string.IsNullOrWhiteSpace(dBTable.TableName) && (dBTable.TableName.Length < 1 || dBTable.TableName.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.DBTableTableName, "1", "200"), new[] { ModelsRes.DBTableTableName });
            }

            if (string.IsNullOrWhiteSpace(dBTable.Plurial))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.DBTablePlurial), new[] { ModelsRes.DBTablePlurial });
            }

            if (!string.IsNullOrWhiteSpace(dBTable.Plurial) && (dBTable.Plurial.Length < 1 || dBTable.Plurial.Length > 3))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.DBTablePlurial, "1", "3"), new[] { ModelsRes.DBTablePlurial });
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
