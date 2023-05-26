using System;
using System.Collections.Generic;
using UnityEngine;

public enum OperatorType
{
    [Operator("==")]
    Equal,
    [Operator("!=")]
    NotEqual,
    [Operator(">")]
    GreaterThan,
    [Operator("<")]
    LessThan
}

public class OperatorAttribute : Attribute
{
    public string Operator { get; }

    public OperatorAttribute(string op)
    {
        Operator = op;
    }
}

public static class OperatorMapper
{
    private static readonly Dictionary<OperatorType, string> operatorMap = new Dictionary<OperatorType, string>();

    static OperatorMapper()
    {
        var enumType = typeof(OperatorType);
        var enumValues = Enum.GetValues(enumType) as OperatorType[];

        foreach (var value in enumValues)
        {
            var fieldInfo = enumType.GetField(value.ToString());
            var attribute = fieldInfo.GetCustomAttributes(typeof(OperatorAttribute), false) as OperatorAttribute[];

            if (attribute != null && attribute.Length > 0)
            {
                operatorMap[value] = attribute[0].Operator;
            }
            else
            {
                operatorMap[value] = value.ToString(); // Use the enum value as the default operator
            }
        }
    }

    public static string GetOperator(OperatorType operatorType)
    {
        if (operatorMap.ContainsKey(operatorType))
        {
            return operatorMap[operatorType];
        }

        Debug.LogError($"Operator mapping not found for OperatorType: {operatorType}");
        return "";
    }
}