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
    public partial class BoxModelLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private BoxModelLanguageService boxModelLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelLanguageServiceTest() : base()
        {
            //boxModelLanguageService = new BoxModelLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void BoxModelLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    BoxModelLanguage boxModelLanguage = GetFilledRandomBoxModelLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = boxModelLanguageService.GetBoxModelLanguageList().Count();

                    Assert.AreEqual(boxModelLanguageService.GetBoxModelLanguageList().Count(), (from c in dbTestDB.BoxModelLanguages select c).Take(200).Count());

                    boxModelLanguageService.Add(boxModelLanguage);
                    if (boxModelLanguage.HasErrors)
                    {
                        Assert.AreEqual("", boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, boxModelLanguageService.GetBoxModelLanguageList().Where(c => c == boxModelLanguage).Any());
                    boxModelLanguageService.Update(boxModelLanguage);
                    if (boxModelLanguage.HasErrors)
                    {
                        Assert.AreEqual("", boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, boxModelLanguageService.GetBoxModelLanguageList().Count());
                    boxModelLanguageService.Delete(boxModelLanguage);
                    if (boxModelLanguage.HasErrors)
                    {
                        Assert.AreEqual("", boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, boxModelLanguageService.GetBoxModelLanguageList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // boxModelLanguage.BoxModelLanguageID   (Int32)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.BoxModelLanguageID = 0;
                    boxModelLanguageService.Update(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "BoxModelLanguageBoxModelLanguageID"), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.BoxModelLanguageID = 10000000;
                    boxModelLanguageService.Update(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "BoxModelLanguage", "BoxModelLanguageBoxModelLanguageID", boxModelLanguage.BoxModelLanguageID.ToString()), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "BoxModel", ExistPlurial = "s", ExistFieldID = "BoxModelID", AllowableTVtypeList = )]
                    // boxModelLanguage.BoxModelID   (Int32)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.BoxModelID = 0;
                    boxModelLanguageService.Add(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelLanguageBoxModelID", boxModelLanguage.BoxModelID.ToString()), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // boxModelLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.Language = (LanguageEnum)1000000;
                    boxModelLanguageService.Add(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "BoxModelLanguageLanguage"), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // boxModelLanguage.ScenarioName   (String)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("ScenarioName");
                    Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
                    Assert.AreEqual(1, boxModelLanguage.ValidationResults.Count());
                    Assert.IsTrue(boxModelLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "BoxModelLanguageScenarioName")).Any());
                    Assert.AreEqual(null, boxModelLanguage.ScenarioName);
                    Assert.AreEqual(count, boxModelLanguageService.GetBoxModelLanguageList().Count());

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.ScenarioName = GetRandomString("", 251);
                    Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "BoxModelLanguageScenarioName", "250"), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelLanguageService.GetBoxModelLanguageList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // boxModelLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    boxModelLanguageService.Add(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "BoxModelLanguageTranslationStatus"), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // boxModelLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.LastUpdateDate_UTC = new DateTime();
                    boxModelLanguageService.Add(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "BoxModelLanguageLastUpdateDate_UTC"), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    boxModelLanguageService.Add(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "BoxModelLanguageLastUpdateDate_UTC", "1980"), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // boxModelLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.LastUpdateContactTVItemID = 0;
                    boxModelLanguageService.Add(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "BoxModelLanguageLastUpdateContactTVItemID", boxModelLanguage.LastUpdateContactTVItemID.ToString()), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.LastUpdateContactTVItemID = 1;
                    boxModelLanguageService.Add(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "BoxModelLanguageLastUpdateContactTVItemID", "Contact"), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // boxModelLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // boxModelLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetBoxModelLanguageWithBoxModelLanguageID(boxModelLanguage.BoxModelLanguageID)
        [TestMethod]
        public void GetBoxModelLanguageWithBoxModelLanguageID__boxModelLanguage_BoxModelLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    BoxModelLanguage boxModelLanguage = (from c in dbTestDB.BoxModelLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(boxModelLanguage);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        boxModelLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            BoxModelLanguage boxModelLanguageRet = boxModelLanguageService.GetBoxModelLanguageWithBoxModelLanguageID(boxModelLanguage.BoxModelLanguageID);
                            CheckBoxModelLanguageFields(new List<BoxModelLanguage>() { boxModelLanguageRet });
                            Assert.AreEqual(boxModelLanguage.BoxModelLanguageID, boxModelLanguageRet.BoxModelLanguageID);
                        }
                        else if (detail == "A")
                        {
                            BoxModelLanguage_A boxModelLanguage_ARet = boxModelLanguageService.GetBoxModelLanguage_AWithBoxModelLanguageID(boxModelLanguage.BoxModelLanguageID);
                            CheckBoxModelLanguage_AFields(new List<BoxModelLanguage_A>() { boxModelLanguage_ARet });
                            Assert.AreEqual(boxModelLanguage.BoxModelLanguageID, boxModelLanguage_ARet.BoxModelLanguageID);
                        }
                        else if (detail == "B")
                        {
                            BoxModelLanguage_B boxModelLanguage_BRet = boxModelLanguageService.GetBoxModelLanguage_BWithBoxModelLanguageID(boxModelLanguage.BoxModelLanguageID);
                            CheckBoxModelLanguage_BFields(new List<BoxModelLanguage_B>() { boxModelLanguage_BRet });
                            Assert.AreEqual(boxModelLanguage.BoxModelLanguageID, boxModelLanguage_BRet.BoxModelLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelLanguageWithBoxModelLanguageID(boxModelLanguage.BoxModelLanguageID)

        #region Tests Generated for GetBoxModelLanguageList()
        [TestMethod]
        public void GetBoxModelLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    BoxModelLanguage boxModelLanguage = (from c in dbTestDB.BoxModelLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(boxModelLanguage);

                    List<BoxModelLanguage> boxModelLanguageDirectQueryList = new List<BoxModelLanguage>();
                    boxModelLanguageDirectQueryList = (from c in dbTestDB.BoxModelLanguages select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        boxModelLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<BoxModelLanguage> boxModelLanguageList = new List<BoxModelLanguage>();
                            boxModelLanguageList = boxModelLanguageService.GetBoxModelLanguageList().ToList();
                            CheckBoxModelLanguageFields(boxModelLanguageList);
                        }
                        else if (detail == "A")
                        {
                            List<BoxModelLanguage_A> boxModelLanguage_AList = new List<BoxModelLanguage_A>();
                            boxModelLanguage_AList = boxModelLanguageService.GetBoxModelLanguage_AList().ToList();
                            CheckBoxModelLanguage_AFields(boxModelLanguage_AList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList.Count, boxModelLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<BoxModelLanguage_B> boxModelLanguage_BList = new List<BoxModelLanguage_B>();
                            boxModelLanguage_BList = boxModelLanguageService.GetBoxModelLanguage_BList().ToList();
                            CheckBoxModelLanguage_BFields(boxModelLanguage_BList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList.Count, boxModelLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelLanguageList()

        #region Tests Generated for GetBoxModelLanguageList() Skip Take
        [TestMethod]
        public void GetBoxModelLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelLanguageService.Query = boxModelLanguageService.FillQuery(typeof(BoxModelLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<BoxModelLanguage> boxModelLanguageDirectQueryList = new List<BoxModelLanguage>();
                        boxModelLanguageDirectQueryList = (from c in dbTestDB.BoxModelLanguages select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<BoxModelLanguage> boxModelLanguageList = new List<BoxModelLanguage>();
                            boxModelLanguageList = boxModelLanguageService.GetBoxModelLanguageList().ToList();
                            CheckBoxModelLanguageFields(boxModelLanguageList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguageList[0].BoxModelLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<BoxModelLanguage_A> boxModelLanguage_AList = new List<BoxModelLanguage_A>();
                            boxModelLanguage_AList = boxModelLanguageService.GetBoxModelLanguage_AList().ToList();
                            CheckBoxModelLanguage_AFields(boxModelLanguage_AList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguage_AList[0].BoxModelLanguageID);
                            Assert.AreEqual(boxModelLanguageDirectQueryList.Count, boxModelLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<BoxModelLanguage_B> boxModelLanguage_BList = new List<BoxModelLanguage_B>();
                            boxModelLanguage_BList = boxModelLanguageService.GetBoxModelLanguage_BList().ToList();
                            CheckBoxModelLanguage_BFields(boxModelLanguage_BList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguage_BList[0].BoxModelLanguageID);
                            Assert.AreEqual(boxModelLanguageDirectQueryList.Count, boxModelLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelLanguageList() Skip Take

        #region Tests Generated for GetBoxModelLanguageList() Skip Take Order
        [TestMethod]
        public void GetBoxModelLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelLanguageService.Query = boxModelLanguageService.FillQuery(typeof(BoxModelLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "BoxModelLanguageID", "");

                        List<BoxModelLanguage> boxModelLanguageDirectQueryList = new List<BoxModelLanguage>();
                        boxModelLanguageDirectQueryList = (from c in dbTestDB.BoxModelLanguages select c).Skip(1).Take(1).OrderBy(c => c.BoxModelLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<BoxModelLanguage> boxModelLanguageList = new List<BoxModelLanguage>();
                            boxModelLanguageList = boxModelLanguageService.GetBoxModelLanguageList().ToList();
                            CheckBoxModelLanguageFields(boxModelLanguageList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguageList[0].BoxModelLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<BoxModelLanguage_A> boxModelLanguage_AList = new List<BoxModelLanguage_A>();
                            boxModelLanguage_AList = boxModelLanguageService.GetBoxModelLanguage_AList().ToList();
                            CheckBoxModelLanguage_AFields(boxModelLanguage_AList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguage_AList[0].BoxModelLanguageID);
                            Assert.AreEqual(boxModelLanguageDirectQueryList.Count, boxModelLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<BoxModelLanguage_B> boxModelLanguage_BList = new List<BoxModelLanguage_B>();
                            boxModelLanguage_BList = boxModelLanguageService.GetBoxModelLanguage_BList().ToList();
                            CheckBoxModelLanguage_BFields(boxModelLanguage_BList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguage_BList[0].BoxModelLanguageID);
                            Assert.AreEqual(boxModelLanguageDirectQueryList.Count, boxModelLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelLanguageList() Skip Take Order

        #region Tests Generated for GetBoxModelLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetBoxModelLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelLanguageService.Query = boxModelLanguageService.FillQuery(typeof(BoxModelLanguage), culture.TwoLetterISOLanguageName, 1, 1, "BoxModelLanguageID,BoxModelID", "");

                        List<BoxModelLanguage> boxModelLanguageDirectQueryList = new List<BoxModelLanguage>();
                        boxModelLanguageDirectQueryList = (from c in dbTestDB.BoxModelLanguages select c).Skip(1).Take(1).OrderBy(c => c.BoxModelLanguageID).ThenBy(c => c.BoxModelID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<BoxModelLanguage> boxModelLanguageList = new List<BoxModelLanguage>();
                            boxModelLanguageList = boxModelLanguageService.GetBoxModelLanguageList().ToList();
                            CheckBoxModelLanguageFields(boxModelLanguageList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguageList[0].BoxModelLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<BoxModelLanguage_A> boxModelLanguage_AList = new List<BoxModelLanguage_A>();
                            boxModelLanguage_AList = boxModelLanguageService.GetBoxModelLanguage_AList().ToList();
                            CheckBoxModelLanguage_AFields(boxModelLanguage_AList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguage_AList[0].BoxModelLanguageID);
                            Assert.AreEqual(boxModelLanguageDirectQueryList.Count, boxModelLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<BoxModelLanguage_B> boxModelLanguage_BList = new List<BoxModelLanguage_B>();
                            boxModelLanguage_BList = boxModelLanguageService.GetBoxModelLanguage_BList().ToList();
                            CheckBoxModelLanguage_BFields(boxModelLanguage_BList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguage_BList[0].BoxModelLanguageID);
                            Assert.AreEqual(boxModelLanguageDirectQueryList.Count, boxModelLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelLanguageList() Skip Take 2Order

        #region Tests Generated for GetBoxModelLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetBoxModelLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelLanguageService.Query = boxModelLanguageService.FillQuery(typeof(BoxModelLanguage), culture.TwoLetterISOLanguageName, 0, 1, "BoxModelLanguageID", "BoxModelLanguageID,EQ,4", "");

                        List<BoxModelLanguage> boxModelLanguageDirectQueryList = new List<BoxModelLanguage>();
                        boxModelLanguageDirectQueryList = (from c in dbTestDB.BoxModelLanguages select c).Where(c => c.BoxModelLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.BoxModelLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<BoxModelLanguage> boxModelLanguageList = new List<BoxModelLanguage>();
                            boxModelLanguageList = boxModelLanguageService.GetBoxModelLanguageList().ToList();
                            CheckBoxModelLanguageFields(boxModelLanguageList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguageList[0].BoxModelLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<BoxModelLanguage_A> boxModelLanguage_AList = new List<BoxModelLanguage_A>();
                            boxModelLanguage_AList = boxModelLanguageService.GetBoxModelLanguage_AList().ToList();
                            CheckBoxModelLanguage_AFields(boxModelLanguage_AList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguage_AList[0].BoxModelLanguageID);
                            Assert.AreEqual(boxModelLanguageDirectQueryList.Count, boxModelLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<BoxModelLanguage_B> boxModelLanguage_BList = new List<BoxModelLanguage_B>();
                            boxModelLanguage_BList = boxModelLanguageService.GetBoxModelLanguage_BList().ToList();
                            CheckBoxModelLanguage_BFields(boxModelLanguage_BList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguage_BList[0].BoxModelLanguageID);
                            Assert.AreEqual(boxModelLanguageDirectQueryList.Count, boxModelLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelLanguageList() Skip Take Order Where

        #region Tests Generated for GetBoxModelLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetBoxModelLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelLanguageService.Query = boxModelLanguageService.FillQuery(typeof(BoxModelLanguage), culture.TwoLetterISOLanguageName, 0, 1, "BoxModelLanguageID", "BoxModelLanguageID,GT,2|BoxModelLanguageID,LT,5", "");

                        List<BoxModelLanguage> boxModelLanguageDirectQueryList = new List<BoxModelLanguage>();
                        boxModelLanguageDirectQueryList = (from c in dbTestDB.BoxModelLanguages select c).Where(c => c.BoxModelLanguageID > 2 && c.BoxModelLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.BoxModelLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<BoxModelLanguage> boxModelLanguageList = new List<BoxModelLanguage>();
                            boxModelLanguageList = boxModelLanguageService.GetBoxModelLanguageList().ToList();
                            CheckBoxModelLanguageFields(boxModelLanguageList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguageList[0].BoxModelLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<BoxModelLanguage_A> boxModelLanguage_AList = new List<BoxModelLanguage_A>();
                            boxModelLanguage_AList = boxModelLanguageService.GetBoxModelLanguage_AList().ToList();
                            CheckBoxModelLanguage_AFields(boxModelLanguage_AList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguage_AList[0].BoxModelLanguageID);
                            Assert.AreEqual(boxModelLanguageDirectQueryList.Count, boxModelLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<BoxModelLanguage_B> boxModelLanguage_BList = new List<BoxModelLanguage_B>();
                            boxModelLanguage_BList = boxModelLanguageService.GetBoxModelLanguage_BList().ToList();
                            CheckBoxModelLanguage_BFields(boxModelLanguage_BList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguage_BList[0].BoxModelLanguageID);
                            Assert.AreEqual(boxModelLanguageDirectQueryList.Count, boxModelLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetBoxModelLanguageList() 2Where
        [TestMethod]
        public void GetBoxModelLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelLanguageService.Query = boxModelLanguageService.FillQuery(typeof(BoxModelLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "BoxModelLanguageID,GT,2|BoxModelLanguageID,LT,5", "");

                        List<BoxModelLanguage> boxModelLanguageDirectQueryList = new List<BoxModelLanguage>();
                        boxModelLanguageDirectQueryList = (from c in dbTestDB.BoxModelLanguages select c).Where(c => c.BoxModelLanguageID > 2 && c.BoxModelLanguageID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<BoxModelLanguage> boxModelLanguageList = new List<BoxModelLanguage>();
                            boxModelLanguageList = boxModelLanguageService.GetBoxModelLanguageList().ToList();
                            CheckBoxModelLanguageFields(boxModelLanguageList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguageList[0].BoxModelLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<BoxModelLanguage_A> boxModelLanguage_AList = new List<BoxModelLanguage_A>();
                            boxModelLanguage_AList = boxModelLanguageService.GetBoxModelLanguage_AList().ToList();
                            CheckBoxModelLanguage_AFields(boxModelLanguage_AList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguage_AList[0].BoxModelLanguageID);
                            Assert.AreEqual(boxModelLanguageDirectQueryList.Count, boxModelLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<BoxModelLanguage_B> boxModelLanguage_BList = new List<BoxModelLanguage_B>();
                            boxModelLanguage_BList = boxModelLanguageService.GetBoxModelLanguage_BList().ToList();
                            CheckBoxModelLanguage_BFields(boxModelLanguage_BList);
                            Assert.AreEqual(boxModelLanguageDirectQueryList[0].BoxModelLanguageID, boxModelLanguage_BList[0].BoxModelLanguageID);
                            Assert.AreEqual(boxModelLanguageDirectQueryList.Count, boxModelLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelLanguageList() 2Where

        #region Functions private
        private void CheckBoxModelLanguageFields(List<BoxModelLanguage> boxModelLanguageList)
        {
            Assert.IsNotNull(boxModelLanguageList[0].BoxModelLanguageID);
            Assert.IsNotNull(boxModelLanguageList[0].BoxModelID);
            Assert.IsNotNull(boxModelLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguageList[0].ScenarioName));
            Assert.IsNotNull(boxModelLanguageList[0].TranslationStatus);
            Assert.IsNotNull(boxModelLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(boxModelLanguageList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(boxModelLanguageList[0].HasErrors);
        }
        private void CheckBoxModelLanguage_AFields(List<BoxModelLanguage_A> boxModelLanguage_AList)
        {
            Assert.IsNotNull(boxModelLanguage_AList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(boxModelLanguage_AList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguage_AList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(boxModelLanguage_AList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguage_AList[0].TranslationStatusText));
            }
            Assert.IsNotNull(boxModelLanguage_AList[0].BoxModelLanguageID);
            Assert.IsNotNull(boxModelLanguage_AList[0].BoxModelID);
            Assert.IsNotNull(boxModelLanguage_AList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguage_AList[0].ScenarioName));
            Assert.IsNotNull(boxModelLanguage_AList[0].TranslationStatus);
            Assert.IsNotNull(boxModelLanguage_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(boxModelLanguage_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(boxModelLanguage_AList[0].HasErrors);
        }
        private void CheckBoxModelLanguage_BFields(List<BoxModelLanguage_B> boxModelLanguage_BList)
        {
            if (!string.IsNullOrWhiteSpace(boxModelLanguage_BList[0].BoxModelLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguage_BList[0].BoxModelLanguageReportTest));
            }
            Assert.IsNotNull(boxModelLanguage_BList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(boxModelLanguage_BList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguage_BList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(boxModelLanguage_BList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguage_BList[0].TranslationStatusText));
            }
            Assert.IsNotNull(boxModelLanguage_BList[0].BoxModelLanguageID);
            Assert.IsNotNull(boxModelLanguage_BList[0].BoxModelID);
            Assert.IsNotNull(boxModelLanguage_BList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguage_BList[0].ScenarioName));
            Assert.IsNotNull(boxModelLanguage_BList[0].TranslationStatus);
            Assert.IsNotNull(boxModelLanguage_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(boxModelLanguage_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(boxModelLanguage_BList[0].HasErrors);
        }
        private BoxModelLanguage GetFilledRandomBoxModelLanguage(string OmitPropName)
        {
            BoxModelLanguage boxModelLanguage = new BoxModelLanguage();

            if (OmitPropName != "BoxModelID") boxModelLanguage.BoxModelID = 1;
            if (OmitPropName != "Language") boxModelLanguage.Language = LanguageRequest;
            if (OmitPropName != "ScenarioName") boxModelLanguage.ScenarioName = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") boxModelLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") boxModelLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") boxModelLanguage.LastUpdateContactTVItemID = 2;

            return boxModelLanguage;
        }
        #endregion Functions private
    }
}
