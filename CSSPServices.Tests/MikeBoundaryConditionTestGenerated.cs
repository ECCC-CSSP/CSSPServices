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

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class MikeBoundaryConditionTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MikeBoundaryConditionService mikeBoundaryConditionService { get; set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionTest() : base()
        {
            mikeBoundaryConditionService = new MikeBoundaryConditionService(LanguageRequest, dbTestDB, ContactID);
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

        #region Tests Generated
        [TestMethod]
        public void MikeBoundaryCondition_Testing()
        {

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

            mikeBoundaryConditionService.Add(mikeBoundaryCondition);
            if (mikeBoundaryCondition.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, mikeBoundaryConditionService.GetRead().Where(c => c == mikeBoundaryCondition).Any());
            mikeBoundaryConditionService.Update(mikeBoundaryCondition);
            if (mikeBoundaryCondition.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, mikeBoundaryConditionService.GetRead().Count());
            mikeBoundaryConditionService.Delete(mikeBoundaryCondition);
            if (mikeBoundaryCondition.ValidationResults.Count() > 0)
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
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionID), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.MikeBoundaryConditionMesh", OrTVType = "MikeBoundaryConditionWebTide")]
            // mikeBoundaryCondition.MikeBoundaryConditionTVItemID   (Int32)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 0;
            mikeBoundaryConditionService.Add(mikeBoundaryCondition);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVItemID, mikeBoundaryCondition.MikeBoundaryConditionTVItemID.ToString()), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);

            // MikeBoundaryConditionTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(100))]
            // mikeBoundaryCondition.MikeBoundaryConditionCode   (String)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("MikeBoundaryConditionCode");
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode)).Any());
            Assert.AreEqual(null, mikeBoundaryCondition.MikeBoundaryConditionCode);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            // MikeBoundaryConditionCode has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string mikeBoundaryConditionMikeBoundaryConditionCodeMin = GetRandomString("", 100);
            mikeBoundaryCondition.MikeBoundaryConditionCode = mikeBoundaryConditionMikeBoundaryConditionCodeMin;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionCodeMin, mikeBoundaryCondition.MikeBoundaryConditionCode);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

            // MikeBoundaryConditionCode has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            mikeBoundaryConditionMikeBoundaryConditionCodeMin = GetRandomString("", 99);
            mikeBoundaryCondition.MikeBoundaryConditionCode = mikeBoundaryConditionMikeBoundaryConditionCodeMin;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionCodeMin, mikeBoundaryCondition.MikeBoundaryConditionCode);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

            // MikeBoundaryConditionCode has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            mikeBoundaryConditionMikeBoundaryConditionCodeMin = GetRandomString("", 101);
            mikeBoundaryCondition.MikeBoundaryConditionCode = mikeBoundaryConditionMikeBoundaryConditionCodeMin;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode, "100")).Any());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionCodeMin, mikeBoundaryCondition.MikeBoundaryConditionCode);
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
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionName)).Any());
            Assert.AreEqual(null, mikeBoundaryCondition.MikeBoundaryConditionName);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            // MikeBoundaryConditionName has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string mikeBoundaryConditionMikeBoundaryConditionNameMin = GetRandomString("", 100);
            mikeBoundaryCondition.MikeBoundaryConditionName = mikeBoundaryConditionMikeBoundaryConditionNameMin;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionNameMin, mikeBoundaryCondition.MikeBoundaryConditionName);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

            // MikeBoundaryConditionName has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            mikeBoundaryConditionMikeBoundaryConditionNameMin = GetRandomString("", 99);
            mikeBoundaryCondition.MikeBoundaryConditionName = mikeBoundaryConditionMikeBoundaryConditionNameMin;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionNameMin, mikeBoundaryCondition.MikeBoundaryConditionName);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

            // MikeBoundaryConditionName has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            mikeBoundaryConditionMikeBoundaryConditionNameMin = GetRandomString("", 101);
            mikeBoundaryCondition.MikeBoundaryConditionName = mikeBoundaryConditionMikeBoundaryConditionNameMin;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionName, "100")).Any());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionNameMin, mikeBoundaryCondition.MikeBoundaryConditionName);
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(1, 100000)]
            // mikeBoundaryCondition.MikeBoundaryConditionLength_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [MikeBoundaryConditionLength_m]

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            // MikeBoundaryConditionLength_m has Min [1.0D] and Max [100000.0D]. At Min should return true and no errors
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = 1.0D;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(1.0D, mikeBoundaryCondition.MikeBoundaryConditionLength_m);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());
            // MikeBoundaryConditionLength_m has Min [1.0D] and Max [100000.0D]. At Min + 1 should return true and no errors
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = 2.0D;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(2.0D, mikeBoundaryCondition.MikeBoundaryConditionLength_m);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());
            // MikeBoundaryConditionLength_m has Min [1.0D] and Max [100000.0D]. At Min - 1 should return false with one error
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = 0.0D;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionLength_m, "1", "100000")).Any());
            Assert.AreEqual(0.0D, mikeBoundaryCondition.MikeBoundaryConditionLength_m);
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());
            // MikeBoundaryConditionLength_m has Min [1.0D] and Max [100000.0D]. At Max should return true and no errors
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = 100000.0D;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(100000.0D, mikeBoundaryCondition.MikeBoundaryConditionLength_m);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());
            // MikeBoundaryConditionLength_m has Min [1.0D] and Max [100000.0D]. At Max - 1 should return true and no errors
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = 99999.0D;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(99999.0D, mikeBoundaryCondition.MikeBoundaryConditionLength_m);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());
            // MikeBoundaryConditionLength_m has Min [1.0D] and Max [100000.0D]. At Max + 1 should return false with one error
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = 100001.0D;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionLength_m, "1", "100000")).Any());
            Assert.AreEqual(100001.0D, mikeBoundaryCondition.MikeBoundaryConditionLength_m);
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
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat)).Any());
            Assert.AreEqual(null, mikeBoundaryCondition.MikeBoundaryConditionFormat);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            // MikeBoundaryConditionFormat has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string mikeBoundaryConditionMikeBoundaryConditionFormatMin = GetRandomString("", 100);
            mikeBoundaryCondition.MikeBoundaryConditionFormat = mikeBoundaryConditionMikeBoundaryConditionFormatMin;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionFormatMin, mikeBoundaryCondition.MikeBoundaryConditionFormat);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

            // MikeBoundaryConditionFormat has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            mikeBoundaryConditionMikeBoundaryConditionFormatMin = GetRandomString("", 99);
            mikeBoundaryCondition.MikeBoundaryConditionFormat = mikeBoundaryConditionMikeBoundaryConditionFormatMin;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionFormatMin, mikeBoundaryCondition.MikeBoundaryConditionFormat);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

            // MikeBoundaryConditionFormat has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            mikeBoundaryConditionMikeBoundaryConditionFormatMin = GetRandomString("", 101);
            mikeBoundaryCondition.MikeBoundaryConditionFormat = mikeBoundaryConditionMikeBoundaryConditionFormatMin;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat, "100")).Any());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionFormatMin, mikeBoundaryCondition.MikeBoundaryConditionFormat);
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity   (MikeBoundaryConditionLevelOrVelocityEnum)
            // -----------------------------------

            // MikeBoundaryConditionLevelOrVelocity will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mikeBoundaryCondition.WebTideDataSet   (WebTideDataSetEnum)
            // -----------------------------------

            // WebTideDataSet will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000)]
            // mikeBoundaryCondition.NumberOfWebTideNodes   (Int32)
            // -----------------------------------

            // NumberOfWebTideNodes will automatically be initialized at 0 --> not null

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            // NumberOfWebTideNodes has Min [0] and Max [1000]. At Min should return true and no errors
            mikeBoundaryCondition.NumberOfWebTideNodes = 0;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(0, mikeBoundaryCondition.NumberOfWebTideNodes);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());
            // NumberOfWebTideNodes has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mikeBoundaryCondition.NumberOfWebTideNodes = 1;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(1, mikeBoundaryCondition.NumberOfWebTideNodes);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());
            // NumberOfWebTideNodes has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mikeBoundaryCondition.NumberOfWebTideNodes = -1;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionNumberOfWebTideNodes, "0", "1000")).Any());
            Assert.AreEqual(-1, mikeBoundaryCondition.NumberOfWebTideNodes);
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());
            // NumberOfWebTideNodes has Min [0] and Max [1000]. At Max should return true and no errors
            mikeBoundaryCondition.NumberOfWebTideNodes = 1000;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(1000, mikeBoundaryCondition.NumberOfWebTideNodes);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());
            // NumberOfWebTideNodes has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mikeBoundaryCondition.NumberOfWebTideNodes = 999;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(999, mikeBoundaryCondition.NumberOfWebTideNodes);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());
            // NumberOfWebTideNodes has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mikeBoundaryCondition.NumberOfWebTideNodes = 1001;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionNumberOfWebTideNodes, "0", "1000")).Any());
            Assert.AreEqual(1001, mikeBoundaryCondition.NumberOfWebTideNodes);
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // mikeBoundaryCondition.WebTideDataFromStartToEndDate   (String)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("WebTideDataFromStartToEndDate");
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionWebTideDataFromStartToEndDate)).Any());
            Assert.AreEqual(null, mikeBoundaryCondition.WebTideDataFromStartToEndDate);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mikeBoundaryCondition.TVType   (TVTypeEnum)
            // -----------------------------------

            // TVType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mikeBoundaryCondition.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // mikeBoundaryCondition.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.LastUpdateContactTVItemID = 0;
            mikeBoundaryConditionService.Add(mikeBoundaryCondition);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeBoundaryConditionLastUpdateContactTVItemID, mikeBoundaryCondition.LastUpdateContactTVItemID.ToString()), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // mikeBoundaryCondition.MikeBoundaryConditionTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // mikeBoundaryCondition.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
