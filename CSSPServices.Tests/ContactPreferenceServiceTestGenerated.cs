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
                    ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new GetParam(), dbTestDB, ContactID);

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactPreferenceContactPreferenceID), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactPreferenceID = 10000000;
                    contactPreferenceService.Update(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ContactPreference, CSSPModelsRes.ContactPreferenceContactPreferenceID, contactPreference.ContactPreferenceID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID", AllowableTVtypeList = Error)]
                    // contactPreference.ContactID   (Int32)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactID = 0;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Contact, CSSPModelsRes.ContactPreferenceContactID, contactPreference.ContactID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // contactPreference.TVType   (TVTypeEnum)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.TVType = (TVTypeEnum)1000000;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactPreferenceTVType), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 1000)]
                    // contactPreference.MarkerSize   (Int32)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.MarkerSize = 0;
                    Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ContactPreferenceMarkerSize, "1", "1000"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactPreferenceService.GetRead().Count());
                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.MarkerSize = 1001;
                    Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ContactPreferenceMarkerSize, "1", "1000"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactPreferenceService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // contactPreference.ContactPreferenceWeb   (ContactPreferenceWeb)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactPreferenceWeb = null;
                    Assert.IsNull(contactPreference.ContactPreferenceWeb);

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactPreferenceWeb = new ContactPreferenceWeb();
                    Assert.IsNotNull(contactPreference.ContactPreferenceWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // contactPreference.ContactPreferenceReport   (ContactPreferenceReport)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactPreferenceReport = null;
                    Assert.IsNull(contactPreference.ContactPreferenceReport);

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactPreferenceReport = new ContactPreferenceReport();
                    Assert.IsNotNull(contactPreference.ContactPreferenceReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // contactPreference.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.LastUpdateDate_UTC = new DateTime();
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactPreferenceLastUpdateDate_UTC), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ContactPreferenceLastUpdateDate_UTC, "1980"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // contactPreference.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.LastUpdateContactTVItemID = 0;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ContactPreferenceLastUpdateContactTVItemID, contactPreference.LastUpdateContactTVItemID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.LastUpdateContactTVItemID = 1;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ContactPreferenceLastUpdateContactTVItemID, "Contact"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // contactPreference.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // contactPreference.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
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
                    GetParam getParam = new GetParam();
                    ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new GetParam(), dbTestDB, ContactID);
                    ContactPreference contactPreference = (from c in contactPreferenceService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(contactPreference);

                    ContactPreference contactPreferenceRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            contactPreferenceRet = contactPreferenceService.GetContactPreferenceWithContactPreferenceID(contactPreference.ContactPreferenceID, getParam);
                            Assert.IsNull(contactPreferenceRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactPreferenceRet = contactPreferenceService.GetContactPreferenceWithContactPreferenceID(contactPreference.ContactPreferenceID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactPreferenceRet = contactPreferenceService.GetContactPreferenceWithContactPreferenceID(contactPreference.ContactPreferenceID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactPreferenceRet = contactPreferenceService.GetContactPreferenceWithContactPreferenceID(contactPreference.ContactPreferenceID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // ContactPreference fields
                        Assert.IsNotNull(contactPreferenceRet.ContactPreferenceID);
                        Assert.IsNotNull(contactPreferenceRet.ContactID);
                        Assert.IsNotNull(contactPreferenceRet.TVType);
                        Assert.IsNotNull(contactPreferenceRet.MarkerSize);
                        Assert.IsNotNull(contactPreferenceRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(contactPreferenceRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // ContactPreferenceWeb and ContactPreferenceReport fields should be null here
                            Assert.IsNull(contactPreferenceRet.ContactPreferenceWeb);
                            Assert.IsNull(contactPreferenceRet.ContactPreferenceReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // ContactPreferenceWeb fields should not be null and ContactPreferenceReport fields should be null here
                            if (contactPreferenceRet.ContactPreferenceWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(contactPreferenceRet.ContactPreferenceWeb.LastUpdateContactTVText));
                            }
                            if (contactPreferenceRet.ContactPreferenceWeb.TVTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(contactPreferenceRet.ContactPreferenceWeb.TVTypeText));
                            }
                            Assert.IsNull(contactPreferenceRet.ContactPreferenceReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // ContactPreferenceWeb and ContactPreferenceReport fields should NOT be null here
                            if (contactPreferenceRet.ContactPreferenceWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(contactPreferenceRet.ContactPreferenceWeb.LastUpdateContactTVText));
                            }
                            if (contactPreferenceRet.ContactPreferenceWeb.TVTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(contactPreferenceRet.ContactPreferenceWeb.TVTypeText));
                            }
                            if (contactPreferenceRet.ContactPreferenceReport.ContactPreferenceReportText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(contactPreferenceRet.ContactPreferenceReport.ContactPreferenceReportText));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of ContactPreference
        #endregion Tests Get List of ContactPreference

    }
}
