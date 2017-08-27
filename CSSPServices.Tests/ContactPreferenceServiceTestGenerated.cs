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
    public partial class ContactPreferenceServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ContactPreferenceService contactPreferenceService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactPreferenceServiceTest() : base()
        {
            //contactPreferenceService = new ContactPreferenceService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ContactPreference GetFilledRandomContactPreference(string OmitPropName)
        {
            ContactPreference contactPreference = new ContactPreference();

            if (OmitPropName != "ContactID") contactPreference.ContactID = 1;
            if (OmitPropName != "TVType") contactPreference.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "MarkerSize") contactPreference.MarkerSize = GetRandomInt(1, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") contactPreference.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") contactPreference.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") contactPreference.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "TVTypeText") contactPreference.TVTypeText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") contactPreference.HasErrors = true;

            return contactPreference;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ContactPreference_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactPreferenceService contactPreferenceService = new ContactPreferenceService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ContactPreference contactPreference = GetFilledRandomContactPreference("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                count = contactPreferenceService.GetRead().Count();

                Assert.AreEqual(contactPreferenceService.GetRead().Count(), contactPreferenceService.GetEdit().Count());

                contactPreferenceService.Add(contactPreference);
                if (contactPreference.HasErrors)
                {
                    Assert.AreEqual("", contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, contactPreferenceService.GetRead().Where(c => c == contactPreference).Any());
                contactPreferenceService.Update(contactPreference);
                if (contactPreference.HasErrors)
                {
                    Assert.AreEqual("", contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, contactPreferenceService.GetRead().Count());
                contactPreferenceService.Delete(contactPreference);
                if (contactPreference.HasErrors)
                {
                    Assert.AreEqual("", contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, contactPreferenceService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // contactPreference.ContactPreferenceID   (Int32)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactPreferenceID = 0;
                    contactPreferenceService.Update(contactPreference);
                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.ContactPreferenceContactPreferenceID), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactPreferenceID = 10000000;
                    contactPreferenceService.Update(contactPreference);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.ContactPreference, ModelsRes.ContactPreferenceContactPreferenceID, contactPreference.ContactPreferenceID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID", AllowableTVtypeList = Error)]
                    // contactPreference.ContactID   (Int32)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactID = 0;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Contact, ModelsRes.ContactPreferenceContactID, contactPreference.ContactID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // contactPreference.TVType   (TVTypeEnum)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.TVType = (TVTypeEnum)1000000;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.ContactPreferenceTVType), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 1000)]
                    // contactPreference.MarkerSize   (Int32)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.MarkerSize = 0;
                    Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ContactPreferenceMarkerSize, "1", "1000"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactPreferenceService.GetRead().Count());
                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.MarkerSize = 1001;
                    Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ContactPreferenceMarkerSize, "1", "1000"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactPreferenceService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // contactPreference.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // contactPreference.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.LastUpdateContactTVItemID = 0;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ContactPreferenceLastUpdateContactTVItemID, contactPreference.LastUpdateContactTVItemID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.LastUpdateContactTVItemID = 1;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ContactPreferenceLastUpdateContactTVItemID, "Contact"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // contactPreference.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactPreferenceLastUpdateContactTVText, "200"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactPreferenceService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // contactPreference.TVTypeText   (String)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.TVTypeText = GetRandomString("", 101);
                    Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactPreferenceTVTypeText, "100"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactPreferenceService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // contactPreference.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // contactPreference.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void ContactPreference_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactPreferenceService contactPreferenceService = new ContactPreferenceService(LanguageRequest, dbTestDB, ContactID);
                    ContactPreference contactPreference = (from c in contactPreferenceService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(contactPreference);

                    ContactPreference contactPreferenceRet = contactPreferenceService.GetContactPreferenceWithContactPreferenceID(contactPreference.ContactPreferenceID);
                    Assert.IsNotNull(contactPreferenceRet.ContactPreferenceID);
                    Assert.IsNotNull(contactPreferenceRet.ContactID);
                    Assert.IsNotNull(contactPreferenceRet.TVType);
                    Assert.IsNotNull(contactPreferenceRet.MarkerSize);
                    Assert.IsNotNull(contactPreferenceRet.LastUpdateDate_UTC);
                    Assert.IsNotNull(contactPreferenceRet.LastUpdateContactTVItemID);

                    Assert.IsNotNull(contactPreferenceRet.LastUpdateContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(contactPreferenceRet.LastUpdateContactTVText));
                    Assert.IsNotNull(contactPreferenceRet.TVTypeText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(contactPreferenceRet.TVTypeText));
                    Assert.IsNotNull(contactPreferenceRet.HasErrors);
                }
            }
        }
        #endregion Tests Get With Key

    }
}
