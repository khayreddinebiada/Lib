using UnityEngine;

public class SceneEditor : MonoBehaviour
{
    /// <summary>
    /// Here we will execute the function and will apply on the object as paramter
    /// </summary>
    /// <param name="obj"> Object will change depend on the instructions. </param>
    public void OnAccessGameObject(GameObject obj)
    {
        /// Here we will execute the functions on the Object that was entry as parameter.
        Debug.Log("Entry your instructions for automation.");
    }
}
