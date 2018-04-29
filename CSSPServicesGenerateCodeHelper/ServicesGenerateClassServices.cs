using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using System.IO;
using CSSPModels;
using CSSPEnums;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using CSSPModelsGenerateCodeHelper;
using CSSPGenerateCodeBase;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class ServicesGenerateCodeHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // constructor was done in the ServicesGenerateCodeHelper.cs file
        #endregion Constructors

        #region Functions private
        private void CreateClassServiceFunctionsPrivateRegionFillClassWeb(Type type, Type[] types, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (TypeName == "AspNetUser")
            {
                return;
            }

            bool ClassContainsEnum = false;
            sb.AppendLine(@"        #region Functions private Generated " + TypeName + @"FillWeb");
            sb.AppendLine(@"        private IQueryable<" + TypeName + @"> Fill" + TypeName + @"Web(IQueryable<" + TypeName + @"> " + TypeNameLower + @"Query, string FilterAndOrderText)");
            sb.AppendLine(@"        {");
            Type WebType = null;
            foreach (PropertyInfo prop in type.GetProperties())
            {
                foreach (Type type2 in types)
                {
                    if (type2.Name == type.Name + "Web")
                    {
                        WebType = type2;
                        if (prop.GetGetMethod().IsVirtual)
                        {
                            continue;
                        }

                        if (prop.Name == "ValidationResults")
                        {
                            continue;
                        }

                        CSSPProp csspProp = new CSSPProp();
                        if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                        {
                            ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                            return;
                        }
                        if (csspProp.HasCSSPEnumTypeAttribute)
                        {
                            ClassContainsEnum = true;
                            break;
                        }
                    }
                }
            }
            if (WebType == null)
            {
                ErrorEvent(new ErrorEventArgs("WebType should not be null"));
                return;
            }
            if (ClassContainsEnum)
            {
                sb.AppendLine(@"            Enums enums = new Enums(LanguageRequest);");
                sb.AppendLine(@"");
                List<string> EnumTypeNameAddedList = new List<string>();
                foreach (PropertyInfo prop in WebType.GetProperties())
                {
                    if (prop.GetGetMethod().IsVirtual)
                    {
                        continue;
                    }

                    if (prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    CSSPProp csspProp = new CSSPProp();
                    if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, WebType))
                    {
                        ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                        return;
                    }
                    if (csspProp.HasCSSPEnumTypeTextAttribute)
                    {
                        if (!EnumTypeNameAddedList.Contains(csspProp.EnumTypeName))
                        {
                            sb.AppendLine(@"            List<EnumIDAndText> " + csspProp.EnumTypeName + @"List = enums.GetEnumTextOrderedList(typeof(" + csspProp.EnumTypeName + @"));");
                            EnumTypeNameAddedList.Add(csspProp.EnumTypeName);
                        }
                    }
                }
                sb.AppendLine(@"");
            }
            sb.AppendLine(@"            " + TypeNameLower + @"Query = (from c in " + TypeNameLower + @"Query");
            foreach (PropertyInfo prop in WebType.GetProperties())
            {
                if (prop.GetGetMethod().IsVirtual)
                {
                    continue;
                }

                if (prop.Name == "ValidationResults")
                {
                    continue;
                }

                CSSPProp csspProp = new CSSPProp();
                if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, WebType))
                {
                    ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                    return;
                }
                if (csspProp.HasCSSPEnumTypeAttribute)
                {
                    ClassContainsEnum = true;
                }
                if (csspProp.HasCSSPFillAttribute)
                {
                    sb.AppendLine(@"                let " + csspProp.PropName + @" = (from cl in db." + csspProp.FillTypeName + csspProp.FillPlurial + "");
                    sb.AppendLine(@"                    where cl." + csspProp.FillFieldID + @" == c." + csspProp.FillEqualField + "");
                    if (csspProp.FillNeedLanguage)
                    {
                        sb.AppendLine(@"                    && cl.Language == LanguageRequest");
                    }
                    sb.AppendLine(@"                    select cl." + csspProp.FillReturnField + @").FirstOrDefault()");
                }
            }
            sb.AppendLine(@"                    select new " + TypeName + @"");
            sb.AppendLine(@"                    {");
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.GetGetMethod().IsVirtual)
                {
                    continue;
                }

                if (prop.Name == "ValidationResults" || prop.Name == "HasErrors" || prop.Name.EndsWith("Web") || prop.Name.EndsWith("Report"))
                {
                    continue;
                }

                CSSPProp csspProp = new CSSPProp();
                if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                {
                    ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                    return;
                }
                if (type.Name == "ContactLogin" && prop.Name == "PasswordHash")
                {
                    continue;
                }
                if (type.Name == "ContactLogin" && prop.Name == "PasswordSalt")
                {
                    continue;
                }
                if (!csspProp.HasNotMappedAttribute)
                {
                    sb.AppendLine(@"                        " + csspProp.PropName + @" = c." + csspProp.PropName + @",");
                }
                else if (csspProp.HasCSSPEnumTypeTextAttribute)
                {
                    sb.AppendLine(@"                        " + csspProp.PropName + @" = (from e in " + csspProp.EnumTypeName + @"List");
                    sb.AppendLine(@"                                where e.EnumID == (int?)c." + csspProp.EnumType + @"");
                    sb.AppendLine(@"                                select e.EnumText).FirstOrDefault(),");
                }
                else
                {
                    sb.AppendLine(@"                        " + csspProp.PropName + @" = c." + csspProp.PropName + @",");
                }
            }
            if (WebType.GetProperties().Count() > 0)
            {
                int count = 0;

                foreach (PropertyInfo prop in WebType.GetProperties())
                {
                    if (prop.GetGetMethod().IsVirtual)
                    {
                        continue;
                    }

                    if (prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    CSSPProp csspProp = new CSSPProp();
                    if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, WebType))
                    {
                        ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                        return;
                    }
                    if (count == 0)
                    {
                        sb.AppendLine(@"                        " + type.Name + @"Web = new " + type.Name + @"Web");
                        sb.AppendLine(@"                        {");
                    }
                    count += 1;
                    if ((type.Name == "ContactLogin" || type.Name == "ResetPassword") && prop.Name == "Password")
                    {
                        continue;
                    }
                    if ((type.Name == "ContactLogin" || type.Name == "ResetPassword") && prop.Name == "ConfirmPassword")
                    {
                        continue;
                    }

                    if (csspProp.HasCSSPFillAttribute)
                    {
                        sb.AppendLine(@"                            " + csspProp.PropName + @" = " + csspProp.PropName + @",");
                    }
                    else if (csspProp.HasCSSPEnumTypeTextAttribute)
                    {
                        sb.AppendLine(@"                            " + csspProp.PropName + @" = (from e in " + csspProp.EnumTypeName + @"List");
                        sb.AppendLine(@"                                where e.EnumID == (int?)c." + csspProp.EnumType + @"");
                        sb.AppendLine(@"                                select e.EnumText).FirstOrDefault(),");
                    }
                    else
                    {
                        sb.AppendLine(@"                            " + csspProp.PropName + @" = " + csspProp.PropName + @",");
                    }
                }
                sb.AppendLine(@"                        },");
                sb.AppendLine(@"                        " + type.Name + @"Report = null,");
            }
            sb.AppendLine(@"                        HasErrors = false,");
            sb.AppendLine(@"                        ValidationResults = null,");
            sb.AppendLine(@"                    });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return " + TypeNameLower + @"Query;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Functions private Generated " + TypeName + @"FillWeb");
            sb.AppendLine(@"");
        }
        private void CreateClassServiceFunctionsPrivateRegionFillClassReport(Type type, Type[] types, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            bool ClassContainsEnum = false;
            sb.AppendLine(@"        #region Functions private Generated " + TypeName + @"FillReport (To be copied)");
            sb.AppendLine(@"        // --------------------------------------------------------------------------------");
            sb.AppendLine(@"        // You should copy to AddressServiceExtra and/or sync with it then remove this function");
            sb.AppendLine(@"        // --------------------------------------------------------------------------------");
            sb.AppendLine(@"        private IQueryable<" + TypeName + @"> Fill" + TypeName + @"Report(IQueryable<" + TypeName + @"> " + TypeNameLower + @"Query, string FilterAndOrderText)");
            sb.AppendLine(@"        {");
            Type WebType = null;
            Type ReportType = null;
            foreach (PropertyInfo prop in type.GetProperties())
            {
                foreach (Type type2 in types)
                {
                    if (type2.Name == type.Name + "Web")
                    {
                        WebType = type2;
                        if (prop.GetGetMethod().IsVirtual)
                        {
                            continue;
                        }

                        if (prop.Name == "ValidationResults")
                        {
                            continue;
                        }

                        CSSPProp csspProp = new CSSPProp();
                        if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                        {
                            ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                            return;
                        }
                        if (csspProp.HasCSSPEnumTypeAttribute)
                        {
                            ClassContainsEnum = true;
                            break;
                        }
                    }
                }
                foreach (Type type2 in types)
                {
                    if (type2.Name == type.Name + "Report")
                    {
                        ReportType = type2;
                        if (prop.GetGetMethod().IsVirtual)
                        {
                            continue;
                        }

                        if (prop.Name == "ValidationResults")
                        {
                            continue;
                        }

                        CSSPProp csspProp = new CSSPProp();
                        if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                        {
                            ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                            return;
                        }
                        if (csspProp.HasCSSPEnumTypeAttribute)
                        {
                            ClassContainsEnum = true;
                            break;
                        }
                    }
                }
            }
            if (WebType == null)
            {
                ErrorEvent(new ErrorEventArgs("WebType should not be null"));
                return;
            }
            if (ReportType == null)
            {
                ErrorEvent(new ErrorEventArgs("ReportType should not be null"));
                return;
            }
            if (ClassContainsEnum)
            {
                sb.AppendLine(@"            Enums enums = new Enums(LanguageRequest);");
                sb.AppendLine(@"");
                List<string> EnumTypeNameAddedList = new List<string>();
                foreach (PropertyInfo prop in WebType.GetProperties())
                {
                    if (prop.GetGetMethod().IsVirtual)
                    {
                        continue;
                    }

                    if (prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    CSSPProp csspProp = new CSSPProp();
                    if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, WebType))
                    {
                        ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                        return;
                    }
                    if (csspProp.HasCSSPEnumTypeTextAttribute)
                    {
                        if (!EnumTypeNameAddedList.Contains(csspProp.EnumTypeName))
                        {
                            sb.AppendLine(@"            List<EnumIDAndText> " + csspProp.EnumTypeName + @"List = enums.GetEnumTextOrderedList(typeof(" + csspProp.EnumTypeName + @"));");
                            EnumTypeNameAddedList.Add(csspProp.EnumTypeName);
                        }
                    }
                }
                foreach (PropertyInfo prop in ReportType.GetProperties())
                {
                    if (prop.GetGetMethod().IsVirtual)
                    {
                        continue;
                    }

                    if (prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    CSSPProp csspProp = new CSSPProp();
                    if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, ReportType))
                    {
                        ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                        return;
                    }
                    if (csspProp.HasCSSPEnumTypeTextAttribute)
                    {
                        if (!EnumTypeNameAddedList.Contains(csspProp.EnumTypeName))
                        {
                            sb.AppendLine(@"            List<EnumIDAndText> " + csspProp.EnumTypeName + @"List = enums.GetEnumTextOrderedList(typeof(" + csspProp.EnumTypeName + @"));");
                            EnumTypeNameAddedList.Add(csspProp.EnumTypeName);
                        }
                    }
                }
                sb.AppendLine(@"");
            }
            sb.AppendLine(@"            " + TypeNameLower + @"Query = (from c in " + TypeNameLower + @"Query");
            foreach (PropertyInfo prop in WebType.GetProperties())
            {
                if (prop.GetGetMethod().IsVirtual)
                {
                    continue;
                }

                if (prop.Name == "ValidationResults")
                {
                    continue;
                }

                CSSPProp csspProp = new CSSPProp();
                if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, WebType))
                {
                    ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                    return;
                }
                if (csspProp.HasCSSPEnumTypeAttribute)
                {
                    ClassContainsEnum = true;
                }
                if (csspProp.HasCSSPFillAttribute)
                {
                    sb.AppendLine(@"                let " + csspProp.PropName + @" = (from cl in db." + csspProp.FillTypeName + csspProp.FillPlurial + "");
                    sb.AppendLine(@"                    where cl." + csspProp.FillFieldID + @" == c." + csspProp.FillEqualField + "");
                    if (csspProp.FillNeedLanguage)
                    {
                        sb.AppendLine(@"                    && cl.Language == LanguageRequest");
                    }
                    sb.AppendLine(@"                    select cl." + csspProp.FillReturnField + @").FirstOrDefault()");
                }
            }
            foreach (PropertyInfo prop in ReportType.GetProperties())
            {
                if (prop.GetGetMethod().IsVirtual)
                {
                    continue;
                }

                if (prop.Name == "ValidationResults")
                {
                    continue;
                }

                CSSPProp csspProp = new CSSPProp();
                if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, ReportType))
                {
                    ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                    return;
                }
                if (csspProp.HasCSSPEnumTypeAttribute)
                {
                    ClassContainsEnum = true;
                }
                if (csspProp.HasCSSPFillAttribute)
                {
                    sb.AppendLine(@"                let " + csspProp.PropName + @" = (from cl in db." + csspProp.FillTypeName + csspProp.FillPlurial + "");
                    sb.AppendLine(@"                    where cl." + csspProp.FillFieldID + @" == c." + csspProp.FillEqualField + "");
                    if (csspProp.FillNeedLanguage)
                    {
                        sb.AppendLine(@"                    && cl.Language == LanguageRequest");
                    }
                    sb.AppendLine(@"                    select cl." + csspProp.FillReturnField + @").FirstOrDefault()");
                }
            }
            sb.AppendLine(@"                    select new " + TypeName + @"");
            sb.AppendLine(@"                    {");
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.GetGetMethod().IsVirtual)
                {
                    continue;
                }

                if (prop.Name == "ValidationResults" || prop.Name == "HasErrors" || prop.Name.EndsWith("Web") || prop.Name.EndsWith("Report"))
                {
                    continue;
                }

                CSSPProp csspProp = new CSSPProp();
                if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                {
                    ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                    return;
                }
                if (type.Name == "ContactLogin" && prop.Name == "PasswordHash")
                {
                    continue;
                }
                if (type.Name == "ContactLogin" && prop.Name == "PasswordSalt")
                {
                    continue;
                }
                if (!csspProp.HasNotMappedAttribute)
                {
                    sb.AppendLine(@"                        " + csspProp.PropName + @" = c." + csspProp.PropName + @",");
                }
                else if (csspProp.HasCSSPEnumTypeTextAttribute)
                {
                    sb.AppendLine(@"                        " + csspProp.PropName + @" = (from e in " + csspProp.EnumTypeName + @"List");
                    sb.AppendLine(@"                                where e.EnumID == (int?)c." + csspProp.EnumType + @"");
                    sb.AppendLine(@"                                select e.EnumText).FirstOrDefault(),");
                }
                else
                {
                    sb.AppendLine(@"                        " + csspProp.PropName + @" = c." + csspProp.PropName + @",");
                }
            }
            if (WebType.GetProperties().Count() > 0)
            {
                int count = 0;

                foreach (PropertyInfo prop in WebType.GetProperties())
                {
                    if (prop.GetGetMethod().IsVirtual)
                    {
                        continue;
                    }

                    if (prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    CSSPProp csspProp = new CSSPProp();
                    if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, WebType))
                    {
                        ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                        return;
                    }
                    if (count == 0)
                    {
                        sb.AppendLine(@"                        " + type.Name + @"Web = new " + type.Name + @"Web");
                        sb.AppendLine(@"                        {");
                    }
                    count += 1;
                    if ((type.Name == "ContactLogin" || type.Name == "ResetPassword") && prop.Name == "Password")
                    {
                        continue;
                    }
                    if ((type.Name == "ContactLogin" || type.Name == "ResetPassword") && prop.Name == "ConfirmPassword")
                    {
                        continue;
                    }
                    if (csspProp.HasCSSPFillAttribute)
                    {
                        sb.AppendLine(@"                            " + csspProp.PropName + @" = " + csspProp.PropName + @",");
                    }
                    else if (csspProp.HasCSSPEnumTypeTextAttribute)
                    {
                        sb.AppendLine(@"                            " + csspProp.PropName + @" = (from e in " + csspProp.EnumTypeName + @"List");
                        sb.AppendLine(@"                                where e.EnumID == (int?)c." + csspProp.EnumType + @"");
                        sb.AppendLine(@"                                select e.EnumText).FirstOrDefault(),");
                    }
                    else
                    {
                        sb.AppendLine(@"                            " + csspProp.PropName + @" = " + csspProp.PropName + @",");
                    }
                }
                sb.AppendLine(@"                        },");
            }
            if (ReportType.GetProperties().Count() > 0)
            {
                int count = 0;

                foreach (PropertyInfo prop in ReportType.GetProperties())
                {
                    if (prop.GetGetMethod().IsVirtual)
                    {
                        continue;
                    }

                    if (prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    CSSPProp csspProp = new CSSPProp();
                    if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, ReportType))
                    {
                        ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                        return;
                    }
                    if (count == 0)
                    {
                        sb.AppendLine(@"                        " + type.Name + @"Report = new " + type.Name + @"Report");
                        sb.AppendLine(@"                        {");
                    }
                    count += 1;
                    if (csspProp.HasCSSPFillAttribute)
                    {
                        sb.AppendLine(@"                            " + csspProp.PropName + @" = " + csspProp.PropName + @",");
                    }
                    else if (csspProp.HasCSSPEnumTypeTextAttribute)
                    {
                        sb.AppendLine(@"                            " + csspProp.PropName + @" = (from e in " + csspProp.EnumTypeName + @"List");
                        sb.AppendLine(@"                                where e.EnumID == (int?)c." + csspProp.EnumType + @"");
                        sb.AppendLine(@"                                select e.EnumText).FirstOrDefault(),");
                    }
                    else
                    {
                        sb.AppendLine(@"                            " + csspProp.PropName + @" = """ + csspProp.PropName + @""",");
                    }
                }
                sb.AppendLine(@"                        },");
            }
            sb.AppendLine(@"                        HasErrors = false,");
            sb.AppendLine(@"                        ValidationResults = null,");
            sb.AppendLine(@"                    });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return " + TypeNameLower + @"Query;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Functions private Generated " + TypeName + @"FillReport (To be copied)");
            sb.AppendLine(@"");
        }
        private void CreateClassServiceFunctionsPrivateRegionTrySave(Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Functions private Generated TryToSave");
            sb.AppendLine(@"        private bool TryToSave(" + TypeName + @" " + TypeNameLower + @")");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            try");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                db.SaveChanges();");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            catch (DbUpdateException ex)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                " + TypeNameLower + @".ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")) }.AsEnumerable();");
            sb.AppendLine(@"                return false;");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Functions private Generated TryToSave");
            sb.AppendLine(@"");
        }
        private void CreateClassServiceFunctionsPublicGenerateCRUD(Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            List<string> TypeNameWithPlurial_es = new List<string>() { "Address", };

            string Plurial = "s";
            if (TypeNameWithPlurial_es.Contains(TypeName))
            {
                Plurial = "es";
            }

            sb.AppendLine(@"        #region Functions public Generated CRUD");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"        public bool Add(" + TypeName + @" " + TypeNameLower + @", AddContactTypeEnum addContactType)");
            }
            else
            {
                sb.AppendLine(@"        public bool Add(" + TypeName + @" " + TypeNameLower + @")");
            }
            sb.AppendLine(@"        {");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"            " + TypeNameLower + @".ValidationResults = Validate(new ValidationContext(" + TypeNameLower + @"), ActionDBTypeEnum.Create, addContactType);");
            }
            else
            {
                sb.AppendLine(@"            " + TypeNameLower + @".ValidationResults = Validate(new ValidationContext(" + TypeNameLower + @"), ActionDBTypeEnum.Create);");
            }
            sb.AppendLine(@"            if (" + TypeNameLower + @".ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            db." + TypeName + Plurial + @".Add(" + TypeNameLower + @");");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (!TryToSave(" + TypeNameLower + @")) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        public bool Delete(" + TypeName + @" " + TypeNameLower + @")");
            sb.AppendLine(@"        {");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"            " + TypeNameLower + @".ValidationResults = Validate(new ValidationContext(" + TypeNameLower + @"), ActionDBTypeEnum.Update, AddContactTypeEnum.LoggedIn);");
            }
            else
            {
                sb.AppendLine(@"            " + TypeNameLower + @".ValidationResults = Validate(new ValidationContext(" + TypeNameLower + @"), ActionDBTypeEnum.Delete);");
            }
            sb.AppendLine(@"            if (" + TypeNameLower + @".ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            db." + TypeName + Plurial + @".Remove(" + TypeNameLower + @");");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (!TryToSave(" + TypeNameLower + @")) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        public bool Update(" + TypeName + @" " + TypeNameLower + @")");
            sb.AppendLine(@"        {");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"            " + TypeNameLower + @".ValidationResults = Validate(new ValidationContext(" + TypeNameLower + @"), ActionDBTypeEnum.Update, AddContactTypeEnum.LoggedIn);");
            }
            else
            {
                sb.AppendLine(@"            " + TypeNameLower + @".ValidationResults = Validate(new ValidationContext(" + TypeNameLower + @"), ActionDBTypeEnum.Update);");
            }
            sb.AppendLine(@"            if (" + TypeNameLower + @".ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            db." + TypeName + Plurial + @".Update(" + TypeNameLower + @");");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (!TryToSave(" + TypeNameLower + @")) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        public IQueryable<" + TypeName + @"> GetRead()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (GetParam.OrderAscending)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return db." + TypeName + Plurial + @".AsNoTracking();");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            else");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return db." + TypeName + Plurial + @".AsNoTracking().OrderByDescending(c => c." + TypeName + "ID);");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        public IQueryable<" + TypeName + @"> GetEdit()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (GetParam.OrderAscending)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return db." + TypeName + Plurial + @";");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            else");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return db." + TypeName + Plurial + @".OrderByDescending(c => c." + TypeName + "ID);");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Functions public Generated CRUD");
            sb.AppendLine(@"");
        }
        private void CreateClassServiceFunctionsPublicGenerateGet(Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Functions public Generated Get");
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.GetGetMethod().IsVirtual)
                {
                    continue;
                }

                if (prop.Name == "ValidationResults")
                {
                    continue;
                }

                CSSPProp csspProp = new CSSPProp();
                if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                {
                    ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                    return;
                }
                if (csspProp.IsKey)
                {
                    if (TypeName == "AspNetUser")
                    {
                        sb.AppendLine(@"        public " + TypeName + @" Get" + TypeName + @"With" + TypeName + @"ID(string Id,");
                    }
                    else
                    {
                        sb.AppendLine(@"        public " + TypeName + @" Get" + TypeName + @"With" + TypeName + @"ID(int " + TypeName + @"ID, GetParam getParam)");
                    }
                    sb.AppendLine(@"        {");
                    if (TypeName == "AspNetUser")
                    {
                        sb.AppendLine(@"            IQueryable<" + TypeName + @"> " + TypeNameLower + @"Query = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())");
                        sb.AppendLine(@"                                                where c.Id == Id");
                        sb.AppendLine(@"                                                select c);");
                    }
                    else
                    {
                        sb.AppendLine(@"            IQueryable<" + TypeName + @"> " + TypeNameLower + @"Query = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())");
                        sb.AppendLine(@"                                                where c." + TypeName + @"ID == " + TypeName + @"ID");
                        sb.AppendLine(@"                                                select c);");
                    }
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            switch (getParam.EntityQueryDetailType)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                case EntityQueryDetailTypeEnum.EntityOnly:");
                    sb.AppendLine(@"                    return " + TypeNameLower + @"Query.FirstOrDefault();");
                    sb.AppendLine(@"                case EntityQueryDetailTypeEnum.EntityWeb:");
                    if (TypeName == "AspNetUser")
                    {
                        sb.AppendLine(@"                    return null;");
                    }
                    else
                    {
                        sb.AppendLine(@"                    return Fill" + TypeName + @"Web(" + TypeNameLower + @"Query, """").FirstOrDefault();");
                    }
                    sb.AppendLine(@"                case EntityQueryDetailTypeEnum.EntityReport:");
                    if (TypeName == "AspNetUser")
                    {
                        sb.AppendLine(@"                    return null;");
                    }
                    else
                    {
                        sb.AppendLine(@"                    return Fill" + TypeName + @"Report(" + TypeNameLower + @"Query, """").FirstOrDefault();");
                    }
                    sb.AppendLine(@"                default:");
                    sb.AppendLine(@"                    return null;");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");
                    sb.AppendLine(@"        public IQueryable<" + TypeName + @"> Get" + TypeName + @"List(GetParam getParam, string FilterAndOrderText = """")");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            IQueryable<" + TypeName + @"> " + TypeNameLower + @"Query = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())");
                    sb.AppendLine(@"                                                select c);");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            switch (getParam.EntityQueryDetailType)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                case EntityQueryDetailTypeEnum.EntityOnly:");
                    sb.AppendLine(@"                    {");
                    sb.AppendLine(@"                        if (!getParam.OrderAscending)");
                    sb.AppendLine(@"                        {");
                    sb.AppendLine(@"                            " + TypeNameLower + @"Query  = " + TypeNameLower + @"Query.OrderByDescending(c => c." + TypeName + @"ID);");
                    sb.AppendLine(@"                        }");
                    sb.AppendLine(@"                        " + TypeNameLower + @"Query = " + TypeNameLower + @"Query.Skip(getParam.Skip).Take(getParam.Take);");
                    sb.AppendLine(@"                        return " + TypeNameLower + @"Query;");
                    sb.AppendLine(@"                    }");
                    sb.AppendLine(@"                case EntityQueryDetailTypeEnum.EntityWeb:");
                    if (TypeName == "AspNetUser")
                    {
                        sb.AppendLine(@"                    return null;");
                    }
                    else
                    {
                        sb.AppendLine(@"                    {");
                        sb.AppendLine(@"                        if (!getParam.OrderAscending)");
                        sb.AppendLine(@"                        {");
                        sb.AppendLine(@"                            " + TypeNameLower + @"Query = Fill" + TypeName + @"Web(" + TypeNameLower + @"Query, FilterAndOrderText).OrderByDescending(c => c." + TypeName + @"ID);");
                        sb.AppendLine(@"                        }");
                        sb.AppendLine(@"                        " + TypeNameLower + @"Query = Fill" + TypeName + @"Web(" + TypeNameLower + @"Query, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);");
                        sb.AppendLine(@"                        return " + TypeNameLower + @"Query;");
                        sb.AppendLine(@"                    }");
                    }
                    sb.AppendLine(@"                case EntityQueryDetailTypeEnum.EntityReport:");
                    if (TypeName == "AspNetUser")
                    {
                        sb.AppendLine(@"                    return null;");
                    }
                    else
                    {
                        sb.AppendLine(@"                    {");
                        sb.AppendLine(@"                        if (!getParam.OrderAscending)");
                        sb.AppendLine(@"                        {");
                        sb.AppendLine(@"                            " + TypeNameLower + @"Query = Fill" + TypeName + @"Report(" + TypeNameLower + @"Query, FilterAndOrderText).OrderByDescending(c => c." + TypeName + @"ID);");
                        sb.AppendLine(@"                        }");
                        sb.AppendLine(@"                        " + TypeNameLower + @"Query = Fill" + TypeName + @"Report(" + TypeNameLower + @"Query, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);");
                        sb.AppendLine(@"                        return " + TypeNameLower + @"Query;");
                        sb.AppendLine(@"                    }");
                    }
                    sb.AppendLine(@"                default:");
                    sb.AppendLine(@"                    return null;");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");
                }
            }
            sb.AppendLine(@"        #endregion Functions public Generated Get");
            sb.AppendLine(@"");
        }
        private void CreateValidation_AfterYear(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.Year != null)
            {
                if (csspProp.IsNullable == true)
                {
                    sb.AppendLine(@"            if (" + TypeNameLower + "." + csspProp.PropName + " != null && ((DateTime)" + TypeNameLower + "." + csspProp.PropName + ").Year < " + csspProp.Year + ")");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                " + TypeNameLower + ".HasErrors = true;");
                    sb.AppendLine(@"                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Year + @"""), new[] { CSSPModelsRes." + TypeName + csspProp.PropName + " });");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
            }
        }
        private void CreateValidation_Bigger(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(csspProp.OtherField))
            {
                sb.AppendLine(@"            if (" + TypeNameLower + "." + csspProp.OtherField + " > " + TypeNameLower + "." + csspProp.PropName + ")");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                " + TypeNameLower + ".HasErrors = true;");
                sb.AppendLine(@"                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, CSSPModelsRes." + TypeName + csspProp.PropName + ", CSSPModelsRes." + TypeName + csspProp.OtherField + "), new[] { CSSPModelsRes." + TypeName + csspProp.PropName + " });");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
            }
        }
        private void CreateValidation_Email(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.dataType == DataType.EmailAddress)
            {
                sb.AppendLine(@"            if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @"))");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                Regex regex = new Regex(@""^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$"");");
                sb.AppendLine(@"                if (!regex.IsMatch(" + TypeNameLower + @"." + prop.Name + @"))");
                sb.AppendLine(@"                {");
                sb.AppendLine(@"                    " + TypeNameLower + ".HasErrors = true;");
                sb.AppendLine(@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotAValidEmail, CSSPModelsRes." + TypeName + prop.Name + @"), new[] { """ + csspProp.PropName + @""" });");
                sb.AppendLine(@"                }");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
            }
        }
        private void CreateValidation_EnumType(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.HasCSSPEnumTypeAttribute)
            {
                if (csspProp.IsNullable)
                {
                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" != null)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                retStr = enums.EnumTypeOK(typeof(" + csspProp.PropType + @"), (int?)" + TypeNameLower + @"." + prop.Name + @");");
                    sb.AppendLine(@"                if (" + TypeNameLower + @"." + prop.Name + @" == " + csspProp.PropType + ".Error || !string.IsNullOrWhiteSpace(retStr))");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    " + TypeNameLower + ".HasErrors = true;");
                    sb.AppendLine(@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes." + TypeName + prop.Name + @"), new[] { """ + csspProp.PropName + @""" });");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
                else
                {
                    sb.AppendLine(@"            retStr = enums.EnumTypeOK(typeof(" + csspProp.PropType + @"), (int?)" + TypeNameLower + @"." + prop.Name + @");");
                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" == " + prop.PropertyType.Name + @".Error || !string.IsNullOrWhiteSpace(retStr))");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                " + TypeNameLower + ".HasErrors = true;");
                    sb.AppendLine(@"                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes." + TypeName + prop.Name + @"), new[] { """ + csspProp.PropName + @""" });");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
            }
        }
        private void CreateValidation_Length(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!csspProp.IsKey)
            {
                switch (csspProp.PropType)
                {
                    case "Boolean":
                        {
                            // nothing
                        }
                        break;
                    case "DateTime":
                    case "DateTimeOffset":
                        {
                            // nothing
                        }
                        break;
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "Single":
                    case "Double":
                        {
                            if (csspProp.Min == null && csspProp.Max == null)
                            {
                                if (!csspProp.HasCSSPExistAttribute)
                                {
                                    sb.AppendLine(@"            //" + prop.Name + @" has no Range Attribute");
                                    sb.AppendLine(@"");
                                }
                            }
                            else if (csspProp.Min != null && csspProp.Max != null)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine(@"            " + prop.Name + @" = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    if (csspProp.IsNullable)
                                    {
                                        sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" != null)");
                                        sb.AppendLine(@"            {");
                                        sb.AppendLine(@"                if (" + TypeNameLower + @"." + csspProp.PropName + @" < " + csspProp.Min.ToString() + @" || " + TypeNameLower + @"." + csspProp.PropName + @" > " + csspProp.Max.ToString() + @")");
                                        sb.AppendLine(@"                {");
                                        sb.AppendLine(@"                    " + TypeNameLower + ".HasErrors = true;");
                                        sb.AppendLine(@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Min.ToString() + @""", """ + csspProp.Max.ToString() + @"""), new[] { """ + csspProp.PropName + @""" });");
                                        sb.AppendLine(@"                }");
                                        sb.AppendLine(@"            }");
                                        sb.AppendLine(@"");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" < " + csspProp.Min.ToString() + @" || " + TypeNameLower + @"." + csspProp.PropName + @" > " + csspProp.Max.ToString() + @")");
                                        sb.AppendLine(@"            {");
                                        sb.AppendLine(@"                " + TypeNameLower + ".HasErrors = true;");
                                        sb.AppendLine(@"                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Min.ToString() + @""", """ + csspProp.Max.ToString() + @"""), new[] { """ + csspProp.PropName + @""" });");
                                        sb.AppendLine(@"            }");
                                        sb.AppendLine(@"");
                                    }
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                if (csspProp.IsNullable)
                                {
                                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" != null)");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine(@"                if (" + TypeNameLower + @"." + csspProp.PropName + @" < " + csspProp.Min.ToString() + @")");
                                    sb.AppendLine(@"                {");
                                    sb.AppendLine(@"                    " + TypeNameLower + ".HasErrors = true;");
                                    sb.AppendLine(@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Min.ToString() + @"""), new[] { """ + csspProp.PropName + @""" });");
                                    sb.AppendLine(@"                }");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                                else
                                {
                                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" < " + csspProp.Min.ToString() + @")");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine(@"                " + TypeNameLower + ".HasErrors = true;");
                                    sb.AppendLine(@"                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Min.ToString() + @"""), new[] { """ + csspProp.PropName + @""" });");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }

                            }
                            else if (csspProp.Max != null)
                            {
                                if (csspProp.IsNullable)
                                {
                                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" != null)");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine(@"                if (" + TypeNameLower + @"." + csspProp.PropName + @" > " + csspProp.Max.ToString() + @")");
                                    sb.AppendLine(@"                {");
                                    sb.AppendLine(@"                    " + TypeNameLower + ".HasErrors = true;");
                                    sb.AppendLine(@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._MaxValueIs_, CSSPModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Max.ToString() + @"""), new[] { """ + csspProp.PropName + @""" });");
                                    sb.AppendLine(@"                }");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                                else
                                {
                                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" > " + csspProp.Max.ToString() + @")");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine(@"                " + TypeNameLower + ".HasErrors = true;");
                                    sb.AppendLine(@"                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxValueIs_, CSSPModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Max.ToString() + @"""), new[] { """ + csspProp.PropName + @""" });");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                            }
                            else
                            {
                                sb.AppendLine(@"                " + prop.Name + @" = CreateValidationNotRequiredLengths_ConditionShouldNotHappenIn_Int,");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    case "String":
                        {
                            if (csspProp.Min == null && csspProp.Max == null)
                            {
                                sb.AppendLine(@"            //" + prop.Name + @" has no StringLength Attribute");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.Min != null && csspProp.Max != null)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine(@"            " + prop.Name + @" = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    sb.AppendLine(@"            if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @") && (" + TypeNameLower + @"." + csspProp.PropName + @".Length < " + csspProp.Min.ToString() + @" || " + TypeNameLower + @"." + csspProp.PropName + @".Length > " + csspProp.Max.ToString() + @"))");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine(@"                " + TypeNameLower + ".HasErrors = true;");
                                    sb.AppendLine(@"                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Min.ToString() + @""", """ + csspProp.Max.ToString() + @"""), new[] { """ + csspProp.PropName + @""" });");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                sb.AppendLine(@"            if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @") && " + TypeNameLower + @"." + csspProp.PropName + @".Length < " + csspProp.Min.ToString() + @")");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                " + TypeNameLower + ".HasErrors = true;");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(CSSPServicesRes._MinLengthIs_, CSSPModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Min.ToString() + @"""), new[] { """ + csspProp.PropName + @""" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.Max != null)
                            {
                                sb.AppendLine(@"            if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @") && " + TypeNameLower + @"." + csspProp.PropName + @".Length > " + csspProp.Max.ToString() + @")");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                " + TypeNameLower + ".HasErrors = true;");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Max.ToString() + @"""), new[] { """ + csspProp.PropName + @""" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else
                            {
                                sb.AppendLine(@"            // " + prop.Name + @" has no validation");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    default:
                        {
                            if (csspProp.PropName.EndsWith("Web") || csspProp.PropName.EndsWith("Report"))
                            {
                                // nothing yet
                            }
                            else
                            {
                                if (!csspProp.HasCSSPEnumTypeAttribute)
                                {
                                    sb.AppendLine(@"                //Error: Type not implemented [" + csspProp.PropName + "] of type [" + csspProp.PropType + "]");
                                }
                            }
                        }
                        break;
                }
            }
        }
        private void CreateValidation_NotNullable(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!csspProp.IsNullable)
                switch (prop.PropertyType.Name)
                {
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "Single":
                    case "Double":
                        {
                            //sb.AppendLine(@"            //" + prop.Name + @" (" + prop.PropertyType.Name + @") is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D");
                            //sb.AppendLine(@"");
                        }
                        break;
                    case "Boolean":
                        {
                            if (csspProp.PropName == "HasErrors")
                            {
                                // nothing yet
                            }
                            else
                            {
                                //sb.AppendLine(@"            //" + prop.Name + @" (bool) is required but no testing needed ");
                                //sb.AppendLine(@"");
                            }
                        }
                        break;
                    case "DateTime":
                    case "DateTimeOffset":
                        {
                            sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @".Year == 1)");
                            sb.AppendLine(@"            {");
                            sb.AppendLine(@"                " + TypeNameLower + ".HasErrors = true;");
                            sb.AppendLine(@"                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes." + TypeName + prop.Name + @"), new[] { """ + csspProp.PropName + @""" });");
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"            else");
                            sb.AppendLine(@"            {");
                            sb.AppendLine(@"                if (" + TypeNameLower + @"." + prop.Name + @".Year < " + csspProp.Year + ")");
                            sb.AppendLine(@"                {");
                            sb.AppendLine(@"                " + TypeNameLower + ".HasErrors = true;");
                            sb.AppendLine(@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes." + TypeName + prop.Name + @", """ + csspProp.Year + @"""), new[] { """ + csspProp.PropName + @""" });");
                            sb.AppendLine(@"                }");
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"");
                        }
                        break;
                    case "String":
                        {
                            if (!csspProp.IsKey)
                            {
                                sb.AppendLine(@"            if (string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @"))");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                " + TypeNameLower + ".HasErrors = true;");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes." + TypeName + prop.Name + @"), new[] { """ + csspProp.PropName + @""" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    default:
                        {
                            if (!csspProp.HasCSSPEnumTypeAttribute)
                            {
                                sb.AppendLine(@"                //Error: Type not implemented [" + prop.Name + "] of type [" + prop.PropertyType.Name + "]");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                }
        }
        private void CreateValidation_Key(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (prop.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("KeyAttribute")).Any())
            {
                sb.AppendLine(@"            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)");
                sb.AppendLine(@"            {");
                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine(@"                if (" + TypeNameLower + @"." + prop.Name + @" == """")");
                }
                else
                {
                    sb.AppendLine(@"                if (" + TypeNameLower + @"." + prop.Name + @" == 0)");
                }
                sb.AppendLine(@"                {");
                sb.AppendLine(@"                    " + TypeNameLower + ".HasErrors = true;");
                sb.AppendLine(@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes." + TypeName + prop.Name + @"), new[] { """ + csspProp.PropName + @""" });");
                sb.AppendLine(@"                }");
                sb.AppendLine(@"");
                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine(@"                if (!GetRead().Where(c => c.Id == " + TypeNameLower + @".Id).Any())");
                }
                else
                {
                    sb.AppendLine(@"                if (!GetRead().Where(c => c." + TypeName + @"ID == " + TypeNameLower + @"." + TypeName + @"ID).Any())");
                }
                sb.AppendLine(@"                {");
                sb.AppendLine(@"                    " + TypeNameLower + ".HasErrors = true;");
                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine(@"                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes." + TypeName + @", CSSPModelsRes." + TypeName + @"Id, (" + TypeNameLower + @".Id == null ? """" : " + TypeNameLower + @".Id.ToString())), new[] { """ + csspProp.PropName + @""" });");
                }
                else
                {
                    sb.AppendLine(@"                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes." + TypeName + @", CSSPModelsRes." + TypeName + TypeName + @"ID, " + TypeNameLower + @"." + TypeName + @"ID.ToString()), new[] { """ + csspProp.PropName + @""" });");
                }
                sb.AppendLine(@"                }");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");

                if (TypeName == "TVItem")
                {
                    sb.AppendLine(@"            if (tvItem.TVType == TVTypeEnum.Root)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                if (GetRead().Count() > 0)");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    " + TypeNameLower + ".HasErrors = true;");
                    sb.AppendLine(@"                    yield return new ValidationResult(CSSPServicesRes.TVItemRootShouldBeTheFirstOneAdded, new[] { CSSPModelsRes.TVItemTVItemID });");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }

            }
        }
        private void CreateValidation_Exist(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(csspProp.ExistTypeName) && !string.IsNullOrWhiteSpace(csspProp.ExistPlurial) && !string.IsNullOrWhiteSpace(csspProp.ExistFieldID))
            {
                if (TypeName == "TVItem" && (csspProp.PropName == "ParentID" || csspProp.PropName == "LastUpdateContactTVItemID"))
                {
                    sb.AppendLine(@"            if (tvItem.TVType != TVTypeEnum.Root)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                " + csspProp.ExistTypeName + " " + csspProp.ExistTypeName + csspProp.PropName + " = (from c in db." + csspProp.ExistTypeName + csspProp.ExistPlurial + " where c." + csspProp.ExistFieldID + " == " + TypeNameLower + "." + csspProp.PropName + " select c).FirstOrDefault();");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"                if (" + csspProp.ExistTypeName + csspProp.PropName + " == null)");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    " + TypeNameLower + ".HasErrors = true;");
                    sb.AppendLine(@"                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes." + csspProp.ExistTypeName + ", CSSPModelsRes." + TypeName + csspProp.PropName + ", " + TypeNameLower + "." + csspProp.PropName + @".ToString()), new[] { """ + csspProp.PropName + @""" });");
                    sb.AppendLine(@"                }");
                    if (csspProp.ExistTypeName == "TVItem")
                    {
                        sb.AppendLine(@"                else");
                        sb.AppendLine(@"                {");
                        sb.AppendLine(@"                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                        sb.AppendLine(@"                    {");
                        foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                        {
                            sb.AppendLine(@"                        TVTypeEnum." + tvType.ToString() + ",");
                        }
                        sb.AppendLine(@"                    };");
                        sb.AppendLine(@"                    if (!AllowableTVTypes.Contains(" + csspProp.ExistTypeName + csspProp.PropName + ".TVType))");
                        sb.AppendLine(@"                    {");
                        sb.AppendLine(@"                        " + TypeNameLower + ".HasErrors = true;");
                        sb.AppendLine(@"                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes." + TypeName + csspProp.PropName + @", """ + String.Join(",", csspProp.AllowableTVTypeList) + @"""), new[] { """ + csspProp.PropName + @""" });");
                        sb.AppendLine(@"                    }");
                        sb.AppendLine(@"                }");
                    }
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
                else
                {
                    if (csspProp.IsNullable)
                    {
                        sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" != null)");
                        sb.AppendLine(@"            {");
                        sb.AppendLine(@"                " + csspProp.ExistTypeName + " " + csspProp.ExistTypeName + csspProp.PropName + " = (from c in db." + csspProp.ExistTypeName + csspProp.ExistPlurial + " where c." + csspProp.ExistFieldID + " == " + TypeNameLower + "." + csspProp.PropName + " select c).FirstOrDefault();");
                        sb.AppendLine(@"");
                        sb.AppendLine(@"                if (" + csspProp.ExistTypeName + csspProp.PropName + " == null)");
                        sb.AppendLine(@"                {");
                        sb.AppendLine(@"                    " + TypeNameLower + ".HasErrors = true;");
                        sb.AppendLine(@"                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes." + csspProp.ExistTypeName + ", CSSPModelsRes." + TypeName + csspProp.PropName + ", (" + TypeNameLower + "." + csspProp.PropName + @" == null ? """" : " + TypeNameLower + "." + csspProp.PropName + @".ToString())), new[] { """ + csspProp.PropName + @""" });");
                        sb.AppendLine(@"                }");
                        if (csspProp.ExistTypeName == "TVItem")
                        {
                            sb.AppendLine(@"                else");
                            sb.AppendLine(@"                {");
                            sb.AppendLine(@"                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                            sb.AppendLine(@"                    {");
                            foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                            {
                                sb.AppendLine(@"                        TVTypeEnum." + tvType.ToString() + ",");
                            }
                            sb.AppendLine(@"                    };");
                            sb.AppendLine(@"                    if (!AllowableTVTypes.Contains(" + csspProp.ExistTypeName + csspProp.PropName + ".TVType))");
                            sb.AppendLine(@"                    {");
                            sb.AppendLine(@"                        " + TypeNameLower + ".HasErrors = true;");
                            sb.AppendLine(@"                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes." + TypeName + csspProp.PropName + @", """ + String.Join(",", csspProp.AllowableTVTypeList) + @"""), new[] { """ + csspProp.PropName + @""" });");
                            sb.AppendLine(@"                    }");
                            sb.AppendLine(@"                }");
                        }
                        sb.AppendLine(@"            }");
                        sb.AppendLine(@"");
                    }
                    else
                    {
                        sb.AppendLine(@"            " + csspProp.ExistTypeName + " " + csspProp.ExistTypeName + csspProp.PropName + " = (from c in db." + csspProp.ExistTypeName + csspProp.ExistPlurial + " where c." + csspProp.ExistFieldID + " == " + TypeNameLower + "." + csspProp.PropName + " select c).FirstOrDefault();");
                        sb.AppendLine(@"");
                        sb.AppendLine(@"            if (" + csspProp.ExistTypeName + csspProp.PropName + " == null)");
                        sb.AppendLine(@"            {");
                        sb.AppendLine(@"                " + TypeNameLower + ".HasErrors = true;");
                        sb.AppendLine(@"                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes." + csspProp.ExistTypeName + ", CSSPModelsRes." + TypeName + csspProp.PropName + ", (" + TypeNameLower + "." + csspProp.PropName + @" == null ? """" : " + TypeNameLower + "." + csspProp.PropName + @".ToString())), new[] { """ + csspProp.PropName + @""" });");
                        sb.AppendLine(@"            }");
                        if (csspProp.ExistTypeName == "TVItem")
                        {
                            sb.AppendLine(@"            else");
                            sb.AppendLine(@"            {");
                            sb.AppendLine(@"                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                            sb.AppendLine(@"                {");
                            foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                            {
                                sb.AppendLine(@"                    TVTypeEnum." + tvType.ToString() + ",");
                            }
                            sb.AppendLine(@"                };");
                            sb.AppendLine(@"                if (!AllowableTVTypes.Contains(" + csspProp.ExistTypeName + csspProp.PropName + ".TVType))");
                            sb.AppendLine(@"                {");
                            sb.AppendLine(@"                    " + TypeNameLower + ".HasErrors = true;");
                            sb.AppendLine(@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes." + TypeName + csspProp.PropName + @", """ + String.Join(",", csspProp.AllowableTVTypeList) + @"""), new[] { """ + csspProp.PropName + @""" });");
                            sb.AppendLine(@"                }");
                            sb.AppendLine(@"            }");
                        }
                        sb.AppendLine(@"");
                    }
                }
            }
        }
        #endregion Functions private

        #region Functions public
        public void GenerateCodeOf_ClassServiceGenerated()
        {
            FileInfo fiDLL = new FileInfo(@"C:\CSSP Code\CSSPModels\CSSPModels\bin\Debug\CSSPModels.dll");

            if (!fiDLL.Exists)
            {
                ErrorEvent(new ErrorEventArgs(fiDLL.FullName + " does not exist"));
                return;
            }

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                bool ClassNotMapped = false;
                StringBuilder sb = new StringBuilder();
                string TypeName = type.Name;
                //IEntityType entityType = null;

                string TypeNameLower = "";

                if (type.Name.StartsWith("MWQM"))
                {
                    TypeNameLower = type.Name.Substring(0, 4).ToLower() + type.Name.Substring(4);
                }
                else if (type.Name.StartsWith("TV") || type.Name.StartsWith("VP"))
                {
                    TypeNameLower = type.Name.Substring(0, 2).ToLower() + type.Name.Substring(2);
                }
                else
                {
                    TypeNameLower = type.Name.Substring(0, 1).ToLower() + type.Name.Substring(1);
                }

                StatusTempEvent(new StatusEventArgs(TypeName));
                Application.DoEvents();

                if (modelsGenerateCodeHelper.SkipType(type))
                {
                    continue;
                }

                //if (type.Name != "Address")
                //{
                //    continue;
                //}

                foreach (CustomAttributeData customAttributeData in type.CustomAttributes)
                {
                    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                    {
                        ClassNotMapped = true;
                        break;
                    }
                }

                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using CSSPModels;");
                sb.AppendLine(@"using CSSPModels.Resources;");
                sb.AppendLine(@"using CSSPServices.Resources;");
                sb.AppendLine(@"using Microsoft.EntityFrameworkCore;");
                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using System.ComponentModel.DataAnnotations;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"using System.Reflection;");
                sb.AppendLine(@"using System.Security.Principal;");
                sb.AppendLine(@"using System.Text;");
                sb.AppendLine(@"using System.Text.RegularExpressions;");
                sb.AppendLine(@"using System.Threading;");
                sb.AppendLine(@"using System.Threading.Tasks;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPServices");
                sb.AppendLine(@"{");
                sb.AppendLine(@"    /// <summary>");
                sb.AppendLine(@"    ///     <para>bonjour " + TypeName + "</para>");
                sb.AppendLine(@"    /// </summary>");
                sb.AppendLine(@"    public partial class " + TypeName + @"Service : BaseService");
                sb.AppendLine(@"    {");
                sb.AppendLine(@"        #region Variables");
                sb.AppendLine(@"        #endregion Variables");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Properties");
                sb.AppendLine(@"        #endregion Properties");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Constructors");
                sb.AppendLine(@"        public " + TypeName + @"Service(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)");
                sb.AppendLine(@"            : base(getParam, db, ContactID)");
                sb.AppendLine(@"        {");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Constructors");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Validation");
                if (TypeName == "Contact")
                {
                    sb.AppendLine(@"        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType, AddContactTypeEnum addContactType)");
                }
                else
                {
                    sb.AppendLine(@"        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)");
                }
                sb.AppendLine(@"        {");
                sb.AppendLine(@"            string retStr = """";");
                sb.AppendLine(@"            Enums enums = new Enums(LanguageRequest);");
                sb.AppendLine(@"            " + TypeName + @" " + TypeNameLower + @" = validationContext.ObjectInstance as " + TypeName + @";");
                sb.AppendLine(@"            " + TypeNameLower + ".HasErrors = false;");
                sb.AppendLine(@"");

                foreach (PropertyInfo prop in type.GetProperties())
                {
                    if (prop.GetGetMethod().IsVirtual)
                    {
                        continue;
                    }

                    if (prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    CSSPProp csspProp = new CSSPProp();
                    if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                    {
                        ErrorEvent(new ErrorEventArgs("Error while creating code [" + csspProp.Error + "]"));
                        return;
                    }

                    if (!ClassNotMapped)
                    {
                        CreateValidation_Key(prop, csspProp, TypeName, TypeNameLower, sb);
                    }

                    CreateValidation_NotNullable(prop, csspProp, TypeName, TypeNameLower, sb);
                    CreateValidation_Length(prop, csspProp, TypeName, TypeNameLower, sb);
                    CreateValidation_Email(prop, csspProp, TypeName, TypeNameLower, sb);
                    CreateValidation_AfterYear(prop, csspProp, TypeName, TypeNameLower, sb);
                    CreateValidation_Bigger(prop, csspProp, TypeName, TypeNameLower, sb);
                    CreateValidation_Exist(prop, csspProp, TypeName, TypeNameLower, sb);
                    CreateValidation_EnumType(prop, csspProp, TypeName, TypeNameLower, sb);
                }

                sb.AppendLine(@"            retStr = """"; // added to stop compiling error");
                sb.AppendLine(@"            if (retStr != """") // will never be true");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                " + TypeNameLower + ".HasErrors = true;");
                sb.AppendLine(@"                yield return new ValidationResult(""AAA"", new[] { ""AAA"" });");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
                sb.AppendLine(@"        }");

                sb.AppendLine(@"        #endregion Validation");
                sb.AppendLine(@"");

                if (!ClassNotMapped)
                {
                    CreateClassServiceFunctionsPublicGenerateGet(type, TypeName, TypeNameLower, sb);
                    CreateClassServiceFunctionsPublicGenerateCRUD(type, TypeName, TypeNameLower, sb);
                    CreateClassServiceFunctionsPrivateRegionFillClassWeb(type, types, TypeName, TypeNameLower, sb);
                    //CreateClassServiceFunctionsPrivateRegionFillClassReport(type, types, TypeName, TypeNameLower, sb);
                    CreateClassServiceFunctionsPrivateRegionTrySave(type, TypeName, TypeNameLower, sb);
                }

                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                FileInfo fiOutputGen = new FileInfo(@"C:\CSSP Code\CSSPServices\CSSPServices\" + TypeName + "ServiceGenerated.cs");
                using (StreamWriter sw2 = fiOutputGen.CreateText())
                {
                    sw2.Write(sb.ToString());
                }

                ErrorEvent(new ErrorEventArgs("Created [" + fiOutputGen.FullName + "] ..."));

                StatusTempEvent(new StatusEventArgs("Done ..."));
            }
        }
        #endregion Functions public
    }
}
