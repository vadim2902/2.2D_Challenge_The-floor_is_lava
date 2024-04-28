using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject LosePanel;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lava"))
        {
            EndGame();
        }
    }


    void EndGame()
    {
        LosePanel.SetActive(true);
    }
}
