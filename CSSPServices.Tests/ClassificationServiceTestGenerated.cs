using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.Security.Principal;
using System.Globalization;
using CSSPServices.Resources;
using CSSPModels.Resources;
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class ClassificationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ClassificationService classificationService { get; set; }
        #endregion Properties

        #region Constructors
        public ClassificationServiceTest() : base()
        {
            //classificationService = new ClassificationService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Classification GetFilledRandomClassification(string OmitPropName)
        {
            Classification classification = new Classification();

            if (OmitPropName != "ClassificationTVItemID") classification.ClassificationTVItemID = 13;
            if (OmitPropName != "ClassificationType") classification.ClassificationType = (ClassificationTypeEnum)GetRandomEnumType(typeof(ClassificationTypeEnum));
            if (OmitPropName != "Ordinal") classification.Ordinal = GetRandomInt(0, 10000);
            if (OmitPropName != "LastUpdateDate_UTC") classification.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") classification.LastUpdateContactTVItemID = 2;

            return classification;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Classification_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ClassificationService classificationService = new ClassificationService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    Classification classification = GetFilledRandomClassification("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = classificationService.GetRead().Count();

                    Assert.AreEqual(classificationService.GetRead().Count(), classificationService.GetEdit().Count());

                    classificationService.Add(classification);
                    if (classification.HasErrors)
                    {
                        Assert.AreEqual("", classification.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, classificationService.GetRead().Where(c => c == classification).Any());
                    classificationService.Update(classification);
                    if (classification.HasErrors)
                    {
                        Assert.AreEqual("", classification.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, classificationService.GetRead().Count());
                    classificationService.Delete(classification);
                    if (classification.HasErrors)
                    {
                        Assert.AreEqual("", classification.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, classificationService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // classification.ClassificationID   (Int32)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationID = 0;
                    classificationService.Update(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClassificationClassificationID), classification.ValidationResults.FirstOrDefault().ErrorMessage);

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationID = 10000000;
                    classificationService.Update(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Classification, CSSPModelsRes.ClassificationClassificationID, classification.ClassificationID.ToString()), classification.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Classification)]
                    // classification.ClassificationTVItemID   (Int32)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationTVItemID = 0;
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ClassificationClassificationTVItemID, classification.ClassificationTVItemID.ToString()), classification.ValidationResults.FirstOrDefault().ErrorMessage);

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationTVItemID = 1;
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ClassificationClassificationTVItemID, "Classification"), classification.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // classification.ClassificationType   (ClassificationTypeEnum)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationType = (ClassificationTypeEnum)1000000;
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClassificationClassificationType), classification.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000)]
                    // classification.Ordinal   (Int32)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.Ordinal = -1;
                    Assert.AreEqual(false, classificationService.Add(classification));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClassificationOrdinal, "0", "10000"), classification.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, classificationService.GetRead().Count());
                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.Ordinal = 10001;
                    Assert.AreEqual(false, classificationService.Add(classification));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClassificationOrdinal, "0", "10000"), classification.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, classificationService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // classification.ClassificationWeb   (ClassificationWeb)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationWeb = null;
                    Assert.IsNull(classification.ClassificationWeb);

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationWeb = new ClassificationWeb();
                    Assert.IsNotNull(classification.ClassificationWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // classification.ClassificationReport   (ClassificationReport)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationReport = null;
                    Assert.IsNull(classification.ClassificationReport);

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationReport = new ClassificationReport();
                    Assert.IsNotNull(classification.ClassificationReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // classification.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.LastUpdateDate_UTC = new DateTime();
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClassificationLastUpdateDate_UTC), classification.ValidationResults.FirstOrDefault().ErrorMessage);
                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClassificationLastUpdateDate_UTC, "1980"), classification.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // classification.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.LastUpdateContactTVItemID = 0;
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ClassificationLastUpdateContactTVItemID, classification.LastUpdateContactTVItemID.ToString()), classification.ValidationResults.FirstOrDefault().ErrorMessage);

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.LastUpdateContactTVItemID = 1;
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ClassificationLastUpdateContactTVItemID, "Contact"), classification.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // classification.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // classification.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetClassificationWithClassificationID(classification.ClassificationID)
        [TestMethod]
        public void GetClassificationWithClassificationID__classification_ClassificationID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ClassificationService classificationService = new ClassificationService(new GetParam(), dbTestDB, ContactID);
                    Classification classification = (from c in classificationService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(classification);

                    Classification classificationRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        classificationService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            classificationRet = classificationService.GetClassificationWithClassificationID(classification.ClassificationID);
                            Assert.IsNull(classificationRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            classificationRet = classificationService.GetClassificationWithClassificationID(classification.ClassificationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            classificationRet = classificationService.GetClassificationWithClassificationID(classification.ClassificationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            classificationRet = classificationService.GetClassificationWithClassificationID(classification.ClassificationID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Classification fields
                        Assert.IsNotNull(classificationRet.ClassificationID);
                        Assert.IsNotNull(classificationRet.ClassificationTVItemID);
                        Assert.IsNotNull(classificationRet.ClassificationType);
                        Assert.IsNotNull(classificationRet.Ordinal);
                        Assert.IsNotNull(classificationRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(classificationRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // ClassificationWeb and ClassificationReport fields should be null here
                            Assert.IsNull(classificationRet.ClassificationWeb);
                            Assert.IsNull(classificationRet.ClassificationReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // ClassificationWeb fields should not be null and ClassificationReport fields should be null here
                            if (classificationRet.ClassificationWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(classificationRet.ClassificationWeb.LastUpdateContactTVText));
                            }
                            if (classificationRet.ClassificationWeb.ClassificationTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(classificationRet.ClassificationWeb.ClassificationTVText));
                            }
                            Assert.IsNull(classificationRet.ClassificationReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // ClassificationWeb and ClassificationReport fields should NOT be null here
                            if (classificationRet.ClassificationWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(classificationRet.ClassificationWeb.LastUpdateContactTVText));
                            }
                            if (classificationRet.ClassificationWeb.ClassificationTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(classificationRet.ClassificationWeb.ClassificationTVText));
                            }
                            if (classificationRet.ClassificationReport.ClassificationReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(classificationRet.ClassificationReport.ClassificationReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationWithClassificationID(classification.ClassificationID)

        #region Tests Generated for GetClassificationList()
        [TestMethod]
        public void GetClassificationList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ClassificationService classificationService = new ClassificationService(new GetParam(), dbTestDB, ContactID);
                    Classification classification = (from c in classificationService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(classification);

                    List<Classification> classificationList = new List<Classification>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        classificationService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            classificationList = classificationService.GetClassificationList().ToList();
                            Assert.AreEqual(0, classificationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            classificationList = classificationService.GetClassificationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            classificationList = classificationService.GetClassificationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            classificationList = classificationService.GetClassificationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Classification fields
                        Assert.IsNotNull(classificationList[0].ClassificationID);
                        Assert.IsNotNull(classificationList[0].ClassificationTVItemID);
                        Assert.IsNotNull(classificationList[0].ClassificationType);
                        Assert.IsNotNull(classificationList[0].Ordinal);
                        Assert.IsNotNull(classificationList[0].LastUpdateDate_UTC);
                        Assert.IsNotNull(classificationList[0].LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // ClassificationWeb and ClassificationReport fields should be null here
                            Assert.IsNull(classificationList[0].ClassificationWeb);
                            Assert.IsNull(classificationList[0].ClassificationReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // ClassificationWeb fields should not be null and ClassificationReport fields should be null here
                            if (classificationList[0].ClassificationWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(classificationList[0].ClassificationWeb.LastUpdateContactTVText));
                            }
                            if (classificationList[0].ClassificationWeb.ClassificationTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(classificationList[0].ClassificationWeb.ClassificationTVText));
                            }
                            Assert.IsNull(classificationList[0].ClassificationReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // ClassificationWeb and ClassificationReport fields should NOT be null here
                            if (classificationList[0].ClassificationWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(classificationList[0].ClassificationWeb.LastUpdateContactTVText));
                            }
                            if (classificationList[0].ClassificationWeb.ClassificationTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(classificationList[0].ClassificationWeb.ClassificationTVText));
                            }
                            if (classificationList[0].ClassificationReport.ClassificationReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(classificationList[0].ClassificationReport.ClassificationReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList()

        #region Tests Generated for GetClassificationList() Skip Take
        [TestMethod]
        public void GetClassificationList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<Classification> classificationList = new List<Classification>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                        GetParam getParam = getParamService.FillProp(typeof(Classification), "en", 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);
                        ClassificationService classificationService = new ClassificationService(getParam, dbTestDB, ContactID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            classificationList = classificationService.GetClassificationList().ToList();
                            Assert.AreEqual(0, classificationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            classificationList = classificationService.GetClassificationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            classificationList = classificationService.GetClassificationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            classificationList = classificationService.GetClassificationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }

                        Assert.AreEqual(getParam.Take, classificationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() Skip Take

    }
}
