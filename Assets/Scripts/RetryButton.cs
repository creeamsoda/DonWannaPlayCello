using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void retry()
    {
        SceneManager.LoadScene("Stage1");
    }
}
