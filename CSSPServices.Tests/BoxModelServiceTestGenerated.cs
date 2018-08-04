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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void BoxModel_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BoxModelService boxModelService = new BoxModelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    count = boxModelService.GetBoxModelList().Count();

                    Assert.AreEqual(boxModelService.GetBoxModelList().Count(), (from c in dbTestDB.BoxModels select c).Take(200).Count());

                    boxModelService.Add(boxModel);
                    if (boxModel.HasErrors)
                    {
                        Assert.AreEqual("", boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, boxModelService.GetBoxModelList().Where(c => c == boxModel).Any());
                    boxModelService.Update(boxModel);
                    if (boxModel.HasErrors)
                    {
                        Assert.AreEqual("", boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, boxModelService.GetBoxModelList().Count());
                    boxModelService.Delete(boxModel);
                    if (boxModel.HasErrors)
                    {
                        Assert.AreEqual("", boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "BoxModelBoxModelID"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.BoxModelID = 10000000;
                    boxModelService.Update(boxModel);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelBoxModelID", boxModel.BoxModelID.ToString()), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
                    // boxModel.InfrastructureTVItemID   (Int32)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.InfrastructureTVItemID = 0;
                    boxModelService.Add(boxModel);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "BoxModelInfrastructureTVItemID", boxModel.InfrastructureTVItemID.ToString()), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.InfrastructureTVItemID = 1;
                    boxModelService.Add(boxModel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "BoxModelInfrastructureTVItemID", "Infrastructure"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelFlow_m3_day", "0", "10000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Flow_m3_day = 10001.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelFlow_m3_day", "0", "10000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelDepth_m", "0", "1000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Depth_m = 1001.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelDepth_m", "0", "1000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelTemperature_C", "-15", "40"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Temperature_C = 41.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelTemperature_C", "-15", "40"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // boxModel.Dilution   (Int32)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Dilution = -1;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelDilution", "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Dilution = 10000001;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelDilution", "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelDecayRate_per_day", "0", "100"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.DecayRate_per_day = 101.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelDecayRate_per_day", "0", "100"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // boxModel.FCUntreated_MPN_100ml   (Int32)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.FCUntreated_MPN_100ml = -1;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelFCUntreated_MPN_100ml", "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.FCUntreated_MPN_100ml = 10000001;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelFCUntreated_MPN_100ml", "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // boxModel.FCPreDisinfection_MPN_100ml   (Int32)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.FCPreDisinfection_MPN_100ml = -1;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelFCPreDisinfection_MPN_100ml", "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.FCPreDisinfection_MPN_100ml = 10000001;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelFCPreDisinfection_MPN_100ml", "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // boxModel.Concentration_MPN_100ml   (Int32)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Concentration_MPN_100ml = -1;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelConcentration_MPN_100ml", "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.Concentration_MPN_100ml = 10000001;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelConcentration_MPN_100ml", "0", "10000000"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, "BoxModelT90_hour", "0"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelFlowDuration_hour", "0", "24"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.FlowDuration_hour = 25.0D;
                    Assert.AreEqual(false, boxModelService.Add(boxModel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelFlowDuration_hour", "0", "24"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelService.GetBoxModelList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // boxModel.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.LastUpdateDate_UTC = new DateTime();
                    boxModelService.Add(boxModel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "BoxModelLastUpdateDate_UTC"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    boxModelService.Add(boxModel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "BoxModelLastUpdateDate_UTC", "1980"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // boxModel.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.LastUpdateContactTVItemID = 0;
                    boxModelService.Add(boxModel);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "BoxModelLastUpdateContactTVItemID", boxModel.LastUpdateContactTVItemID.ToString()), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);

                    boxModel = null;
                    boxModel = GetFilledRandomBoxModel("");
                    boxModel.LastUpdateContactTVItemID = 1;
                    boxModelService.Add(boxModel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "BoxModelLastUpdateContactTVItemID", "Contact"), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);


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

        #region Tests Generated for GetBoxModelWithBoxModelID(boxModel.BoxModelID)
        [TestMethod]
        public void GetBoxModelWithBoxModelID__boxModel_BoxModelID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BoxModelService boxModelService = new BoxModelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    BoxModel boxModel = (from c in dbTestDB.BoxModels select c).FirstOrDefault();
                    Assert.IsNotNull(boxModel);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        boxModelService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            BoxModel boxModelRet = boxModelService.GetBoxModelWithBoxModelID(boxModel.BoxModelID);
                            CheckBoxModelFields(new List<BoxModel>() { boxModelRet });
                            Assert.AreEqual(boxModel.BoxModelID, boxModelRet.BoxModelID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            BoxModelWeb boxModelWebRet = boxModelService.GetBoxModelWebWithBoxModelID(boxModel.BoxModelID);
                            CheckBoxModelWebFields(new List<BoxModelWeb>() { boxModelWebRet });
                            Assert.AreEqual(boxModel.BoxModelID, boxModelWebRet.BoxModelID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            BoxModelReport boxModelReportRet = boxModelService.GetBoxModelReportWithBoxModelID(boxModel.BoxModelID);
                            CheckBoxModelReportFields(new List<BoxModelReport>() { boxModelReportRet });
                            Assert.AreEqual(boxModel.BoxModelID, boxModelReportRet.BoxModelID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelWithBoxModelID(boxModel.BoxModelID)

        #region Tests Generated for GetBoxModelList()
        [TestMethod]
        public void GetBoxModelList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BoxModelService boxModelService = new BoxModelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    BoxModel boxModel = (from c in dbTestDB.BoxModels select c).FirstOrDefault();
                    Assert.IsNotNull(boxModel);

                    List<BoxModel> boxModelDirectQueryList = new List<BoxModel>();
                    boxModelDirectQueryList = (from c in dbTestDB.BoxModels select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        boxModelService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<BoxModel> boxModelList = new List<BoxModel>();
                            boxModelList = boxModelService.GetBoxModelList().ToList();
                            CheckBoxModelFields(boxModelList);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<BoxModelWeb> boxModelWebList = new List<BoxModelWeb>();
                            boxModelWebList = boxModelService.GetBoxModelWebList().ToList();
                            CheckBoxModelWebFields(boxModelWebList);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<BoxModelReport> boxModelReportList = new List<BoxModelReport>();
                            boxModelReportList = boxModelService.GetBoxModelReportList().ToList();
                            CheckBoxModelReportFields(boxModelReportList);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelList()

        #region Tests Generated for GetBoxModelList() Skip Take
        [TestMethod]
        public void GetBoxModelList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        BoxModelService boxModelService = new BoxModelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelService.Query = boxModelService.FillQuery(typeof(BoxModel), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<BoxModel> boxModelDirectQueryList = new List<BoxModel>();
                        boxModelDirectQueryList = (from c in dbTestDB.BoxModels select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<BoxModel> boxModelList = new List<BoxModel>();
                            boxModelList = boxModelService.GetBoxModelList().ToList();
                            CheckBoxModelFields(boxModelList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<BoxModelWeb> boxModelWebList = new List<BoxModelWeb>();
                            boxModelWebList = boxModelService.GetBoxModelWebList().ToList();
                            CheckBoxModelWebFields(boxModelWebList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelWebList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<BoxModelReport> boxModelReportList = new List<BoxModelReport>();
                            boxModelReportList = boxModelService.GetBoxModelReportList().ToList();
                            CheckBoxModelReportFields(boxModelReportList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelReportList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelList() Skip Take

        #region Tests Generated for GetBoxModelList() Skip Take Order
        [TestMethod]
        public void GetBoxModelList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        BoxModelService boxModelService = new BoxModelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelService.Query = boxModelService.FillQuery(typeof(BoxModel), culture.TwoLetterISOLanguageName, 1, 1,  "BoxModelID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<BoxModel> boxModelDirectQueryList = new List<BoxModel>();
                        boxModelDirectQueryList = (from c in dbTestDB.BoxModels select c).Skip(1).Take(1).OrderBy(c => c.BoxModelID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<BoxModel> boxModelList = new List<BoxModel>();
                            boxModelList = boxModelService.GetBoxModelList().ToList();
                            CheckBoxModelFields(boxModelList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<BoxModelWeb> boxModelWebList = new List<BoxModelWeb>();
                            boxModelWebList = boxModelService.GetBoxModelWebList().ToList();
                            CheckBoxModelWebFields(boxModelWebList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelWebList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<BoxModelReport> boxModelReportList = new List<BoxModelReport>();
                            boxModelReportList = boxModelService.GetBoxModelReportList().ToList();
                            CheckBoxModelReportFields(boxModelReportList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelReportList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelList() Skip Take Order

        #region Tests Generated for GetBoxModelList() Skip Take 2Order
        [TestMethod]
        public void GetBoxModelList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        BoxModelService boxModelService = new BoxModelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelService.Query = boxModelService.FillQuery(typeof(BoxModel), culture.TwoLetterISOLanguageName, 1, 1, "BoxModelID,InfrastructureTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<BoxModel> boxModelDirectQueryList = new List<BoxModel>();
                        boxModelDirectQueryList = (from c in dbTestDB.BoxModels select c).Skip(1).Take(1).OrderBy(c => c.BoxModelID).ThenBy(c => c.InfrastructureTVItemID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<BoxModel> boxModelList = new List<BoxModel>();
                            boxModelList = boxModelService.GetBoxModelList().ToList();
                            CheckBoxModelFields(boxModelList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<BoxModelWeb> boxModelWebList = new List<BoxModelWeb>();
                            boxModelWebList = boxModelService.GetBoxModelWebList().ToList();
                            CheckBoxModelWebFields(boxModelWebList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelWebList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<BoxModelReport> boxModelReportList = new List<BoxModelReport>();
                            boxModelReportList = boxModelService.GetBoxModelReportList().ToList();
                            CheckBoxModelReportFields(boxModelReportList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelReportList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelList() Skip Take 2Order

        #region Tests Generated for GetBoxModelList() Skip Take Order Where
        [TestMethod]
        public void GetBoxModelList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        BoxModelService boxModelService = new BoxModelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelService.Query = boxModelService.FillQuery(typeof(BoxModel), culture.TwoLetterISOLanguageName, 0, 1, "BoxModelID", "BoxModelID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<BoxModel> boxModelDirectQueryList = new List<BoxModel>();
                        boxModelDirectQueryList = (from c in dbTestDB.BoxModels select c).Where(c => c.BoxModelID == 4).Skip(0).Take(1).OrderBy(c => c.BoxModelID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<BoxModel> boxModelList = new List<BoxModel>();
                            boxModelList = boxModelService.GetBoxModelList().ToList();
                            CheckBoxModelFields(boxModelList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<BoxModelWeb> boxModelWebList = new List<BoxModelWeb>();
                            boxModelWebList = boxModelService.GetBoxModelWebList().ToList();
                            CheckBoxModelWebFields(boxModelWebList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelWebList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<BoxModelReport> boxModelReportList = new List<BoxModelReport>();
                            boxModelReportList = boxModelService.GetBoxModelReportList().ToList();
                            CheckBoxModelReportFields(boxModelReportList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelReportList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelList() Skip Take Order Where

        #region Tests Generated for GetBoxModelList() Skip Take Order 2Where
        [TestMethod]
        public void GetBoxModelList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        BoxModelService boxModelService = new BoxModelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelService.Query = boxModelService.FillQuery(typeof(BoxModel), culture.TwoLetterISOLanguageName, 0, 1, "BoxModelID", "BoxModelID,GT,2|BoxModelID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<BoxModel> boxModelDirectQueryList = new List<BoxModel>();
                        boxModelDirectQueryList = (from c in dbTestDB.BoxModels select c).Where(c => c.BoxModelID > 2 && c.BoxModelID < 5).Skip(0).Take(1).OrderBy(c => c.BoxModelID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<BoxModel> boxModelList = new List<BoxModel>();
                            boxModelList = boxModelService.GetBoxModelList().ToList();
                            CheckBoxModelFields(boxModelList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<BoxModelWeb> boxModelWebList = new List<BoxModelWeb>();
                            boxModelWebList = boxModelService.GetBoxModelWebList().ToList();
                            CheckBoxModelWebFields(boxModelWebList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelWebList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<BoxModelReport> boxModelReportList = new List<BoxModelReport>();
                            boxModelReportList = boxModelService.GetBoxModelReportList().ToList();
                            CheckBoxModelReportFields(boxModelReportList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelReportList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelList() Skip Take Order 2Where

        #region Tests Generated for GetBoxModelList() 2Where
        [TestMethod]
        public void GetBoxModelList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        BoxModelService boxModelService = new BoxModelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelService.Query = boxModelService.FillQuery(typeof(BoxModel), culture.TwoLetterISOLanguageName, 0, 10000, "", "BoxModelID,GT,2|BoxModelID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<BoxModel> boxModelDirectQueryList = new List<BoxModel>();
                        boxModelDirectQueryList = (from c in dbTestDB.BoxModels select c).Where(c => c.BoxModelID > 2 && c.BoxModelID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<BoxModel> boxModelList = new List<BoxModel>();
                            boxModelList = boxModelService.GetBoxModelList().ToList();
                            CheckBoxModelFields(boxModelList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<BoxModelWeb> boxModelWebList = new List<BoxModelWeb>();
                            boxModelWebList = boxModelService.GetBoxModelWebList().ToList();
                            CheckBoxModelWebFields(boxModelWebList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelWebList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<BoxModelReport> boxModelReportList = new List<BoxModelReport>();
                            boxModelReportList = boxModelService.GetBoxModelReportList().ToList();
                            CheckBoxModelReportFields(boxModelReportList);
                            Assert.AreEqual(boxModelDirectQueryList[0].BoxModelID, boxModelReportList[0].BoxModelID);
                            Assert.AreEqual(boxModelDirectQueryList.Count, boxModelReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelList() 2Where

        #region Functions private
        private void CheckBoxModelFields(List<BoxModel> boxModelList)
        {
            Assert.IsNotNull(boxModelList[0].BoxModelID);
            Assert.IsNotNull(boxModelList[0].InfrastructureTVItemID);
            Assert.IsNotNull(boxModelList[0].Flow_m3_day);
            Assert.IsNotNull(boxModelList[0].Depth_m);
            Assert.IsNotNull(boxModelList[0].Temperature_C);
            Assert.IsNotNull(boxModelList[0].Dilution);
            Assert.IsNotNull(boxModelList[0].DecayRate_per_day);
            Assert.IsNotNull(boxModelList[0].FCUntreated_MPN_100ml);
            Assert.IsNotNull(boxModelList[0].FCPreDisinfection_MPN_100ml);
            Assert.IsNotNull(boxModelList[0].Concentration_MPN_100ml);
            Assert.IsNotNull(boxModelList[0].T90_hour);
            Assert.IsNotNull(boxModelList[0].FlowDuration_hour);
            Assert.IsNotNull(boxModelList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(boxModelList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(boxModelList[0].HasErrors);
        }
        private void CheckBoxModelWebFields(List<BoxModelWeb> boxModelWebList)
        {
            Assert.IsNotNull(boxModelWebList[0].InfrastructureTVItemLanguage);
            Assert.IsNotNull(boxModelWebList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(boxModelWebList[0].BoxModelID);
            Assert.IsNotNull(boxModelWebList[0].InfrastructureTVItemID);
            Assert.IsNotNull(boxModelWebList[0].Flow_m3_day);
            Assert.IsNotNull(boxModelWebList[0].Depth_m);
            Assert.IsNotNull(boxModelWebList[0].Temperature_C);
            Assert.IsNotNull(boxModelWebList[0].Dilution);
            Assert.IsNotNull(boxModelWebList[0].DecayRate_per_day);
            Assert.IsNotNull(boxModelWebList[0].FCUntreated_MPN_100ml);
            Assert.IsNotNull(boxModelWebList[0].FCPreDisinfection_MPN_100ml);
            Assert.IsNotNull(boxModelWebList[0].Concentration_MPN_100ml);
            Assert.IsNotNull(boxModelWebList[0].T90_hour);
            Assert.IsNotNull(boxModelWebList[0].FlowDuration_hour);
            Assert.IsNotNull(boxModelWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(boxModelWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(boxModelWebList[0].HasErrors);
        }
        private void CheckBoxModelReportFields(List<BoxModelReport> boxModelReportList)
        {
            if (!string.IsNullOrWhiteSpace(boxModelReportList[0].BoxModelReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelReportList[0].BoxModelReportTest));
            }
            Assert.IsNotNull(boxModelReportList[0].InfrastructureTVItemLanguage);
            Assert.IsNotNull(boxModelReportList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(boxModelReportList[0].BoxModelID);
            Assert.IsNotNull(boxModelReportList[0].InfrastructureTVItemID);
            Assert.IsNotNull(boxModelReportList[0].Flow_m3_day);
            Assert.IsNotNull(boxModelReportList[0].Depth_m);
            Assert.IsNotNull(boxModelReportList[0].Temperature_C);
            Assert.IsNotNull(boxModelReportList[0].Dilution);
            Assert.IsNotNull(boxModelReportList[0].DecayRate_per_day);
            Assert.IsNotNull(boxModelReportList[0].FCUntreated_MPN_100ml);
            Assert.IsNotNull(boxModelReportList[0].FCPreDisinfection_MPN_100ml);
            Assert.IsNotNull(boxModelReportList[0].Concentration_MPN_100ml);
            Assert.IsNotNull(boxModelReportList[0].T90_hour);
            Assert.IsNotNull(boxModelReportList[0].FlowDuration_hour);
            Assert.IsNotNull(boxModelReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(boxModelReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(boxModelReportList[0].HasErrors);
        }
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
    }
}
