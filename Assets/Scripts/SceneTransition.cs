using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]private string str;
    [SerializeField]private Canvas canvas;
    [SerializeField]private Scene unload_scene;

    private void Start()
    {
    }

    public void Transtion()
    {
        if (str != null)
        {
            StartCoroutine(LoadAsync());
        } else
        {
            Debug.Log("シーン名を記入してください。");
        }
    }

    IEnumerator LoadAsync()
    {
        //現在のシーンをunloadに設定
        unload_scene = SceneManager.GetActiveScene();
        //次のシーンをロードして現在のシーンをアンロードする
        yield return SceneManager.LoadSceneAsync(str, LoadSceneMode.Additive);
        yield return SceneManager.UnloadSceneAsync(unload_scene);
    }

    public void CoverCanvas()
    {
        if (canvas != null)
        {
            canvas.enabled = true;
            StartCoroutine(Wait(2.0f));
            //Transtion();
        } else
        {
            Debug.Log("キャンバスを設定してください。");
        }
    }

    IEnumerator Wait(float f)
    {
        yield return new WaitForSeconds(f);
        Transtion();
    }
}
