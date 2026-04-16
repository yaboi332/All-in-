using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndTurnButton : MonoBehaviour
{   
    public Button button;
    public TextMeshProUGUI buttonText;
    public BattleManager battleManager;

    public void SwitchToContinue()
    {
        buttonText.text = "Return";
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(battleManager.OnContinueButton);
    }
}