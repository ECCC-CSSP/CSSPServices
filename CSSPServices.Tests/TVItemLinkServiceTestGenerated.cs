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
    public partial class TVItemLinkServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemLinkService tvItemLinkService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLinkServiceTest() : base()
        {
            //tvItemLinkService = new TVItemLinkService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVItemLink_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TVItemLink tvItemLink = GetFilledRandomTVItemLink("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tvItemLinkService.GetTVItemLinkList().Count();

                    Assert.AreEqual(tvItemLinkService.GetTVItemLinkList().Count(), (from c in dbTestDB.TVItemLinks select c).Take(200).Count());

                    tvItemLinkService.Add(tvItemLink);
                    if (tvItemLink.HasErrors)
                    {
                        Assert.AreEqual("", tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvItemLinkService.GetTVItemLinkList().Where(c => c == tvItemLink).Any());
                    tvItemLinkService.Update(tvItemLink);
                    if (tvItemLink.HasErrors)
                    {
                        Assert.AreEqual("", tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvItemLinkService.GetTVItemLinkList().Count());
                    tvItemLinkService.Delete(tvItemLink);
                    if (tvItemLink.HasErrors)
                    {
                        Assert.AreEqual("", tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvItemLinkService.GetTVItemLinkList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tvItemLink.TVItemLinkID   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVItemLinkID = 0;
                    tvItemLinkService.Update(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemLinkTVItemLinkID"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVItemLinkID = 10000000;
                    tvItemLinkService.Update(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItemLink", "TVItemLinkTVItemLinkID", tvItemLink.TVItemLinkID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint)]
                    // tvItemLink.FromTVItemID   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.FromTVItemID = 0;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemLinkFromTVItemID", tvItemLink.FromTVItemID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.FromTVItemID = 13;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemLinkFromTVItemID", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint)]
                    // tvItemLink.ToTVItemID   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.ToTVItemID = 0;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemLinkToTVItemID", tvItemLink.ToTVItemID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.ToTVItemID = 13;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemLinkToTVItemID", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItemLink.FromTVType   (TVTypeEnum)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.FromTVType = (TVTypeEnum)1000000;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemLinkFromTVType"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItemLink.ToTVType   (TVTypeEnum)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.ToTVType = (TVTypeEnum)1000000;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemLinkToTVType"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvItemLink.StartDateTime_Local   (DateTime)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.StartDateTime_Local = new DateTime(1979, 1, 1);
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVItemLinkStartDateTime_Local", "1980"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // [CSSPBigger(OtherField = StartDateTime_Local)]
                    // tvItemLink.EndDateTime_Local   (DateTime)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.EndDateTime_Local = new DateTime(1979, 1, 1);
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVItemLinkEndDateTime_Local", "1980"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // tvItemLink.Ordinal   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.Ordinal = -1;
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVItemLinkOrdinal", "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLinkService.GetTVItemLinkList().Count());
                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.Ordinal = 101;
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVItemLinkOrdinal", "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLinkService.GetTVItemLinkList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // tvItemLink.TVLevel   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVLevel = -1;
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVItemLinkTVLevel", "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLinkService.GetTVItemLinkList().Count());
                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVLevel = 101;
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVItemLinkTVLevel", "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLinkService.GetTVItemLinkList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // tvItemLink.TVPath   (String)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("TVPath");
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(1, tvItemLink.ValidationResults.Count());
                    Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "TVItemLinkTVPath")).Any());
                    Assert.AreEqual(null, tvItemLink.TVPath);
                    Assert.AreEqual(count, tvItemLinkService.GetTVItemLinkList().Count());

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVPath = GetRandomString("", 251);
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "TVItemLinkTVPath", "250"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLinkService.GetTVItemLinkList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItemLink", ExistPlurial = "s", ExistFieldID = "TVItemLinkID", AllowableTVtypeList = )]
                    // tvItemLink.ParentTVItemLinkID   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.ParentTVItemLinkID = 0;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItemLink", "TVItemLinkParentTVItemLinkID", tvItemLink.ParentTVItemLinkID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvItemLink.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.LastUpdateDate_UTC = new DateTime();
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemLinkLastUpdateDate_UTC"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVItemLinkLastUpdateDate_UTC", "1980"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvItemLink.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.LastUpdateContactTVItemID = 0;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemLinkLastUpdateContactTVItemID", tvItemLink.LastUpdateContactTVItemID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.LastUpdateContactTVItemID = 1;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemLinkLastUpdateContactTVItemID", "Contact"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemLink.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemLink.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTVItemLinkWithTVItemLinkID(tvItemLink.TVItemLinkID)
        [TestMethod]
        public void GetTVItemLinkWithTVItemLinkID__tvItemLink_TVItemLinkID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVItemLink tvItemLink = (from c in dbTestDB.TVItemLinks select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemLink);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        tvItemLinkService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            TVItemLink tvItemLinkRet = tvItemLinkService.GetTVItemLinkWithTVItemLinkID(tvItemLink.TVItemLinkID);
                            CheckTVItemLinkFields(new List<TVItemLink>() { tvItemLinkRet });
                            Assert.AreEqual(tvItemLink.TVItemLinkID, tvItemLinkRet.TVItemLinkID);
                        }
                        else if (detail == "A")
                        {
                            TVItemLink_A tvItemLink_ARet = tvItemLinkService.GetTVItemLink_AWithTVItemLinkID(tvItemLink.TVItemLinkID);
                            CheckTVItemLink_AFields(new List<TVItemLink_A>() { tvItemLink_ARet });
                            Assert.AreEqual(tvItemLink.TVItemLinkID, tvItemLink_ARet.TVItemLinkID);
                        }
                        else if (detail == "B")
                        {
                            TVItemLink_B tvItemLink_BRet = tvItemLinkService.GetTVItemLink_BWithTVItemLinkID(tvItemLink.TVItemLinkID);
                            CheckTVItemLink_BFields(new List<TVItemLink_B>() { tvItemLink_BRet });
                            Assert.AreEqual(tvItemLink.TVItemLinkID, tvItemLink_BRet.TVItemLinkID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkWithTVItemLinkID(tvItemLink.TVItemLinkID)

        #region Tests Generated for GetTVItemLinkList()
        [TestMethod]
        public void GetTVItemLinkList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVItemLink tvItemLink = (from c in dbTestDB.TVItemLinks select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemLink);

                    List<TVItemLink> tvItemLinkDirectQueryList = new List<TVItemLink>();
                    tvItemLinkDirectQueryList = (from c in dbTestDB.TVItemLinks select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        tvItemLinkService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemLink> tvItemLinkList = new List<TVItemLink>();
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                            CheckTVItemLinkFields(tvItemLinkList);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemLink_A> tvItemLink_AList = new List<TVItemLink_A>();
                            tvItemLink_AList = tvItemLinkService.GetTVItemLink_AList().ToList();
                            CheckTVItemLink_AFields(tvItemLink_AList);
                            Assert.AreEqual(tvItemLinkDirectQueryList.Count, tvItemLink_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemLink_B> tvItemLink_BList = new List<TVItemLink_B>();
                            tvItemLink_BList = tvItemLinkService.GetTVItemLink_BList().ToList();
                            CheckTVItemLink_BFields(tvItemLink_BList);
                            Assert.AreEqual(tvItemLinkDirectQueryList.Count, tvItemLink_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkList()

        #region Tests Generated for GetTVItemLinkList() Skip Take
        [TestMethod]
        public void GetTVItemLinkList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<TVItemLink> tvItemLinkDirectQueryList = new List<TVItemLink>();
                        tvItemLinkDirectQueryList = (from c in dbTestDB.TVItemLinks select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemLink> tvItemLinkList = new List<TVItemLink>();
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                            CheckTVItemLinkFields(tvItemLinkList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLinkList[0].TVItemLinkID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemLink_A> tvItemLink_AList = new List<TVItemLink_A>();
                            tvItemLink_AList = tvItemLinkService.GetTVItemLink_AList().ToList();
                            CheckTVItemLink_AFields(tvItemLink_AList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLink_AList[0].TVItemLinkID);
                            Assert.AreEqual(tvItemLinkDirectQueryList.Count, tvItemLink_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemLink_B> tvItemLink_BList = new List<TVItemLink_B>();
                            tvItemLink_BList = tvItemLinkService.GetTVItemLink_BList().ToList();
                            CheckTVItemLink_BFields(tvItemLink_BList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLink_BList[0].TVItemLinkID);
                            Assert.AreEqual(tvItemLinkDirectQueryList.Count, tvItemLink_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkList() Skip Take

        #region Tests Generated for GetTVItemLinkList() Skip Take Order
        [TestMethod]
        public void GetTVItemLinkList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), culture.TwoLetterISOLanguageName, 1, 1,  "TVItemLinkID", "");

                        List<TVItemLink> tvItemLinkDirectQueryList = new List<TVItemLink>();
                        tvItemLinkDirectQueryList = (from c in dbTestDB.TVItemLinks select c).Skip(1).Take(1).OrderBy(c => c.TVItemLinkID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemLink> tvItemLinkList = new List<TVItemLink>();
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                            CheckTVItemLinkFields(tvItemLinkList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLinkList[0].TVItemLinkID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemLink_A> tvItemLink_AList = new List<TVItemLink_A>();
                            tvItemLink_AList = tvItemLinkService.GetTVItemLink_AList().ToList();
                            CheckTVItemLink_AFields(tvItemLink_AList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLink_AList[0].TVItemLinkID);
                            Assert.AreEqual(tvItemLinkDirectQueryList.Count, tvItemLink_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemLink_B> tvItemLink_BList = new List<TVItemLink_B>();
                            tvItemLink_BList = tvItemLinkService.GetTVItemLink_BList().ToList();
                            CheckTVItemLink_BFields(tvItemLink_BList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLink_BList[0].TVItemLinkID);
                            Assert.AreEqual(tvItemLinkDirectQueryList.Count, tvItemLink_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkList() Skip Take Order

        #region Tests Generated for GetTVItemLinkList() Skip Take 2Order
        [TestMethod]
        public void GetTVItemLinkList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), culture.TwoLetterISOLanguageName, 1, 1, "TVItemLinkID,FromTVItemID", "");

                        List<TVItemLink> tvItemLinkDirectQueryList = new List<TVItemLink>();
                        tvItemLinkDirectQueryList = (from c in dbTestDB.TVItemLinks select c).Skip(1).Take(1).OrderBy(c => c.TVItemLinkID).ThenBy(c => c.FromTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemLink> tvItemLinkList = new List<TVItemLink>();
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                            CheckTVItemLinkFields(tvItemLinkList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLinkList[0].TVItemLinkID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemLink_A> tvItemLink_AList = new List<TVItemLink_A>();
                            tvItemLink_AList = tvItemLinkService.GetTVItemLink_AList().ToList();
                            CheckTVItemLink_AFields(tvItemLink_AList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLink_AList[0].TVItemLinkID);
                            Assert.AreEqual(tvItemLinkDirectQueryList.Count, tvItemLink_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemLink_B> tvItemLink_BList = new List<TVItemLink_B>();
                            tvItemLink_BList = tvItemLinkService.GetTVItemLink_BList().ToList();
                            CheckTVItemLink_BFields(tvItemLink_BList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLink_BList[0].TVItemLinkID);
                            Assert.AreEqual(tvItemLinkDirectQueryList.Count, tvItemLink_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkList() Skip Take 2Order

        #region Tests Generated for GetTVItemLinkList() Skip Take Order Where
        [TestMethod]
        public void GetTVItemLinkList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), culture.TwoLetterISOLanguageName, 0, 1, "TVItemLinkID", "TVItemLinkID,EQ,4", "");

                        List<TVItemLink> tvItemLinkDirectQueryList = new List<TVItemLink>();
                        tvItemLinkDirectQueryList = (from c in dbTestDB.TVItemLinks select c).Where(c => c.TVItemLinkID == 4).Skip(0).Take(1).OrderBy(c => c.TVItemLinkID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemLink> tvItemLinkList = new List<TVItemLink>();
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                            CheckTVItemLinkFields(tvItemLinkList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLinkList[0].TVItemLinkID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemLink_A> tvItemLink_AList = new List<TVItemLink_A>();
                            tvItemLink_AList = tvItemLinkService.GetTVItemLink_AList().ToList();
                            CheckTVItemLink_AFields(tvItemLink_AList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLink_AList[0].TVItemLinkID);
                            Assert.AreEqual(tvItemLinkDirectQueryList.Count, tvItemLink_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemLink_B> tvItemLink_BList = new List<TVItemLink_B>();
                            tvItemLink_BList = tvItemLinkService.GetTVItemLink_BList().ToList();
                            CheckTVItemLink_BFields(tvItemLink_BList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLink_BList[0].TVItemLinkID);
                            Assert.AreEqual(tvItemLinkDirectQueryList.Count, tvItemLink_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkList() Skip Take Order Where

        #region Tests Generated for GetTVItemLinkList() Skip Take Order 2Where
        [TestMethod]
        public void GetTVItemLinkList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), culture.TwoLetterISOLanguageName, 0, 1, "TVItemLinkID", "TVItemLinkID,GT,2|TVItemLinkID,LT,5", "");

                        List<TVItemLink> tvItemLinkDirectQueryList = new List<TVItemLink>();
                        tvItemLinkDirectQueryList = (from c in dbTestDB.TVItemLinks select c).Where(c => c.TVItemLinkID > 2 && c.TVItemLinkID < 5).Skip(0).Take(1).OrderBy(c => c.TVItemLinkID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemLink> tvItemLinkList = new List<TVItemLink>();
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                            CheckTVItemLinkFields(tvItemLinkList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLinkList[0].TVItemLinkID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemLink_A> tvItemLink_AList = new List<TVItemLink_A>();
                            tvItemLink_AList = tvItemLinkService.GetTVItemLink_AList().ToList();
                            CheckTVItemLink_AFields(tvItemLink_AList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLink_AList[0].TVItemLinkID);
                            Assert.AreEqual(tvItemLinkDirectQueryList.Count, tvItemLink_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemLink_B> tvItemLink_BList = new List<TVItemLink_B>();
                            tvItemLink_BList = tvItemLinkService.GetTVItemLink_BList().ToList();
                            CheckTVItemLink_BFields(tvItemLink_BList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLink_BList[0].TVItemLinkID);
                            Assert.AreEqual(tvItemLinkDirectQueryList.Count, tvItemLink_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkList() Skip Take Order 2Where

        #region Tests Generated for GetTVItemLinkList() 2Where
        [TestMethod]
        public void GetTVItemLinkList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), culture.TwoLetterISOLanguageName, 0, 10000, "", "TVItemLinkID,GT,2|TVItemLinkID,LT,5", "");

                        List<TVItemLink> tvItemLinkDirectQueryList = new List<TVItemLink>();
                        tvItemLinkDirectQueryList = (from c in dbTestDB.TVItemLinks select c).Where(c => c.TVItemLinkID > 2 && c.TVItemLinkID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemLink> tvItemLinkList = new List<TVItemLink>();
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                            CheckTVItemLinkFields(tvItemLinkList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLinkList[0].TVItemLinkID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemLink_A> tvItemLink_AList = new List<TVItemLink_A>();
                            tvItemLink_AList = tvItemLinkService.GetTVItemLink_AList().ToList();
                            CheckTVItemLink_AFields(tvItemLink_AList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLink_AList[0].TVItemLinkID);
                            Assert.AreEqual(tvItemLinkDirectQueryList.Count, tvItemLink_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemLink_B> tvItemLink_BList = new List<TVItemLink_B>();
                            tvItemLink_BList = tvItemLinkService.GetTVItemLink_BList().ToList();
                            CheckTVItemLink_BFields(tvItemLink_BList);
                            Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLink_BList[0].TVItemLinkID);
                            Assert.AreEqual(tvItemLinkDirectQueryList.Count, tvItemLink_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkList() 2Where

        #region Functions private
        private void CheckTVItemLinkFields(List<TVItemLink> tvItemLinkList)
        {
            Assert.IsNotNull(tvItemLinkList[0].TVItemLinkID);
            Assert.IsNotNull(tvItemLinkList[0].FromTVItemID);
            Assert.IsNotNull(tvItemLinkList[0].ToTVItemID);
            Assert.IsNotNull(tvItemLinkList[0].FromTVType);
            Assert.IsNotNull(tvItemLinkList[0].ToTVType);
            if (tvItemLinkList[0].StartDateTime_Local != null)
            {
                Assert.IsNotNull(tvItemLinkList[0].StartDateTime_Local);
            }
            if (tvItemLinkList[0].EndDateTime_Local != null)
            {
                Assert.IsNotNull(tvItemLinkList[0].EndDateTime_Local);
            }
            Assert.IsNotNull(tvItemLinkList[0].Ordinal);
            Assert.IsNotNull(tvItemLinkList[0].TVLevel);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkList[0].TVPath));
            if (tvItemLinkList[0].ParentTVItemLinkID != null)
            {
                Assert.IsNotNull(tvItemLinkList[0].ParentTVItemLinkID);
            }
            Assert.IsNotNull(tvItemLinkList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemLinkList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvItemLinkList[0].HasErrors);
        }
        private void CheckTVItemLink_AFields(List<TVItemLink_A> tvItemLink_AList)
        {
            Assert.IsNotNull(tvItemLink_AList[0].FromTVItemLanguage);
            Assert.IsNotNull(tvItemLink_AList[0].ToTVItemLanguage);
            Assert.IsNotNull(tvItemLink_AList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvItemLink_AList[0].FromTVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLink_AList[0].FromTVTypeText));
            }
            if (!string.IsNullOrWhiteSpace(tvItemLink_AList[0].ToTVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLink_AList[0].ToTVTypeText));
            }
            Assert.IsNotNull(tvItemLink_AList[0].TVItemLinkID);
            Assert.IsNotNull(tvItemLink_AList[0].FromTVItemID);
            Assert.IsNotNull(tvItemLink_AList[0].ToTVItemID);
            Assert.IsNotNull(tvItemLink_AList[0].FromTVType);
            Assert.IsNotNull(tvItemLink_AList[0].ToTVType);
            if (tvItemLink_AList[0].StartDateTime_Local != null)
            {
                Assert.IsNotNull(tvItemLink_AList[0].StartDateTime_Local);
            }
            if (tvItemLink_AList[0].EndDateTime_Local != null)
            {
                Assert.IsNotNull(tvItemLink_AList[0].EndDateTime_Local);
            }
            Assert.IsNotNull(tvItemLink_AList[0].Ordinal);
            Assert.IsNotNull(tvItemLink_AList[0].TVLevel);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLink_AList[0].TVPath));
            if (tvItemLink_AList[0].ParentTVItemLinkID != null)
            {
                Assert.IsNotNull(tvItemLink_AList[0].ParentTVItemLinkID);
            }
            Assert.IsNotNull(tvItemLink_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemLink_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvItemLink_AList[0].HasErrors);
        }
        private void CheckTVItemLink_BFields(List<TVItemLink_B> tvItemLink_BList)
        {
            if (!string.IsNullOrWhiteSpace(tvItemLink_BList[0].TVItemLinkReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLink_BList[0].TVItemLinkReportTest));
            }
            Assert.IsNotNull(tvItemLink_BList[0].FromTVItemLanguage);
            Assert.IsNotNull(tvItemLink_BList[0].ToTVItemLanguage);
            Assert.IsNotNull(tvItemLink_BList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvItemLink_BList[0].FromTVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLink_BList[0].FromTVTypeText));
            }
            if (!string.IsNullOrWhiteSpace(tvItemLink_BList[0].ToTVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLink_BList[0].ToTVTypeText));
            }
            Assert.IsNotNull(tvItemLink_BList[0].TVItemLinkID);
            Assert.IsNotNull(tvItemLink_BList[0].FromTVItemID);
            Assert.IsNotNull(tvItemLink_BList[0].ToTVItemID);
            Assert.IsNotNull(tvItemLink_BList[0].FromTVType);
            Assert.IsNotNull(tvItemLink_BList[0].ToTVType);
            if (tvItemLink_BList[0].StartDateTime_Local != null)
            {
                Assert.IsNotNull(tvItemLink_BList[0].StartDateTime_Local);
            }
            if (tvItemLink_BList[0].EndDateTime_Local != null)
            {
                Assert.IsNotNull(tvItemLink_BList[0].EndDateTime_Local);
            }
            Assert.IsNotNull(tvItemLink_BList[0].Ordinal);
            Assert.IsNotNull(tvItemLink_BList[0].TVLevel);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLink_BList[0].TVPath));
            if (tvItemLink_BList[0].ParentTVItemLinkID != null)
            {
                Assert.IsNotNull(tvItemLink_BList[0].ParentTVItemLinkID);
            }
            Assert.IsNotNull(tvItemLink_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemLink_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvItemLink_BList[0].HasErrors);
        }
        private TVItemLink GetFilledRandomTVItemLink(string OmitPropName)
        {
            TVItemLink tvItemLink = new TVItemLink();

            if (OmitPropName != "FromTVItemID") tvItemLink.FromTVItemID = 1;
            if (OmitPropName != "ToTVItemID") tvItemLink.ToTVItemID = 1;
            if (OmitPropName != "FromTVType") tvItemLink.FromTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ToTVType") tvItemLink.ToTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "StartDateTime_Local") tvItemLink.StartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_Local") tvItemLink.EndDateTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "Ordinal") tvItemLink.Ordinal = GetRandomInt(0, 100);
            if (OmitPropName != "TVLevel") tvItemLink.TVLevel = GetRandomInt(0, 100);
            if (OmitPropName != "TVPath") tvItemLink.TVPath = GetRandomString("", 5);
            // Need to implement [TVItemLink ParentTVItemLinkID TVItemLink TVItemLinkID]
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLink.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemLink.LastUpdateContactTVItemID = 2;

            return tvItemLink;
        }
        #endregion Functions private
    }
}
