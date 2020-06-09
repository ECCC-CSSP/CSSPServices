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
    public partial class ReportTypeService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportTypeService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ReportType reportType = validationContext.ObjectInstance as ReportType;
            reportType.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (reportType.ReportTypeID == 0)
                {
                    reportType.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ReportTypeID"), new[] { "ReportTypeID" });
                }

                if (!(from c in db.ReportTypes select c).Where(c => c.ReportTypeID == reportType.ReportTypeID).Any())
                {
                    reportType.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportTypeID", reportType.ReportTypeID.ToString()), new[] { "ReportTypeID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)reportType.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVType"), new[] { "TVType" });
            }

            retStr = enums.EnumTypeOK(typeof(FileTypeEnum), (int?)reportType.FileType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "FileType"), new[] { "FileType" });
            }

            if (string.IsNullOrWhiteSpace(reportType.UniqueCode))
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "UniqueCode"), new[] { "UniqueCode" });
            }

            if (!string.IsNullOrWhiteSpace(reportType.UniqueCode) && reportType.UniqueCode.Length > 100)
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "UniqueCode", "100"), new[] { "UniqueCode" });
            }

            if (reportType.Language != null)
            {
                retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)reportType.Language);
                if (reportType.Language == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    reportType.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Language"), new[] { "Language" });
                }
            }

            if (!string.IsNullOrWhiteSpace(reportType.Name) && reportType.Name.Length > 100)
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "Name", "100"), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(reportType.Description) && reportType.Description.Length > 1000)
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "Description", "1000"), new[] { "Description" });
            }

            if (!string.IsNullOrWhiteSpace(reportType.StartOfFileName) && reportType.StartOfFileName.Length > 100)
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "StartOfFileName", "100"), new[] { "StartOfFileName" });
            }

            if (reportType.LastUpdateDate_UTC.Year == 1)
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (reportType.LastUpdateDate_UTC.Year < 1980)
                {
                reportType.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == reportType.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", reportType.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    reportType.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                reportType.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ReportType GetReportTypeWithReportTypeID(int ReportTypeID)
        {
            return (from c in db.ReportTypes
                    where c.ReportTypeID == ReportTypeID
                    select c).FirstOrDefault();

        }
        public IQueryable<ReportType> GetReportTypeList()
        {
            IQueryable<ReportType> ReportTypeQuery = (from c in db.ReportTypes select c);

            ReportTypeQuery = EnhanceQueryStatements<ReportType>(ReportTypeQuery) as IQueryable<ReportType>;

            return ReportTypeQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(ReportType reportType)
        {
            reportType.ValidationResults = Validate(new ValidationContext(reportType), ActionDBTypeEnum.Create);
            if (reportType.ValidationResults.Count() > 0) return false;

            db.ReportTypes.Add(reportType);

            if (!TryToSave(reportType)) return false;

            return true;
        }
        public bool Delete(ReportType reportType)
        {
            reportType.ValidationResults = Validate(new ValidationContext(reportType), ActionDBTypeEnum.Delete);
            if (reportType.ValidationResults.Count() > 0) return false;

            db.ReportTypes.Remove(reportType);

            if (!TryToSave(reportType)) return false;

            return true;
        }
        public bool Update(ReportType reportType)
        {
            reportType.ValidationResults = Validate(new ValidationContext(reportType), ActionDBTypeEnum.Update);
            if (reportType.ValidationResults.Count() > 0) return false;

            db.ReportTypes.Update(reportType);

            if (!TryToSave(reportType)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(ReportType reportType)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                reportType.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
