﻿using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class BaseService
    {
        #region Variables public
        public List<LanguageEnum> LanguageListAllowable = new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr };
        //public int TakeMax = 1000000;
        public string BasePath = @"E:\inetpub\wwwroot\cssp\App_Data\";
        public double R = 6378137.0;
        public double d2r = Math.PI / 180;
        public double r2d = 180 / Math.PI;
        //public Random random = new Random((int)(DateTime.Now.Ticks));
        //public List<TVTypeNamesAndPath> tvTypeNamesAndPathList = new List<TVTypeNamesAndPath>();
        //public List<PolSourceObsInfoChild> polSourceObsInfoChildList = new List<PolSourceObsInfoChild>();
        #endregion Variables public

        #region Properties
        public CSSPDBContext db { get; set; }
        public bool CanSendEmail { get; set; }
        public int ContactID { get; set; }
        public string FromEmail { get; set; }
        public LanguageEnum LanguageRequest { get; set; }
        public Query Query { get; set; }
        #endregion Properties

        #region Constructors
        public BaseService(Query query, CSSPDBContext db, int ContactID)
        {
            if (!LanguageListAllowable.Contains((LanguageEnum)query.Language))
            {
                this.LanguageRequest = LanguageEnum.en;
            }
            else
            {
                this.LanguageRequest = (LanguageEnum)query.Language;
            }

            if (LanguageRequest == LanguageEnum.fr)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-CA");
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-CA");
            }
            this.ContactID = ContactID;
            this.db = db;
            CanSendEmail = true;
            FromEmail = "ec.pccsm-cssp.ec@canada.ca";
            Query = query;
        }
        #endregion Constructors  

        #region Validation
        public IEnumerable<ValidationResult> ValidateQuery(ValidationContext validationContext)
        {
            Enums enums = new Enums(LanguageRequest);
            Query query = validationContext.ObjectInstance as Query;
            query.HasErrors = false;

            if (query.ModelType == null)
            {
                query.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ShouldNotBeNullOrEmpty, "ModelType"), new[] { "ModelType" });
            }

            if (!(query.Lang == "fr" || query.Lang == "en"))
            {
                query.HasErrors = true;
                yield return new ValidationResult(CSSPServicesRes.AllowableLanguagesAreFRAndEN, new[] { "Lang" });
            }

            if (query.Skip < 0)
            {
                query.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ShouldBeAbove_, "Skip", "0"), new[] { "Skip" });
            }

            if (query.Skip > 1000000)
            {
                query.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ShouldBeBelow_, "Skip", "1000000"), new[] { "Skip" });
            }

            if (query.Take < 1)
            {
                query.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ShouldBeAbove_, "Take", "1"), new[] { "Skip" });
            }

            if (query.Take > 1000000)
            {
                query.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ShouldBeBelow_, "Take", "1000000"), new[] { "Take" });
            }

            query.OrderList = new List<string>();
            if (!string.IsNullOrWhiteSpace(query.Order))
            {
                query.OrderList = query.Order.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToList();

                foreach (string PropertyName in query.OrderList)
                {
                    if (!query.ModelType.GetProperties().Where(c => c.Name == PropertyName).Any())
                    {
                        query.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._DoesNotExistForModelType_, PropertyName, query.ModelType.Name), new[] { "Order" });
                    }
                }
            }

            query.WhereInfoList = new List<WhereInfo>();

            if (!string.IsNullOrWhiteSpace(query.Where))
            {
                List<string> WhereList = query.Where.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToList();

                foreach (string w in WhereList)
                {
                    // Example of where == "TVItemID,EQ,5"
                    List<string> ValList = w.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToList();
                    if (ValList.Count != 3)
                    {
                        query.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._NeedToHaveValidStringFormatEx_, "Where", "TVItemID,GT,5|TVItemID,LT,20"), new[] { "Where" });
                    }
                    else
                    {
                        WhereInfo whereInfo = new WhereInfo();

                        if (!query.ModelType.GetProperties().Where(c => c.Name == ValList[0]).Any())
                        {
                            query.HasErrors = true;
                            yield return new ValidationResult(string.Format(CSSPServicesRes._DoesNotExistForModelType_, ValList[0], query.ModelType.Name), new[] { "Where" });
                        }
                        else
                        {
                            whereInfo.PropertyName = ValList[0];

                            PropertyInfo propertyInfo = query.ModelType.GetProperties().Where(c => c.Name == ValList[0]).FirstOrDefault();
                            if (propertyInfo == null)
                            {
                                query.HasErrors = true;
                                yield return new ValidationResult(string.Format(CSSPServicesRes._DoesNotExistForModelType_, ValList[0], query.ModelType.Name), new[] { "Where" });
                            }
                            else
                            {
                                whereInfo.Value = ValList[2];

                                switch (propertyInfo.PropertyType.FullName)
                                {
                                    case "System.Int16":
                                    case "System.Int32":
                                    case "System.Int64":
                                        {
                                            whereInfo.PropertyType = PropertyTypeEnum.Int;
                                            int TempInt;
                                            if (int.TryParse(whereInfo.Value, out TempInt))
                                            {
                                                whereInfo.ValueInt = TempInt;
                                            }
                                            else
                                            {
                                                query.HasErrors = true;
                                                yield return new ValidationResult(string.Format(CSSPServicesRes._NeedsToBeANumberFor_OfModel_, whereInfo.Value, whereInfo.PropertyName, query.ModelType.Name), new[] { "Where" });
                                            }
                                        }
                                        break;
                                    case "System.Double":
                                        {
                                            whereInfo.PropertyType = PropertyTypeEnum.Double;
                                            double TempDouble;
                                            if (Double.TryParse(whereInfo.Value, out TempDouble))
                                            {
                                                whereInfo.ValueDouble = TempDouble;
                                            }
                                            else
                                            {
                                                query.HasErrors = true;
                                                yield return new ValidationResult(string.Format(CSSPServicesRes._NeedsToBeANumberFor_OfModel_, whereInfo.Value, whereInfo.PropertyName, query.ModelType.Name), new[] { "Where" });
                                            }
                                        }
                                        break;
                                    case "System.String":
                                        {
                                            whereInfo.PropertyType = PropertyTypeEnum.String;
                                            // no need to do anything here as the string value has already been saved under the whereInfo.Value
                                        }
                                        break;
                                    case "System.Boolean":
                                        {
                                            whereInfo.PropertyType = PropertyTypeEnum.Boolean;
                                            bool TempBool;
                                            if (bool.TryParse(whereInfo.Value, out TempBool))
                                            {
                                                whereInfo.ValueBool = TempBool;
                                            }
                                            else
                                            {
                                                query.HasErrors = true;
                                                yield return new ValidationResult(string.Format(CSSPServicesRes._NeedsToBeTrueOrFalseFor_OfModel_, whereInfo.Value, whereInfo.PropertyName, query.ModelType.Name), new[] { "Where" });
                                            }
                                        }
                                        break;
                                    case "System.DateTime":
                                        {
                                            whereInfo.PropertyType = PropertyTypeEnum.DateTime;
                                            DateTime TempDateTime;
                                            if (DateTime.TryParse(whereInfo.Value, out TempDateTime))
                                            {
                                                whereInfo.ValueDateTime = TempDateTime;
                                            }
                                            else
                                            {
                                                query.HasErrors = true;
                                                yield return new ValidationResult(string.Format(CSSPServicesRes._NeedsToBeADateFor_OfModel_, whereInfo.Value, whereInfo.PropertyName, query.ModelType.Name), new[] { "Where" });
                                            }
                                        }
                                        break;
                                    default:
                                        {
                                            if (propertyInfo.PropertyType.FullName.Contains("Enum, CSSPEnums, "))
                                            {
                                                whereInfo.PropertyType = PropertyTypeEnum.Enum;
                                                string EnumTypeName = propertyInfo.PropertyType.FullName.Substring(propertyInfo.PropertyType.FullName.IndexOf("CSSPEnums.") + "CSSPEnums.".Length);
                                                EnumTypeName = EnumTypeName.Substring(0, EnumTypeName.IndexOf(","));

                                                FileInfo fiDLL = new FileInfo(@"C:\CSSPCode\CSSPEnums\CSSPEnums\bin\Debug\CSSPEnums.dll");

                                                if (!fiDLL.Exists)
                                                {
                                                    query.HasErrors = true;
                                                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFindFile_, @"C:\CSSPCode\CSSPEnums\CSSPEnums\bin\Debug\CSSPEnums.dll"), new[] { "Where" });
                                                }

                                                var importAssembly = Assembly.LoadFile(fiDLL.FullName);
                                                Type[] types = importAssembly.GetTypes();

                                                foreach (Type type in types)
                                                {
                                                    if (type.Name == EnumTypeName)
                                                    {
                                                        if (Char.IsNumber(whereInfo.Value[0]))
                                                        {
                                                            int TempInt;
                                                            if (int.TryParse(whereInfo.Value, out TempInt))
                                                            {
                                                                whereInfo.ValueInt = TempInt;
                                                            }
                                                            else
                                                            {
                                                                query.HasErrors = true;
                                                                yield return new ValidationResult(string.Format(CSSPServicesRes._NeedsToBeANumberFor_OfModel_, whereInfo.Value, whereInfo.PropertyName, query.ModelType.Name), new[] { "Where" });
                                                            }

                                                            if (!(from c in Enum.GetValues(type) as int[] where c == whereInfo.ValueInt select c).Any())
                                                            {
                                                                query.HasErrors = true;
                                                                yield return new ValidationResult(string.Format(CSSPServicesRes._NeedsToBeAValidEnumNumberFor_OfModel_, whereInfo.Value, whereInfo.PropertyName, query.ModelType.Name), new[] { "Where" });
                                                            }
                                                            else
                                                            {
                                                                int[] AllEnumIntList = Enum.GetValues(type) as int[];
                                                                string[] AllEnumTextList = Enum.GetNames(type) as string[];

                                                                for (int i = 0, count = AllEnumIntList.Count(); i < count; i++)
                                                                {
                                                                    if (AllEnumIntList[i] == whereInfo.ValueInt)
                                                                    {
                                                                        whereInfo.ValueInt = AllEnumIntList[i];
                                                                        whereInfo.ValueEnumText = AllEnumTextList[i];
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (!(from c in Enum.GetNames(type) where c == whereInfo.Value select c).Any())
                                                            {
                                                                query.HasErrors = true;
                                                                yield return new ValidationResult(string.Format(CSSPServicesRes._NeedsToBeAValidEnumTextFor_OfModel_, whereInfo.Value, whereInfo.PropertyName, query.ModelType.Name), new[] { "Where" });
                                                            }
                                                            else
                                                            {
                                                                int[] AllEnumIntList = Enum.GetValues(type) as int[];
                                                                string[] AllEnumTextList = Enum.GetNames(type) as string[];

                                                                for (int i = 0, count = AllEnumIntList.Count(); i < count; i++)
                                                                {
                                                                    if (AllEnumTextList[i] == whereInfo.Value)
                                                                    {
                                                                        whereInfo.ValueInt = AllEnumIntList[i];
                                                                        whereInfo.ValueEnumText = AllEnumTextList[i];
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                query.HasErrors = true;
                                                yield return new ValidationResult(string.Format(CSSPServicesRes._NotImplementedYet, propertyInfo.PropertyType.FullName), new[] { "Where" });
                                            }
                                        }
                                        break;
                                }


                                switch (ValList[1].ToUpper())
                                {
                                    case "EQ":
                                        {
                                            whereInfo.WhereOperator = WhereOperatorEnum.Equal;
                                        }
                                        break;
                                    case "LT":
                                        {
                                            whereInfo.WhereOperator = WhereOperatorEnum.LessThan;
                                        }
                                        break;
                                    case "GT":
                                        {
                                            whereInfo.WhereOperator = WhereOperatorEnum.GreaterThan;
                                        }
                                        break;
                                    case "C":
                                        {
                                            whereInfo.WhereOperator = WhereOperatorEnum.Contains;
                                        }
                                        break;
                                    case "SW":
                                        {
                                            whereInfo.WhereOperator = WhereOperatorEnum.StartsWith;
                                        }
                                        break;
                                    case "EW":
                                        {
                                            whereInfo.WhereOperator = WhereOperatorEnum.EndsWith;
                                        }
                                        break;
                                    default:
                                        {
                                            query.HasErrors = true;
                                            yield return new ValidationResult(string.Format(CSSPServicesRes.WhereOperator_NotImplementedYet, ValList[1]), new[] { "Where" });
                                        }
                                        break;
                                }

                                query.WhereInfoList.Add(whereInfo);
                            }
                        }
                    }
                }
            }
        }
        #endregion Validation

        #region Functions public
        public Object EnhanceQueryStatements<T>(Object obj)
        {
            IQueryable<T> query = (IQueryable<T>)obj;

            foreach (WhereInfo whereInfo in Query.WhereInfoList)
            {
                switch (whereInfo.WhereOperator)
                {
                    case WhereOperatorEnum.Contains:
                        {
                            query = EF_Where_Expression.WhereContains(query, whereInfo.PropertyName, whereInfo.Value);
                        }
                        break;
                    case WhereOperatorEnum.EndsWith:
                        {
                            query = EF_Where_Expression.WhereEndsWith(query, whereInfo.PropertyName, whereInfo.Value);
                        }
                        break;
                    case WhereOperatorEnum.Equal:
                        {
                            switch (whereInfo.PropertyType)
                            {
                                case PropertyTypeEnum.Int:
                                    query = EF_Where_Expression.WhereEqual(query, whereInfo.PropertyName, whereInfo.ValueInt);
                                    break;
                                case PropertyTypeEnum.Double:
                                    query = EF_Where_Expression.WhereEqual(query, whereInfo.PropertyName, whereInfo.ValueDouble);
                                    break;
                                case PropertyTypeEnum.String:
                                    query = EF_Where_Expression.WhereEqual(query, whereInfo.PropertyName, whereInfo.Value);
                                    break;
                                case PropertyTypeEnum.Boolean:
                                    query = EF_Where_Expression.WhereEqual(query, whereInfo.PropertyName, whereInfo.ValueBool);
                                    break;
                                case PropertyTypeEnum.DateTime:
                                    query = EF_Where_Expression.WhereEqual(query, whereInfo.PropertyName, whereInfo.ValueDateTime);
                                    break;
                                case PropertyTypeEnum.Enum:
                                    query = EF_Where_Expression.WhereEqual(query, whereInfo.PropertyName, whereInfo.ValueInt);
                                    break;
                                default:
                                    query = EF_Where_Expression.WhereEqual(query, whereInfo.PropertyName, whereInfo.Value);
                                    break;
                            }
                        }
                        break;
                    case WhereOperatorEnum.GreaterThan:
                        {
                            switch (whereInfo.PropertyType)
                            {
                                case PropertyTypeEnum.Int:
                                    query = EF_Where_Expression.WhereGreaterThan(query, whereInfo.PropertyName, whereInfo.ValueInt);
                                    break;
                                case PropertyTypeEnum.Double:
                                    query = EF_Where_Expression.WhereGreaterThan(query, whereInfo.PropertyName, whereInfo.ValueDouble);
                                    break;
                                case PropertyTypeEnum.String:
                                    query = EF_Where_Expression.WhereGreaterThan(query, whereInfo.PropertyName, whereInfo.Value);
                                    break;
                                case PropertyTypeEnum.Boolean:
                                    query = EF_Where_Expression.WhereGreaterThan(query, whereInfo.PropertyName, whereInfo.ValueBool);
                                    break;
                                case PropertyTypeEnum.DateTime:
                                    query = EF_Where_Expression.WhereGreaterThan(query, whereInfo.PropertyName, whereInfo.ValueDateTime);
                                    break;
                                case PropertyTypeEnum.Enum:
                                    query = EF_Where_Expression.WhereGreaterThan(query, whereInfo.PropertyName, whereInfo.ValueInt);
                                    break;
                                default:
                                    query = EF_Where_Expression.WhereGreaterThan(query, whereInfo.PropertyName, whereInfo.Value);
                                    break;
                            }
                        }
                        break;
                    case WhereOperatorEnum.LessThan:
                        {
                            switch (whereInfo.PropertyType)
                            {
                                case PropertyTypeEnum.Int:
                                    query = EF_Where_Expression.WhereLessThan(query, whereInfo.PropertyName, whereInfo.ValueInt);
                                    break;
                                case PropertyTypeEnum.Double:
                                    query = EF_Where_Expression.WhereLessThan(query, whereInfo.PropertyName, whereInfo.ValueDouble);
                                    break;
                                case PropertyTypeEnum.String:
                                    query = EF_Where_Expression.WhereLessThan(query, whereInfo.PropertyName, whereInfo.Value);
                                    break;
                                case PropertyTypeEnum.Boolean:
                                    query = EF_Where_Expression.WhereLessThan(query, whereInfo.PropertyName, whereInfo.ValueBool);
                                    break;
                                case PropertyTypeEnum.DateTime:
                                    query = EF_Where_Expression.WhereLessThan(query, whereInfo.PropertyName, whereInfo.ValueDateTime);
                                    break;
                                case PropertyTypeEnum.Enum:
                                    query = EF_Where_Expression.WhereLessThan(query, whereInfo.PropertyName, whereInfo.ValueInt);
                                    break;
                                default:
                                    query = EF_Where_Expression.WhereLessThan(query, whereInfo.PropertyName, whereInfo.Value);
                                    break;
                            }
                        }
                        break;
                    case WhereOperatorEnum.StartsWith:
                        {
                            query = EF_Where_Expression.WhereStartsWith(query, whereInfo.PropertyName, whereInfo.Value);
                        }
                        break;
                    default:
                        break;
                }
            }

            if (Query.OrderList.Count > 0)
            {
                int CountOrder = 0;
                foreach (string PropertyName in Query.OrderList)
                {
                    CountOrder += 1;
                    if (CountOrder > 1)
                    {
                        query = OrderExpression.ThenByProp(query, PropertyName);
                    }
                    else
                    {
                        query = OrderExpression.OrderByProp(query, PropertyName);
                    }
                }
            }
            else
            {
                string PropertyName = "";
                if (typeof(T).Name.EndsWith("ExtraA") || typeof(T).Name.EndsWith("ExtraB") || typeof(T).Name.EndsWith("ExtraC") || typeof(T).Name.EndsWith("ExtraD") || typeof(T).Name.EndsWith("ExtraE"))
                {
                    PropertyName = typeof(T).Name.Substring(0, typeof(T).Name.Length - 6) + "ID";
                }
                else
                {
                    PropertyName = typeof(T).Name + "ID";
                }

                query = OrderExpression.OrderByProp(query, PropertyName);
            }

            if (Query.Skip > 0)
            {
                query = query.Skip(Query.Skip);
            }

            query = query.Take(Query.Take);

            return query;
        }
        public Query FillQuery(Type modelType, string lang = "en", int skip = 0, int take = 200, string order = "", string where = "",
                string extra = "")
        {
            Query query = new Query();

            query.ModelType = modelType;
            query.Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en);
            query.Lang = lang ?? "en";
            query.Skip = skip;
            query.Take = (take < 1 ? 1 : take);
            query.Order = order ?? "";
            query.Where = where ?? "";
            query.Extra = extra ?? "";

            query.ValidationResults = ValidateQuery(new ValidationContext(query));
            if (query.ValidationResults.Count() > 0) return query;

            return query;
        }
        #endregion Functions public
    }
}
