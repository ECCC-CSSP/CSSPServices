using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CSSPServices
{
    public partial class LogService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        #endregion Validation

        #region Functions public
        //public static string GetInformation(object obj)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties().Where(c => !c.PropertyType.ToString().StartsWith("EdoodiaDBD") || !c.PropertyType.ToString().StartsWith("CSSPWebToolsDB") || !c.PropertyType.ToString().StartsWith("System.Collections")))
        //    {
        //        sb.AppendLine(string.Format("{0}\t{1}",
        //            propertyInfo.Name, propertyInfo.GetValue(obj, null)));
        //    }

        //    return sb.ToString();
        //}
        #endregion Functions public

        #region Functions private
        #endregion Functions private 
    }
}
