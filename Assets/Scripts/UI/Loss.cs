using UnityEngine;

public class Loss : MonoBehaviour
{
    public void OpenPanel(GameObject loss)
    {
        loss.SetActive(true);
        Time.timeScale = 0;
    }
}