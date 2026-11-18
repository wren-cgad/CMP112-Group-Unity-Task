using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class RetryScreen : MonoBehaviour
{
    private bool canRetry = false;
    public TextMeshProUGUI retryText;
    // Update is called once per frame
    void Update()
    {
        if (canRetry){
            if (Input.GetKey(KeyCode.R)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    public void setRetry(){
        canRetry = true;
        retryText.enabled = true;
    }
}
