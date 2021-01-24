#if UNITY_EDITOR
using UnityEngine;
using Object = UnityEngine.Object;

public class SceneAutomation : MonoBehaviour
{
    public SceneEditor sceneEditor;

    public string tagSearching;

    /// <summary>
    /// We will access to all scene objects and modify depend on OnAccessGameObject function in class SceneEditor.
    /// </summary>
    public void AccessAndModify()
    {
        Object[] objs = FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in objs)
        {
            sceneEditor.OnAccessGameObject(((MonoBehaviour)obj).gameObject);
        }
    }
}
#endif