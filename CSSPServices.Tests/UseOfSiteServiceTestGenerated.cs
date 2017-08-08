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

                useOfSiteService.Add(useOfSite);
                if (useOfSite.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, useOfSiteService.GetRead().Where(c => c == useOfSite).Any());
                useOfSiteService.Update(useOfSite);
                if (useOfSite.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, useOfSiteService.GetRead().Count());
                useOfSiteService.Delete(useOfSite);
                if (useOfSite.ValidationResults.Count() > 0)
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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.UseOfSiteUseOfSiteID), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = ClimateSite,HydrometricSite,TideSite)]
                // useOfSite.SiteTVItemID   (Int32)
                // -----------------------------------

                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.SiteTVItemID = 0;
                useOfSiteService.Add(useOfSite);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.UseOfSiteSiteTVItemID, useOfSite.SiteTVItemID.ToString()), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);

                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.SiteTVItemID = 1;
                useOfSiteService.Add(useOfSite);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.UseOfSiteSiteTVItemID, "ClimateSite,HydrometricSite,TideSite"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                // useOfSite.SubsectorTVItemID   (Int32)
                // -----------------------------------

                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.SubsectorTVItemID = 0;
                useOfSiteService.Add(useOfSite);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.UseOfSiteSubsectorTVItemID, useOfSite.SubsectorTVItemID.ToString()), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);

                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.SubsectorTVItemID = 1;
                useOfSiteService.Add(useOfSite);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.UseOfSiteSubsectorTVItemID, "Subsector"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // useOfSite.SiteType   (SiteTypeEnum)
                // -----------------------------------

                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.SiteType = (SiteTypeEnum)1000000;
                useOfSiteService.Add(useOfSite);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.UseOfSiteSiteType), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 1000)]
                // useOfSite.Ordinal   (Int32)
                // -----------------------------------

                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.Ordinal = -1;
                Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteOrdinal, "0", "1000"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.Ordinal = 1001;
                Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteOrdinal, "0", "1000"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteStartYear, "1980", "2050"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.StartYear = 2051;
                Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteStartYear, "1980", "2050"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteEndYear, "1980", "2050"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.EndYear = 2051;
                Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteEndYear, "1980", "2050"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteWeight_perc, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.Weight_perc = 101.0D;
                Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteWeight_perc, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam1, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.Param1 = 101.0D;
                Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam1, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam2, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.Param2 = 101.0D;
                Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam2, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam3, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.Param3 = 101.0D;
                Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam3, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam4, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, useOfSiteService.GetRead().Count());
                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.Param4 = 101.0D;
                Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam4, "0", "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, useOfSiteService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // useOfSite.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // useOfSite.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.LastUpdateContactTVItemID = 0;
                useOfSiteService.Add(useOfSite);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.UseOfSiteLastUpdateContactTVItemID, useOfSite.LastUpdateContactTVItemID.ToString()), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);

                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.LastUpdateContactTVItemID = 1;
                useOfSiteService.Add(useOfSite);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.UseOfSiteLastUpdateContactTVItemID, "Contact"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // useOfSite.SiteTVText   (String)
                // -----------------------------------

                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.SiteTVText = GetRandomString("", 201);
                Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.UseOfSiteSiteTVText, "200"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, useOfSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // useOfSite.SubsectorTVText   (String)
                // -----------------------------------

                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.SubsectorTVText = GetRandomString("", 201);
                Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.UseOfSiteSubsectorTVText, "200"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, useOfSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // useOfSite.LastUpdateContactTVText   (String)
                // -----------------------------------

                useOfSite = null;
                useOfSite = GetFilledRandomUseOfSite("");
                useOfSite.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.UseOfSiteLastUpdateContactTVText, "200"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.UseOfSiteSiteTypeText, "100"), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, useOfSiteService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // useOfSite.ValidationResults   (IEnumerable`1)
                // -----------------------------------

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

                UseOfSiteService useOfSiteService = new UseOfSiteService(LanguageRequest, dbTestDB, ContactID);

                UseOfSite useOfSite = (from c in useOfSiteService.GetRead()
                                             select c).FirstOrDefault();
                Assert.IsNotNull(useOfSite);

                UseOfSite useOfSiteRet = useOfSiteService.GetUseOfSiteWithUseOfSiteID(useOfSite.UseOfSiteID);
                Assert.AreEqual(useOfSite.UseOfSiteID, useOfSiteRet.UseOfSiteID);
            }
        }
        #endregion Tests Get With Key

    }
}
