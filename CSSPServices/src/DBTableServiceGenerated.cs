/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
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
    public partial class DBTableService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DBTableService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            DBTable dBTable = validationContext.ObjectInstance as DBTable;
            dBTable.HasErrors = false;

            if (string.IsNullOrWhiteSpace(dBTable.TableName))
            {
                dBTable.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TableName"), new[] { "TableName" });
            }

            if (!string.IsNullOrWhiteSpace(dBTable.TableName) && (dBTable.TableName.Length < 1 || dBTable.TableName.Length > 200))
            {
                dBTable.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "TableName", "1", "200"), new[] { "TableName" });
            }

            if (string.IsNullOrWhiteSpace(dBTable.Plurial))
            {
                dBTable.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Plurial"), new[] { "Plurial" });
            }

            if (!string.IsNullOrWhiteSpace(dBTable.Plurial) && (dBTable.Plurial.Length < 1 || dBTable.Plurial.Length > 3))
            {
                dBTable.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "Plurial", "1", "3"), new[] { "Plurial" });
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                dBTable.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
