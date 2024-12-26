using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "End")
        {
            SceneManager.LoadScene("Win_Scene"); // استبدل "WinScene" باسم مشهد الفوز الخاص بك
        }
    }
}