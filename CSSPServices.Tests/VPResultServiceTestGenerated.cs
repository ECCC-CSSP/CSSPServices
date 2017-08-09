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
    public partial class VPResultServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private VPResultService vpResultService { get; set; }
        #endregion Properties

        #region Constructors
        public VPResultServiceTest() : base()
        {
            //vpResultService = new VPResultService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPResult GetFilledRandomVPResult(string OmitPropName)
        {
            VPResult vpResult = new VPResult();

            if (OmitPropName != "VPScenarioID") vpResult.VPScenarioID = 1;
            if (OmitPropName != "Ordinal") vpResult.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "Concentration_MPN_100ml") vpResult.Concentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "Dilution") vpResult.Dilution = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "FarFieldWidth_m") vpResult.FarFieldWidth_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "DispersionDistance_m") vpResult.DispersionDistance_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "TravelTime_hour") vpResult.TravelTime_hour = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "LastUpdateDate_UTC") vpResult.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") vpResult.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") vpResult.LastUpdateContactTVText = GetRandomString("", 5);

            return vpResult;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void VPResult_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                VPResultService vpResultService = new VPResultService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                VPResult vpResult = GetFilledRandomVPResult("");

                // -------------------------------
                // -------------------------------
                // CRUD testing
                // -------------------------------
                // -------------------------------

                count = vpResultService.GetRead().Count();

                vpResultService.Add(vpResult);
                if (vpResult.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, vpResultService.GetRead().Where(c => c == vpResult).Any());
                vpResultService.Update(vpResult);
                if (vpResult.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, vpResultService.GetRead().Count());
                vpResultService.Delete(vpResult);
                if (vpResult.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, vpResultService.GetRead().Count());

                // -------------------------------
                // -------------------------------
                // Properties testing
                // -------------------------------
                // -------------------------------


                // -----------------------------------
                // [Key]
                // Is NOT Nullable
                // vpResult.VPResultID   (Int32)
                // -----------------------------------

                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.VPResultID = 0;
                vpResultService.Update(vpResult);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.VPResultVPResultID), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = Error)]
                // vpResult.VPScenarioID   (Int32)
                // -----------------------------------

                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.VPScenarioID = 0;
                vpResultService.Add(vpResult);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.VPScenario, ModelsRes.VPResultVPScenarioID, vpResult.VPScenarioID.ToString()), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 1000)]
                // vpResult.Ordinal   (Int32)
                // -----------------------------------

                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.Ordinal = -1;
                Assert.AreEqual(false, vpResultService.Add(vpResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultOrdinal, "0", "1000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpResultService.GetRead().Count());
                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.Ordinal = 1001;
                Assert.AreEqual(false, vpResultService.Add(vpResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultOrdinal, "0", "1000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 10000000)]
                // vpResult.Concentration_MPN_100ml   (Int32)
                // -----------------------------------

                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.Concentration_MPN_100ml = -1;
                Assert.AreEqual(false, vpResultService.Add(vpResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultConcentration_MPN_100ml, "0", "10000000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpResultService.GetRead().Count());
                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.Concentration_MPN_100ml = 10000001;
                Assert.AreEqual(false, vpResultService.Add(vpResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultConcentration_MPN_100ml, "0", "10000000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 1000000)]
                // vpResult.Dilution   (Double)
                // -----------------------------------

                //Error: Type not implemented [Dilution]

                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.Dilution = -1.0D;
                Assert.AreEqual(false, vpResultService.Add(vpResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultDilution, "0", "1000000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpResultService.GetRead().Count());
                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.Dilution = 1000001.0D;
                Assert.AreEqual(false, vpResultService.Add(vpResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultDilution, "0", "1000000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 10000)]
                // vpResult.FarFieldWidth_m   (Double)
                // -----------------------------------

                //Error: Type not implemented [FarFieldWidth_m]

                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.FarFieldWidth_m = -1.0D;
                Assert.AreEqual(false, vpResultService.Add(vpResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultFarFieldWidth_m, "0", "10000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpResultService.GetRead().Count());
                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.FarFieldWidth_m = 10001.0D;
                Assert.AreEqual(false, vpResultService.Add(vpResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultFarFieldWidth_m, "0", "10000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 100000)]
                // vpResult.DispersionDistance_m   (Double)
                // -----------------------------------

                //Error: Type not implemented [DispersionDistance_m]

                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.DispersionDistance_m = -1.0D;
                Assert.AreEqual(false, vpResultService.Add(vpResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultDispersionDistance_m, "0", "100000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpResultService.GetRead().Count());
                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.DispersionDistance_m = 100001.0D;
                Assert.AreEqual(false, vpResultService.Add(vpResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultDispersionDistance_m, "0", "100000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 100)]
                // vpResult.TravelTime_hour   (Double)
                // -----------------------------------

                //Error: Type not implemented [TravelTime_hour]

                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.TravelTime_hour = -1.0D;
                Assert.AreEqual(false, vpResultService.Add(vpResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultTravelTime_hour, "0", "100"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpResultService.GetRead().Count());
                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.TravelTime_hour = 101.0D;
                Assert.AreEqual(false, vpResultService.Add(vpResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultTravelTime_hour, "0", "100"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // vpResult.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // vpResult.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.LastUpdateContactTVItemID = 0;
                vpResultService.Add(vpResult);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.VPResultLastUpdateContactTVItemID, vpResult.LastUpdateContactTVItemID.ToString()), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);

                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.LastUpdateContactTVItemID = 1;
                vpResultService.Add(vpResult);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.VPResultLastUpdateContactTVItemID, "Contact"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // vpResult.LastUpdateContactTVText   (String)
                // -----------------------------------

                vpResult = null;
                vpResult = GetFilledRandomVPResult("");
                vpResult.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, vpResultService.Add(vpResult));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.VPResultLastUpdateContactTVText, "200"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // vpResult.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void VPResult_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                VPResultService vpResultService = new VPResultService(LanguageRequest, dbTestDB, ContactID);
                VPResult vpResult = (from c in vpResultService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(vpResult);

                VPResult vpResultRet = vpResultService.GetVPResultWithVPResultID(vpResult.VPResultID);
                Assert.IsNotNull(vpResultRet.VPResultID);
                Assert.IsNotNull(vpResultRet.VPScenarioID);
                Assert.IsNotNull(vpResultRet.Ordinal);
                Assert.IsNotNull(vpResultRet.Concentration_MPN_100ml);
                Assert.IsNotNull(vpResultRet.Dilution);
                Assert.IsNotNull(vpResultRet.FarFieldWidth_m);
                Assert.IsNotNull(vpResultRet.DispersionDistance_m);
                Assert.IsNotNull(vpResultRet.TravelTime_hour);
                Assert.IsNotNull(vpResultRet.LastUpdateDate_UTC);
                Assert.IsNotNull(vpResultRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(vpResultRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(vpResultRet.LastUpdateContactTVText));
            }
        }
        #endregion Tests Get With Key

    }
}