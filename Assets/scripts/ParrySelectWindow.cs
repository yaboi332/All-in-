using UnityEngine;

public class ParrySelectWindow : MonoBehaviour
{
        public GameObject popUpBox;
        public GameObject buttonBlocker;
    
    public void Start()
    {
        popUpBox.SetActive(false);
        buttonBlocker.SetActive(false);
    }

    public void PopUp()
    {
        popUpBox.SetActive(true);
        buttonBlocker.SetActive(true);
    }

    public void HidePopUp()
    {
        popUpBox.SetActive(false);
        buttonBlocker.SetActive(false);
    }

}
