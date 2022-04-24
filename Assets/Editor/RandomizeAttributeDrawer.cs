using UnityEngine;
using UnityEditor;
[CustomPropertyDrawer(typeof(RandomizeAttribute))]
public class RandomizeAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        base.OnGUI(position, property, label);
    }
}
