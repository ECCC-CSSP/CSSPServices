 /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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

        #region Tests Generated CRUD
        [TestMethod]
        public void Classification_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    Assert.AreEqual(count, (from c in dbTestDB.Classifications select c).Count());

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

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [TestMethod]
        public void Classification_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = classificationService.GetClassificationList().Count();

                    Classification classification = GetFilledRandomClassification("");

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ClassificationID"), classification.ValidationResults.FirstOrDefault().ErrorMessage);

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationID = 10000000;
                    classificationService.Update(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Classification", "ClassificationID", classification.ClassificationID.ToString()), classification.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Classification)]
                    // classification.ClassificationTVItemID   (Int32)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationTVItemID = 0;
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ClassificationTVItemID", classification.ClassificationTVItemID.ToString()), classification.ValidationResults.FirstOrDefault().ErrorMessage);

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationTVItemID = 1;
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "ClassificationTVItemID", "Classification"), classification.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // classification.ClassificationType   (ClassificationTypeEnum)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.ClassificationType = (ClassificationTypeEnum)1000000;
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ClassificationType"), classification.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000)]
                    // classification.Ordinal   (Int32)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.Ordinal = -1;
                    Assert.AreEqual(false, classificationService.Add(classification));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "10000"), classification.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, classificationService.GetClassificationList().Count());
                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.Ordinal = 10001;
                    Assert.AreEqual(false, classificationService.Add(classification));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "10000"), classification.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), classification.ValidationResults.FirstOrDefault().ErrorMessage);
                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), classification.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // classification.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.LastUpdateContactTVItemID = 0;
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", classification.LastUpdateContactTVItemID.ToString()), classification.ValidationResults.FirstOrDefault().ErrorMessage);

                    classification = null;
                    classification = GetFilledRandomClassification("");
                    classification.LastUpdateContactTVItemID = 1;
                    classificationService.Add(classification);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), classification.ValidationResults.FirstOrDefault().ErrorMessage);


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
        #endregion Tests Generated Properties

        #region Tests Generated for GetClassificationWithClassificationID(classification.ClassificationID)
        [TestMethod]
        public void GetClassificationWithClassificationID__classification_ClassificationID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Classification classification = (from c in dbTestDB.Classifications select c).FirstOrDefault();
                    Assert.IsNotNull(classification);

                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        classificationService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            Classification classificationRet = classificationService.GetClassificationWithClassificationID(classification.ClassificationID);
                            CheckClassificationFields(new List<Classification>() { classificationRet });
                            Assert.AreEqual(classification.ClassificationID, classificationRet.ClassificationID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Classification classification = (from c in dbTestDB.Classifications select c).FirstOrDefault();
                    Assert.IsNotNull(classification);

                    List<Classification> classificationDirectQueryList = new List<Classification>();
                    classificationDirectQueryList = (from c in dbTestDB.Classifications select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        classificationService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 1, 1, "", "", "", extra);

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() Skip Take

        #region Tests Generated for GetClassificationList() Skip Take Asc
        [TestMethod]
        public void GetClassificationList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 1, 1,  "ClassificationID", "", "", extra);

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).OrderBy(c => c.ClassificationID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() Skip Take Asc

        #region Tests Generated for GetClassificationList() Skip Take 2 Asc
        [TestMethod]
        public void GetClassificationList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 1, 1, "ClassificationID,ClassificationTVItemID", "", "", extra);

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).OrderBy(c => c.ClassificationID).ThenBy(c => c.ClassificationTVItemID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() Skip Take 2 Asc

        #region Tests Generated for GetClassificationList() Skip Take Asc Where
        [TestMethod]
        public void GetClassificationList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 0, 1, "ClassificationID", "", "ClassificationID,EQ,4", "");

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).Where(c => c.ClassificationID == 4).OrderBy(c => c.ClassificationID).Skip(0).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() Skip Take Asc Where

        #region Tests Generated for GetClassificationList() Skip Take Asc 2 Where
        [TestMethod]
        public void GetClassificationList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 0, 1, "ClassificationID", "", "ClassificationID,GT,2|ClassificationID,LT,5", "");

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).Where(c => c.ClassificationID > 2 && c.ClassificationID < 5).Skip(0).Take(1).OrderBy(c => c.ClassificationID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() Skip Take Asc 2 Where

        #region Tests Generated for GetClassificationList() Skip Take Desc
        [TestMethod]
        public void GetClassificationList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 1, 1, "", "ClassificationID", "", extra);

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).OrderByDescending(c => c.ClassificationID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() Skip Take Desc

        #region Tests Generated for GetClassificationList() Skip Take 2 Desc
        [TestMethod]
        public void GetClassificationList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 1, 1, "", "ClassificationID,ClassificationTVItemID", "", extra);

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).OrderByDescending(c => c.ClassificationID).ThenByDescending(c => c.ClassificationTVItemID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() Skip Take 2 Desc

        #region Tests Generated for GetClassificationList() Skip Take Desc Where
        [TestMethod]
        public void GetClassificationList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 0, 1, "ClassificationID", "", "ClassificationID,EQ,4", "");

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).Where(c => c.ClassificationID == 4).OrderByDescending(c => c.ClassificationID).Skip(0).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() Skip Take Desc Where

        #region Tests Generated for GetClassificationList() Skip Take Desc 2 Where
        [TestMethod]
        public void GetClassificationList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 0, 1, "", "ClassificationID", "ClassificationID,GT,2|ClassificationID,LT,5", "");

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).Where(c => c.ClassificationID > 2 && c.ClassificationID < 5).OrderByDescending(c => c.ClassificationID).Skip(0).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() Skip Take Desc 2 Where

        #region Tests Generated for GetClassificationList() 2 Where
        [TestMethod]
        public void GetClassificationList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        ClassificationService classificationService = new ClassificationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        classificationService.Query = classificationService.FillQuery(typeof(Classification), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "ClassificationID,GT,2|ClassificationID,LT,5", extra);

                        List<Classification> classificationDirectQueryList = new List<Classification>();
                        classificationDirectQueryList = (from c in dbTestDB.Classifications select c).Where(c => c.ClassificationID > 2 && c.ClassificationID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Classification> classificationList = new List<Classification>();
                            classificationList = classificationService.GetClassificationList().ToList();
                            CheckClassificationFields(classificationList);
                            Assert.AreEqual(classificationDirectQueryList[0].ClassificationID, classificationList[0].ClassificationID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetClassificationList() 2 Where

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
