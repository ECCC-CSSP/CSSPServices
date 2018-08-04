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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Classification_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    count = classificationService.GetClassificationList().Count();

                    Assert.AreEqual(classificationService.GetClassificationList().Count(), (from c in dbTestDB.Classifications select c).Take(200).Count());

                    classificationService.Add(classification);
                    if (classification.HasErrors)
                    {
                        Assert.AreEqual("", classification.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, classificationService.GetClassificationList().Where(c => c == classification).Any());
                    classificationService.Update(classification);
                    if (classification.HasErrors)
                    {
                        Assert.AreEqual("", classification.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, classificationService.GetClassificationList().Count());
                    classificationService.Delete(classification);
                    if (classification.HasErrors)
                    {
                        Assert.AreEqual("", classification.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, classificationService.GetClassificationList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ClassificationClassificationID"), classification.ValidationResults.FirstOrDefault().ErrorMessage);

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationID = 10000000;
                    classificationService.Update(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Classification", "ClassificationClassificationID", classification.ClassificationID.ToString()), classification.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Classification)]
                    // classification.ClassificationTVItemID   (Int32)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationTVItemID = 0;
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ClassificationClassificationTVItemID", classification.ClassificationTVItemID.ToString()), classification.ValidationResults.FirstOrDefault().ErrorMessage);

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationTVItemID = 1;
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "ClassificationClassificationTVItemID", "Classification"), classification.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // classification.ClassificationType   (ClassificationTypeEnum)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationType = (ClassificationTypeEnum)1000000;
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ClassificationClassificationType"), classification.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000)]
                    // classification.Ordinal   (Int32)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.Ordinal = -1;
                    Assert.AreEqual(false, classificationService.Add(classification));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ClassificationOrdinal", "0", "10000"), classification.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, classificationService.GetClassificationList().Count());
                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.Ordinal = 10001;
                    Assert.AreEqual(false, classificationService.Add(classification));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ClassificationOrdinal", "0", "10000"), classification.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, classificationService.GetClassificationList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // classification.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.LastUpdateDate_UTC = new DateTime();
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ClassificationLastUpdateDate_UTC"), classification.ValidationResults.FirstOrDefault().ErrorMessage);
                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ClassificationLastUpdateDate_UTC", "1980"), classification.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // classification.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.LastUpdateContactTVItemID = 0;
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ClassificationLastUpdateContactTVItemID", classification.LastUpdateContactTVItemID.ToString()), classification.ValidationResults.FirstOrDefault().ErrorMessage);

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.LastUpdateContactTVItemID = 1;
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "ClassificationLastUpdateContactTVItemID", "Contact"), classification.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Classification classification = (from c in dbTestDB.Classifications select c).FirstOrDefault();
                    Assert.IsNotNull(classification);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        classificationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            Classification classificationRet = classificationService.GetClassificationWithClassificationID(classification.ClassificationID);
                            CheckClassificationFields(new List<Classification>() { classificationRet });
                            Assert.AreEqual(classification.ClassificationID, classificationRet.ClassificationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ClassificationWeb classificationWebRet = classificationService.GetClassificationWebWithClassificationID(classification.ClassificationID);
                            CheckClassificationWebFields(new List<ClassificationWeb>() { classificationWebRet });
                            Assert.AreEqual(classification.ClassificationID, classificationWebRet.ClassificationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ClassificationReport classificationReportRet = classificationService.GetClassificationReportWithClassificationID(classification.ClassificationID);
                            CheckClassificationReportFields(new List<ClassificationReport>() { classificationReportRet });
                            Assert.AreEqual(classification.ClassificationID, classificationReportRet.ClassificationID);
                        }
                        else
                        {
                            // nothing for now
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
                    ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Classification classification = (from c in dbTestDB.Classifications select c).FirstOrDefault();
                    Assert.IsNotNull(classification);

                    List<Classification> classificationDirectQueryList = new List<Classification>();
                    classificationDirectQueryList = (from c in dbTestDB.Classifications select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        classificationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ClassificationWeb> classificationWebList = new List<ClassificationWeb>();
                            classificationWebList = classificationService.GetClassificationWebList().ToList();
                            CheckClassificationWebFields(classificationWebList);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ClassificationReport> classificationReportList = new List<ClassificationReport>();
                            classificationReportList = classificationService.GetClassificationReportList().ToList();
                            CheckClassificationReportFields(classificationReportList);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ClassificationWeb> classificationWebList = new List<ClassificationWeb>();
                            classificationWebList = classificationService.GetClassificationWebList().ToList();
                            CheckClassificationWebFields(classificationWebList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationWebList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ClassificationReport> classificationReportList = new List<ClassificationReport>();
                            classificationReportList = classificationService.GetClassificationReportList().ToList();
                            CheckClassificationReportFields(classificationReportList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationReportList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() Skip Take

        #region Tests Generated for GetClassificationList() Skip Take Order
        [TestMethod]
        public void GetClassificationList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 1, 1,  "ClassificationID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).Skip(1).Take(1).OrderBy(c => c.ClassificationID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ClassificationWeb> classificationWebList = new List<ClassificationWeb>();
                            classificationWebList = classificationService.GetClassificationWebList().ToList();
                            CheckClassificationWebFields(classificationWebList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationWebList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ClassificationReport> classificationReportList = new List<ClassificationReport>();
                            classificationReportList = classificationService.GetClassificationReportList().ToList();
                            CheckClassificationReportFields(classificationReportList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationReportList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() Skip Take Order

        #region Tests Generated for GetClassificationList() Skip Take 2Order
        [TestMethod]
        public void GetClassificationList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 1, 1, "ClassificationID,ClassificationTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).Skip(1).Take(1).OrderBy(c => c.ClassificationID).ThenBy(c => c.ClassificationTVItemID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ClassificationWeb> classificationWebList = new List<ClassificationWeb>();
                            classificationWebList = classificationService.GetClassificationWebList().ToList();
                            CheckClassificationWebFields(classificationWebList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationWebList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ClassificationReport> classificationReportList = new List<ClassificationReport>();
                            classificationReportList = classificationService.GetClassificationReportList().ToList();
                            CheckClassificationReportFields(classificationReportList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationReportList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() Skip Take 2Order

        #region Tests Generated for GetClassificationList() Skip Take Order Where
        [TestMethod]
        public void GetClassificationList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 0, 1, "ClassificationID", "ClassificationID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).Where(c => c.ClassificationID == 4).Skip(0).Take(1).OrderBy(c => c.ClassificationID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ClassificationWeb> classificationWebList = new List<ClassificationWeb>();
                            classificationWebList = classificationService.GetClassificationWebList().ToList();
                            CheckClassificationWebFields(classificationWebList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationWebList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ClassificationReport> classificationReportList = new List<ClassificationReport>();
                            classificationReportList = classificationService.GetClassificationReportList().ToList();
                            CheckClassificationReportFields(classificationReportList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationReportList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() Skip Take Order Where

        #region Tests Generated for GetClassificationList() Skip Take Order 2Where
        [TestMethod]
        public void GetClassificationList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 0, 1, "ClassificationID", "ClassificationID,GT,2|ClassificationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).Where(c => c.ClassificationID > 2 && c.ClassificationID < 5).Skip(0).Take(1).OrderBy(c => c.ClassificationID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ClassificationWeb> classificationWebList = new List<ClassificationWeb>();
                            classificationWebList = classificationService.GetClassificationWebList().ToList();
                            CheckClassificationWebFields(classificationWebList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationWebList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ClassificationReport> classificationReportList = new List<ClassificationReport>();
                            classificationReportList = classificationService.GetClassificationReportList().ToList();
                            CheckClassificationReportFields(classificationReportList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationReportList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() Skip Take Order 2Where

        #region Tests Generated for GetClassificationList() 2Where
        [TestMethod]
        public void GetClassificationList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 0, 10000, "", "ClassificationID,GT,2|ClassificationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).Where(c => c.ClassificationID > 2 && c.ClassificationID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ClassificationWeb> classificationWebList = new List<ClassificationWeb>();
                            classificationWebList = classificationService.GetClassificationWebList().ToList();
                            CheckClassificationWebFields(classificationWebList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationWebList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ClassificationReport> classificationReportList = new List<ClassificationReport>();
                            classificationReportList = classificationService.GetClassificationReportList().ToList();
                            CheckClassificationReportFields(classificationReportList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationReportList[0].ClassificationID);
                            Assert.AreEqual(classificationDirectQueryList.Count, classificationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() 2Where

        #region Functions private
        private void CheckClassificationFields(List<Classification> classificationList)
        {
            Assert.IsNotNull(classificationList[0].ClassificationID);
            Assert.IsNotNull(classificationList[0].ClassificationTVItemID);
            Assert.IsNotNull(classificationList[0].ClassificationType);
            Assert.IsNotNull(classificationList[0].Ordinal);
            Assert.IsNotNull(classificationList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(classificationList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(classificationList[0].HasErrors);
        }
        private void CheckClassificationWebFields(List<ClassificationWeb> classificationWebList)
        {
            Assert.IsNotNull(classificationWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(classificationWebList[0].ClassificationTVText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(classificationWebList[0].ClassificationTVText));
            }
            Assert.IsNotNull(classificationWebList[0].ClassificationID);
            Assert.IsNotNull(classificationWebList[0].ClassificationTVItemID);
            Assert.IsNotNull(classificationWebList[0].ClassificationType);
            Assert.IsNotNull(classificationWebList[0].Ordinal);
            Assert.IsNotNull(classificationWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(classificationWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(classificationWebList[0].HasErrors);
        }
        private void CheckClassificationReportFields(List<ClassificationReport> classificationReportList)
        {
            if (!string.IsNullOrWhiteSpace(classificationReportList[0].ClassificationReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(classificationReportList[0].ClassificationReportTest));
            }
            Assert.IsNotNull(classificationReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(classificationReportList[0].ClassificationTVText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(classificationReportList[0].ClassificationTVText));
            }
            Assert.IsNotNull(classificationReportList[0].ClassificationID);
            Assert.IsNotNull(classificationReportList[0].ClassificationTVItemID);
            Assert.IsNotNull(classificationReportList[0].ClassificationType);
            Assert.IsNotNull(classificationReportList[0].Ordinal);
            Assert.IsNotNull(classificationReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(classificationReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(classificationReportList[0].HasErrors);
        }
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
    }
}
