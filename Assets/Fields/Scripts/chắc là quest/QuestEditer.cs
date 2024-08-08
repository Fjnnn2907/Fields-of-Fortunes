using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Quest))]
public class QuestDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty questName = property.FindPropertyRelative("questName");
        SerializedProperty questDescription = property.FindPropertyRelative("questDescription");
        SerializedProperty dialogueLines = property.FindPropertyRelative("dialogueLines");
        SerializedProperty rewards = property.FindPropertyRelative("rewards");
        SerializedProperty questType = property.FindPropertyRelative("questType");
        SerializedProperty enemyToKill = property.FindPropertyRelative("enemyToKill");
        SerializedProperty killCount = property.FindPropertyRelative("killCount");
        SerializedProperty itemsToCollect = property.FindPropertyRelative("itemsToCollect");

        Rect singleFieldRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(singleFieldRect, questName);
        singleFieldRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        EditorGUI.PropertyField(singleFieldRect, questDescription);
        singleFieldRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        EditorGUI.PropertyField(singleFieldRect, dialogueLines, true);
        singleFieldRect.y += EditorGUI.GetPropertyHeight(dialogueLines) + EditorGUIUtility.standardVerticalSpacing;
        EditorGUI.PropertyField(singleFieldRect, rewards, true);
        singleFieldRect.y += EditorGUI.GetPropertyHeight(rewards) + EditorGUIUtility.standardVerticalSpacing;
        EditorGUI.PropertyField(singleFieldRect, questType);
        singleFieldRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

        Quest.QuestType type = (Quest.QuestType)questType.enumValueIndex;

        if (type == Quest.QuestType.Kill)
        {
            EditorGUI.PropertyField(singleFieldRect, enemyToKill);
            singleFieldRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            EditorGUI.PropertyField(singleFieldRect, killCount);
        }
        else if (type == Quest.QuestType.Collect)
        {
            EditorGUI.PropertyField(singleFieldRect, itemsToCollect, true);
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        SerializedProperty dialogueLines = property.FindPropertyRelative("dialogueLines");
        SerializedProperty rewards = property.FindPropertyRelative("rewards");
        SerializedProperty questType = property.FindPropertyRelative("questType");
        SerializedProperty itemsToCollect = property.FindPropertyRelative("itemsToCollect");

        float height = EditorGUIUtility.singleLineHeight * 4 + EditorGUI.GetPropertyHeight(dialogueLines) + EditorGUI.GetPropertyHeight(rewards) + EditorGUIUtility.standardVerticalSpacing * 5;

        Quest.QuestType type = (Quest.QuestType)questType.enumValueIndex;
        if (type == Quest.QuestType.Kill)
        {
            height += EditorGUIUtility.singleLineHeight * 2 + EditorGUIUtility.standardVerticalSpacing * 2;
        }
        else if (type == Quest.QuestType.Collect)
        {
            height += EditorGUI.GetPropertyHeight(itemsToCollect) + EditorGUIUtility.standardVerticalSpacing;
        }

        return height;
    }
}
