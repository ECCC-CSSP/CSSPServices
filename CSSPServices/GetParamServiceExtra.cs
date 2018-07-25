using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class QueryService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
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

                                                FileInfo fiDLL = new FileInfo(@"C:\CSSP Code\CSSPEnums\CSSPEnums\bin\Debug\CSSPEnums.dll");

                                                if (!fiDLL.Exists)
                                                {
                                                    query.HasErrors = true;
                                                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFindFile_, @"C:\CSSP Code\CSSPEnums\CSSPEnums\bin\Debug\CSSPEnums.dll"), new[] { "Where" });
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
        public Query FillProp(Type modelType, string lang = "en", int skip = 0, int take = 100, string order = "", string where = "",
                 EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
                 EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            Query query = new Query();

            query.ModelType = modelType;
            query.Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en);
            query.Lang = lang ?? "en";
            query.Skip = skip;
            query.Take = (take < 1 ? 1 : take);
            query.Order = order ?? "";
            query.Where = where ?? "";
            query.EntityQueryDetailType = EntityQueryDetailType;
            query.EntityQueryType = EntityQueryType;

            query.ValidationResults = Validate(new ValidationContext(query));
            if (query.ValidationResults.Count() > 0) return query;

            return query;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
