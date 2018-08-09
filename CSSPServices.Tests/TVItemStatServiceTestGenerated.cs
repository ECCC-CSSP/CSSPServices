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
    public partial class TVItemStatServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemStatService tvItemStatService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemStatServiceTest() : base()
        {
            //tvItemStatService = new TVItemStatService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVItemStat_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TVItemStat tvItemStat = GetFilledRandomTVItemStat("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tvItemStatService.GetTVItemStatList().Count();

                    Assert.AreEqual(tvItemStatService.GetTVItemStatList().Count(), (from c in dbTestDB.TVItemStats select c).Take(200).Count());

                    tvItemStatService.Add(tvItemStat);
                    if (tvItemStat.HasErrors)
                    {
                        Assert.AreEqual("", tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvItemStatService.GetTVItemStatList().Where(c => c == tvItemStat).Any());
                    tvItemStatService.Update(tvItemStat);
                    if (tvItemStat.HasErrors)
                    {
                        Assert.AreEqual("", tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvItemStatService.GetTVItemStatList().Count());
                    tvItemStatService.Delete(tvItemStat);
                    if (tvItemStat.HasErrors)
                    {
                        Assert.AreEqual("", tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvItemStatService.GetTVItemStatList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tvItemStat.TVItemStatID   (Int32)
                    // -----------------------------------

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.TVItemStatID = 0;
                    tvItemStatService.Update(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemStatTVItemStatID"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.TVItemStatID = 10000000;
                    tvItemStatService.Update(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItemStat", "TVItemStatTVItemStatID", tvItemStat.TVItemStatID.ToString()), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint)]
                    // tvItemStat.TVItemID   (Int32)
                    // -----------------------------------

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.TVItemID = 0;
                    tvItemStatService.Add(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemStatTVItemID", tvItemStat.TVItemID.ToString()), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.TVItemID = 13;
                    tvItemStatService.Add(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemStatTVItemID", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItemStat.TVType   (TVTypeEnum)
                    // -----------------------------------

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.TVType = (TVTypeEnum)1000000;
                    tvItemStatService.Add(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemStatTVType"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // tvItemStat.ChildCount   (Int32)
                    // -----------------------------------

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.ChildCount = -1;
                    Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVItemStatChildCount", "0", "10000000"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemStatService.GetTVItemStatList().Count());
                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.ChildCount = 10000001;
                    Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVItemStatChildCount", "0", "10000000"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemStatService.GetTVItemStatList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvItemStat.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.LastUpdateDate_UTC = new DateTime();
                    tvItemStatService.Add(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemStatLastUpdateDate_UTC"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvItemStatService.Add(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVItemStatLastUpdateDate_UTC", "1980"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvItemStat.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.LastUpdateContactTVItemID = 0;
                    tvItemStatService.Add(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemStatLastUpdateContactTVItemID", tvItemStat.LastUpdateContactTVItemID.ToString()), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.LastUpdateContactTVItemID = 1;
                    tvItemStatService.Add(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemStatLastUpdateContactTVItemID", "Contact"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemStat.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemStat.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTVItemStatWithTVItemStatID(tvItemStat.TVItemStatID)
        [TestMethod]
        public void GetTVItemStatWithTVItemStatID__tvItemStat_TVItemStatID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVItemStat tvItemStat = (from c in dbTestDB.TVItemStats select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemStat);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        tvItemStatService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            TVItemStat tvItemStatRet = tvItemStatService.GetTVItemStatWithTVItemStatID(tvItemStat.TVItemStatID);
                            CheckTVItemStatFields(new List<TVItemStat>() { tvItemStatRet });
                            Assert.AreEqual(tvItemStat.TVItemStatID, tvItemStatRet.TVItemStatID);
                        }
                        else if (detail == "A")
                        {
                            TVItemStat_A tvItemStat_ARet = tvItemStatService.GetTVItemStat_AWithTVItemStatID(tvItemStat.TVItemStatID);
                            CheckTVItemStat_AFields(new List<TVItemStat_A>() { tvItemStat_ARet });
                            Assert.AreEqual(tvItemStat.TVItemStatID, tvItemStat_ARet.TVItemStatID);
                        }
                        else if (detail == "B")
                        {
                            TVItemStat_B tvItemStat_BRet = tvItemStatService.GetTVItemStat_BWithTVItemStatID(tvItemStat.TVItemStatID);
                            CheckTVItemStat_BFields(new List<TVItemStat_B>() { tvItemStat_BRet });
                            Assert.AreEqual(tvItemStat.TVItemStatID, tvItemStat_BRet.TVItemStatID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemStatWithTVItemStatID(tvItemStat.TVItemStatID)

        #region Tests Generated for GetTVItemStatList()
        [TestMethod]
        public void GetTVItemStatList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVItemStat tvItemStat = (from c in dbTestDB.TVItemStats select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemStat);

                    List<TVItemStat> tvItemStatDirectQueryList = new List<TVItemStat>();
                    tvItemStatDirectQueryList = (from c in dbTestDB.TVItemStats select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        tvItemStatService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemStat> tvItemStatList = new List<TVItemStat>();
                            tvItemStatList = tvItemStatService.GetTVItemStatList().ToList();
                            CheckTVItemStatFields(tvItemStatList);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemStat_A> tvItemStat_AList = new List<TVItemStat_A>();
                            tvItemStat_AList = tvItemStatService.GetTVItemStat_AList().ToList();
                            CheckTVItemStat_AFields(tvItemStat_AList);
                            Assert.AreEqual(tvItemStatDirectQueryList.Count, tvItemStat_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemStat_B> tvItemStat_BList = new List<TVItemStat_B>();
                            tvItemStat_BList = tvItemStatService.GetTVItemStat_BList().ToList();
                            CheckTVItemStat_BFields(tvItemStat_BList);
                            Assert.AreEqual(tvItemStatDirectQueryList.Count, tvItemStat_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemStatList()

        #region Tests Generated for GetTVItemStatList() Skip Take
        [TestMethod]
        public void GetTVItemStatList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemStatService.Query = tvItemStatService.FillQuery(typeof(TVItemStat), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<TVItemStat> tvItemStatDirectQueryList = new List<TVItemStat>();
                        tvItemStatDirectQueryList = (from c in dbTestDB.TVItemStats select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemStat> tvItemStatList = new List<TVItemStat>();
                            tvItemStatList = tvItemStatService.GetTVItemStatList().ToList();
                            CheckTVItemStatFields(tvItemStatList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStatList[0].TVItemStatID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemStat_A> tvItemStat_AList = new List<TVItemStat_A>();
                            tvItemStat_AList = tvItemStatService.GetTVItemStat_AList().ToList();
                            CheckTVItemStat_AFields(tvItemStat_AList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStat_AList[0].TVItemStatID);
                            Assert.AreEqual(tvItemStatDirectQueryList.Count, tvItemStat_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemStat_B> tvItemStat_BList = new List<TVItemStat_B>();
                            tvItemStat_BList = tvItemStatService.GetTVItemStat_BList().ToList();
                            CheckTVItemStat_BFields(tvItemStat_BList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStat_BList[0].TVItemStatID);
                            Assert.AreEqual(tvItemStatDirectQueryList.Count, tvItemStat_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemStatList() Skip Take

        #region Tests Generated for GetTVItemStatList() Skip Take Order
        [TestMethod]
        public void GetTVItemStatList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemStatService.Query = tvItemStatService.FillQuery(typeof(TVItemStat), culture.TwoLetterISOLanguageName, 1, 1,  "TVItemStatID", "");

                        List<TVItemStat> tvItemStatDirectQueryList = new List<TVItemStat>();
                        tvItemStatDirectQueryList = (from c in dbTestDB.TVItemStats select c).Skip(1).Take(1).OrderBy(c => c.TVItemStatID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemStat> tvItemStatList = new List<TVItemStat>();
                            tvItemStatList = tvItemStatService.GetTVItemStatList().ToList();
                            CheckTVItemStatFields(tvItemStatList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStatList[0].TVItemStatID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemStat_A> tvItemStat_AList = new List<TVItemStat_A>();
                            tvItemStat_AList = tvItemStatService.GetTVItemStat_AList().ToList();
                            CheckTVItemStat_AFields(tvItemStat_AList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStat_AList[0].TVItemStatID);
                            Assert.AreEqual(tvItemStatDirectQueryList.Count, tvItemStat_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemStat_B> tvItemStat_BList = new List<TVItemStat_B>();
                            tvItemStat_BList = tvItemStatService.GetTVItemStat_BList().ToList();
                            CheckTVItemStat_BFields(tvItemStat_BList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStat_BList[0].TVItemStatID);
                            Assert.AreEqual(tvItemStatDirectQueryList.Count, tvItemStat_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemStatList() Skip Take Order

        #region Tests Generated for GetTVItemStatList() Skip Take 2Order
        [TestMethod]
        public void GetTVItemStatList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemStatService.Query = tvItemStatService.FillQuery(typeof(TVItemStat), culture.TwoLetterISOLanguageName, 1, 1, "TVItemStatID,TVItemID", "");

                        List<TVItemStat> tvItemStatDirectQueryList = new List<TVItemStat>();
                        tvItemStatDirectQueryList = (from c in dbTestDB.TVItemStats select c).Skip(1).Take(1).OrderBy(c => c.TVItemStatID).ThenBy(c => c.TVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemStat> tvItemStatList = new List<TVItemStat>();
                            tvItemStatList = tvItemStatService.GetTVItemStatList().ToList();
                            CheckTVItemStatFields(tvItemStatList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStatList[0].TVItemStatID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemStat_A> tvItemStat_AList = new List<TVItemStat_A>();
                            tvItemStat_AList = tvItemStatService.GetTVItemStat_AList().ToList();
                            CheckTVItemStat_AFields(tvItemStat_AList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStat_AList[0].TVItemStatID);
                            Assert.AreEqual(tvItemStatDirectQueryList.Count, tvItemStat_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemStat_B> tvItemStat_BList = new List<TVItemStat_B>();
                            tvItemStat_BList = tvItemStatService.GetTVItemStat_BList().ToList();
                            CheckTVItemStat_BFields(tvItemStat_BList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStat_BList[0].TVItemStatID);
                            Assert.AreEqual(tvItemStatDirectQueryList.Count, tvItemStat_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemStatList() Skip Take 2Order

        #region Tests Generated for GetTVItemStatList() Skip Take Order Where
        [TestMethod]
        public void GetTVItemStatList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemStatService.Query = tvItemStatService.FillQuery(typeof(TVItemStat), culture.TwoLetterISOLanguageName, 0, 1, "TVItemStatID", "TVItemStatID,EQ,4", "");

                        List<TVItemStat> tvItemStatDirectQueryList = new List<TVItemStat>();
                        tvItemStatDirectQueryList = (from c in dbTestDB.TVItemStats select c).Where(c => c.TVItemStatID == 4).Skip(0).Take(1).OrderBy(c => c.TVItemStatID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemStat> tvItemStatList = new List<TVItemStat>();
                            tvItemStatList = tvItemStatService.GetTVItemStatList().ToList();
                            CheckTVItemStatFields(tvItemStatList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStatList[0].TVItemStatID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemStat_A> tvItemStat_AList = new List<TVItemStat_A>();
                            tvItemStat_AList = tvItemStatService.GetTVItemStat_AList().ToList();
                            CheckTVItemStat_AFields(tvItemStat_AList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStat_AList[0].TVItemStatID);
                            Assert.AreEqual(tvItemStatDirectQueryList.Count, tvItemStat_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemStat_B> tvItemStat_BList = new List<TVItemStat_B>();
                            tvItemStat_BList = tvItemStatService.GetTVItemStat_BList().ToList();
                            CheckTVItemStat_BFields(tvItemStat_BList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStat_BList[0].TVItemStatID);
                            Assert.AreEqual(tvItemStatDirectQueryList.Count, tvItemStat_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemStatList() Skip Take Order Where

        #region Tests Generated for GetTVItemStatList() Skip Take Order 2Where
        [TestMethod]
        public void GetTVItemStatList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemStatService.Query = tvItemStatService.FillQuery(typeof(TVItemStat), culture.TwoLetterISOLanguageName, 0, 1, "TVItemStatID", "TVItemStatID,GT,2|TVItemStatID,LT,5", "");

                        List<TVItemStat> tvItemStatDirectQueryList = new List<TVItemStat>();
                        tvItemStatDirectQueryList = (from c in dbTestDB.TVItemStats select c).Where(c => c.TVItemStatID > 2 && c.TVItemStatID < 5).Skip(0).Take(1).OrderBy(c => c.TVItemStatID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemStat> tvItemStatList = new List<TVItemStat>();
                            tvItemStatList = tvItemStatService.GetTVItemStatList().ToList();
                            CheckTVItemStatFields(tvItemStatList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStatList[0].TVItemStatID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemStat_A> tvItemStat_AList = new List<TVItemStat_A>();
                            tvItemStat_AList = tvItemStatService.GetTVItemStat_AList().ToList();
                            CheckTVItemStat_AFields(tvItemStat_AList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStat_AList[0].TVItemStatID);
                            Assert.AreEqual(tvItemStatDirectQueryList.Count, tvItemStat_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemStat_B> tvItemStat_BList = new List<TVItemStat_B>();
                            tvItemStat_BList = tvItemStatService.GetTVItemStat_BList().ToList();
                            CheckTVItemStat_BFields(tvItemStat_BList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStat_BList[0].TVItemStatID);
                            Assert.AreEqual(tvItemStatDirectQueryList.Count, tvItemStat_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemStatList() Skip Take Order 2Where

        #region Tests Generated for GetTVItemStatList() 2Where
        [TestMethod]
        public void GetTVItemStatList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemStatService tvItemStatService = new TVItemStatService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemStatService.Query = tvItemStatService.FillQuery(typeof(TVItemStat), culture.TwoLetterISOLanguageName, 0, 10000, "", "TVItemStatID,GT,2|TVItemStatID,LT,5", "");

                        List<TVItemStat> tvItemStatDirectQueryList = new List<TVItemStat>();
                        tvItemStatDirectQueryList = (from c in dbTestDB.TVItemStats select c).Where(c => c.TVItemStatID > 2 && c.TVItemStatID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemStat> tvItemStatList = new List<TVItemStat>();
                            tvItemStatList = tvItemStatService.GetTVItemStatList().ToList();
                            CheckTVItemStatFields(tvItemStatList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStatList[0].TVItemStatID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemStat_A> tvItemStat_AList = new List<TVItemStat_A>();
                            tvItemStat_AList = tvItemStatService.GetTVItemStat_AList().ToList();
                            CheckTVItemStat_AFields(tvItemStat_AList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStat_AList[0].TVItemStatID);
                            Assert.AreEqual(tvItemStatDirectQueryList.Count, tvItemStat_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemStat_B> tvItemStat_BList = new List<TVItemStat_B>();
                            tvItemStat_BList = tvItemStatService.GetTVItemStat_BList().ToList();
                            CheckTVItemStat_BFields(tvItemStat_BList);
                            Assert.AreEqual(tvItemStatDirectQueryList[0].TVItemStatID, tvItemStat_BList[0].TVItemStatID);
                            Assert.AreEqual(tvItemStatDirectQueryList.Count, tvItemStat_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemStatList() 2Where

        #region Functions private
        private void CheckTVItemStatFields(List<TVItemStat> tvItemStatList)
        {
            Assert.IsNotNull(tvItemStatList[0].TVItemStatID);
            Assert.IsNotNull(tvItemStatList[0].TVItemID);
            Assert.IsNotNull(tvItemStatList[0].TVType);
            Assert.IsNotNull(tvItemStatList[0].ChildCount);
            Assert.IsNotNull(tvItemStatList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemStatList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvItemStatList[0].HasErrors);
        }
        private void CheckTVItemStat_AFields(List<TVItemStat_A> tvItemStat_AList)
        {
            Assert.IsNotNull(tvItemStat_AList[0].TVItemLanguage);
            Assert.IsNotNull(tvItemStat_AList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvItemStat_AList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemStat_AList[0].TVTypeText));
            }
            Assert.IsNotNull(tvItemStat_AList[0].TVItemStatID);
            Assert.IsNotNull(tvItemStat_AList[0].TVItemID);
            Assert.IsNotNull(tvItemStat_AList[0].TVType);
            Assert.IsNotNull(tvItemStat_AList[0].ChildCount);
            Assert.IsNotNull(tvItemStat_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemStat_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvItemStat_AList[0].HasErrors);
        }
        private void CheckTVItemStat_BFields(List<TVItemStat_B> tvItemStat_BList)
        {
            if (!string.IsNullOrWhiteSpace(tvItemStat_BList[0].TVItemStatReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemStat_BList[0].TVItemStatReportTest));
            }
            Assert.IsNotNull(tvItemStat_BList[0].TVItemLanguage);
            Assert.IsNotNull(tvItemStat_BList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvItemStat_BList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemStat_BList[0].TVTypeText));
            }
            Assert.IsNotNull(tvItemStat_BList[0].TVItemStatID);
            Assert.IsNotNull(tvItemStat_BList[0].TVItemID);
            Assert.IsNotNull(tvItemStat_BList[0].TVType);
            Assert.IsNotNull(tvItemStat_BList[0].ChildCount);
            Assert.IsNotNull(tvItemStat_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemStat_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvItemStat_BList[0].HasErrors);
        }
        private TVItemStat GetFilledRandomTVItemStat(string OmitPropName)
        {
            TVItemStat tvItemStat = new TVItemStat();

            if (OmitPropName != "TVItemID") tvItemStat.TVItemID = 1;
            if (OmitPropName != "TVType") tvItemStat.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ChildCount") tvItemStat.ChildCount = GetRandomInt(0, 10000000);
            if (OmitPropName != "LastUpdateDate_UTC") tvItemStat.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemStat.LastUpdateContactTVItemID = 2;

            return tvItemStat;
        }
        #endregion Functions private
    }
}
