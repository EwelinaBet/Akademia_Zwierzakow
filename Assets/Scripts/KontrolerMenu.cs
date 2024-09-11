using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KontrolerMenu : MonoBehaviour
{
    public void NowaGra()
    {
        StartCoroutine(KorutynaNowaGra());
    }

    public IEnumerator KorutynaNowaGra()
    {
        yield return new WaitForSeconds(0.4f);

        SceneManager.LoadScene("Gra");
    }

    public void Wyjscie()
    {
        StartCoroutine(KorutynaWyjscie());
    }

    public IEnumerator KorutynaWyjscie()
    {
        yield return new WaitForSeconds(0.4f);

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
