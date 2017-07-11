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
    public partial class VPResultService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public VPResultService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            VPResult vpResult = validationContext.ObjectInstance as VPResult;

            //VPResultID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //VPResultID has no Range Attribute

            //VPScenarioID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //VPScenarioID has no Range Attribute

            //Ordinal (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Ordinal has no Range Attribute

            //Concentration_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Concentration_MPN_100ml has no Range Attribute

            //Dilution (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Dilution has no Range Attribute

            //FarFieldWidth_m (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //FarFieldWidth_m has no Range Attribute

            //DispersionDistance_m (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //DispersionDistance_m has no Range Attribute

            //TravelTime_hour (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TravelTime_hour has no Range Attribute

            if (vpResult.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPResultLastUpdateDate_UTC), new[] { ModelsRes.VPResultLastUpdateDate_UTC });
            }

            if (vpResult.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.VPResultLastUpdateDate_UTC, "1980"), new[] { ModelsRes.VPResultLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpResult.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.VPResultLastUpdateContactTVItemID, "1"), new[] { ModelsRes.VPResultLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == vpResult.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.VPResultLastUpdateContactTVItemID, vpResult.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.VPResultLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(VPResult vpResult)
        {
            vpResult.ValidationResults = Validate(new ValidationContext(vpResult), ActionDBTypeEnum.Create);
            if (vpResult.ValidationResults.Count() > 0) return false;

            db.VPResults.Add(vpResult);

            if (!TryToSave(vpResult)) return false;

            return true;
        }
        public bool AddRange(List<VPResult> vpResultList)
        {
            foreach (VPResult vpResult in vpResultList)
            {
                vpResult.ValidationResults = Validate(new ValidationContext(vpResult), ActionDBTypeEnum.Create);
                if (vpResult.ValidationResults.Count() > 0) return false;
            }

            db.VPResults.AddRange(vpResultList);

            if (!TryToSaveRange(vpResultList)) return false;

            return true;
        }
        public bool Delete(VPResult vpResult)
        {
            if (!db.VPResults.Where(c => c.VPResultID == vpResult.VPResultID).Any())
            {
                vpResult.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "VPResult", "VPResultID", vpResult.VPResultID.ToString())) }.AsEnumerable();
                return false;
            }

            db.VPResults.Remove(vpResult);

            if (!TryToSave(vpResult)) return false;

            return true;
        }
        public bool DeleteRange(List<VPResult> vpResultList)
        {
            foreach (VPResult vpResult in vpResultList)
            {
                if (!db.VPResults.Where(c => c.VPResultID == vpResult.VPResultID).Any())
                {
                    vpResultList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "VPResult", "VPResultID", vpResult.VPResultID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.VPResults.RemoveRange(vpResultList);

            if (!TryToSaveRange(vpResultList)) return false;

            return true;
        }
        public bool Update(VPResult vpResult)
        {
            vpResult.ValidationResults = Validate(new ValidationContext(vpResult), ActionDBTypeEnum.Update);
            if (vpResult.ValidationResults.Count() > 0) return false;

            db.VPResults.Update(vpResult);

            if (!TryToSave(vpResult)) return false;

            return true;
        }
        public bool UpdateRange(List<VPResult> vpResultList)
        {
            foreach (VPResult vpResult in vpResultList)
            {
                vpResult.ValidationResults = Validate(new ValidationContext(vpResult), ActionDBTypeEnum.Update);
                if (vpResult.ValidationResults.Count() > 0) return false;
            }
            db.VPResults.UpdateRange(vpResultList);

            if (!TryToSaveRange(vpResultList)) return false;

            return true;
        }
        public IQueryable<VPResult> GetRead()
        {
            return db.VPResults.AsNoTracking();
        }
        public IQueryable<VPResult> GetEdit()
        {
            return db.VPResults;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(VPResult vpResult)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpResult.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<VPResult> vpResultList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpResultList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
