using CSSPEnums;
using CSSPModels;

namespace CSSPServices
{
    public static class ExtentionEnumCasting
    {
        public static object GetEnumCasting(WhereInfo whereInfo)
        {
            switch (whereInfo.EnumType.Name)
            {
                case "TVTypeEnum":
                    return (TVTypeEnum)whereInfo.ValueInt;
                default:
                    return null;
            }
        }
    }
}
