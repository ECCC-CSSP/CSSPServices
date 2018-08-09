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
    public partial class MikeSourceServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MikeSourceService mikeSourceService { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceServiceTest() : base()
        {
            //mikeSourceService = new MikeSourceService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MikeSource_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MikeSource mikeSource = GetFilledRandomMikeSource("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mikeSourceService.GetMikeSourceList().Count();

                    Assert.AreEqual(mikeSourceService.GetMikeSourceList().Count(), (from c in dbTestDB.MikeSources select c).Take(200).Count());

                    mikeSourceService.Add(mikeSource);
                    if (mikeSource.HasErrors)
                    {
                        Assert.AreEqual("", mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mikeSourceService.GetMikeSourceList().Where(c => c == mikeSource).Any());
                    mikeSourceService.Update(mikeSource);
                    if (mikeSource.HasErrors)
                    {
                        Assert.AreEqual("", mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mikeSourceService.GetMikeSourceList().Count());
                    mikeSourceService.Delete(mikeSource);
                    if (mikeSource.HasErrors)
                    {
                        Assert.AreEqual("", mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mikeSourceService.GetMikeSourceList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mikeSource.MikeSourceID   (Int32)
                    // -----------------------------------

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.MikeSourceID = 0;
                    mikeSourceService.Update(mikeSource);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MikeSourceMikeSourceID"), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.MikeSourceID = 10000000;
                    mikeSourceService.Update(mikeSource);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MikeSource", "MikeSourceMikeSourceID", mikeSource.MikeSourceID.ToString()), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MikeSource)]
                    // mikeSource.MikeSourceTVItemID   (Int32)
                    // -----------------------------------

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.MikeSourceTVItemID = 0;
                    mikeSourceService.Add(mikeSource);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeSourceMikeSourceTVItemID", mikeSource.MikeSourceTVItemID.ToString()), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.MikeSourceTVItemID = 1;
                    mikeSourceService.Add(mikeSource);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MikeSourceMikeSourceTVItemID", "MikeSource"), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // mikeSource.IsContinuous   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // mikeSource.Include   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // mikeSource.IsRiver   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(50))]
                    // mikeSource.SourceNumberString   (String)
                    // -----------------------------------

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("SourceNumberString");
                    Assert.AreEqual(false, mikeSourceService.Add(mikeSource));
                    Assert.AreEqual(1, mikeSource.ValidationResults.Count());
                    Assert.IsTrue(mikeSource.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "MikeSourceSourceNumberString")).Any());
                    Assert.AreEqual(null, mikeSource.SourceNumberString);
                    Assert.AreEqual(count, mikeSourceService.GetMikeSourceList().Count());

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.SourceNumberString = GetRandomString("", 51);
                    Assert.AreEqual(false, mikeSourceService.Add(mikeSource));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "MikeSourceSourceNumberString", "50"), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceService.GetMikeSourceList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeSource.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.LastUpdateDate_UTC = new DateTime();
                    mikeSourceService.Add(mikeSource);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MikeSourceLastUpdateDate_UTC"), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mikeSourceService.Add(mikeSource);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeSourceLastUpdateDate_UTC", "1980"), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mikeSource.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.LastUpdateContactTVItemID = 0;
                    mikeSourceService.Add(mikeSource);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeSourceLastUpdateContactTVItemID", mikeSource.LastUpdateContactTVItemID.ToString()), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.LastUpdateContactTVItemID = 1;
                    mikeSourceService.Add(mikeSource);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MikeSourceLastUpdateContactTVItemID", "Contact"), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeSource.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeSource.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMikeSourceWithMikeSourceID(mikeSource.MikeSourceID)
        [TestMethod]
        public void GetMikeSourceWithMikeSourceID__mikeSource_MikeSourceID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MikeSource mikeSource = (from c in dbTestDB.MikeSources select c).FirstOrDefault();
                    Assert.IsNotNull(mikeSource);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        mikeSourceService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            MikeSource mikeSourceRet = mikeSourceService.GetMikeSourceWithMikeSourceID(mikeSource.MikeSourceID);
                            CheckMikeSourceFields(new List<MikeSource>() { mikeSourceRet });
                            Assert.AreEqual(mikeSource.MikeSourceID, mikeSourceRet.MikeSourceID);
                        }
                        else if (detail == "A")
                        {
                            MikeSource_A mikeSource_ARet = mikeSourceService.GetMikeSource_AWithMikeSourceID(mikeSource.MikeSourceID);
                            CheckMikeSource_AFields(new List<MikeSource_A>() { mikeSource_ARet });
                            Assert.AreEqual(mikeSource.MikeSourceID, mikeSource_ARet.MikeSourceID);
                        }
                        else if (detail == "B")
                        {
                            MikeSource_B mikeSource_BRet = mikeSourceService.GetMikeSource_BWithMikeSourceID(mikeSource.MikeSourceID);
                            CheckMikeSource_BFields(new List<MikeSource_B>() { mikeSource_BRet });
                            Assert.AreEqual(mikeSource.MikeSourceID, mikeSource_BRet.MikeSourceID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceWithMikeSourceID(mikeSource.MikeSourceID)

        #region Tests Generated for GetMikeSourceList()
        [TestMethod]
        public void GetMikeSourceList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MikeSource mikeSource = (from c in dbTestDB.MikeSources select c).FirstOrDefault();
                    Assert.IsNotNull(mikeSource);

                    List<MikeSource> mikeSourceDirectQueryList = new List<MikeSource>();
                    mikeSourceDirectQueryList = (from c in dbTestDB.MikeSources select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        mikeSourceService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MikeSource> mikeSourceList = new List<MikeSource>();
                            mikeSourceList = mikeSourceService.GetMikeSourceList().ToList();
                            CheckMikeSourceFields(mikeSourceList);
                        }
                        else if (detail == "A")
                        {
                            List<MikeSource_A> mikeSource_AList = new List<MikeSource_A>();
                            mikeSource_AList = mikeSourceService.GetMikeSource_AList().ToList();
                            CheckMikeSource_AFields(mikeSource_AList);
                            Assert.AreEqual(mikeSourceDirectQueryList.Count, mikeSource_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MikeSource_B> mikeSource_BList = new List<MikeSource_B>();
                            mikeSource_BList = mikeSourceService.GetMikeSource_BList().ToList();
                            CheckMikeSource_BFields(mikeSource_BList);
                            Assert.AreEqual(mikeSourceDirectQueryList.Count, mikeSource_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceList()

        #region Tests Generated for GetMikeSourceList() Skip Take
        [TestMethod]
        public void GetMikeSourceList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeSourceService.Query = mikeSourceService.FillQuery(typeof(MikeSource), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<MikeSource> mikeSourceDirectQueryList = new List<MikeSource>();
                        mikeSourceDirectQueryList = (from c in dbTestDB.MikeSources select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MikeSource> mikeSourceList = new List<MikeSource>();
                            mikeSourceList = mikeSourceService.GetMikeSourceList().ToList();
                            CheckMikeSourceFields(mikeSourceList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSourceList[0].MikeSourceID);
                        }
                        else if (detail == "A")
                        {
                            List<MikeSource_A> mikeSource_AList = new List<MikeSource_A>();
                            mikeSource_AList = mikeSourceService.GetMikeSource_AList().ToList();
                            CheckMikeSource_AFields(mikeSource_AList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSource_AList[0].MikeSourceID);
                            Assert.AreEqual(mikeSourceDirectQueryList.Count, mikeSource_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MikeSource_B> mikeSource_BList = new List<MikeSource_B>();
                            mikeSource_BList = mikeSourceService.GetMikeSource_BList().ToList();
                            CheckMikeSource_BFields(mikeSource_BList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSource_BList[0].MikeSourceID);
                            Assert.AreEqual(mikeSourceDirectQueryList.Count, mikeSource_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceList() Skip Take

        #region Tests Generated for GetMikeSourceList() Skip Take Order
        [TestMethod]
        public void GetMikeSourceList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeSourceService.Query = mikeSourceService.FillQuery(typeof(MikeSource), culture.TwoLetterISOLanguageName, 1, 1,  "MikeSourceID", "");

                        List<MikeSource> mikeSourceDirectQueryList = new List<MikeSource>();
                        mikeSourceDirectQueryList = (from c in dbTestDB.MikeSources select c).Skip(1).Take(1).OrderBy(c => c.MikeSourceID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MikeSource> mikeSourceList = new List<MikeSource>();
                            mikeSourceList = mikeSourceService.GetMikeSourceList().ToList();
                            CheckMikeSourceFields(mikeSourceList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSourceList[0].MikeSourceID);
                        }
                        else if (detail == "A")
                        {
                            List<MikeSource_A> mikeSource_AList = new List<MikeSource_A>();
                            mikeSource_AList = mikeSourceService.GetMikeSource_AList().ToList();
                            CheckMikeSource_AFields(mikeSource_AList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSource_AList[0].MikeSourceID);
                            Assert.AreEqual(mikeSourceDirectQueryList.Count, mikeSource_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MikeSource_B> mikeSource_BList = new List<MikeSource_B>();
                            mikeSource_BList = mikeSourceService.GetMikeSource_BList().ToList();
                            CheckMikeSource_BFields(mikeSource_BList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSource_BList[0].MikeSourceID);
                            Assert.AreEqual(mikeSourceDirectQueryList.Count, mikeSource_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceList() Skip Take Order

        #region Tests Generated for GetMikeSourceList() Skip Take 2Order
        [TestMethod]
        public void GetMikeSourceList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeSourceService.Query = mikeSourceService.FillQuery(typeof(MikeSource), culture.TwoLetterISOLanguageName, 1, 1, "MikeSourceID,MikeSourceTVItemID", "");

                        List<MikeSource> mikeSourceDirectQueryList = new List<MikeSource>();
                        mikeSourceDirectQueryList = (from c in dbTestDB.MikeSources select c).Skip(1).Take(1).OrderBy(c => c.MikeSourceID).ThenBy(c => c.MikeSourceTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MikeSource> mikeSourceList = new List<MikeSource>();
                            mikeSourceList = mikeSourceService.GetMikeSourceList().ToList();
                            CheckMikeSourceFields(mikeSourceList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSourceList[0].MikeSourceID);
                        }
                        else if (detail == "A")
                        {
                            List<MikeSource_A> mikeSource_AList = new List<MikeSource_A>();
                            mikeSource_AList = mikeSourceService.GetMikeSource_AList().ToList();
                            CheckMikeSource_AFields(mikeSource_AList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSource_AList[0].MikeSourceID);
                            Assert.AreEqual(mikeSourceDirectQueryList.Count, mikeSource_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MikeSource_B> mikeSource_BList = new List<MikeSource_B>();
                            mikeSource_BList = mikeSourceService.GetMikeSource_BList().ToList();
                            CheckMikeSource_BFields(mikeSource_BList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSource_BList[0].MikeSourceID);
                            Assert.AreEqual(mikeSourceDirectQueryList.Count, mikeSource_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceList() Skip Take 2Order

        #region Tests Generated for GetMikeSourceList() Skip Take Order Where
        [TestMethod]
        public void GetMikeSourceList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeSourceService.Query = mikeSourceService.FillQuery(typeof(MikeSource), culture.TwoLetterISOLanguageName, 0, 1, "MikeSourceID", "MikeSourceID,EQ,4", "");

                        List<MikeSource> mikeSourceDirectQueryList = new List<MikeSource>();
                        mikeSourceDirectQueryList = (from c in dbTestDB.MikeSources select c).Where(c => c.MikeSourceID == 4).Skip(0).Take(1).OrderBy(c => c.MikeSourceID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MikeSource> mikeSourceList = new List<MikeSource>();
                            mikeSourceList = mikeSourceService.GetMikeSourceList().ToList();
                            CheckMikeSourceFields(mikeSourceList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSourceList[0].MikeSourceID);
                        }
                        else if (detail == "A")
                        {
                            List<MikeSource_A> mikeSource_AList = new List<MikeSource_A>();
                            mikeSource_AList = mikeSourceService.GetMikeSource_AList().ToList();
                            CheckMikeSource_AFields(mikeSource_AList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSource_AList[0].MikeSourceID);
                            Assert.AreEqual(mikeSourceDirectQueryList.Count, mikeSource_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MikeSource_B> mikeSource_BList = new List<MikeSource_B>();
                            mikeSource_BList = mikeSourceService.GetMikeSource_BList().ToList();
                            CheckMikeSource_BFields(mikeSource_BList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSource_BList[0].MikeSourceID);
                            Assert.AreEqual(mikeSourceDirectQueryList.Count, mikeSource_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceList() Skip Take Order Where

        #region Tests Generated for GetMikeSourceList() Skip Take Order 2Where
        [TestMethod]
        public void GetMikeSourceList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeSourceService.Query = mikeSourceService.FillQuery(typeof(MikeSource), culture.TwoLetterISOLanguageName, 0, 1, "MikeSourceID", "MikeSourceID,GT,2|MikeSourceID,LT,5", "");

                        List<MikeSource> mikeSourceDirectQueryList = new List<MikeSource>();
                        mikeSourceDirectQueryList = (from c in dbTestDB.MikeSources select c).Where(c => c.MikeSourceID > 2 && c.MikeSourceID < 5).Skip(0).Take(1).OrderBy(c => c.MikeSourceID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MikeSource> mikeSourceList = new List<MikeSource>();
                            mikeSourceList = mikeSourceService.GetMikeSourceList().ToList();
                            CheckMikeSourceFields(mikeSourceList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSourceList[0].MikeSourceID);
                        }
                        else if (detail == "A")
                        {
                            List<MikeSource_A> mikeSource_AList = new List<MikeSource_A>();
                            mikeSource_AList = mikeSourceService.GetMikeSource_AList().ToList();
                            CheckMikeSource_AFields(mikeSource_AList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSource_AList[0].MikeSourceID);
                            Assert.AreEqual(mikeSourceDirectQueryList.Count, mikeSource_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MikeSource_B> mikeSource_BList = new List<MikeSource_B>();
                            mikeSource_BList = mikeSourceService.GetMikeSource_BList().ToList();
                            CheckMikeSource_BFields(mikeSource_BList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSource_BList[0].MikeSourceID);
                            Assert.AreEqual(mikeSourceDirectQueryList.Count, mikeSource_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceList() Skip Take Order 2Where

        #region Tests Generated for GetMikeSourceList() 2Where
        [TestMethod]
        public void GetMikeSourceList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MikeSourceService mikeSourceService = new MikeSourceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeSourceService.Query = mikeSourceService.FillQuery(typeof(MikeSource), culture.TwoLetterISOLanguageName, 0, 10000, "", "MikeSourceID,GT,2|MikeSourceID,LT,5", "");

                        List<MikeSource> mikeSourceDirectQueryList = new List<MikeSource>();
                        mikeSourceDirectQueryList = (from c in dbTestDB.MikeSources select c).Where(c => c.MikeSourceID > 2 && c.MikeSourceID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MikeSource> mikeSourceList = new List<MikeSource>();
                            mikeSourceList = mikeSourceService.GetMikeSourceList().ToList();
                            CheckMikeSourceFields(mikeSourceList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSourceList[0].MikeSourceID);
                        }
                        else if (detail == "A")
                        {
                            List<MikeSource_A> mikeSource_AList = new List<MikeSource_A>();
                            mikeSource_AList = mikeSourceService.GetMikeSource_AList().ToList();
                            CheckMikeSource_AFields(mikeSource_AList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSource_AList[0].MikeSourceID);
                            Assert.AreEqual(mikeSourceDirectQueryList.Count, mikeSource_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MikeSource_B> mikeSource_BList = new List<MikeSource_B>();
                            mikeSource_BList = mikeSourceService.GetMikeSource_BList().ToList();
                            CheckMikeSource_BFields(mikeSource_BList);
                            Assert.AreEqual(mikeSourceDirectQueryList[0].MikeSourceID, mikeSource_BList[0].MikeSourceID);
                            Assert.AreEqual(mikeSourceDirectQueryList.Count, mikeSource_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceList() 2Where

        #region Functions private
        private void CheckMikeSourceFields(List<MikeSource> mikeSourceList)
        {
            Assert.IsNotNull(mikeSourceList[0].MikeSourceID);
            Assert.IsNotNull(mikeSourceList[0].MikeSourceTVItemID);
            Assert.IsNotNull(mikeSourceList[0].IsContinuous);
            Assert.IsNotNull(mikeSourceList[0].Include);
            Assert.IsNotNull(mikeSourceList[0].IsRiver);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeSourceList[0].SourceNumberString));
            Assert.IsNotNull(mikeSourceList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mikeSourceList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mikeSourceList[0].HasErrors);
        }
        private void CheckMikeSource_AFields(List<MikeSource_A> mikeSource_AList)
        {
            Assert.IsNotNull(mikeSource_AList[0].MikeSourceTVItemLanguage);
            Assert.IsNotNull(mikeSource_AList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(mikeSource_AList[0].MikeSourceID);
            Assert.IsNotNull(mikeSource_AList[0].MikeSourceTVItemID);
            Assert.IsNotNull(mikeSource_AList[0].IsContinuous);
            Assert.IsNotNull(mikeSource_AList[0].Include);
            Assert.IsNotNull(mikeSource_AList[0].IsRiver);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeSource_AList[0].SourceNumberString));
            Assert.IsNotNull(mikeSource_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mikeSource_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mikeSource_AList[0].HasErrors);
        }
        private void CheckMikeSource_BFields(List<MikeSource_B> mikeSource_BList)
        {
            if (!string.IsNullOrWhiteSpace(mikeSource_BList[0].MikeSourceReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeSource_BList[0].MikeSourceReportTest));
            }
            Assert.IsNotNull(mikeSource_BList[0].MikeSourceTVItemLanguage);
            Assert.IsNotNull(mikeSource_BList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(mikeSource_BList[0].MikeSourceID);
            Assert.IsNotNull(mikeSource_BList[0].MikeSourceTVItemID);
            Assert.IsNotNull(mikeSource_BList[0].IsContinuous);
            Assert.IsNotNull(mikeSource_BList[0].Include);
            Assert.IsNotNull(mikeSource_BList[0].IsRiver);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeSource_BList[0].SourceNumberString));
            Assert.IsNotNull(mikeSource_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mikeSource_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mikeSource_BList[0].HasErrors);
        }
        private MikeSource GetFilledRandomMikeSource(string OmitPropName)
        {
            MikeSource mikeSource = new MikeSource();

            if (OmitPropName != "MikeSourceTVItemID") mikeSource.MikeSourceTVItemID = 49;
            if (OmitPropName != "IsContinuous") mikeSource.IsContinuous = true;
            if (OmitPropName != "Include") mikeSource.Include = true;
            if (OmitPropName != "IsRiver") mikeSource.IsRiver = true;
            if (OmitPropName != "SourceNumberString") mikeSource.SourceNumberString = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") mikeSource.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeSource.LastUpdateContactTVItemID = 2;

            return mikeSource;
        }
        #endregion Functions private
    }
}
