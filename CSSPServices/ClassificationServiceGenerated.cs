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
    ///     <para>bonjour Classification</para>
    /// </summary>
    public partial class ClassificationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ClassificationService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Classification classification = validationContext.ObjectInstance as Classification;
            classification.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (classification.ClassificationID == 0)
                {
                    classification.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClassificationClassificationID), new[] { "ClassificationID" });
                }

                if (!GetRead().Where(c => c.ClassificationID == classification.ClassificationID).Any())
                {
                    classification.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Classification, CSSPModelsRes.ClassificationClassificationID, classification.ClassificationID.ToString()), new[] { "ClassificationID" });
                }
            }

            TVItem TVItemClassificationTVItemID = (from c in db.TVItems where c.TVItemID == classification.ClassificationTVItemID select c).FirstOrDefault();

            if (TVItemClassificationTVItemID == null)
            {
                classification.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ClassificationClassificationTVItemID, classification.ClassificationTVItemID.ToString()), new[] { "ClassificationTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Classification,
                };
                if (!AllowableTVTypes.Contains(TVItemClassificationTVItemID.TVType))
                {
                    classification.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ClassificationClassificationTVItemID, "Classification"), new[] { "ClassificationTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(ClassificationTypeEnum), (int?)classification.ClassificationType);
            if (classification.ClassificationType == ClassificationTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                classification.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClassificationClassificationType), new[] { "ClassificationType" });
            }

            if (classification.Ordinal < 0 || classification.Ordinal > 10000)
            {
                classification.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClassificationOrdinal, "0", "10000"), new[] { "Ordinal" });
            }

            if (classification.LastUpdateDate_UTC.Year == 1)
            {
                classification.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClassificationLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (classification.LastUpdateDate_UTC.Year < 1980)
                {
                classification.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClassificationLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == classification.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                classification.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ClassificationLastUpdateContactTVItemID, classification.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    classification.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ClassificationLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                classification.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public Classification GetClassificationWithClassificationID(int ClassificationID)
        {
            IQueryable<Classification> classificationQuery = (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.ClassificationID == ClassificationID
                                                select c);

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return classificationQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillClassificationWeb(classificationQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillClassificationReport(classificationQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<Classification> GetClassificationList()
        {
            IQueryable<Classification> classificationQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        classificationQuery = EnhanceQueryStatements<Classification>(classificationQuery) as IQueryable<Classification>;

                        return classificationQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        classificationQuery = FillClassificationWeb(classificationQuery);

                        classificationQuery = EnhanceQueryStatements<Classification>(classificationQuery) as IQueryable<Classification>;

                        return classificationQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        classificationQuery = FillClassificationReport(classificationQuery);

                        classificationQuery = EnhanceQueryStatements<Classification>(classificationQuery) as IQueryable<Classification>;

                        return classificationQuery;
                    }
                default:
                    {
                        classificationQuery = classificationQuery.Where(c => c.ClassificationID == 0);

                        return classificationQuery;
                    }
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(Classification classification)
        {
            classification.ValidationResults = Validate(new ValidationContext(classification), ActionDBTypeEnum.Create);
            if (classification.ValidationResults.Count() > 0) return false;

            db.Classifications.Add(classification);

            if (!TryToSave(classification)) return false;

            return true;
        }
        public bool Delete(Classification classification)
        {
            classification.ValidationResults = Validate(new ValidationContext(classification), ActionDBTypeEnum.Delete);
            if (classification.ValidationResults.Count() > 0) return false;

            db.Classifications.Remove(classification);

            if (!TryToSave(classification)) return false;

            return true;
        }
        public bool Update(Classification classification)
        {
            classification.ValidationResults = Validate(new ValidationContext(classification), ActionDBTypeEnum.Update);
            if (classification.ValidationResults.Count() > 0) return false;

            db.Classifications.Update(classification);

            if (!TryToSave(classification)) return false;

            return true;
        }
        public IQueryable<Classification> GetRead()
        {
            IQueryable<Classification> classificationQuery = db.Classifications.AsNoTracking();

            return classificationQuery;
        }
        public IQueryable<Classification> GetEdit()
        {
            IQueryable<Classification> classificationQuery = db.Classifications;

            return classificationQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated ClassificationFillWeb
        private IQueryable<Classification> FillClassificationWeb(IQueryable<Classification> classificationQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> ClassificationTypeEnumList = enums.GetEnumTextOrderedList(typeof(ClassificationTypeEnum));

            classificationQuery = (from c in classificationQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new Classification
                    {
                        ClassificationID = c.ClassificationID,
                        ClassificationTVItemID = c.ClassificationTVItemID,
                        ClassificationType = c.ClassificationType,
                        Ordinal = c.Ordinal,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        ClassificationWeb = new ClassificationWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            ClassificationTVText = (from e in ClassificationTypeEnumList
                                where e.EnumID == (int?)c.ClassificationType
                                select e.EnumText).FirstOrDefault(),
                        },
                        ClassificationReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return classificationQuery;
        }
        #endregion Functions private Generated ClassificationFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(Classification classification)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                classification.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
