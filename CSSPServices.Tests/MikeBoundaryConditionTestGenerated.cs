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

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 1;
            mikeBoundaryConditionService.Add(mikeBoundaryCondition);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVItemID, "MikeBoundaryConditionMesh"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


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
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionCode = GetRandomString("", 101);
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode, "100"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
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
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionName = GetRandomString("", 101);
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionName, "100"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(1, 100000)]
            // mikeBoundaryCondition.MikeBoundaryConditionLength_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [MikeBoundaryConditionLength_m]

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = 0.0D;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionLength_m, "1", "100000"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());
            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = 100001.0D;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionLength_m, "1", "100000"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
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
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionFormat = GetRandomString("", 101);
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat, "100"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
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
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocity), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mikeBoundaryCondition.WebTideDataSet   (WebTideDataSetEnum)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.WebTideDataSet = (WebTideDataSetEnum)1000000;
            mikeBoundaryConditionService.Add(mikeBoundaryCondition);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionWebTideDataSet), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000)]
            // mikeBoundaryCondition.NumberOfWebTideNodes   (Int32)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.NumberOfWebTideNodes = -1;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionNumberOfWebTideNodes, "0", "1000"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, mikeBoundaryConditionService.GetRead().Count());
            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.NumberOfWebTideNodes = 1001;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionNumberOfWebTideNodes, "0", "1000"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
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
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionTVType), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mikeBoundaryCondition.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


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

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.LastUpdateContactTVItemID = 1;
            mikeBoundaryConditionService.Add(mikeBoundaryCondition);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MikeBoundaryConditionLastUpdateContactTVItemID, "Contact"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


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
