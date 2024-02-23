using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class triggerSceneLoad : MonoBehaviour
{
    public string scene;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(scene);
    }
}
