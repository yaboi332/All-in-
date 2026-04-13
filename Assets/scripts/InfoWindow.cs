using UnityEngine;

public class InfoWindow : MonoBehaviour
{
    public GameObject infoPanel;
    public TMPro.TextMeshProUGUI infoText;

    public GameObject InfoButtonBlocker;

    public void Start()
    {
        infoPanel.SetActive(false);
        InfoButtonBlocker.SetActive(false);
    }

    public void ShowInfo(string info)
    {
        infoText.text = info;
        infoPanel.SetActive(true);
        InfoButtonBlocker.SetActive(true);
    }

    public void HideInfo()
    {
        infoPanel.SetActive(false);
        InfoButtonBlocker.SetActive(false);
    }

    public void ShowPlayerInfo(Player playerUnit)
    {
        string info = $"Name: {playerUnit.unitName}\nHealth: {playerUnit.health}/{playerUnit.maxHealth}\nSP: {playerUnit.skillPoints}/{playerUnit.MaxSkillPoints}";
        ShowInfo(info);
    }
    
    public void ShowEnemyInfo(Unit enemyUnit){
    
        string info = $"Name: {enemyUnit.unitName}\nHealth: {enemyUnit.health}/{enemyUnit.maxHealth}";
        ShowInfo(info);
    }
}
