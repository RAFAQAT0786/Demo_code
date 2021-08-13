using System;
using System.Linq;
using System.Runtime.Serialization;

public enum Orientation
{
    Portrait,
    Landscape
}

public enum Month
{
    [EnumMember(Value = "JAN")]
    January = 1,

    [EnumMember(Value = "FEB")]
    February = 2,

    [EnumMember(Value = "MAR")]
    March = 3,

    [EnumMember(Value = "APR")]
    April = 4,

    [EnumMember(Value = "MAY")]
    May = 5,

    [EnumMember(Value = "JUN")]
    June = 6,

    [EnumMember(Value = "JUL")]
    July = 7,

    [EnumMember(Value = "AUG")]
    August = 8,

    [EnumMember(Value = "SEP")]
    September = 9,

    [EnumMember(Value = "OCT")]
    October = 10,

    [EnumMember(Value = "NOV")]
    November = 11,

    [EnumMember(Value = "DEC")]
    December = 12
}

public class EnumHelper
{
    public static string GetEnumMemberAttrValue(Type enumType, object enumVal)
    {
        var memInfo = enumType.GetMember(enumVal.ToString());
        var attr = memInfo[0].GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
        if (attr != null)
        {
            return attr.Value;
        }

        return null;
    }

    public static T ToEnum<T>(object str)
    {
        var enumType = typeof(T);
        foreach (var name in Enum.GetNames(enumType))
        {
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            if (enumMemberAttribute.Value == str.ToString()) return (T)Enum.Parse(enumType, name);
        }
        return default(T);
    }

    public static string ToEnumString<T>(T instance)
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("instance", "Must be enum type");
        string enumString = instance.ToString();
        var field = typeof(T).GetField(enumString);
        if (field != null) // instance can be a number that was cast to T, instead of a named value, or could be a combination of flags instead of a single value
        {
            var attr = (EnumMemberAttribute)field.GetCustomAttributes(typeof(EnumMemberAttribute), false).SingleOrDefault();
            if (attr != null) // if there's no EnumMember attr, use the default value
                enumString = attr.Value;
        }
        return enumString;
    }

    public static int EnumStringToInt<T>(string value)
    {
        return (int)Enum.Parse(typeof(T), value);
    }
}