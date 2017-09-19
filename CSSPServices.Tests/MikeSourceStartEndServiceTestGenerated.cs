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
    public partial class MikeSourceStartEndServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MikeSourceStartEndService mikeSourceStartEndService { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndServiceTest() : base()
        {
            //mikeSourceStartEndService = new MikeSourceStartEndService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MikeSourceStartEnd GetFilledRandomMikeSourceStartEnd(string OmitPropName)
        {
            MikeSourceStartEnd mikeSourceStartEnd = new MikeSourceStartEnd();

            if (OmitPropName != "MikeSourceID") mikeSourceStartEnd.MikeSourceID = 1;
            if (OmitPropName != "StartDateAndTime_Local") mikeSourceStartEnd.StartDateAndTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateAndTime_Local") mikeSourceStartEnd.EndDateAndTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "SourceFlowStart_m3_day") mikeSourceStartEnd.SourceFlowStart_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourceFlowEnd_m3_day") mikeSourceStartEnd.SourceFlowEnd_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourcePollutionStart_MPN_100ml") mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourcePollutionEnd_MPN_100ml") mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourceTemperatureStart_C") mikeSourceStartEnd.SourceTemperatureStart_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SourceTemperatureEnd_C") mikeSourceStartEnd.SourceTemperatureEnd_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SourceSalinityStart_PSU") mikeSourceStartEnd.SourceSalinityStart_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "SourceSalinityEnd_PSU") mikeSourceStartEnd.SourceSalinityEnd_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "LastUpdateDate_UTC") mikeSourceStartEnd.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeSourceStartEnd.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") mikeSourceStartEnd.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") mikeSourceStartEnd.HasErrors = true;

            return mikeSourceStartEnd;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MikeSourceStartEnd_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MikeSourceStartEnd mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                count = mikeSourceStartEndService.GetRead().Count();

                Assert.AreEqual(mikeSourceStartEndService.GetRead().Count(), mikeSourceStartEndService.GetEdit().Count());

                mikeSourceStartEndService.Add(mikeSourceStartEnd);
                if (mikeSourceStartEnd.HasErrors)
                {
                    Assert.AreEqual("", mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, mikeSourceStartEndService.GetRead().Where(c => c == mikeSourceStartEnd).Any());
                mikeSourceStartEndService.Update(mikeSourceStartEnd);
                if (mikeSourceStartEnd.HasErrors)
                {
                    Assert.AreEqual("", mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, mikeSourceStartEndService.GetRead().Count());
                mikeSourceStartEndService.Delete(mikeSourceStartEnd);
                if (mikeSourceStartEnd.HasErrors)
                {
                    Assert.AreEqual("", mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mikeSourceStartEnd.MikeSourceStartEndID   (Int32)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.MikeSourceStartEndID = 0;
                    mikeSourceStartEndService.Update(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeSourceStartEndMikeSourceStartEndID), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.MikeSourceStartEndID = 10000000;
                    mikeSourceStartEndService.Update(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MikeSourceStartEnd, CSSPModelsRes.MikeSourceStartEndMikeSourceStartEndID, mikeSourceStartEnd.MikeSourceStartEndID.ToString()), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "MikeSource", ExistPlurial = "s", ExistFieldID = "MikeSourceID", AllowableTVtypeList = Error)]
                    // mikeSourceStartEnd.MikeSourceID   (Int32)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.MikeSourceID = 0;
                    mikeSourceStartEndService.Add(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MikeSource, CSSPModelsRes.MikeSourceStartEndMikeSourceID, mikeSourceStartEnd.MikeSourceID.ToString()), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeSourceStartEnd.StartDateAndTime_Local   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // [CSSPBigger(OtherField = StartDateAndTime_Local)]
                    // mikeSourceStartEnd.EndDateAndTime_Local   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000000)]
                    // mikeSourceStartEnd.SourceFlowStart_m3_day   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [SourceFlowStart_m3_day]

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceFlowStart_m3_day = -1.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceFlowStart_m3_day, "0", "1000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceFlowStart_m3_day = 1000001.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceFlowStart_m3_day, "0", "1000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000000)]
                    // mikeSourceStartEnd.SourceFlowEnd_m3_day   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [SourceFlowEnd_m3_day]

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceFlowEnd_m3_day = -1.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceFlowEnd_m3_day, "0", "1000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceFlowEnd_m3_day = 1000001.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceFlowEnd_m3_day, "0", "1000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // mikeSourceStartEnd.SourcePollutionStart_MPN_100ml   (Int32)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = -1;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourcePollutionStart_MPN_100ml, "0", "10000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = 10000001;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourcePollutionStart_MPN_100ml, "0", "10000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml   (Int32)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = -1;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourcePollutionEnd_MPN_100ml, "0", "10000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = 10000001;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourcePollutionEnd_MPN_100ml, "0", "10000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-10, 40)]
                    // mikeSourceStartEnd.SourceTemperatureStart_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [SourceTemperatureStart_C]

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceTemperatureStart_C = -11.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceTemperatureStart_C, "-10", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceTemperatureStart_C = 41.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceTemperatureStart_C, "-10", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-10, 40)]
                    // mikeSourceStartEnd.SourceTemperatureEnd_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [SourceTemperatureEnd_C]

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceTemperatureEnd_C = -11.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceTemperatureEnd_C, "-10", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceTemperatureEnd_C = 41.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceTemperatureEnd_C, "-10", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 40)]
                    // mikeSourceStartEnd.SourceSalinityStart_PSU   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [SourceSalinityStart_PSU]

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceSalinityStart_PSU = -1.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceSalinityStart_PSU, "0", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceSalinityStart_PSU = 41.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceSalinityStart_PSU, "0", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 40)]
                    // mikeSourceStartEnd.SourceSalinityEnd_PSU   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [SourceSalinityEnd_PSU]

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceSalinityEnd_PSU = -1.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceSalinityEnd_PSU, "0", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceSalinityEnd_PSU = 41.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceSalinityEnd_PSU, "0", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeSourceStartEnd.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mikeSourceStartEnd.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.LastUpdateContactTVItemID = 0;
                    mikeSourceStartEndService.Add(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MikeSourceStartEndLastUpdateContactTVItemID, mikeSourceStartEnd.LastUpdateContactTVItemID.ToString()), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.LastUpdateContactTVItemID = 1;
                    mikeSourceStartEndService.Add(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MikeSourceStartEndLastUpdateContactTVItemID, "Contact"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // mikeSourceStartEnd.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MikeSourceStartEndLastUpdateContactTVText, "200"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeSourceStartEnd.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeSourceStartEnd.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void MikeSourceStartEnd_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(LanguageRequest, dbTestDB, ContactID);
                    MikeSourceStartEnd mikeSourceStartEnd = (from c in mikeSourceStartEndService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mikeSourceStartEnd);

                    MikeSourceStartEnd mikeSourceStartEndRet = mikeSourceStartEndService.GetMikeSourceStartEndWithMikeSourceStartEndID(mikeSourceStartEnd.MikeSourceStartEndID);
                    Assert.IsNotNull(mikeSourceStartEndRet.MikeSourceStartEndID);
                    Assert.IsNotNull(mikeSourceStartEndRet.MikeSourceID);
                    Assert.IsNotNull(mikeSourceStartEndRet.StartDateAndTime_Local);
                    Assert.IsNotNull(mikeSourceStartEndRet.EndDateAndTime_Local);
                    Assert.IsNotNull(mikeSourceStartEndRet.SourceFlowStart_m3_day);
                    Assert.IsNotNull(mikeSourceStartEndRet.SourceFlowEnd_m3_day);
                    Assert.IsNotNull(mikeSourceStartEndRet.SourcePollutionStart_MPN_100ml);
                    Assert.IsNotNull(mikeSourceStartEndRet.SourcePollutionEnd_MPN_100ml);
                    Assert.IsNotNull(mikeSourceStartEndRet.SourceTemperatureStart_C);
                    Assert.IsNotNull(mikeSourceStartEndRet.SourceTemperatureEnd_C);
                    Assert.IsNotNull(mikeSourceStartEndRet.SourceSalinityStart_PSU);
                    Assert.IsNotNull(mikeSourceStartEndRet.SourceSalinityEnd_PSU);
                    Assert.IsNotNull(mikeSourceStartEndRet.LastUpdateDate_UTC);
                    Assert.IsNotNull(mikeSourceStartEndRet.LastUpdateContactTVItemID);

                    Assert.IsNotNull(mikeSourceStartEndRet.LastUpdateContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mikeSourceStartEndRet.LastUpdateContactTVText));
                    Assert.IsNotNull(mikeSourceStartEndRet.HasErrors);
                }
            }
        }
        #endregion Tests Get With Key

    }
}
