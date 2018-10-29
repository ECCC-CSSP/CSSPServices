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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    Assert.AreEqual(count, (from c in dbTestDB.UseOfSites select c).Count());

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

                    //CSSPError: Type not implemented [Weight_perc]

                    //CSSPError: Type not implemented [Weight_perc]

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

                    //CSSPError: Type not implemented [Param1]

                    //CSSPError: Type not implemented [Param1]

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

                    //CSSPError: Type not implemented [Param2]

                    //CSSPError: Type not implemented [Param2]

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

                    //CSSPError: Type not implemented [Param3]

                    //CSSPError: Type not implemented [Param3]

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

                    //CSSPError: Type not implemented [Param4]

                    //CSSPError: Type not implemented [Param4]

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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    UseOfSite useOfSite = (from c in dbTestDB.UseOfSites select c).FirstOrDefault();
                    Assert.IsNotNull(useOfSite);

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        useOfSiteService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            UseOfSite useOfSiteRet = useOfSiteService.GetUseOfSiteWithUseOfSiteID(useOfSite.UseOfSiteID);
                            CheckUseOfSiteFields(new List<UseOfSite>() { useOfSiteRet });
                            Assert.AreEqual(useOfSite.UseOfSiteID, useOfSiteRet.UseOfSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            UseOfSiteExtraA useOfSiteExtraARet = useOfSiteService.GetUseOfSiteExtraAWithUseOfSiteID(useOfSite.UseOfSiteID);
                            CheckUseOfSiteExtraAFields(new List<UseOfSiteExtraA>() { useOfSiteExtraARet });
                            Assert.AreEqual(useOfSite.UseOfSiteID, useOfSiteExtraARet.UseOfSiteID);
                        }
                        else if (extra == "ExtraB")
                        {
                            UseOfSiteExtraB useOfSiteExtraBRet = useOfSiteService.GetUseOfSiteExtraBWithUseOfSiteID(useOfSite.UseOfSiteID);
                            CheckUseOfSiteExtraBFields(new List<UseOfSiteExtraB>() { useOfSiteExtraBRet });
                            Assert.AreEqual(useOfSite.UseOfSiteID, useOfSiteExtraBRet.UseOfSiteID);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    UseOfSite useOfSite = (from c in dbTestDB.UseOfSites select c).FirstOrDefault();
                    Assert.IsNotNull(useOfSite);

                    List<UseOfSite> useOfSiteDirectQueryList = new List<UseOfSite>();
                    useOfSiteDirectQueryList = (from c in dbTestDB.UseOfSites select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        useOfSiteService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                            useOfSiteList = useOfSiteService.GetUseOfSiteList().ToList();
                            CheckUseOfSiteFields(useOfSiteList);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<UseOfSiteExtraA> useOfSiteExtraAList = new List<UseOfSiteExtraA>();
                            useOfSiteExtraAList = useOfSiteService.GetUseOfSiteExtraAList().ToList();
                            CheckUseOfSiteExtraAFields(useOfSiteExtraAList);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<UseOfSiteExtraB> useOfSiteExtraBList = new List<UseOfSiteExtraB>();
                            useOfSiteExtraBList = useOfSiteService.GetUseOfSiteExtraBList().ToList();
                            CheckUseOfSiteExtraBFields(useOfSiteExtraBList);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSiteExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        useOfSiteService.Query = useOfSiteService.FillQuery(typeof(UseOfSite), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<UseOfSite> useOfSiteDirectQueryList = new List<UseOfSite>();
                        useOfSiteDirectQueryList = (from c in dbTestDB.UseOfSites select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                            useOfSiteList = useOfSiteService.GetUseOfSiteList().ToList();
                            CheckUseOfSiteFields(useOfSiteList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteList[0].UseOfSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<UseOfSiteExtraA> useOfSiteExtraAList = new List<UseOfSiteExtraA>();
                            useOfSiteExtraAList = useOfSiteService.GetUseOfSiteExtraAList().ToList();
                            CheckUseOfSiteExtraAFields(useOfSiteExtraAList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteExtraAList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<UseOfSiteExtraB> useOfSiteExtraBList = new List<UseOfSiteExtraB>();
                            useOfSiteExtraBList = useOfSiteService.GetUseOfSiteExtraBList().ToList();
                            CheckUseOfSiteExtraBFields(useOfSiteExtraBList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteExtraBList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSiteExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        useOfSiteService.Query = useOfSiteService.FillQuery(typeof(UseOfSite), culture.TwoLetterISOLanguageName, 1, 1,  "UseOfSiteID", "");

                        List<UseOfSite> useOfSiteDirectQueryList = new List<UseOfSite>();
                        useOfSiteDirectQueryList = (from c in dbTestDB.UseOfSites select c).Skip(1).Take(1).OrderBy(c => c.UseOfSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                            useOfSiteList = useOfSiteService.GetUseOfSiteList().ToList();
                            CheckUseOfSiteFields(useOfSiteList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteList[0].UseOfSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<UseOfSiteExtraA> useOfSiteExtraAList = new List<UseOfSiteExtraA>();
                            useOfSiteExtraAList = useOfSiteService.GetUseOfSiteExtraAList().ToList();
                            CheckUseOfSiteExtraAFields(useOfSiteExtraAList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteExtraAList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<UseOfSiteExtraB> useOfSiteExtraBList = new List<UseOfSiteExtraB>();
                            useOfSiteExtraBList = useOfSiteService.GetUseOfSiteExtraBList().ToList();
                            CheckUseOfSiteExtraBFields(useOfSiteExtraBList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteExtraBList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSiteExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        useOfSiteService.Query = useOfSiteService.FillQuery(typeof(UseOfSite), culture.TwoLetterISOLanguageName, 1, 1, "UseOfSiteID,SiteTVItemID", "");

                        List<UseOfSite> useOfSiteDirectQueryList = new List<UseOfSite>();
                        useOfSiteDirectQueryList = (from c in dbTestDB.UseOfSites select c).Skip(1).Take(1).OrderBy(c => c.UseOfSiteID).ThenBy(c => c.SiteTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                            useOfSiteList = useOfSiteService.GetUseOfSiteList().ToList();
                            CheckUseOfSiteFields(useOfSiteList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteList[0].UseOfSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<UseOfSiteExtraA> useOfSiteExtraAList = new List<UseOfSiteExtraA>();
                            useOfSiteExtraAList = useOfSiteService.GetUseOfSiteExtraAList().ToList();
                            CheckUseOfSiteExtraAFields(useOfSiteExtraAList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteExtraAList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<UseOfSiteExtraB> useOfSiteExtraBList = new List<UseOfSiteExtraB>();
                            useOfSiteExtraBList = useOfSiteService.GetUseOfSiteExtraBList().ToList();
                            CheckUseOfSiteExtraBFields(useOfSiteExtraBList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteExtraBList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSiteExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        useOfSiteService.Query = useOfSiteService.FillQuery(typeof(UseOfSite), culture.TwoLetterISOLanguageName, 0, 1, "UseOfSiteID", "UseOfSiteID,EQ,4", "");

                        List<UseOfSite> useOfSiteDirectQueryList = new List<UseOfSite>();
                        useOfSiteDirectQueryList = (from c in dbTestDB.UseOfSites select c).Where(c => c.UseOfSiteID == 4).Skip(0).Take(1).OrderBy(c => c.UseOfSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                            useOfSiteList = useOfSiteService.GetUseOfSiteList().ToList();
                            CheckUseOfSiteFields(useOfSiteList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteList[0].UseOfSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<UseOfSiteExtraA> useOfSiteExtraAList = new List<UseOfSiteExtraA>();
                            useOfSiteExtraAList = useOfSiteService.GetUseOfSiteExtraAList().ToList();
                            CheckUseOfSiteExtraAFields(useOfSiteExtraAList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteExtraAList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<UseOfSiteExtraB> useOfSiteExtraBList = new List<UseOfSiteExtraB>();
                            useOfSiteExtraBList = useOfSiteService.GetUseOfSiteExtraBList().ToList();
                            CheckUseOfSiteExtraBFields(useOfSiteExtraBList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteExtraBList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSiteExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        useOfSiteService.Query = useOfSiteService.FillQuery(typeof(UseOfSite), culture.TwoLetterISOLanguageName, 0, 1, "UseOfSiteID", "UseOfSiteID,GT,2|UseOfSiteID,LT,5", "");

                        List<UseOfSite> useOfSiteDirectQueryList = new List<UseOfSite>();
                        useOfSiteDirectQueryList = (from c in dbTestDB.UseOfSites select c).Where(c => c.UseOfSiteID > 2 && c.UseOfSiteID < 5).Skip(0).Take(1).OrderBy(c => c.UseOfSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                            useOfSiteList = useOfSiteService.GetUseOfSiteList().ToList();
                            CheckUseOfSiteFields(useOfSiteList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteList[0].UseOfSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<UseOfSiteExtraA> useOfSiteExtraAList = new List<UseOfSiteExtraA>();
                            useOfSiteExtraAList = useOfSiteService.GetUseOfSiteExtraAList().ToList();
                            CheckUseOfSiteExtraAFields(useOfSiteExtraAList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteExtraAList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<UseOfSiteExtraB> useOfSiteExtraBList = new List<UseOfSiteExtraB>();
                            useOfSiteExtraBList = useOfSiteService.GetUseOfSiteExtraBList().ToList();
                            CheckUseOfSiteExtraBFields(useOfSiteExtraBList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteExtraBList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSiteExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        useOfSiteService.Query = useOfSiteService.FillQuery(typeof(UseOfSite), culture.TwoLetterISOLanguageName, 0, 10000, "", "UseOfSiteID,GT,2|UseOfSiteID,LT,5", "");

                        List<UseOfSite> useOfSiteDirectQueryList = new List<UseOfSite>();
                        useOfSiteDirectQueryList = (from c in dbTestDB.UseOfSites select c).Where(c => c.UseOfSiteID > 2 && c.UseOfSiteID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                            useOfSiteList = useOfSiteService.GetUseOfSiteList().ToList();
                            CheckUseOfSiteFields(useOfSiteList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteList[0].UseOfSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<UseOfSiteExtraA> useOfSiteExtraAList = new List<UseOfSiteExtraA>();
                            useOfSiteExtraAList = useOfSiteService.GetUseOfSiteExtraAList().ToList();
                            CheckUseOfSiteExtraAFields(useOfSiteExtraAList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteExtraAList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<UseOfSiteExtraB> useOfSiteExtraBList = new List<UseOfSiteExtraB>();
                            useOfSiteExtraBList = useOfSiteService.GetUseOfSiteExtraBList().ToList();
                            CheckUseOfSiteExtraBFields(useOfSiteExtraBList);
                            Assert.AreEqual(useOfSiteDirectQueryList[0].UseOfSiteID, useOfSiteExtraBList[0].UseOfSiteID);
                            Assert.AreEqual(useOfSiteDirectQueryList.Count, useOfSiteExtraBList.Count);
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
        private void CheckUseOfSiteExtraAFields(List<UseOfSiteExtraA> useOfSiteExtraAList)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSiteExtraAList[0].SiteText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSiteExtraAList[0].SubsectorText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSiteExtraAList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(useOfSiteExtraAList[0].SiteTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSiteExtraAList[0].SiteTypeText));
            }
            Assert.IsNotNull(useOfSiteExtraAList[0].UseOfSiteID);
            Assert.IsNotNull(useOfSiteExtraAList[0].SiteTVItemID);
            Assert.IsNotNull(useOfSiteExtraAList[0].SubsectorTVItemID);
            Assert.IsNotNull(useOfSiteExtraAList[0].SiteType);
            Assert.IsNotNull(useOfSiteExtraAList[0].Ordinal);
            Assert.IsNotNull(useOfSiteExtraAList[0].StartYear);
            if (useOfSiteExtraAList[0].EndYear != null)
            {
                Assert.IsNotNull(useOfSiteExtraAList[0].EndYear);
            }
            if (useOfSiteExtraAList[0].UseWeight != null)
            {
                Assert.IsNotNull(useOfSiteExtraAList[0].UseWeight);
            }
            if (useOfSiteExtraAList[0].Weight_perc != null)
            {
                Assert.IsNotNull(useOfSiteExtraAList[0].Weight_perc);
            }
            if (useOfSiteExtraAList[0].UseEquation != null)
            {
                Assert.IsNotNull(useOfSiteExtraAList[0].UseEquation);
            }
            if (useOfSiteExtraAList[0].Param1 != null)
            {
                Assert.IsNotNull(useOfSiteExtraAList[0].Param1);
            }
            if (useOfSiteExtraAList[0].Param2 != null)
            {
                Assert.IsNotNull(useOfSiteExtraAList[0].Param2);
            }
            if (useOfSiteExtraAList[0].Param3 != null)
            {
                Assert.IsNotNull(useOfSiteExtraAList[0].Param3);
            }
            if (useOfSiteExtraAList[0].Param4 != null)
            {
                Assert.IsNotNull(useOfSiteExtraAList[0].Param4);
            }
            Assert.IsNotNull(useOfSiteExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(useOfSiteExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(useOfSiteExtraAList[0].HasErrors);
        }
        private void CheckUseOfSiteExtraBFields(List<UseOfSiteExtraB> useOfSiteExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(useOfSiteExtraBList[0].UseOfSiteReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSiteExtraBList[0].UseOfSiteReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSiteExtraBList[0].SiteText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSiteExtraBList[0].SubsectorText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSiteExtraBList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(useOfSiteExtraBList[0].SiteTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSiteExtraBList[0].SiteTypeText));
            }
            Assert.IsNotNull(useOfSiteExtraBList[0].UseOfSiteID);
            Assert.IsNotNull(useOfSiteExtraBList[0].SiteTVItemID);
            Assert.IsNotNull(useOfSiteExtraBList[0].SubsectorTVItemID);
            Assert.IsNotNull(useOfSiteExtraBList[0].SiteType);
            Assert.IsNotNull(useOfSiteExtraBList[0].Ordinal);
            Assert.IsNotNull(useOfSiteExtraBList[0].StartYear);
            if (useOfSiteExtraBList[0].EndYear != null)
            {
                Assert.IsNotNull(useOfSiteExtraBList[0].EndYear);
            }
            if (useOfSiteExtraBList[0].UseWeight != null)
            {
                Assert.IsNotNull(useOfSiteExtraBList[0].UseWeight);
            }
            if (useOfSiteExtraBList[0].Weight_perc != null)
            {
                Assert.IsNotNull(useOfSiteExtraBList[0].Weight_perc);
            }
            if (useOfSiteExtraBList[0].UseEquation != null)
            {
                Assert.IsNotNull(useOfSiteExtraBList[0].UseEquation);
            }
            if (useOfSiteExtraBList[0].Param1 != null)
            {
                Assert.IsNotNull(useOfSiteExtraBList[0].Param1);
            }
            if (useOfSiteExtraBList[0].Param2 != null)
            {
                Assert.IsNotNull(useOfSiteExtraBList[0].Param2);
            }
            if (useOfSiteExtraBList[0].Param3 != null)
            {
                Assert.IsNotNull(useOfSiteExtraBList[0].Param3);
            }
            if (useOfSiteExtraBList[0].Param4 != null)
            {
                Assert.IsNotNull(useOfSiteExtraBList[0].Param4);
            }
            Assert.IsNotNull(useOfSiteExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(useOfSiteExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(useOfSiteExtraBList[0].HasErrors);
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
