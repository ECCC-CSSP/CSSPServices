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
    public partial class BoxModelServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private BoxModelService boxModelService { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelServiceTest() : base()
        {
            //boxModelService = new BoxModelService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private BoxModel GetFilledRandomBoxModel(string OmitPropName)
        {
            BoxModel boxModel = new BoxModel();

            if (OmitPropName != "InfrastructureTVItemID") boxModel.InfrastructureTVItemID = 37;
            if (OmitPropName != "Flow_m3_day") boxModel.Flow_m3_day = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "Depth_m") boxModel.Depth_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "Temperature_C") boxModel.Temperature_C = GetRandomDouble(-15.0D, 40.0D);
            if (OmitPropName != "Dilution") boxModel.Dilution = GetRandomInt(0, 10000000);
            if (OmitPropName != "DecayRate_per_day") boxModel.DecayRate_per_day = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "FCUntreated_MPN_100ml") boxModel.FCUntreated_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "FCPreDisinfection_MPN_100ml") boxModel.FCPreDisinfection_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "Concentration_MPN_100ml") boxModel.Concentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "T90_hour") boxModel.T90_hour = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "FlowDuration_hour") boxModel.FlowDuration_hour = GetRandomDouble(0.0D, 24.0D);
            if (OmitPropName != "LastUpdateDate_UTC") boxModel.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") boxModel.LastUpdateContactTVItemID = 2;

            return boxModel;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void BoxModel_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BoxModelService boxModelService = new BoxModelService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    BoxModel boxModel = GetFilledRandomBoxModel("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = boxModelService.GetRead().Count();

                    Assert.AreEqual(boxModelService.GetRead().Count(), boxModelService.GetEdit().Count());

                    boxModelService.Add(boxModel);
                    if (boxModel.HasErrors)
                    {
                        Assert.AreEqual("", boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, boxModelService.GetRead().Where(c => c == boxModel).Any());
                    boxModelService.Update(boxModel);
                    if (boxModel.HasErrors)
                    {
                        Assert.AreEqual("", boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, boxModelService.GetRead().Count());
                    boxModelService.Delete(boxModel);
                    if (boxModel.HasErrors)
                    {
                        Assert.AreEqual("", boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, boxModelService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // boxModel.BoxModelID   (Int32)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.BoxModelID = 0;
                    boxModelService.Update(boxModel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.BoxModelBoxModelID), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.BoxModelID = 10000000;
                    boxModelService.Update(boxModel);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.BoxModel, CSSPModelsRes.BoxModelBoxModelID, boxModel.BoxModelID.ToString()), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
                    // boxModel.InfrastructureTVItemID   (Int32)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.InfrastructureTVItemID = 0;
                    boxModelService.Add(boxModel);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.BoxModelInfrastructureTVItemID, boxModel.InfrastructureTVItemID.ToString()), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.InfrastructureTVItemID = 1;
                    boxModelService.Add(boxModel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.BoxModelInfrastructureTVItemID, "Infrastructure"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000)]
                    // boxModel.Flow_m3_day   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Flow_m3_day]

                    //Error: Type not implemented [Flow_m3_day]

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Flow_m3_day = -1.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFlow_m3_day, "0", "10000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Flow_m3_day = 10001.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFlow_m3_day, "0", "10000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // boxModel.Depth_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Depth_m]

                    //Error: Type not implemented [Depth_m]

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Depth_m = -1.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelDepth_m, "0", "1000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Depth_m = 1001.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelDepth_m, "0", "1000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-15, 40)]
                    // boxModel.Temperature_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Temperature_C]

                    //Error: Type not implemented [Temperature_C]

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Temperature_C = -16.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelTemperature_C, "-15", "40"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Temperature_C = 41.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelTemperature_C, "-15", "40"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // boxModel.Dilution   (Int32)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Dilution = -1;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelDilution, "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Dilution = 10000001;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelDilution, "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // boxModel.DecayRate_per_day   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DecayRate_per_day]

                    //Error: Type not implemented [DecayRate_per_day]

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.DecayRate_per_day = -1.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelDecayRate_per_day, "0", "100"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.DecayRate_per_day = 101.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelDecayRate_per_day, "0", "100"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // boxModel.FCUntreated_MPN_100ml   (Int32)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.FCUntreated_MPN_100ml = -1;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFCUntreated_MPN_100ml, "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.FCUntreated_MPN_100ml = 10000001;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFCUntreated_MPN_100ml, "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // boxModel.FCPreDisinfection_MPN_100ml   (Int32)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.FCPreDisinfection_MPN_100ml = -1;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFCPreDisinfection_MPN_100ml, "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.FCPreDisinfection_MPN_100ml = 10000001;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFCPreDisinfection_MPN_100ml, "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // boxModel.Concentration_MPN_100ml   (Int32)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Concentration_MPN_100ml = -1;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelConcentration_MPN_100ml, "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Concentration_MPN_100ml = 10000001;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelConcentration_MPN_100ml, "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, -1)]
                    // boxModel.T90_hour   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [T90_hour]

                    //Error: Type not implemented [T90_hour]

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.T90_hour = -1.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.BoxModelT90_hour, "0"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 24)]
                    // boxModel.FlowDuration_hour   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [FlowDuration_hour]

                    //Error: Type not implemented [FlowDuration_hour]

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.FlowDuration_hour = -1.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFlowDuration_hour, "0", "24"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.FlowDuration_hour = 25.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFlowDuration_hour, "0", "24"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // boxModel.BoxModelWeb   (BoxModelWeb)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.BoxModelWeb = null;
                    Assert.IsNull(boxModel.BoxModelWeb);

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.BoxModelWeb = new BoxModelWeb();
                    Assert.IsNotNull(boxModel.BoxModelWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // boxModel.BoxModelReport   (BoxModelReport)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.BoxModelReport = null;
                    Assert.IsNull(boxModel.BoxModelReport);

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.BoxModelReport = new BoxModelReport();
                    Assert.IsNotNull(boxModel.BoxModelReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // boxModel.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.LastUpdateDate_UTC = new DateTime();
                    boxModelService.Add(boxModel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.BoxModelLastUpdateDate_UTC), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    boxModelService.Add(boxModel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.BoxModelLastUpdateDate_UTC, "1980"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // boxModel.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.LastUpdateContactTVItemID = 0;
                    boxModelService.Add(boxModel);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.BoxModelLastUpdateContactTVItemID, boxModel.LastUpdateContactTVItemID.ToString()), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.LastUpdateContactTVItemID = 1;
                    boxModelService.Add(boxModel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.BoxModelLastUpdateContactTVItemID, "Contact"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // boxModel.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // boxModel.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void BoxModel_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    BoxModelService boxModelService = new BoxModelService(new GetParam(), dbTestDB, ContactID);
                    BoxModel boxModel = (from c in boxModelService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(boxModel);

                    BoxModel boxModelRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            boxModelRet = boxModelService.GetBoxModelWithBoxModelID(boxModel.BoxModelID, getParam);
                            Assert.IsNull(boxModelRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            boxModelRet = boxModelService.GetBoxModelWithBoxModelID(boxModel.BoxModelID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            boxModelRet = boxModelService.GetBoxModelWithBoxModelID(boxModel.BoxModelID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            boxModelRet = boxModelService.GetBoxModelWithBoxModelID(boxModel.BoxModelID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // BoxModel fields
                        Assert.IsNotNull(boxModelRet.BoxModelID);
                        Assert.IsNotNull(boxModelRet.InfrastructureTVItemID);
                        Assert.IsNotNull(boxModelRet.Flow_m3_day);
                        Assert.IsNotNull(boxModelRet.Depth_m);
                        Assert.IsNotNull(boxModelRet.Temperature_C);
                        Assert.IsNotNull(boxModelRet.Dilution);
                        Assert.IsNotNull(boxModelRet.DecayRate_per_day);
                        Assert.IsNotNull(boxModelRet.FCUntreated_MPN_100ml);
                        Assert.IsNotNull(boxModelRet.FCPreDisinfection_MPN_100ml);
                        Assert.IsNotNull(boxModelRet.Concentration_MPN_100ml);
                        Assert.IsNotNull(boxModelRet.T90_hour);
                        Assert.IsNotNull(boxModelRet.FlowDuration_hour);
                        Assert.IsNotNull(boxModelRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(boxModelRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // BoxModelWeb and BoxModelReport fields should be null here
                            Assert.IsNull(boxModelRet.BoxModelWeb);
                            Assert.IsNull(boxModelRet.BoxModelReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // BoxModelWeb fields should not be null and BoxModelReport fields should be null here
                            if (boxModelRet.BoxModelWeb.InfrastructureTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelRet.BoxModelWeb.InfrastructureTVText));
                            }
                            if (boxModelRet.BoxModelWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelRet.BoxModelWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(boxModelRet.BoxModelReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // BoxModelWeb and BoxModelReport fields should NOT be null here
                            if (boxModelRet.BoxModelWeb.InfrastructureTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelRet.BoxModelWeb.InfrastructureTVText));
                            }
                            if (boxModelRet.BoxModelWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelRet.BoxModelWeb.LastUpdateContactTVText));
                            }
                            if (boxModelRet.BoxModelReport.BoxModelReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelRet.BoxModelReport.BoxModelReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of BoxModel
        #endregion Tests Get List of BoxModel

    }
}
