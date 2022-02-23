using UnityEditor;
using UnityEngine;

namespace Xunity.Editor.Drawers
{
	[CustomPropertyDrawer(typeof(RangedFloat), true)]
	public class RangedFloatDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			label = EditorGUI.BeginProperty(position, label, property);
			position = EditorGUI.PrefixLabel(position, label);

			SerializedProperty minProp = property.FindPropertyRelative("min");
			SerializedProperty maxProp = property.FindPropertyRelative("max");

			float minValue = minProp.floatValue;
			float maxValue = maxProp.floatValue;

			float rangeMin = 0;
			float rangeMax = 1;

			var ranges = (MinMaxRangeAttribute[])fieldInfo.GetCustomAttributes(typeof (MinMaxRangeAttribute), true);
			if (ranges.Length > 0)
			{
				rangeMin = ranges[0].Min;
				rangeMax = ranges[0].Max;
			}

			const float rangeBoundsLabelWidth = 40f;

			EditorGUI.BeginChangeCheck();
			var rangeBoundsLabel1Rect = new Rect(position);
			rangeBoundsLabel1Rect.width = rangeBoundsLabelWidth;
			//GUI.Label(rangeBoundsLabel1Rect, new GUIContent(minValue.ToString("F2")));
			minValue = EditorGUI.FloatField(rangeBoundsLabel1Rect, minValue);
			position.xMin += rangeBoundsLabelWidth;

			var rangeBoundsLabel2Rect = new Rect(position);
			rangeBoundsLabel2Rect.xMin = rangeBoundsLabel2Rect.xMax - rangeBoundsLabelWidth;
			//GUI.Label(rangeBoundsLabel2Rect, new GUIContent(maxValue.ToString("F2")));
			maxValue = EditorGUI.FloatField(rangeBoundsLabel2Rect, maxValue);
			position.xMax -= rangeBoundsLabelWidth;

			EditorGUI.MinMaxSlider(position, ref minValue, ref maxValue, rangeMin, rangeMax);
			if (EditorGUI.EndChangeCheck())
			{
				minProp.floatValue = Mathf.Clamp(minValue, rangeMin, rangeMax);
				maxProp.floatValue = Mathf.Clamp(maxValue, rangeMin, rangeMax);
			}

			EditorGUI.EndProperty();
		}
	}
}
