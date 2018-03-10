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
    public partial class MikeBoundaryConditionServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MikeBoundaryConditionService mikeBoundaryConditionService { get; set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionServiceTest() : base()
        {
            //mikeBoundaryConditionService = new MikeBoundaryConditionService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MikeBoundaryCondition GetFilledRandomMikeBoundaryCondition(string OmitPropName)
        {
            MikeBoundaryCondition mikeBoundaryCondition = new MikeBoundaryCondition();

            if (OmitPropName != "MikeBoundaryConditionTVItemID") mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 26;
            if (OmitPropName != "MikeBoundaryConditionCode") mikeBoundaryCondition.MikeBoundaryConditionCode = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionName") mikeBoundaryCondition.MikeBoundaryConditionName = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionLength_m") mikeBoundaryCondition.MikeBoundaryConditionLength_m = GetRandomDouble(1.0D, 100000.0D);
            if (OmitPropName != "MikeBoundaryConditionFormat") mikeBoundaryCondition.MikeBoundaryConditionFormat = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionLevelOrVelocity") mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity = (MikeBoundaryConditionLevelOrVelocityEnum)GetRandomEnumType(typeof(MikeBoundaryConditionLevelOrVelocityEnum));
            if (OmitPropName != "WebTideDataSet") mikeBoundaryCondition.WebTideDataSet = (WebTideDataSetEnum)GetRandomEnumType(typeof(WebTideDataSetEnum));
            if (OmitPropName != "NumberOfWebTideNodes") mikeBoundaryCondition.NumberOfWebTideNodes = GetRandomInt(0, 1000);
            if (OmitPropName != "WebTideDataFromStartToEndDate") mikeBoundaryCondition.WebTideDataFromStartToEndDate = GetRandomString("", 20);
            if (OmitPropName != "TVType") mikeBoundaryCondition.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mikeBoundaryCondition.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeBoundaryCondition.LastUpdateContactTVItemID = 2;

            return mikeBoundaryCondition;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MikeBoundaryCondition_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MikeBoundaryCondition mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mikeBoundaryConditionService.GetRead().Count();

                    Assert.AreEqual(mikeBoundaryConditionService.GetRead().Count(), mikeBoundaryConditionService.GetEdit().Count());

                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    if (mikeBoundaryCondition.HasErrors)
                    {
                        Assert.AreEqual("", mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mikeBoundaryConditionService.GetRead().Where(c => c == mikeBoundaryCondition).Any());
                    mikeBoundaryConditionService.Update(mikeBoundaryCondition);
                    if (mikeBoundaryCondition.HasErrors)
                    {
                        Assert.AreEqual("", mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mikeBoundaryConditionService.GetRead().Count());
                    mikeBoundaryConditionService.Delete(mikeBoundaryCondition);
                    if (mikeBoundaryCondition.HasErrors)
                    {
                        Assert.AreEqual("", mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mikeBoundaryCondition.MikeBoundaryConditionID   (Int32)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionID = 0;
                    mikeBoundaryConditionService.Update(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionID), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionID = 10000000;
                    mikeBoundaryConditionService.Update(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MikeBoundaryCondition, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionID, mikeBoundaryCondition.MikeBoundaryConditionID.ToString()), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide)]
                    // mikeBoundaryCondition.MikeBoundaryConditionTVItemID   (Int32)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 0;
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVItemID, mikeBoundaryCondition.MikeBoundaryConditionTVItemID.ToString()), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 1;
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVItemID, "MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // mikeBoundaryCondition.MikeBoundaryConditionCode   (String)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("MikeBoundaryConditionCode");
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
                    Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode)).Any());
                    Assert.AreEqual(null, mikeBoundaryCondition.MikeBoundaryConditionCode);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionCode = GetRandomString("", 101);
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode, "100"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // mikeBoundaryCondition.MikeBoundaryConditionName   (String)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("MikeBoundaryConditionName");
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
                    Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionName)).Any());
                    Assert.AreEqual(null, mikeBoundaryCondition.MikeBoundaryConditionName);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionName = GetRandomString("", 101);
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionName, "100"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 100000)]
                    // mikeBoundaryCondition.MikeBoundaryConditionLength_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [MikeBoundaryConditionLength_m]

                    //Error: Type not implemented [MikeBoundaryConditionLength_m]

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionLength_m = 0.0D;
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionLength_m, "1", "100000"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());
                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionLength_m = 100001.0D;
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionLength_m, "1", "100000"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // mikeBoundaryCondition.MikeBoundaryConditionFormat   (String)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("MikeBoundaryConditionFormat");
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
                    Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat)).Any());
                    Assert.AreEqual(null, mikeBoundaryCondition.MikeBoundaryConditionFormat);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionFormat = GetRandomString("", 101);
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat, "100"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity   (MikeBoundaryConditionLevelOrVelocityEnum)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity = (MikeBoundaryConditionLevelOrVelocityEnum)1000000;
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocity), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mikeBoundaryCondition.WebTideDataSet   (WebTideDataSetEnum)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.WebTideDataSet = (WebTideDataSetEnum)1000000;
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionWebTideDataSet), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // mikeBoundaryCondition.NumberOfWebTideNodes   (Int32)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.NumberOfWebTideNodes = -1;
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeBoundaryConditionNumberOfWebTideNodes, "0", "1000"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());
                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.NumberOfWebTideNodes = 1001;
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeBoundaryConditionNumberOfWebTideNodes, "0", "1000"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // mikeBoundaryCondition.WebTideDataFromStartToEndDate   (String)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("WebTideDataFromStartToEndDate");
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
                    Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionWebTideDataFromStartToEndDate)).Any());
                    Assert.AreEqual(null, mikeBoundaryCondition.WebTideDataFromStartToEndDate);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mikeBoundaryCondition.TVType   (TVTypeEnum)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.TVType = (TVTypeEnum)1000000;
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionTVType), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mikeBoundaryCondition.MikeBoundaryConditionWeb   (MikeBoundaryConditionWeb)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionWeb = null;
                    Assert.IsNull(mikeBoundaryCondition.MikeBoundaryConditionWeb);

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionWeb = new MikeBoundaryConditionWeb();
                    Assert.IsNotNull(mikeBoundaryCondition.MikeBoundaryConditionWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mikeBoundaryCondition.MikeBoundaryConditionReport   (MikeBoundaryConditionReport)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionReport = null;
                    Assert.IsNull(mikeBoundaryCondition.MikeBoundaryConditionReport);

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionReport = new MikeBoundaryConditionReport();
                    Assert.IsNotNull(mikeBoundaryCondition.MikeBoundaryConditionReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeBoundaryCondition.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.LastUpdateDate_UTC = new DateTime();
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionLastUpdateDate_UTC), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MikeBoundaryConditionLastUpdateDate_UTC, "1980"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mikeBoundaryCondition.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.LastUpdateContactTVItemID = 0;
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MikeBoundaryConditionLastUpdateContactTVItemID, mikeBoundaryCondition.LastUpdateContactTVItemID.ToString()), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.LastUpdateContactTVItemID = 1;
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MikeBoundaryConditionLastUpdateContactTVItemID, "Contact"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeBoundaryCondition.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeBoundaryCondition.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void MikeBoundaryCondition_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new GetParam(), dbTestDB, ContactID);
                    MikeBoundaryCondition mikeBoundaryCondition = (from c in mikeBoundaryConditionService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mikeBoundaryCondition);

                    MikeBoundaryCondition mikeBoundaryConditionRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            mikeBoundaryConditionRet = mikeBoundaryConditionService.GetMikeBoundaryConditionWithMikeBoundaryConditionID(mikeBoundaryCondition.MikeBoundaryConditionID, getParam);
                            Assert.IsNull(mikeBoundaryConditionRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mikeBoundaryConditionRet = mikeBoundaryConditionService.GetMikeBoundaryConditionWithMikeBoundaryConditionID(mikeBoundaryCondition.MikeBoundaryConditionID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mikeBoundaryConditionRet = mikeBoundaryConditionService.GetMikeBoundaryConditionWithMikeBoundaryConditionID(mikeBoundaryCondition.MikeBoundaryConditionID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mikeBoundaryConditionRet = mikeBoundaryConditionService.GetMikeBoundaryConditionWithMikeBoundaryConditionID(mikeBoundaryCondition.MikeBoundaryConditionID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // MikeBoundaryCondition fields
                        Assert.IsNotNull(mikeBoundaryConditionRet.MikeBoundaryConditionID);
                        Assert.IsNotNull(mikeBoundaryConditionRet.MikeBoundaryConditionTVItemID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.MikeBoundaryConditionCode));
                        Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.MikeBoundaryConditionName));
                        Assert.IsNotNull(mikeBoundaryConditionRet.MikeBoundaryConditionLength_m);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.MikeBoundaryConditionFormat));
                        Assert.IsNotNull(mikeBoundaryConditionRet.MikeBoundaryConditionLevelOrVelocity);
                        Assert.IsNotNull(mikeBoundaryConditionRet.WebTideDataSet);
                        Assert.IsNotNull(mikeBoundaryConditionRet.NumberOfWebTideNodes);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.WebTideDataFromStartToEndDate));
                        Assert.IsNotNull(mikeBoundaryConditionRet.TVType);
                        Assert.IsNotNull(mikeBoundaryConditionRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(mikeBoundaryConditionRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // MikeBoundaryConditionWeb and MikeBoundaryConditionReport fields should be null here
                            Assert.IsNull(mikeBoundaryConditionRet.MikeBoundaryConditionWeb);
                            Assert.IsNull(mikeBoundaryConditionRet.MikeBoundaryConditionReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // MikeBoundaryConditionWeb fields should not be null and MikeBoundaryConditionReport fields should be null here
                            if (mikeBoundaryConditionRet.MikeBoundaryConditionWeb.MikeBoundaryConditionTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.MikeBoundaryConditionWeb.MikeBoundaryConditionTVText));
                            }
                            if (mikeBoundaryConditionRet.MikeBoundaryConditionWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.MikeBoundaryConditionWeb.LastUpdateContactTVText));
                            }
                            if (mikeBoundaryConditionRet.MikeBoundaryConditionWeb.MikeBoundaryConditionLevelOrVelocityText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.MikeBoundaryConditionWeb.MikeBoundaryConditionLevelOrVelocityText));
                            }
                            if (mikeBoundaryConditionRet.MikeBoundaryConditionWeb.WebTideDataSetText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.MikeBoundaryConditionWeb.WebTideDataSetText));
                            }
                            if (mikeBoundaryConditionRet.MikeBoundaryConditionWeb.TVTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.MikeBoundaryConditionWeb.TVTypeText));
                            }
                            Assert.IsNull(mikeBoundaryConditionRet.MikeBoundaryConditionReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // MikeBoundaryConditionWeb and MikeBoundaryConditionReport fields should NOT be null here
                            if (mikeBoundaryConditionRet.MikeBoundaryConditionWeb.MikeBoundaryConditionTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.MikeBoundaryConditionWeb.MikeBoundaryConditionTVText));
                            }
                            if (mikeBoundaryConditionRet.MikeBoundaryConditionWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.MikeBoundaryConditionWeb.LastUpdateContactTVText));
                            }
                            if (mikeBoundaryConditionRet.MikeBoundaryConditionWeb.MikeBoundaryConditionLevelOrVelocityText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.MikeBoundaryConditionWeb.MikeBoundaryConditionLevelOrVelocityText));
                            }
                            if (mikeBoundaryConditionRet.MikeBoundaryConditionWeb.WebTideDataSetText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.MikeBoundaryConditionWeb.WebTideDataSetText));
                            }
                            if (mikeBoundaryConditionRet.MikeBoundaryConditionWeb.TVTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.MikeBoundaryConditionWeb.TVTypeText));
                            }
                            if (mikeBoundaryConditionRet.MikeBoundaryConditionReport.MikeBoundaryConditionReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.MikeBoundaryConditionReport.MikeBoundaryConditionReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of MikeBoundaryCondition
        #endregion Tests Get List of MikeBoundaryCondition

    }
}
