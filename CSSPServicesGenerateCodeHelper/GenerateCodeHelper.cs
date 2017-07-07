using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class GenerateCodeHelper
    {
        #region Functions private
        protected EntityProp FillEntityProp(PropertyInfo propInfo, IProperty entProp, IEntityType entityType, Type type, string typeName, string typeNameLower)
        {
            EntityProp entityProp = new EntityProp();

            if (entProp != null)
            {
                string EntStr = entProp.ToString();
                EntStr = EntStr.Substring(EntStr.IndexOf(".") + 1);
                entityProp.PropName = EntStr.Substring(0, EntStr.IndexOf(" "));
                EntStr = EntStr.Substring(EntStr.IndexOf("(") + 1);
                entityProp.PropType = EntStr.Substring(0, EntStr.IndexOf(")"));
                entityProp.IsNullable = false;
                if (entityProp.PropType.StartsWith("Nullable"))
                {
                    entityProp.IsNullable = true;
                }
                entityProp.PropType = entityProp.PropType.Replace("Nullable<", "").Replace(">", "");
                entityProp.IsRequired = false;
                if (EntStr.Contains(" Required "))
                {
                    entityProp.IsRequired = true;
                }
                entityProp.IsKey = false;
                if (EntStr.Contains(" PK "))
                {
                    entityProp.IsKey = true;
                }
                entityProp.IsIndexed = false;
                if (EntStr.Contains(" Index "))
                {
                    entityProp.IsIndexed = true;
                }
                entityProp.MaxLength = 0;
                if (EntStr.Contains(" MaxLength"))
                {
                    string TempEntStr = EntStr.Substring(EntStr.IndexOf(" MaxLength") + " MaxLength".Length);
                    TempEntStr = TempEntStr.Substring(0, TempEntStr.IndexOf(" "));
                    entityProp.MaxLength = int.Parse(TempEntStr);
                }

                if (entityProp.PropType == "int" || entityProp.PropType == "string")
                {
                    entityProp.MinInt = GetEntityValueInt(entProp, "Range", 0);
                    entityProp.MaxInt = GetEntityValueInt(entProp, "Range", 1);
                }
                else if (entityProp.PropType == "float")
                {
                    entityProp.MinFloat = GetEntityValueFloat(entProp, "Range", 0);
                    entityProp.MaxFloat = GetEntityValueFloat(entProp, "Range", 1);
                }
                else if (entityProp.PropType == "float")
                {
                    entityProp.MinDouble = GetEntityValueDouble(entProp, "Range", 0);
                    entityProp.MaxDouble = GetEntityValueDouble(entProp, "Range", 1);
                }

                entityProp.DateBiggerThanOtherField = GetEntityValueString(entProp, "DateBiggerThanOtherField");
                entityProp.DateAfterYear = GetEntityValueInt(entProp, "DateOfYear", 0);
                entityProp.Equal = GetEntityValueString(entProp, "Equal");
                entityProp.ObjectExist = GetEntityValueString(entProp, "ObjectExist");
            }
            else
            {
            }

            return entityProp;
        }
        protected double? GetEntityValueDouble(IProperty entProp, string AnnotationText, int Ordinal)
        {
            IAnnotation entityAnn = null;
            try
            {
                entityAnn = entProp.FindAnnotation(AnnotationText);
            }
            catch (Exception)
            {
                return null;
            }

            if (entityAnn == null)
            {
                return null;
            }

            return ((double[])entityAnn.Value)[Ordinal];
        }
        protected float? GetEntityValueFloat(IProperty entProp, string AnnotationText, int Ordinal)
        {
            IAnnotation entityAnn = null;
            try
            {
                entityAnn = entProp.FindAnnotation(AnnotationText);
            }
            catch (Exception)
            {
                return null;
            }

            if (entityAnn == null)
            {
                return null;
            }

            return ((float[])entityAnn.Value)[Ordinal];
        }
        protected int? GetEntityValueInt(IProperty entProp, string AnnotationText, int Ordinal)
        {
            IAnnotation entityAnn = null;
            try
            {
                entityAnn = entProp.FindAnnotation(AnnotationText);
            }
            catch (Exception)
            {
                return null;
            }

            if (entityAnn == null)
            {
                return null;
            }

            return ((int[])entityAnn.Value)[Ordinal];
        }
        protected string GetEntityValueString(IProperty entProp, string AnnotationText)
        {
            IAnnotation entityAnn = null;
            try
            {
                entityAnn = entProp.FindAnnotation(AnnotationText);
            }
            catch (Exception)
            {
                return "";
            }

            if (entityAnn == null)
            {
                return "";
            }

            return (string)entityAnn.Value;
        }
        protected bool TypePropHasEnum(IEntityType entityType, Type type, string typeName, string typeNameLower)
        {
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.Name != "ValidationResults")
                {
                    if (prop.PropertyType.FullName.Contains("Enum"))
                    {
                        //IProperty entProp = entityType.GetProperties().Where(c => c.Name == prop.Name).FirstOrDefault();

                        //if (entProp != null)
                        //{
                        //    if (!entProp.ToString().Contains(" Required "))
                        //    {
                        return true;
                        //    }
                        //}
                    }
                }
            }

            return false;
        }
        #endregion Functions private

        #region Sub Class
        protected class EntityProp
        {
            public EntityProp()
            {
                PropName = "";
                PropType = "";
                IsNullable = false;
                IsRequired = false;
                IsKey = false;
                IsIndexed = false;
                MaxLength = null;
                MinInt = null;
                MaxInt = null;
                MinFloat = null;
                MaxFloat = null;
                MinDouble = null;
                MaxDouble = null;
                DateBiggerThanOtherField = "";
                DateAfterYear = null;
                Equal = "";
                ObjectExist = "";
            }
            public string PropName { get; set; }
            public string PropType { get; set; }
            public bool IsNullable { get; set; }
            public bool IsRequired { get; set; }
            public bool IsKey { get; set; }
            public bool IsIndexed { get; set; }
            public int? MaxLength { get; set; }
            public int? MinInt { get; set; }
            public int? MaxInt { get; set; }
            public float? MinFloat { get; set; }
            public float? MaxFloat { get; set; }
            public double? MinDouble { get; set; }
            public double? MaxDouble { get; set; }
            public string DateBiggerThanOtherField { get; set; }
            public int? DateAfterYear { get; set; }
            public string Equal { get; set; }
            public string ObjectExist { get; set; }

        }
        #endregion Sub Class
    }
}
