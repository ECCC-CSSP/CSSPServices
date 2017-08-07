using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace CSSPServices
{
    public partial class TVItemService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        #endregion Validation

        #region Functions public get
        public List<TVItem> GetTop_TVItem(int Take)
        {
            List<TVItem> tvItemList = (from c in db.TVItems.AsNoTracking()
                                       from cl in db.TVItemLanguages.AsNoTracking()
                                       where c.TVItemID == cl.TVItemID
                                       && cl.Language == LanguageRequest
                                       orderby c.TVItemID
                                       select new TVItem
                                       {
                                           TVItemID = c.TVItemID,
                                           TVLevel = c.TVLevel,
                                           TVPath = c.TVPath,
                                           TVType = c.TVType,
                                           ParentID = c.ParentID,
                                           IsActive = c.IsActive,
                                           LastUpdateDate_UTC = cl.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = cl.LastUpdateContactTVItemID,
                                           TVText = cl.TVText,
                                           TVTypeText = c.TVType.ToString(),
                                           ValidationResults = null,
                                       }).Take(Take).ToList();

            return tvItemList;
        }
        #endregion Functions public get

        #region Functions public
        public bool AddRoot(TVItem tvItem)
        {
            tvItem.TVItemID = 1; //will be autogenerate
            tvItem.TVLevel = 0;
            tvItem.TVPath = "p1";
            tvItem.TVType = TVTypeEnum.Root;
            tvItem.ParentID = 1; // same as key only because it's the first TVItem in the DB,
            tvItem.IsActive = true;
            tvItem.LastUpdateDate_UTC = DateTime.UtcNow;
            tvItem.LastUpdateContactTVItemID = 1; // same as key only because it's the first TVItem in the DB


            tvItem.ValidationResults = Validate(new ValidationContext(tvItem), ActionDBTypeEnum.Create);
            if (tvItem.ValidationResults.Count() > 0) return false;

            db.TVItems.Add(tvItem);

            if (!TryToSave(tvItem)) return false;

            TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, db, ContactID);
            foreach (LanguageEnum Lang in LanguageListAllowable)
            {
                TVItemLanguage tvItemLanguage = new TVItemLanguage()
                {
                    Language = Lang,
                    TVText = ServicesRes.Root,
                    TVItemID = tvItem.TVItemID,
                    TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                };

                tvItemLanguageService.Add(tvItemLanguage);
            }

            return true;
        }
        public bool AddChildTVItemDB(int ParentTVItemID, string TVText, TVTypeEnum TVType, TVItem tvItem)
        {
            ContactService contactService = new ContactService(LanguageRequest, db, ContactID);

            Contact contactLoggedIn = contactService.GetRead().Where(c => c.ContactID == ContactID).FirstOrDefault();

            TVItem tvItemParent = GetRead().Where(c => c.TVItemID == ParentTVItemID).FirstOrDefault();
            if (tvItemParent == null)
            {
                tvItem.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemTVItemID, ParentTVItemID.ToString())) };
                return false;
            }

            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryTestDB))
            {
                TVItem tvItemExist = (from c in db.TVItems
                                      from cl in db.TVItemLanguages
                                      where c.TVItemID == cl.TVItemID
                                      && cl.TVText == TVText
                                      && c.ParentID == ParentTVItemID
                                      && c.TVType == TVType
                                      select c).FirstOrDefault();

                if (tvItemExist != null)
                {
                    tvItem.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes._AlreadyExists, TVText)) };
                    return false;
                }
            }

            TVItem tvItemNew = new TVItem();
            tvItemNew.TVLevel = tvItemParent.TVLevel + 1;
            tvItemNew.TVPath = tvItemParent.TVPath + "p0"; // will change
            tvItemNew.TVType = (TVTypeEnum)TVType;
            tvItemNew.ParentID = ParentTVItemID;
            tvItemNew.IsActive = true;

            using (TransactionScope ts = new TransactionScope())
            {
                if (!Add(tvItemNew))
                {
                    tvItem.ValidationResults = tvItemNew.ValidationResults;
                    return false;
                }

                tvItemNew.TVPath = tvItemParent.TVPath + "p" + tvItemNew.TVItemID;

                if (!Update(tvItemNew))
                {
                    tvItem.ValidationResults = tvItemNew.ValidationResults;
                    return false;
                }

                TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, db, ContactID);
                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    TVItemLanguage tvItemLanguage = new TVItemLanguage()
                    {
                        Language = Lang,
                        TVText = TVText,
                        TVItemID = tvItemNew.TVItemID,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    if (!tvItemLanguageService.Add(tvItemLanguage))
                    {
                        tvItem.ValidationResults = tvItemLanguage.ValidationResults;
                        return false;
                    }
                }

                ts.Complete();
            }

            return true;
        }
        public bool AddChildContactTVItemDB(int ParentTVItemID, string TVText, TVTypeEnum TVType, TVItem tvItem)
        {
            TVItem tvItemParent = GetRead().Where(c => c.TVItemID == ParentTVItemID).FirstOrDefault();
            if (tvItemParent == null)
            {
                tvItem.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemTVItemID, ParentTVItemID.ToString())) };
                return false;
            }

            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryTestDB))
            {
                TVItem tvItemExist = (from c in db.TVItems
                                      from cl in db.TVItemLanguages
                                      where c.TVItemID == cl.TVItemID
                                      && cl.TVText == TVText
                                      && c.ParentID == ParentTVItemID
                                      && c.TVType == TVType
                                      select c).FirstOrDefault();

                if (tvItemExist != null)
                {
                    tvItem.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes._AlreadyExists, TVText)) };
                    return false;
                }
            }

            TVItem tvItemNew = new TVItem();
            tvItemNew.TVLevel = tvItemParent.TVLevel + 1;
            tvItemNew.TVPath = tvItemParent.TVPath + "p0"; // will change
            tvItemNew.TVType = (TVTypeEnum)TVType;
            tvItemNew.ParentID = ParentTVItemID;
            tvItemNew.IsActive = true;

            using (TransactionScope ts = new TransactionScope())
            {
                if (!Add(tvItemNew))
                {
                    tvItem.ValidationResults = tvItemNew.ValidationResults;
                    return false;
                }

                tvItemNew.TVPath = tvItemParent.TVPath + "p" + tvItemNew.TVItemID;

                if (!Update(tvItemNew))
                {
                    tvItem.ValidationResults = tvItemNew.ValidationResults;
                    return false;
                }

                TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, db, ContactID);
                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    TVItemLanguage tvItemLanguage = new TVItemLanguage()
                    {
                        Language = Lang,
                        TVText = TVText,
                        TVItemID = tvItemNew.TVItemID,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    if (!tvItemLanguageService.Add(tvItemLanguage))
                    {
                        tvItem.ValidationResults = tvItemLanguage.ValidationResults;
                        return false;
                    }
                }

                ts.Complete();
            }

            return true;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
