using UnityEngine;

public class ParrySelectWindow : MonoBehaviour
{
        public GameObject popUpBox;
    
    public void Start()
    {
        popUpBox.SetActive(false);
    }

    public void PopUp()
    {
        popUpBox.SetActive(true);
    }

    public void HidePopUp()
    {
        popUpBox.SetActive(false);
    }

}
