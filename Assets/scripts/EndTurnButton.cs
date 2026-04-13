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
        buttonText.text = "Continue";
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(battleManager.OnContinueButton);
    }
}