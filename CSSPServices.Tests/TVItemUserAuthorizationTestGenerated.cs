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
    public partial class TVItemUserAuthorizationTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVItemUserAuthorizationService tvItemUserAuthorizationService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationTest() : base()
        {
            tvItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemUserAuthorization GetFilledRandomTVItemUserAuthorization(string OmitPropName)
        {
            TVItemUserAuthorization tvItemUserAuthorization = new TVItemUserAuthorization();

            if (OmitPropName != "ContactTVItemID") tvItemUserAuthorization.ContactTVItemID = 2;
            if (OmitPropName != "TVItemID1") tvItemUserAuthorization.TVItemID1 = 2;
            if (OmitPropName != "TVItemID2") tvItemUserAuthorization.TVItemID2 = 2;
            if (OmitPropName != "TVItemID3") tvItemUserAuthorization.TVItemID3 = 2;
            if (OmitPropName != "TVItemID4") tvItemUserAuthorization.TVItemID4 = 2;
            if (OmitPropName != "TVAuth") tvItemUserAuthorization.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvItemUserAuthorization.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemUserAuthorization.LastUpdateContactTVItemID = 2;

            return tvItemUserAuthorization;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItemUserAuthorization_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            TVItemUserAuthorization tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = tvItemUserAuthorizationService.GetRead().Count();

            tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
            if (tvItemUserAuthorization.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, tvItemUserAuthorizationService.GetRead().Where(c => c == tvItemUserAuthorization).Any());
            tvItemUserAuthorizationService.Update(tvItemUserAuthorization);
            if (tvItemUserAuthorization.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, tvItemUserAuthorizationService.GetRead().Count());
            tvItemUserAuthorizationService.Delete(tvItemUserAuthorization);
            if (tvItemUserAuthorization.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tvItemUserAuthorization.TVItemUserAuthorizationID   (Int32)
            // -----------------------------------

            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemUserAuthorizationID = 0;
            tvItemUserAuthorizationService.Update(tvItemUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationTVItemUserAuthorizationID), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // tvItemUserAuthorization.ContactTVItemID   (Int32)
            // -----------------------------------

            // ContactTVItemID will automatically be initialized at 0 --> not null


            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            // ContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemUserAuthorization.ContactTVItemID = 1;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvItemUserAuthorization.ContactTVItemID);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());
            // ContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemUserAuthorization.ContactTVItemID = 2;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvItemUserAuthorization.ContactTVItemID);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());
            // ContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemUserAuthorization.ContactTVItemID = 0;
            Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.IsTrue(tvItemUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemUserAuthorization.ContactTVItemID);
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // [Range(1, -1)]
            // tvItemUserAuthorization.TVItemID1   (Int32)
            // -----------------------------------

            // TVItemID1 will automatically be initialized at 0 --> not null


            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            // TVItemID1 has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemUserAuthorization.TVItemID1 = 1;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvItemUserAuthorization.TVItemID1);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID1 has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemUserAuthorization.TVItemID1 = 2;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvItemUserAuthorization.TVItemID1);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID1 has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemUserAuthorization.TVItemID1 = 0;
            Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.IsTrue(tvItemUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID1, "1")).Any());
            Assert.AreEqual(0, tvItemUserAuthorization.TVItemID1);
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // [Range(1, -1)]
            // tvItemUserAuthorization.TVItemID2   (Int32)
            // -----------------------------------


            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            // TVItemID2 has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemUserAuthorization.TVItemID2 = 1;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvItemUserAuthorization.TVItemID2);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID2 has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemUserAuthorization.TVItemID2 = 2;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvItemUserAuthorization.TVItemID2);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID2 has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemUserAuthorization.TVItemID2 = 0;
            Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.IsTrue(tvItemUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID2, "1")).Any());
            Assert.AreEqual(0, tvItemUserAuthorization.TVItemID2);
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // [Range(1, -1)]
            // tvItemUserAuthorization.TVItemID3   (Int32)
            // -----------------------------------


            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            // TVItemID3 has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemUserAuthorization.TVItemID3 = 1;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvItemUserAuthorization.TVItemID3);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID3 has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemUserAuthorization.TVItemID3 = 2;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvItemUserAuthorization.TVItemID3);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID3 has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemUserAuthorization.TVItemID3 = 0;
            Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.IsTrue(tvItemUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID3, "1")).Any());
            Assert.AreEqual(0, tvItemUserAuthorization.TVItemID3);
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // [Range(1, -1)]
            // tvItemUserAuthorization.TVItemID4   (Int32)
            // -----------------------------------


            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            // TVItemID4 has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemUserAuthorization.TVItemID4 = 1;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvItemUserAuthorization.TVItemID4);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID4 has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemUserAuthorization.TVItemID4 = 2;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvItemUserAuthorization.TVItemID4);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID4 has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemUserAuthorization.TVItemID4 = 0;
            Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.IsTrue(tvItemUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID4, "1")).Any());
            Assert.AreEqual(0, tvItemUserAuthorization.TVItemID4);
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItemUserAuthorization.TVAuth   (TVAuthEnum)
            // -----------------------------------

            // TVAuth will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvItemUserAuthorization.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // tvItemUserAuthorization.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemUserAuthorization.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvItemUserAuthorization.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemUserAuthorization.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvItemUserAuthorization.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemUserAuthorization.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.IsTrue(tvItemUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemUserAuthorization.LastUpdateContactTVItemID);
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItemUserAuthorization.ContactTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // tvItemUserAuthorization.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
