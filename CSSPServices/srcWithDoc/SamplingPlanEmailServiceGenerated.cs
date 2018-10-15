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
    ///     <para>bonjour SamplingPlanEmail</para>
    /// </summary>
    public partial class SamplingPlanEmailService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SamplingPlanEmail samplingPlanEmail = validationContext.ObjectInstance as SamplingPlanEmail;
            samplingPlanEmail.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (samplingPlanEmail.SamplingPlanEmailID == 0)
                {
                    samplingPlanEmail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanEmailSamplingPlanEmailID"), new[] { "SamplingPlanEmailID" });
                }

                if (!(from c in db.SamplingPlanEmails select c).Where(c => c.SamplingPlanEmailID == samplingPlanEmail.SamplingPlanEmailID).Any())
                {
                    samplingPlanEmail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlanEmail", "SamplingPlanEmailSamplingPlanEmailID", samplingPlanEmail.SamplingPlanEmailID.ToString()), new[] { "SamplingPlanEmailID" });
                }
            }

            SamplingPlan SamplingPlanSamplingPlanID = (from c in db.SamplingPlans where c.SamplingPlanID == samplingPlanEmail.SamplingPlanID select c).FirstOrDefault();

            if (SamplingPlanSamplingPlanID == null)
            {
                samplingPlanEmail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanEmailSamplingPlanID", samplingPlanEmail.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
            }

            if (string.IsNullOrWhiteSpace(samplingPlanEmail.Email))
            {
                samplingPlanEmail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanEmailEmail"), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlanEmail.Email) && samplingPlanEmail.Email.Length > 150)
            {
                samplingPlanEmail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "SamplingPlanEmailEmail", "150"), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlanEmail.Email))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(samplingPlanEmail.Email))
                {
                    samplingPlanEmail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotAValidEmail, "SamplingPlanEmailEmail"), new[] { "Email" });
                }
            }

            if (samplingPlanEmail.LastUpdateDate_UTC.Year == 1)
            {
                samplingPlanEmail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanEmailLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (samplingPlanEmail.LastUpdateDate_UTC.Year < 1980)
                {
                samplingPlanEmail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SamplingPlanEmailLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanEmail.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                samplingPlanEmail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanEmailLastUpdateContactTVItemID", samplingPlanEmail.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    samplingPlanEmail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanEmailLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                samplingPlanEmail.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public SamplingPlanEmail GetSamplingPlanEmailWithSamplingPlanEmailID(int SamplingPlanEmailID)
        {
            return (from c in db.SamplingPlanEmails
                    where c.SamplingPlanEmailID == SamplingPlanEmailID
                    select c).FirstOrDefault();

        }
        public IQueryable<SamplingPlanEmail> GetSamplingPlanEmailList()
        {
            IQueryable<SamplingPlanEmail> SamplingPlanEmailQuery = (from c in db.SamplingPlanEmails select c);

            SamplingPlanEmailQuery = EnhanceQueryStatements<SamplingPlanEmail>(SamplingPlanEmailQuery) as IQueryable<SamplingPlanEmail>;

            return SamplingPlanEmailQuery;
        }
        public SamplingPlanEmailExtraA GetSamplingPlanEmailExtraAWithSamplingPlanEmailID(int SamplingPlanEmailID)
        {
            return FillSamplingPlanEmailExtraA().Where(c => c.SamplingPlanEmailID == SamplingPlanEmailID).FirstOrDefault();

        }
        public IQueryable<SamplingPlanEmailExtraA> GetSamplingPlanEmailExtraAList()
        {
            IQueryable<SamplingPlanEmailExtraA> SamplingPlanEmailExtraAQuery = FillSamplingPlanEmailExtraA();

            SamplingPlanEmailExtraAQuery = EnhanceQueryStatements<SamplingPlanEmailExtraA>(SamplingPlanEmailExtraAQuery) as IQueryable<SamplingPlanEmailExtraA>;

            return SamplingPlanEmailExtraAQuery;
        }
        public SamplingPlanEmailExtraB GetSamplingPlanEmailExtraBWithSamplingPlanEmailID(int SamplingPlanEmailID)
        {
            return FillSamplingPlanEmailExtraB().Where(c => c.SamplingPlanEmailID == SamplingPlanEmailID).FirstOrDefault();

        }
        public IQueryable<SamplingPlanEmailExtraB> GetSamplingPlanEmailExtraBList()
        {
            IQueryable<SamplingPlanEmailExtraB> SamplingPlanEmailExtraBQuery = FillSamplingPlanEmailExtraB();

            SamplingPlanEmailExtraBQuery = EnhanceQueryStatements<SamplingPlanEmailExtraB>(SamplingPlanEmailExtraBQuery) as IQueryable<SamplingPlanEmailExtraB>;

            return SamplingPlanEmailExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(SamplingPlanEmail samplingPlanEmail)
        {
            samplingPlanEmail.ValidationResults = Validate(new ValidationContext(samplingPlanEmail), ActionDBTypeEnum.Create);
            if (samplingPlanEmail.ValidationResults.Count() > 0) return false;

            db.SamplingPlanEmails.Add(samplingPlanEmail);

            if (!TryToSave(samplingPlanEmail)) return false;

            return true;
        }
        public bool Delete(SamplingPlanEmail samplingPlanEmail)
        {
            samplingPlanEmail.ValidationResults = Validate(new ValidationContext(samplingPlanEmail), ActionDBTypeEnum.Delete);
            if (samplingPlanEmail.ValidationResults.Count() > 0) return false;

            db.SamplingPlanEmails.Remove(samplingPlanEmail);

            if (!TryToSave(samplingPlanEmail)) return false;

            return true;
        }
        public bool Update(SamplingPlanEmail samplingPlanEmail)
        {
            samplingPlanEmail.ValidationResults = Validate(new ValidationContext(samplingPlanEmail), ActionDBTypeEnum.Update);
            if (samplingPlanEmail.ValidationResults.Count() > 0) return false;

            db.SamplingPlanEmails.Update(samplingPlanEmail);

            if (!TryToSave(samplingPlanEmail)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(SamplingPlanEmail samplingPlanEmail)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                samplingPlanEmail.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
