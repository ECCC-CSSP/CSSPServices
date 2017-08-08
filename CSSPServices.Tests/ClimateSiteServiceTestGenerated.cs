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
    public partial class ClimateSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ClimateSiteService climateSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateSiteServiceTest() : base()
        {
            //climateSiteService = new ClimateSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ClimateSite GetFilledRandomClimateSite(string OmitPropName)
        {
            ClimateSite climateSite = new ClimateSite();

            if (OmitPropName != "ClimateSiteTVItemID") climateSite.ClimateSiteTVItemID = 7;
            if (OmitPropName != "ECDBID") climateSite.ECDBID = GetRandomInt(1, 100000);
            if (OmitPropName != "ClimateSiteName") climateSite.ClimateSiteName = GetRandomString("", 5);
            if (OmitPropName != "Province") climateSite.Province = GetRandomString("", 4);
            if (OmitPropName != "Elevation_m") climateSite.Elevation_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "ClimateID") climateSite.ClimateID = GetRandomString("", 5);
            if (OmitPropName != "WMOID") climateSite.WMOID = GetRandomInt(1, 100000);
            if (OmitPropName != "TCID") climateSite.TCID = GetRandomString("", 3);
            if (OmitPropName != "IsProvincial") climateSite.IsProvincial = true;
            if (OmitPropName != "ProvSiteID") climateSite.ProvSiteID = GetRandomString("", 5);
            if (OmitPropName != "TimeOffset_hour") climateSite.TimeOffset_hour = GetRandomDouble(-10.0D, 0.0D);
            if (OmitPropName != "File_desc") climateSite.File_desc = GetRandomString("", 5);
            if (OmitPropName != "HourlyStartDate_Local") climateSite.HourlyStartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "HourlyEndDate_Local") climateSite.HourlyEndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "HourlyNow") climateSite.HourlyNow = true;
            if (OmitPropName != "DailyStartDate_Local") climateSite.DailyStartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "DailyEndDate_Local") climateSite.DailyEndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "DailyNow") climateSite.DailyNow = true;
            if (OmitPropName != "MonthlyStartDate_Local") climateSite.MonthlyStartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "MonthlyEndDate_Local") climateSite.MonthlyEndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "MonthlyNow") climateSite.MonthlyNow = true;
            if (OmitPropName != "LastUpdateDate_UTC") climateSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") climateSite.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "ClimateSiteTVText") climateSite.ClimateSiteTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") climateSite.LastUpdateContactTVText = GetRandomString("", 5);

            return climateSite;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ClimateSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                ClimateSiteService climateSiteService = new ClimateSiteService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                ClimateSite climateSite = GetFilledRandomClimateSite("");

                // -------------------------------
                // -------------------------------
                // CRUD testing
                // -------------------------------
                // -------------------------------

                count = climateSiteService.GetRead().Count();

                climateSiteService.Add(climateSite);
                if (climateSite.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, climateSiteService.GetRead().Where(c => c == climateSite).Any());
                climateSiteService.Update(climateSite);
                if (climateSite.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, climateSiteService.GetRead().Count());
                climateSiteService.Delete(climateSite);
                if (climateSite.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, climateSiteService.GetRead().Count());

                // -------------------------------
                // -------------------------------
                // Properties testing
                // -------------------------------
                // -------------------------------


                // -----------------------------------
                // [Key]
                // Is NOT Nullable
                // climateSite.ClimateSiteID   (Int32)
                // -----------------------------------

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.ClimateSiteID = 0;
                climateSiteService.Update(climateSite);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteClimateSiteID), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = ClimateSite)]
                // climateSite.ClimateSiteTVItemID   (Int32)
                // -----------------------------------

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.ClimateSiteTVItemID = 0;
                climateSiteService.Add(climateSite);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ClimateSiteClimateSiteTVItemID, climateSite.ClimateSiteTVItemID.ToString()), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.ClimateSiteTVItemID = 1;
                climateSiteService.Add(climateSite);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ClimateSiteClimateSiteTVItemID, "ClimateSite"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [Range(1, 100000)]
                // climateSite.ECDBID   (Int32)
                // -----------------------------------

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.ECDBID = 0;
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteECDBID, "1", "100000"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());
                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.ECDBID = 100001;
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteECDBID, "1", "100000"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [StringLength(100))]
                // climateSite.ClimateSiteName   (String)
                // -----------------------------------

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("ClimateSiteName");
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(1, climateSite.ValidationResults.Count());
                Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteClimateSiteName)).Any());
                Assert.AreEqual(null, climateSite.ClimateSiteName);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.ClimateSiteName = GetRandomString("", 101);
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteClimateSiteName, "100"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [StringLength(4))]
                // climateSite.Province   (String)
                // -----------------------------------

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("Province");
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(1, climateSite.ValidationResults.Count());
                Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteProvince)).Any());
                Assert.AreEqual(null, climateSite.Province);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.Province = GetRandomString("", 5);
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteProvince, "4"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 10000)]
                // climateSite.Elevation_m   (Double)
                // -----------------------------------

                //Error: Type not implemented [Elevation_m]

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.Elevation_m = -1.0D;
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteElevation_m, "0", "10000"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());
                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.Elevation_m = 10001.0D;
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteElevation_m, "0", "10000"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [StringLength(10))]
                // climateSite.ClimateID   (String)
                // -----------------------------------

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.ClimateID = GetRandomString("", 11);
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteClimateID, "10"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(1, 100000)]
                // climateSite.WMOID   (Int32)
                // -----------------------------------

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.WMOID = 0;
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteWMOID, "1", "100000"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());
                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.WMOID = 100001;
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteWMOID, "1", "100000"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [StringLength(3))]
                // climateSite.TCID   (String)
                // -----------------------------------

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.TCID = GetRandomString("", 4);
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteTCID, "3"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // climateSite.IsProvincial   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [StringLength(50))]
                // climateSite.ProvSiteID   (String)
                // -----------------------------------

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.ProvSiteID = GetRandomString("", 51);
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteProvSiteID, "50"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(-10, 0)]
                // climateSite.TimeOffset_hour   (Double)
                // -----------------------------------

                //Error: Type not implemented [TimeOffset_hour]

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.TimeOffset_hour = -11.0D;
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteTimeOffset_hour, "-10", "0"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());
                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.TimeOffset_hour = 1.0D;
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteTimeOffset_hour, "-10", "0"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [StringLength(50))]
                // climateSite.File_desc   (String)
                // -----------------------------------

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.File_desc = GetRandomString("", 51);
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteFile_desc, "50"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // climateSite.HourlyStartDate_Local   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // climateSite.HourlyEndDate_Local   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // climateSite.HourlyNow   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // climateSite.DailyStartDate_Local   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // climateSite.DailyEndDate_Local   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // climateSite.DailyNow   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // climateSite.MonthlyStartDate_Local   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // climateSite.MonthlyEndDate_Local   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // climateSite.MonthlyNow   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // climateSite.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // climateSite.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.LastUpdateContactTVItemID = 0;
                climateSiteService.Add(climateSite);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ClimateSiteLastUpdateContactTVItemID, climateSite.LastUpdateContactTVItemID.ToString()), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.LastUpdateContactTVItemID = 1;
                climateSiteService.Add(climateSite);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ClimateSiteLastUpdateContactTVItemID, "Contact"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // climateSite.ClimateSiteTVText   (String)
                // -----------------------------------

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.ClimateSiteTVText = GetRandomString("", 201);
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteClimateSiteTVText, "200"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // climateSite.LastUpdateContactTVText   (String)
                // -----------------------------------

                climateSite = null;
                climateSite = GetFilledRandomClimateSite("");
                climateSite.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, climateSiteService.Add(climateSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteLastUpdateContactTVText, "200"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, climateSiteService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // climateSite.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void ClimateSite_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                ClimateSiteService climateSiteService = new ClimateSiteService(LanguageRequest, dbTestDB, ContactID);

                ClimateSite climateSite = (from c in climateSiteService.GetRead()
                                             select c).FirstOrDefault();
                Assert.IsNotNull(climateSite);

                ClimateSite climateSiteRet = climateSiteService.GetClimateSiteWithClimateSiteID(climateSite.ClimateSiteID);
                Assert.AreEqual(climateSite.ClimateSiteID, climateSiteRet.ClimateSiteID);
            }
        }
        #endregion Tests Get With Key

    }
}
