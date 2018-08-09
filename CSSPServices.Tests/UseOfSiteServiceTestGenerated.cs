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
    public partial class UseOfSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private UseOfSiteService useOfSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public UseOfSiteServiceTest() : base()
        {
            //useOfSiteService = new UseOfSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void UseOfSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    UseOfSite useOfSite = GetFilledRandomUseOfSite("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = useOfSiteService.GetUseOfSiteList().Count();

                    Assert.AreEqual(useOfSiteService.GetUseOfSiteList().Count(), (from c in dbTestDB.UseOfSites select c).Take(200).Count());

                    useOfSiteService.Add(useOfSite);
                    if (useOfSite.HasErrors)
                    {
                        Assert.AreEqual("", useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, useOfSiteService.GetUseOfSiteList().Where(c => c == useOfSite).Any());
                    useOfSiteService.Update(useOfSite);
                    if (useOfSite.HasErrors)
                    {
                        Assert.AreEqual("", useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, useOfSiteService.GetUseOfSiteList().Count());
                    useOfSiteService.Delete(useOfSite);
                    if (useOfSite.HasErrors)
                    {
                        Assert.AreEqual("", useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // useOfSite.UseOfSiteID   (Int32)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.UseOfSiteID = 0;
                    useOfSiteService.Update(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "UseOfSiteUseOfSiteID"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.UseOfSiteID = 10000000;
                    useOfSiteService.Update(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "UseOfSite", "UseOfSiteUseOfSiteID", useOfSite.UseOfSiteID.ToString()), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = ClimateSite,HydrometricSite,TideSite)]
                    // useOfSite.SiteTVItemID   (Int32)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.SiteTVItemID = 0;
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "UseOfSiteSiteTVItemID", useOfSite.SiteTVItemID.ToString()), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.SiteTVItemID = 1;
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "UseOfSiteSiteTVItemID", "ClimateSite,HydrometricSite,TideSite"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                    // useOfSite.SubsectorTVItemID   (Int32)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.SubsectorTVItemID = 0;
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "UseOfSiteSubsectorTVItemID", useOfSite.SubsectorTVItemID.ToString()), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.SubsectorTVItemID = 1;
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "UseOfSiteSubsectorTVItemID", "Subsector"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // useOfSite.SiteType   (SiteTypeEnum)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.SiteType = (SiteTypeEnum)1000000;
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "UseOfSiteSiteType"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // useOfSite.Ordinal   (Int32)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Ordinal = -1;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteOrdinal", "0", "1000"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Ordinal = 1001;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteOrdinal", "0", "1000"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1980, 2050)]
                    // useOfSite.StartYear   (Int32)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.StartYear = 1979;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteStartYear", "1980", "2050"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.StartYear = 2051;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteStartYear", "1980", "2050"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(1980, 2050)]
                    // useOfSite.EndYear   (Int32)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.EndYear = 1979;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteEndYear", "1980", "2050"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.EndYear = 2051;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteEndYear", "1980", "2050"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // useOfSite.UseWeight   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // useOfSite.Weight_perc   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Weight_perc]

                    //Error: Type not implemented [Weight_perc]

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Weight_perc = -1.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteWeight_perc", "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Weight_perc = 101.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteWeight_perc", "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // useOfSite.UseEquation   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // useOfSite.Param1   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Param1]

                    //Error: Type not implemented [Param1]

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param1 = -1.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteParam1", "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param1 = 101.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteParam1", "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // useOfSite.Param2   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Param2]

                    //Error: Type not implemented [Param2]

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param2 = -1.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteParam2", "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param2 = 101.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteParam2", "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // useOfSite.Param3   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Param3]

                    //Error: Type not implemented [Param3]

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param3 = -1.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteParam3", "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param3 = 101.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteParam3", "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // useOfSite.Param4   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Param4]

                    //Error: Type not implemented [Param4]

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param4 = -1.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteParam4", "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param4 = 101.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "UseOfSiteParam4", "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // useOfSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.LastUpdateDate_UTC = new DateTime();
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "UseOfSiteLastUpdateDate_UTC"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "UseOfSiteLastUpdateDate_UTC", "1980"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // useOfSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.LastUpdateContactTVItemID = 0;
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "UseOfSiteLastUpdateContactTVItemID", useOfSite.LastUpdateContactTVItemID.ToString()), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.LastUpdateContactTVItemID = 1;
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "UseOfSiteLastUpdateContactTVItemID", "Contact"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // useOfSite.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // useOfSite.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetUseOfSiteWithUseOfSiteID(useOfSite.UseOfSiteID)
        [TestMethod]
        public void GetUseOfSiteWithUseOfSiteID__useOfSite_UseOfSiteID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    UseOfSite useOfSite = (from c in dbTestDB.UseOfSites select c).FirstOrDefault();
                    Assert.IsNotNull(useOfSite);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        useOfSiteService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            UseOfSite useOfSiteRet = useOfSiteService.GetUseOfSiteWithUseOfSiteID(useOfSite.UseOfSiteID);
                            CheckUseOfSiteFields(new List<UseOfSite>() { useOfSiteRet });
                            Assert.AreEqual(useOfSite.UseOfSiteID, useOfSiteRet.UseOfSiteID);
                        }
                        else if (detail == "A")
                        {
                            UseOfSite_A useOfSite_ARet = useOfSiteService.GetUseOfSite_AWithUseOfSiteID(useOfSite.UseOfSiteID);
                            CheckUseOfSite_AFields(new List<UseOfSite_A>() { useOfSite_ARet });
                            Assert.AreEqual(useOfSite.UseOfSiteID, useOfSite_ARet.UseOfSiteID);
                        }
                        else if (detail == "B")
                        {
                            UseOfSite_B useOfSite_BRet = useOfSiteService.GetUseOfSite_BWithUseOfSiteID(useOfSite.UseOfSiteID);
                            CheckUseOfSite_BFields(new List<UseOfSite_B>() { useOfSite_BRet });
                            Assert.AreEqual(useOfSite.UseOfSiteID, useOfSite_BRet.UseOfSiteID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetUseOfSiteWithUseOfSiteID(useOfSite.UseOfSiteID)

        #region Tests Generated for GetUseOfSiteList()
        [TestMethod]
        public void GetUseOfSiteList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    UseOfSite useOfSite = (from c in dbTestDB.UseOfSites select c).FirstOrDefault();
                    Assert.IsNotNull(useOfSite);

                    List<UseOfSite> useOfSiteDirectQueryList = new List<UseOfSite>();
                    useOfSiteDirectQueryList = (from c in dbTestDB.UseOfSites select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        useOfSiteService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                            useOfSiteList = useOfSiteService.GetUseOfSiteList().ToList();
                            CheckUseOfSiteFields(useOfSiteList);
                        }
                        else if (detail == "A")
                        {
                            List<UseOfSite_A> useOfSite_AList = new List<UseOfSite_A>();
                            useOfSite_AList = useOfSiteService.GetUseOfSite_AList().ToList();
                            CheckUseOfSite_AFields(useOfSite_AList);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<UseOfSite_B> useOfSite_BList = new List<UseOfSite_B>();
                            useOfSite_BList = useOfSiteService.GetUseOfSite_BList().ToList();
                            CheckUseOfSite_BFields(useOfSite_BList);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetUseOfSiteList()

        #region Tests Generated for GetUseOfSiteList() Skip Take
        [TestMethod]
        public void GetUseOfSiteList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        useOfSiteService.Query = useOfSiteService.FillQuery(typeof(UseOfSite), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<UseOfSite> useOfSiteDirectQueryList = new List<UseOfSite>();
                        useOfSiteDirectQueryList = (from c in dbTestDB.UseOfSites select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                            useOfSiteList = useOfSiteService.GetUseOfSiteList().ToList();
                            CheckUseOfSiteFields(useOfSiteList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteList[0].UseOfSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<UseOfSite_A> useOfSite_AList = new List<UseOfSite_A>();
                            useOfSite_AList = useOfSiteService.GetUseOfSite_AList().ToList();
                            CheckUseOfSite_AFields(useOfSite_AList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSite_AList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<UseOfSite_B> useOfSite_BList = new List<UseOfSite_B>();
                            useOfSite_BList = useOfSiteService.GetUseOfSite_BList().ToList();
                            CheckUseOfSite_BFields(useOfSite_BList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSite_BList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetUseOfSiteList() Skip Take

        #region Tests Generated for GetUseOfSiteList() Skip Take Order
        [TestMethod]
        public void GetUseOfSiteList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        useOfSiteService.Query = useOfSiteService.FillQuery(typeof(UseOfSite), culture.TwoLetterISOLanguageName, 1, 1,  "UseOfSiteID", "");

                        List<UseOfSite> useOfSiteDirectQueryList = new List<UseOfSite>();
                        useOfSiteDirectQueryList = (from c in dbTestDB.UseOfSites select c).Skip(1).Take(1).OrderBy(c => c.UseOfSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                            useOfSiteList = useOfSiteService.GetUseOfSiteList().ToList();
                            CheckUseOfSiteFields(useOfSiteList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteList[0].UseOfSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<UseOfSite_A> useOfSite_AList = new List<UseOfSite_A>();
                            useOfSite_AList = useOfSiteService.GetUseOfSite_AList().ToList();
                            CheckUseOfSite_AFields(useOfSite_AList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSite_AList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<UseOfSite_B> useOfSite_BList = new List<UseOfSite_B>();
                            useOfSite_BList = useOfSiteService.GetUseOfSite_BList().ToList();
                            CheckUseOfSite_BFields(useOfSite_BList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSite_BList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetUseOfSiteList() Skip Take Order

        #region Tests Generated for GetUseOfSiteList() Skip Take 2Order
        [TestMethod]
        public void GetUseOfSiteList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        useOfSiteService.Query = useOfSiteService.FillQuery(typeof(UseOfSite), culture.TwoLetterISOLanguageName, 1, 1, "UseOfSiteID,SiteTVItemID", "");

                        List<UseOfSite> useOfSiteDirectQueryList = new List<UseOfSite>();
                        useOfSiteDirectQueryList = (from c in dbTestDB.UseOfSites select c).Skip(1).Take(1).OrderBy(c => c.UseOfSiteID).ThenBy(c => c.SiteTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                            useOfSiteList = useOfSiteService.GetUseOfSiteList().ToList();
                            CheckUseOfSiteFields(useOfSiteList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteList[0].UseOfSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<UseOfSite_A> useOfSite_AList = new List<UseOfSite_A>();
                            useOfSite_AList = useOfSiteService.GetUseOfSite_AList().ToList();
                            CheckUseOfSite_AFields(useOfSite_AList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSite_AList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<UseOfSite_B> useOfSite_BList = new List<UseOfSite_B>();
                            useOfSite_BList = useOfSiteService.GetUseOfSite_BList().ToList();
                            CheckUseOfSite_BFields(useOfSite_BList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSite_BList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetUseOfSiteList() Skip Take 2Order

        #region Tests Generated for GetUseOfSiteList() Skip Take Order Where
        [TestMethod]
        public void GetUseOfSiteList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        useOfSiteService.Query = useOfSiteService.FillQuery(typeof(UseOfSite), culture.TwoLetterISOLanguageName, 0, 1, "UseOfSiteID", "UseOfSiteID,EQ,4", "");

                        List<UseOfSite> useOfSiteDirectQueryList = new List<UseOfSite>();
                        useOfSiteDirectQueryList = (from c in dbTestDB.UseOfSites select c).Where(c => c.UseOfSiteID == 4).Skip(0).Take(1).OrderBy(c => c.UseOfSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                            useOfSiteList = useOfSiteService.GetUseOfSiteList().ToList();
                            CheckUseOfSiteFields(useOfSiteList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteList[0].UseOfSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<UseOfSite_A> useOfSite_AList = new List<UseOfSite_A>();
                            useOfSite_AList = useOfSiteService.GetUseOfSite_AList().ToList();
                            CheckUseOfSite_AFields(useOfSite_AList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSite_AList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<UseOfSite_B> useOfSite_BList = new List<UseOfSite_B>();
                            useOfSite_BList = useOfSiteService.GetUseOfSite_BList().ToList();
                            CheckUseOfSite_BFields(useOfSite_BList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSite_BList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetUseOfSiteList() Skip Take Order Where

        #region Tests Generated for GetUseOfSiteList() Skip Take Order 2Where
        [TestMethod]
        public void GetUseOfSiteList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        useOfSiteService.Query = useOfSiteService.FillQuery(typeof(UseOfSite), culture.TwoLetterISOLanguageName, 0, 1, "UseOfSiteID", "UseOfSiteID,GT,2|UseOfSiteID,LT,5", "");

                        List<UseOfSite> useOfSiteDirectQueryList = new List<UseOfSite>();
                        useOfSiteDirectQueryList = (from c in dbTestDB.UseOfSites select c).Where(c => c.UseOfSiteID > 2 && c.UseOfSiteID < 5).Skip(0).Take(1).OrderBy(c => c.UseOfSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                            useOfSiteList = useOfSiteService.GetUseOfSiteList().ToList();
                            CheckUseOfSiteFields(useOfSiteList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteList[0].UseOfSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<UseOfSite_A> useOfSite_AList = new List<UseOfSite_A>();
                            useOfSite_AList = useOfSiteService.GetUseOfSite_AList().ToList();
                            CheckUseOfSite_AFields(useOfSite_AList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSite_AList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<UseOfSite_B> useOfSite_BList = new List<UseOfSite_B>();
                            useOfSite_BList = useOfSiteService.GetUseOfSite_BList().ToList();
                            CheckUseOfSite_BFields(useOfSite_BList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSite_BList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetUseOfSiteList() Skip Take Order 2Where

        #region Tests Generated for GetUseOfSiteList() 2Where
        [TestMethod]
        public void GetUseOfSiteList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        useOfSiteService.Query = useOfSiteService.FillQuery(typeof(UseOfSite), culture.TwoLetterISOLanguageName, 0, 10000, "", "UseOfSiteID,GT,2|UseOfSiteID,LT,5", "");

                        List<UseOfSite> useOfSiteDirectQueryList = new List<UseOfSite>();
                        useOfSiteDirectQueryList = (from c in dbTestDB.UseOfSites select c).Where(c => c.UseOfSiteID > 2 && c.UseOfSiteID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                            useOfSiteList = useOfSiteService.GetUseOfSiteList().ToList();
                            CheckUseOfSiteFields(useOfSiteList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteList[0].UseOfSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<UseOfSite_A> useOfSite_AList = new List<UseOfSite_A>();
                            useOfSite_AList = useOfSiteService.GetUseOfSite_AList().ToList();
                            CheckUseOfSite_AFields(useOfSite_AList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSite_AList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<UseOfSite_B> useOfSite_BList = new List<UseOfSite_B>();
                            useOfSite_BList = useOfSiteService.GetUseOfSite_BList().ToList();
                            CheckUseOfSite_BFields(useOfSite_BList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSite_BList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetUseOfSiteList() 2Where

        #region Functions private
        private void CheckUseOfSiteFields(List<UseOfSite> useOfSiteList)
        {
            Assert.IsNotNull(useOfSiteList[0].UseOfSiteID);
            Assert.IsNotNull(useOfSiteList[0].SiteTVItemID);
            Assert.IsNotNull(useOfSiteList[0].SubsectorTVItemID);
            Assert.IsNotNull(useOfSiteList[0].SiteType);
            Assert.IsNotNull(useOfSiteList[0].Ordinal);
            Assert.IsNotNull(useOfSiteList[0].StartYear);
            if (useOfSiteList[0].EndYear != null)
            {
                Assert.IsNotNull(useOfSiteList[0].EndYear);
            }
            if (useOfSiteList[0].UseWeight != null)
            {
                Assert.IsNotNull(useOfSiteList[0].UseWeight);
            }
            if (useOfSiteList[0].Weight_perc != null)
            {
                Assert.IsNotNull(useOfSiteList[0].Weight_perc);
            }
            if (useOfSiteList[0].UseEquation != null)
            {
                Assert.IsNotNull(useOfSiteList[0].UseEquation);
            }
            if (useOfSiteList[0].Param1 != null)
            {
                Assert.IsNotNull(useOfSiteList[0].Param1);
            }
            if (useOfSiteList[0].Param2 != null)
            {
                Assert.IsNotNull(useOfSiteList[0].Param2);
            }
            if (useOfSiteList[0].Param3 != null)
            {
                Assert.IsNotNull(useOfSiteList[0].Param3);
            }
            if (useOfSiteList[0].Param4 != null)
            {
                Assert.IsNotNull(useOfSiteList[0].Param4);
            }
            Assert.IsNotNull(useOfSiteList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(useOfSiteList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(useOfSiteList[0].HasErrors);
        }
        private void CheckUseOfSite_AFields(List<UseOfSite_A> useOfSite_AList)
        {
            Assert.IsNotNull(useOfSite_AList[0].SiteTVItemLanguage);
            Assert.IsNotNull(useOfSite_AList[0].SubsectorTVItemLanguage);
            Assert.IsNotNull(useOfSite_AList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(useOfSite_AList[0].SiteTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSite_AList[0].SiteTypeText));
            }
            Assert.IsNotNull(useOfSite_AList[0].UseOfSiteID);
            Assert.IsNotNull(useOfSite_AList[0].SiteTVItemID);
            Assert.IsNotNull(useOfSite_AList[0].SubsectorTVItemID);
            Assert.IsNotNull(useOfSite_AList[0].SiteType);
            Assert.IsNotNull(useOfSite_AList[0].Ordinal);
            Assert.IsNotNull(useOfSite_AList[0].StartYear);
            if (useOfSite_AList[0].EndYear != null)
            {
                Assert.IsNotNull(useOfSite_AList[0].EndYear);
            }
            if (useOfSite_AList[0].UseWeight != null)
            {
                Assert.IsNotNull(useOfSite_AList[0].UseWeight);
            }
            if (useOfSite_AList[0].Weight_perc != null)
            {
                Assert.IsNotNull(useOfSite_AList[0].Weight_perc);
            }
            if (useOfSite_AList[0].UseEquation != null)
            {
                Assert.IsNotNull(useOfSite_AList[0].UseEquation);
            }
            if (useOfSite_AList[0].Param1 != null)
            {
                Assert.IsNotNull(useOfSite_AList[0].Param1);
            }
            if (useOfSite_AList[0].Param2 != null)
            {
                Assert.IsNotNull(useOfSite_AList[0].Param2);
            }
            if (useOfSite_AList[0].Param3 != null)
            {
                Assert.IsNotNull(useOfSite_AList[0].Param3);
            }
            if (useOfSite_AList[0].Param4 != null)
            {
                Assert.IsNotNull(useOfSite_AList[0].Param4);
            }
            Assert.IsNotNull(useOfSite_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(useOfSite_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(useOfSite_AList[0].HasErrors);
        }
        private void CheckUseOfSite_BFields(List<UseOfSite_B> useOfSite_BList)
        {
            if (!string.IsNullOrWhiteSpace(useOfSite_BList[0].UseOfSiteReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSite_BList[0].UseOfSiteReportTest));
            }
            Assert.IsNotNull(useOfSite_BList[0].SiteTVItemLanguage);
            Assert.IsNotNull(useOfSite_BList[0].SubsectorTVItemLanguage);
            Assert.IsNotNull(useOfSite_BList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(useOfSite_BList[0].SiteTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSite_BList[0].SiteTypeText));
            }
            Assert.IsNotNull(useOfSite_BList[0].UseOfSiteID);
            Assert.IsNotNull(useOfSite_BList[0].SiteTVItemID);
            Assert.IsNotNull(useOfSite_BList[0].SubsectorTVItemID);
            Assert.IsNotNull(useOfSite_BList[0].SiteType);
            Assert.IsNotNull(useOfSite_BList[0].Ordinal);
            Assert.IsNotNull(useOfSite_BList[0].StartYear);
            if (useOfSite_BList[0].EndYear != null)
            {
                Assert.IsNotNull(useOfSite_BList[0].EndYear);
            }
            if (useOfSite_BList[0].UseWeight != null)
            {
                Assert.IsNotNull(useOfSite_BList[0].UseWeight);
            }
            if (useOfSite_BList[0].Weight_perc != null)
            {
                Assert.IsNotNull(useOfSite_BList[0].Weight_perc);
            }
            if (useOfSite_BList[0].UseEquation != null)
            {
                Assert.IsNotNull(useOfSite_BList[0].UseEquation);
            }
            if (useOfSite_BList[0].Param1 != null)
            {
                Assert.IsNotNull(useOfSite_BList[0].Param1);
            }
            if (useOfSite_BList[0].Param2 != null)
            {
                Assert.IsNotNull(useOfSite_BList[0].Param2);
            }
            if (useOfSite_BList[0].Param3 != null)
            {
                Assert.IsNotNull(useOfSite_BList[0].Param3);
            }
            if (useOfSite_BList[0].Param4 != null)
            {
                Assert.IsNotNull(useOfSite_BList[0].Param4);
            }
            Assert.IsNotNull(useOfSite_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(useOfSite_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(useOfSite_BList[0].HasErrors);
        }
        private UseOfSite GetFilledRandomUseOfSite(string OmitPropName)
        {
            UseOfSite useOfSite = new UseOfSite();

            if (OmitPropName != "SiteTVItemID") useOfSite.SiteTVItemID = 7;
            if (OmitPropName != "SubsectorTVItemID") useOfSite.SubsectorTVItemID = 11;
            if (OmitPropName != "SiteType") useOfSite.SiteType = (SiteTypeEnum)GetRandomEnumType(typeof(SiteTypeEnum));
            if (OmitPropName != "Ordinal") useOfSite.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "StartYear") useOfSite.StartYear = GetRandomInt(1980, 2050);
            if (OmitPropName != "EndYear") useOfSite.EndYear = GetRandomInt(1980, 2050);
            if (OmitPropName != "UseWeight") useOfSite.UseWeight = true;
            if (OmitPropName != "Weight_perc") useOfSite.Weight_perc = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "UseEquation") useOfSite.UseEquation = true;
            if (OmitPropName != "Param1") useOfSite.Param1 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "Param2") useOfSite.Param2 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "Param3") useOfSite.Param3 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "Param4") useOfSite.Param4 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "LastUpdateDate_UTC") useOfSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") useOfSite.LastUpdateContactTVItemID = 2;

            return useOfSite;
        }
        #endregion Functions private
    }
}
