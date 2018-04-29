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

        #region Functions public
        #endregion Functions public

        #region Functions private
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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVItemLink_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemLinkService tvItemLinkService = new TVItemLinkService(new GetParam(), dbTestDB, ContactID);

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

                    count = tvItemLinkService.GetRead().Count();

                    Assert.AreEqual(tvItemLinkService.GetRead().Count(), tvItemLinkService.GetEdit().Count());

                    tvItemLinkService.Add(tvItemLink);
                    if (tvItemLink.HasErrors)
                    {
                        Assert.AreEqual("", tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvItemLinkService.GetRead().Where(c => c == tvItemLink).Any());
                    tvItemLinkService.Update(tvItemLink);
                    if (tvItemLink.HasErrors)
                    {
                        Assert.AreEqual("", tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvItemLinkService.GetRead().Count());
                    tvItemLinkService.Delete(tvItemLink);
                    if (tvItemLink.HasErrors)
                    {
                        Assert.AreEqual("", tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLinkTVItemLinkID), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVItemLinkID = 10000000;
                    tvItemLinkService.Update(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItemLink, CSSPModelsRes.TVItemLinkTVItemLinkID, tvItemLink.TVItemLinkID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint)]
                    // tvItemLink.FromTVItemID   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.FromTVItemID = 0;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemLinkFromTVItemID, tvItemLink.FromTVItemID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.FromTVItemID = 27;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLinkFromTVItemID, "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint)]
                    // tvItemLink.ToTVItemID   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.ToTVItemID = 0;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemLinkToTVItemID, tvItemLink.ToTVItemID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.ToTVItemID = 27;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLinkToTVItemID, "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItemLink.FromTVType   (TVTypeEnum)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.FromTVType = (TVTypeEnum)1000000;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLinkFromTVType), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItemLink.ToTVType   (TVTypeEnum)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.ToTVType = (TVTypeEnum)1000000;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLinkToTVType), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvItemLink.StartDateTime_Local   (DateTime)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.StartDateTime_Local = new DateTime(1979, 1, 1);
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVItemLinkStartDateTime_Local, "1980"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVItemLinkEndDateTime_Local, "1980"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // tvItemLink.Ordinal   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.Ordinal = -1;
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemLinkOrdinal, "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.Ordinal = 101;
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemLinkOrdinal, "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // tvItemLink.TVLevel   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVLevel = -1;
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemLinkTVLevel, "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVLevel = 101;
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemLinkTVLevel, "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // tvItemLink.TVPath   (String)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("TVPath");
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(1, tvItemLink.ValidationResults.Count());
                    Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLinkTVPath)).Any());
                    Assert.AreEqual(null, tvItemLink.TVPath);
                    Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVPath = GetRandomString("", 251);
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVItemLinkTVPath, "250"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItemLink", ExistPlurial = "s", ExistFieldID = "TVItemLinkID", AllowableTVtypeList = Error)]
                    // tvItemLink.ParentTVItemLinkID   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.ParentTVItemLinkID = 0;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItemLink, CSSPModelsRes.TVItemLinkParentTVItemLinkID, tvItemLink.ParentTVItemLinkID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvItemLink.TVItemLinkWeb   (TVItemLinkWeb)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVItemLinkWeb = null;
                    Assert.IsNull(tvItemLink.TVItemLinkWeb);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVItemLinkWeb = new TVItemLinkWeb();
                    Assert.IsNotNull(tvItemLink.TVItemLinkWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvItemLink.TVItemLinkReport   (TVItemLinkReport)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVItemLinkReport = null;
                    Assert.IsNull(tvItemLink.TVItemLinkReport);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVItemLinkReport = new TVItemLinkReport();
                    Assert.IsNotNull(tvItemLink.TVItemLinkReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvItemLink.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.LastUpdateDate_UTC = new DateTime();
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLinkLastUpdateDate_UTC), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVItemLinkLastUpdateDate_UTC, "1980"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvItemLink.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.LastUpdateContactTVItemID = 0;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemLinkLastUpdateContactTVItemID, tvItemLink.LastUpdateContactTVItemID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.LastUpdateContactTVItemID = 1;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLinkLastUpdateContactTVItemID, "Contact"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


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

        #region Tests Generated Get With Key
        [TestMethod]
        public void TVItemLink_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    TVItemLinkService tvItemLinkService = new TVItemLinkService(new GetParam(), dbTestDB, ContactID);
                    TVItemLink tvItemLink = (from c in tvItemLinkService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemLink);

                    TVItemLink tvItemLinkRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLinkRet = tvItemLinkService.GetTVItemLinkWithTVItemLinkID(tvItemLink.TVItemLinkID, getParam);
                            Assert.IsNull(tvItemLinkRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLinkRet = tvItemLinkService.GetTVItemLinkWithTVItemLinkID(tvItemLink.TVItemLinkID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLinkRet = tvItemLinkService.GetTVItemLinkWithTVItemLinkID(tvItemLink.TVItemLinkID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLinkRet = tvItemLinkService.GetTVItemLinkWithTVItemLinkID(tvItemLink.TVItemLinkID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // TVItemLink fields
                        Assert.IsNotNull(tvItemLinkRet.TVItemLinkID);
                        Assert.IsNotNull(tvItemLinkRet.FromTVItemID);
                        Assert.IsNotNull(tvItemLinkRet.ToTVItemID);
                        Assert.IsNotNull(tvItemLinkRet.FromTVType);
                        Assert.IsNotNull(tvItemLinkRet.ToTVType);
                        if (tvItemLinkRet.StartDateTime_Local != null)
                        {
                            Assert.IsNotNull(tvItemLinkRet.StartDateTime_Local);
                        }
                        if (tvItemLinkRet.EndDateTime_Local != null)
                        {
                            Assert.IsNotNull(tvItemLinkRet.EndDateTime_Local);
                        }
                        Assert.IsNotNull(tvItemLinkRet.Ordinal);
                        Assert.IsNotNull(tvItemLinkRet.TVLevel);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.TVPath));
                        if (tvItemLinkRet.ParentTVItemLinkID != null)
                        {
                            Assert.IsNotNull(tvItemLinkRet.ParentTVItemLinkID);
                        }
                        Assert.IsNotNull(tvItemLinkRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(tvItemLinkRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // TVItemLinkWeb and TVItemLinkReport fields should be null here
                            Assert.IsNull(tvItemLinkRet.TVItemLinkWeb);
                            Assert.IsNull(tvItemLinkRet.TVItemLinkReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // TVItemLinkWeb fields should not be null and TVItemLinkReport fields should be null here
                            if (tvItemLinkRet.TVItemLinkWeb.FromTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.TVItemLinkWeb.FromTVText));
                            }
                            if (tvItemLinkRet.TVItemLinkWeb.ToTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.TVItemLinkWeb.ToTVText));
                            }
                            if (tvItemLinkRet.TVItemLinkWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.TVItemLinkWeb.LastUpdateContactTVText));
                            }
                            if (tvItemLinkRet.TVItemLinkWeb.FromTVTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.TVItemLinkWeb.FromTVTypeText));
                            }
                            if (tvItemLinkRet.TVItemLinkWeb.ToTVTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.TVItemLinkWeb.ToTVTypeText));
                            }
                            Assert.IsNull(tvItemLinkRet.TVItemLinkReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // TVItemLinkWeb and TVItemLinkReport fields should NOT be null here
                            if (tvItemLinkRet.TVItemLinkWeb.FromTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.TVItemLinkWeb.FromTVText));
                            }
                            if (tvItemLinkRet.TVItemLinkWeb.ToTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.TVItemLinkWeb.ToTVText));
                            }
                            if (tvItemLinkRet.TVItemLinkWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.TVItemLinkWeb.LastUpdateContactTVText));
                            }
                            if (tvItemLinkRet.TVItemLinkWeb.FromTVTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.TVItemLinkWeb.FromTVTypeText));
                            }
                            if (tvItemLinkRet.TVItemLinkWeb.ToTVTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.TVItemLinkWeb.ToTVTypeText));
                            }
                            if (tvItemLinkRet.TVItemLinkReport.TVItemLinkReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.TVItemLinkReport.TVItemLinkReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of TVItemLink
        #endregion Tests Get List of TVItemLink

    }
}
