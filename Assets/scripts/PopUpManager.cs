using UnityEngine;
using System.Collections;
using TMPro;

public class PopUpManager : MonoBehaviour
{
    public GameObject popUpBox;
    public TMP_Text popUpText; 

    public void PopUp(string text,float delay=5f)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        StartCoroutine(HidePopUpAfterDelay(delay));
    }

    private IEnumerator HidePopUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        popUpBox.SetActive(false);
    }
}
