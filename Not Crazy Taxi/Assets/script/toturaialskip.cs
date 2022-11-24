using UnityEngine.SceneManagement;
using UnityEngine;

public class toturaialskip : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Invoke("Delaytoturial", 3f);
    }
    public void Delaytoturial()
    {
        SceneManager.LoadScene(1);
    }

}
