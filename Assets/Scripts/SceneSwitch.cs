using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SwitchScene(string scene_)
    {
        SceneManager.LoadScene(scene_);
    }
}
