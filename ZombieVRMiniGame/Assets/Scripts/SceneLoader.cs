using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{
    //singleton for other functions
    public static SceneLoader instance;

    public OVROverlay Overlay_background;
    public OVROverlay Overlay_text;


    private void Awake()
    {
        if(instance!=null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        //With this way we can go back from scene
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {

        }
    public void LoadScene(string SceneName)
    {
        
        StartCoroutine(ShowOverlayAndLoad(SceneName));

    }

    IEnumerator ShowOverlayAndLoad(string SceneName)
    {

        Overlay_background.enabled = true;
        Overlay_text.enabled = true;

        GameObject centerEyeAnchor = GameObject.Find("CenterEyeAnchor");
        
        Overlay_text.gameObject.transform.position = centerEyeAnchor.transform.position + new Vector3(0f, 0f, 3f);
        Overlay_text.gameObject.transform.rotation = centerEyeAnchor.transform.rotation;
        yield return new WaitForSeconds(3f);
        AsyncOperation asyncload = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneName);

        while (!asyncload.isDone)
        {
            yield return null;
        }

       
        //Disable because its finished
        Overlay_text.enabled = false;
        Overlay_background.enabled = false;
        yield return null;
    }
}
