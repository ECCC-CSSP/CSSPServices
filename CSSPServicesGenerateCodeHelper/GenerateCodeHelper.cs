using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class GenerateCodeHelper
    {
        #region Functions private
        protected bool FillCSSPProp(PropertyInfo propInfo, CSSPProp csspProp, Type type)
        {
            csspProp.PropName = propInfo.Name;

            if (propInfo.PropertyType.FullName.StartsWith("System.Nullable"))
            {
                string typeTxt = propInfo.PropertyType.FullName;
                typeTxt = typeTxt.Substring(typeTxt.IndexOf("[[") + 2);
                typeTxt = typeTxt.Substring(typeTxt.IndexOf(".") + 1);
                typeTxt = typeTxt.Substring(0, typeTxt.IndexOf(","));

                csspProp.PropType = typeTxt;
            }
            else
            {
                csspProp.PropType = propInfo.PropertyType.Name.ToString();
            }

            csspProp.IsKey = propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("KeyAttribute")).Any();

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("DataTypeAttribute")).Any())
            {
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("DataTypeAttribute")).First();
                DataType dataType = ((DataType)customAttributeData.ConstructorArguments[0].Value);
                switch (dataType)
                {
                    case DataType.Custom:
                    case DataType.DateTime:
                    case DataType.Date:
                    case DataType.Time:
                    case DataType.Duration:
                    case DataType.PhoneNumber:
                    case DataType.Currency:
                    case DataType.Text:
                    case DataType.Html:
                    case DataType.MultilineText:
                        {
                            csspProp.Error = "DataType [" + dataType.ToString() + "] is not implemented yet.";
                            return false;
                        }
                    case DataType.EmailAddress:
                        {
                            csspProp.dataType = ((DataType)customAttributeData.ConstructorArguments[0].Value);
                        }
                        break;
                    case DataType.Password:
                    case DataType.Url:
                    case DataType.ImageUrl:
                    case DataType.CreditCard:
                    case DataType.PostalCode:
                    case DataType.Upload:
                        {
                            csspProp.Error = "DataType [" + dataType.ToString() + "] is not implemented yet.";
                            return false;
                        }
                    default:
                        break;
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("StringLengthAttribute")).Any())
            {
                if (propInfo.PropertyType != typeof(System.String))
                {
                    csspProp.Error = "Class [" + type.FullName + "] " + propInfo.Name + " should not contain the StringLength Attribute. StringLength Attribute can only be set for System.String";
                    return false;
                }
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("StringLengthAttribute")).First();
                csspProp.MaxLength = ((int)customAttributeData.ConstructorArguments.ToArray()[0].Value);
                if (customAttributeData.NamedArguments.ToArray().Count() > 0)
                {
                    for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                    {
                        if (customAttributeData.NamedArguments.ToArray()[i].MemberName == "MinimumLength")
                        {
                            csspProp.MinLength = ((int)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                        }
                    }
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("RangeAttribute")).Any())
            {
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("RangeAttribute")).First();
                if (csspProp.PropType == "Int16" || csspProp.PropType == "Int32" || csspProp.PropType == "Int64")
                {
                    csspProp.MinInt = ((int)customAttributeData.ConstructorArguments.ToArray()[0].Value);
                    csspProp.MaxInt = ((int)customAttributeData.ConstructorArguments.ToArray()[1].Value);

                    if (csspProp.MinInt > csspProp.MaxInt && csspProp.MaxInt == -1)
                    {
                        csspProp.MaxInt = null;
                    }
                }
                else if (csspProp.PropType == "Single")
                {
                    csspProp.MinFloat = ((float)((double)customAttributeData.ConstructorArguments.ToArray()[0].Value));
                    csspProp.MaxFloat = ((float)((double)customAttributeData.ConstructorArguments.ToArray()[1].Value));

                    if (csspProp.MinFloat > csspProp.MaxFloat && csspProp.MaxFloat == -1)
                    {
                        csspProp.MaxFloat = null;
                    }
                }
                else if (csspProp.PropType == "Double")
                {
                    csspProp.MinDouble = ((double)customAttributeData.ConstructorArguments.ToArray()[0].Value);
                    csspProp.MaxDouble = ((double)customAttributeData.ConstructorArguments.ToArray()[1].Value);

                    if (csspProp.MinDouble > csspProp.MaxDouble && csspProp.MaxDouble == -1)
                    {
                        csspProp.MaxDouble = null;
                    }
                }
                else
                {
                    csspProp.Error = "Type [" + type.FullName + "] Property [" + csspProp.PropName  + "] of type [" + csspProp.PropType + "] should not use RangeAttribute. Only types [Int,Single,Double] can use RangeAttributre";
                    return false;
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("CompareAttribute")).Any())
            {
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("CompareAttribute")).First();
                csspProp.Compare = ((string)customAttributeData.ConstructorArguments.ToArray()[0].Value);
            }

            csspProp.IsNullable = propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("CSSPAllowNullAttribute")).Any();

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("CSSPBiggerAttribute")).Any())
            {
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("CSSPBiggerAttribute")).First();
                for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                {
                    if (customAttributeData.NamedArguments.ToArray()[i].MemberName == "OtherField")
                    {
                        csspProp.OtherField = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                    }
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("CSSPAfterAttribute")).Any())
            {
                if (csspProp.PropType != "DateTime")
                {
                    csspProp.Error = "Property [" + csspProp.PropName + "] of type [" + csspProp.PropType + "] CSSPAfterAttribute should only be user for DateTime Type";
                    return false;
                }
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("CSSPAfterAttribute")).First();
                for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                {
                    if (customAttributeData.NamedArguments.ToArray()[i].MemberName == "Year")
                    {
                        csspProp.Year = ((int)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                    }
                }
            }

            if (propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("CSSPExistAttribute")).Any())
            {
                CustomAttributeData customAttributeData = propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("CSSPExistAttribute")).First();
                for (int i = 0, count = customAttributeData.NamedArguments.ToArray().Count(); i < count; i++)
                {
                    switch (customAttributeData.NamedArguments.ToArray()[i].MemberName)
                    {
                        case "TypeName":
                            {
                                csspProp.ObjectExistTypeName = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        case "Plurial":
                            {
                                csspProp.ObjectExistPlurial = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        case "FieldID":
                            {
                                csspProp.ObjectExistFieldID = ((string)customAttributeData.NamedArguments.ToArray()[i].TypedValue.Value);
                            }
                            break;
                        default:
                            csspProp.Error = "Property [" + csspProp.PropName + "] of type [" + csspProp.PropType + "] --- member name " + customAttributeData.NamedArguments.ToArray()[i].MemberName + " does not exist for CSSPExistAttribute";
                            return false;
                    }
                }
            }

            csspProp.IsEnumType = propInfo.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("CSSPEnumTypeAttribute")).Any();

            return true;
        }
        #endregion Functions private

        #region Sub Class
        protected class CSSPProp
        {
            public CSSPProp()
            {
                Error = "";
                PropName = "";
                PropType = "";
                IsNullable = false;
                IsKey = false;
                MaxLength = null;
                MinLength = null;
                MinInt = null;
                MaxInt = null;
                MinFloat = null;
                MaxFloat = null;
                MinDouble = null;
                MaxDouble = null;
                OtherField = "";
                Year = null;
                Compare = "";
                ObjectExistTypeName = "";
                ObjectExistPlurial = "";
                ObjectExistFieldID = "";
                IsEnumType = false;
                dataType = DataType.Custom;
            }
            public string Error { get; set; }
            public string PropName { get; set; }
            public string PropType { get; set; }
            public bool IsNullable { get; set; }
            public bool IsKey { get; set; }
            public int? MaxLength { get; set; }
            public int? MinLength { get; set; }
            public int? MinInt { get; set; }
            public int? MaxInt { get; set; }
            public float? MinFloat { get; set; }
            public float? MaxFloat { get; set; }
            public double? MinDouble { get; set; }
            public double? MaxDouble { get; set; }
            public string OtherField { get; set; }
            public int? Year { get; set; }
            public string Compare { get; set; }
            public string ObjectExistTypeName { get; set; }
            public string ObjectExistPlurial { get; set; }
            public string ObjectExistFieldID { get; set; }
            public bool IsEnumType { get; set; }
            public DataType dataType { get; set; }

        }
        #endregion Sub Class
    }
}
