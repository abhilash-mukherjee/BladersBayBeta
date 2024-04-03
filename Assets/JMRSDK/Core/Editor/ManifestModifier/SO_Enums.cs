using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[Serializable]
[Flags]
public enum DeviceType
{
    PRO = 0,
    JIO_GLASS = 1,
    JIO_DIVE = 2,
    HOLOBOARD = 3
}


[Serializable]
public enum Categories
{
    Entertainment = 0,
    Gaming = 1,
    Learning = 2,
    Productivity = 3,
    Utilities = 4,
    Health_And_Wellness = 5,
    Shopping = 6,
    Miscellaneous = 7
}


[Serializable]
[Flags]
public enum InteractionType
{
    Controller = 0,
    GazeAndClick = 1,
    GazeAndDwell = 2
}


public class EnumFlagsAttribute : PropertyAttribute
{
    public EnumFlagsAttribute()
    {
    }
}

[CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
public class EnumFlagsAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        _property.intValue = EditorGUI.MaskField(_position, _label, _property.intValue, _property.enumNames);
    }
}

public static class EnumExtention
{
    public static T SetFlag<T>(this Enum value, T flag, bool set)
    {
        Type underlyingType = Enum.GetUnderlyingType(value.GetType());

        dynamic valueAsInt = Convert.ChangeType(value, underlyingType);
        dynamic flagAsInt = Convert.ChangeType(flag, underlyingType);
        if (set)
        {
            valueAsInt |= flagAsInt;
        }
        else
        {
            valueAsInt &= ~flagAsInt;
        }

        return (T)valueAsInt;
    }
}


