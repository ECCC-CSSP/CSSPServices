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
    public partial class TVTypeUserAuthorizationTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVTypeUserAuthorizationService tvTypeUserAuthorizationService { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationTest() : base()
        {
            tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVTypeUserAuthorization GetFilledRandomTVTypeUserAuthorization(string OmitPropName)
        {
            TVTypeUserAuthorization tvTypeUserAuthorization = new TVTypeUserAuthorization();

            if (OmitPropName != "ContactTVItemID") tvTypeUserAuthorization.ContactTVItemID = 2;
            if (OmitPropName != "TVType") tvTypeUserAuthorization.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "TVAuth") tvTypeUserAuthorization.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvTypeUserAuthorization.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tvTypeUserAuthorization.LastUpdateContactTVItemID = 2;

            return tvTypeUserAuthorization;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVTypeUserAuthorization_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            TVTypeUserAuthorization tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = tvTypeUserAuthorizationService.GetRead().Count();

            tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
            if (tvTypeUserAuthorization.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, tvTypeUserAuthorizationService.GetRead().Where(c => c == tvTypeUserAuthorization).Any());
            tvTypeUserAuthorizationService.Update(tvTypeUserAuthorization);
            if (tvTypeUserAuthorization.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, tvTypeUserAuthorizationService.GetRead().Count());
            tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization);
            if (tvTypeUserAuthorization.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, tvTypeUserAuthorizationService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // tvTypeUserAuthorization.TVTypeUserAuthorizationID   (Int32)
            //-----------------------------------
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.TVTypeUserAuthorizationID = 0;
            tvTypeUserAuthorizationService.Update(tvTypeUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVTypeUserAuthorizationTVTypeUserAuthorizationID), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // tvTypeUserAuthorization.ContactTVItemID   (Int32)
            //-----------------------------------
            // ContactTVItemID will automatically be initialized at 0 --> not null


            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            // ContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvTypeUserAuthorization.ContactTVItemID = 1;
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization));
            Assert.AreEqual(0, tvTypeUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvTypeUserAuthorization.ContactTVItemID);
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization));
            Assert.AreEqual(count, tvTypeUserAuthorizationService.GetRead().Count());
            // ContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvTypeUserAuthorization.ContactTVItemID = 2;
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization));
            Assert.AreEqual(0, tvTypeUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvTypeUserAuthorization.ContactTVItemID);
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization));
            Assert.AreEqual(count, tvTypeUserAuthorizationService.GetRead().Count());
            // ContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvTypeUserAuthorization.ContactTVItemID = 0;
            Assert.AreEqual(false, tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization));
            Assert.IsTrue(tvTypeUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVTypeUserAuthorizationContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvTypeUserAuthorization.ContactTVItemID);
            Assert.AreEqual(count, tvTypeUserAuthorizationService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // tvTypeUserAuthorization.TVType   (TVTypeEnum)
            //-----------------------------------
            // TVType will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // tvTypeUserAuthorization.TVAuth   (TVAuthEnum)
            //-----------------------------------
            // TVAuth will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // tvTypeUserAuthorization.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // tvTypeUserAuthorization.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvTypeUserAuthorization.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization));
            Assert.AreEqual(0, tvTypeUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvTypeUserAuthorization.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization));
            Assert.AreEqual(count, tvTypeUserAuthorizationService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvTypeUserAuthorization.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization));
            Assert.AreEqual(0, tvTypeUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvTypeUserAuthorization.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization));
            Assert.AreEqual(count, tvTypeUserAuthorizationService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvTypeUserAuthorization.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization));
            Assert.IsTrue(tvTypeUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvTypeUserAuthorization.LastUpdateContactTVItemID);
            Assert.AreEqual(count, tvTypeUserAuthorizationService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // tvTypeUserAuthorization.ContactTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // tvTypeUserAuthorization.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
