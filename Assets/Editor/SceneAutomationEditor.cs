using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SceneAutomation))]
public class SceneAutomationEditor : Editor
{
    SerializedProperty sceneEditor;

    private void OnEnable()
    {
        sceneEditor = serializedObject.FindProperty("sceneEditor");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        SceneAutomation prefabAutomation = (SceneAutomation)target;

        EditorGUILayout.PropertyField(sceneEditor);


        if (GUILayout.Button("Automate", GUILayout.Height(50)))
        {
            prefabAutomation.AccessAndModify();
        }

        serializedObject.ApplyModifiedProperties();
    }
}
