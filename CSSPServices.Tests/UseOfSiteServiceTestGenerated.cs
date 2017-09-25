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

        #region Functions public
        #endregion Functions public

        #region Functions private
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
            if (OmitPropName != "SiteTVText") useOfSite.SiteTVText = GetRandomString("", 5);
            if (OmitPropName != "SubsectorTVText") useOfSite.SubsectorTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") useOfSite.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "SiteTypeText") useOfSite.SiteTypeText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") useOfSite.HasErrors = true;

            return useOfSite;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void UseOfSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    UseOfSiteService useOfSiteService = new UseOfSiteService(LanguageRequest, dbTestDB, ContactID);

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

                    count = useOfSiteService.GetRead().Count();

                    Assert.AreEqual(useOfSiteService.GetRead().Count(), useOfSiteService.GetEdit().Count());

                    useOfSiteService.Add(useOfSite);
                    if (useOfSite.HasErrors)
                    {
                        Assert.AreEqual("", useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, useOfSiteService.GetRead().Where(c => c == useOfSite).Any());
                    useOfSiteService.Update(useOfSite);
                    if (useOfSite.HasErrors)
                    {
                        Assert.AreEqual("", useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, useOfSiteService.GetRead().Count());
                    useOfSiteService.Delete(useOfSite);
                    if (useOfSite.HasErrors)
                    {
                        Assert.AreEqual("", useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.UseOfSiteUseOfSiteID), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.UseOfSiteID = 10000000;
                    useOfSiteService.Update(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.UseOfSite, CSSPModelsRes.UseOfSiteUseOfSiteID, useOfSite.UseOfSiteID.ToString()), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = ClimateSite,HydrometricSite,TideSite)]
                    // useOfSite.SiteTVItemID   (Int32)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.SiteTVItemID = 0;
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.UseOfSiteSiteTVItemID, useOfSite.SiteTVItemID.ToString()), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.SiteTVItemID = 1;
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.UseOfSiteSiteTVItemID, "ClimateSite,HydrometricSite,TideSite"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                    // useOfSite.SubsectorTVItemID   (Int32)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.SubsectorTVItemID = 0;
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.UseOfSiteSubsectorTVItemID, useOfSite.SubsectorTVItemID.ToString()), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.SubsectorTVItemID = 1;
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.UseOfSiteSubsectorTVItemID, "Subsector"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // useOfSite.SiteType   (SiteTypeEnum)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.SiteType = (SiteTypeEnum)1000000;
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.UseOfSiteSiteType), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // useOfSite.Ordinal   (Int32)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Ordinal = -1;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteOrdinal, "0", "1000"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Ordinal = 1001;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteOrdinal, "0", "1000"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1980, 2050)]
                    // useOfSite.StartYear   (Int32)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.StartYear = 1979;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteStartYear, "1980", "2050"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.StartYear = 2051;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteStartYear, "1980", "2050"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(1980, 2050)]
                    // useOfSite.EndYear   (Int32)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.EndYear = 1979;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteEndYear, "1980", "2050"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.EndYear = 2051;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteEndYear, "1980", "2050"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());

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

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Weight_perc = -1.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteWeight_perc, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Weight_perc = 101.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteWeight_perc, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());

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

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param1 = -1.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteParam1, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param1 = 101.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteParam1, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // useOfSite.Param2   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Param2]

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param2 = -1.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteParam2, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param2 = 101.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteParam2, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // useOfSite.Param3   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Param3]

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param3 = -1.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteParam3, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param3 = 101.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteParam3, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // useOfSite.Param4   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Param4]

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param4 = -1.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteParam4, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.Param4 = 101.0D;
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteParam4, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // useOfSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // useOfSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.LastUpdateContactTVItemID = 0;
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.UseOfSiteLastUpdateContactTVItemID, useOfSite.LastUpdateContactTVItemID.ToString()), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.LastUpdateContactTVItemID = 1;
                    useOfSiteService.Add(useOfSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.UseOfSiteLastUpdateContactTVItemID, "Contact"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "SiteTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // useOfSite.SiteTVText   (String)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.SiteTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.UseOfSiteSiteTVText, "200"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "SubsectorTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // useOfSite.SubsectorTVText   (String)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.SubsectorTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.UseOfSiteSubsectorTVText, "200"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // useOfSite.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.UseOfSiteLastUpdateContactTVText, "200"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // useOfSite.SiteTypeText   (String)
                    // -----------------------------------

                    useOfSite = null;
                    useOfSite = GetFilledRandomUseOfSite("");
                    useOfSite.SiteTypeText = GetRandomString("", 101);
                    Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.UseOfSiteSiteTypeText, "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, useOfSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // useOfSite.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // useOfSite.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void UseOfSite_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    UseOfSiteService useOfSiteService = new UseOfSiteService(LanguageRequest, dbTestDB, ContactID);
                    UseOfSite useOfSite = (from c in useOfSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(useOfSite);

                    UseOfSite useOfSiteRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityIncludingNotMapped })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            useOfSiteRet = useOfSiteService.GetUseOfSiteWithUseOfSiteID(useOfSite.UseOfSiteID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            useOfSiteRet = useOfSiteService.GetUseOfSiteWithUseOfSiteID(useOfSite.UseOfSiteID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityIncludingNotMapped)
                        {
                            useOfSiteRet = useOfSiteService.GetUseOfSiteWithUseOfSiteID(useOfSite.UseOfSiteID, EntityQueryDetailTypeEnum.EntityIncludingNotMapped);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(useOfSiteRet.UseOfSiteID);
                        Assert.IsNotNull(useOfSiteRet.SiteTVItemID);
                        Assert.IsNotNull(useOfSiteRet.SubsectorTVItemID);
                        Assert.IsNotNull(useOfSiteRet.SiteType);
                        Assert.IsNotNull(useOfSiteRet.Ordinal);
                        Assert.IsNotNull(useOfSiteRet.StartYear);
                        if (useOfSiteRet.EndYear != null)
                        {
                            Assert.IsNotNull(useOfSiteRet.EndYear);
                        }
                        if (useOfSiteRet.UseWeight != null)
                        {
                            Assert.IsNotNull(useOfSiteRet.UseWeight);
                        }
                        if (useOfSiteRet.Weight_perc != null)
                        {
                            Assert.IsNotNull(useOfSiteRet.Weight_perc);
                        }
                        if (useOfSiteRet.UseEquation != null)
                        {
                            Assert.IsNotNull(useOfSiteRet.UseEquation);
                        }
                        if (useOfSiteRet.Param1 != null)
                        {
                            Assert.IsNotNull(useOfSiteRet.Param1);
                        }
                        if (useOfSiteRet.Param2 != null)
                        {
                            Assert.IsNotNull(useOfSiteRet.Param2);
                        }
                        if (useOfSiteRet.Param3 != null)
                        {
                            Assert.IsNotNull(useOfSiteRet.Param3);
                        }
                        if (useOfSiteRet.Param4 != null)
                        {
                            Assert.IsNotNull(useOfSiteRet.Param4);
                        }
                        Assert.IsNotNull(useOfSiteRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(useOfSiteRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (useOfSiteRet.SiteTVText != null)
                            {
                                Assert.IsTrue(string.IsNullOrWhiteSpace(useOfSiteRet.SiteTVText));
                            }
                            if (useOfSiteRet.SubsectorTVText != null)
                            {
                                Assert.IsTrue(string.IsNullOrWhiteSpace(useOfSiteRet.SubsectorTVText));
                            }
                            if (useOfSiteRet.LastUpdateContactTVText != null)
                            {
                                Assert.IsTrue(string.IsNullOrWhiteSpace(useOfSiteRet.LastUpdateContactTVText));
                            }
                            if (useOfSiteRet.SiteTypeText != null)
                            {
                                Assert.IsTrue(string.IsNullOrWhiteSpace(useOfSiteRet.SiteTypeText));
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityIncludingNotMapped)
                        {
                            if (useOfSiteRet.SiteTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSiteRet.SiteTVText));
                            }
                            if (useOfSiteRet.SubsectorTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSiteRet.SubsectorTVText));
                            }
                            if (useOfSiteRet.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSiteRet.LastUpdateContactTVText));
                            }
                            if (useOfSiteRet.SiteTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(useOfSiteRet.SiteTypeText));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of UseOfSite
        #endregion Tests Get List of UseOfSite

    }
}
