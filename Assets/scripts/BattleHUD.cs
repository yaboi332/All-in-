using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public GameObject battleCanvas;
    public GameObject baseUI;

    public Image characterportrait;
    public Slider playerHealthBar;
    public Slider enemyHealthBar;
    public Slider skillPointBar;
    public TMP_Text skillPointText;

    public void SetHUD(Player player, Unit enemy)
    {
        playerHealthBar.maxValue=player.maxHealth;
        playerHealthBar.value=player.health;
        skillPointBar.maxValue=player.MaxSkillPoints;
        skillPointBar.value=player.skillPoints;
        skillPointText.text=player.skillPoints.ToString();
        enemyHealthBar.maxValue=enemy.maxHealth;
        enemyHealthBar.value=enemy.health;
    }

    public void SetHp(int playerHp,int enemyHp)
    {
        playerHealthBar.value= playerHp;
        enemyHealthBar.value=enemyHp;
    }
    public void SetSP(Player player)
    {
        skillPointBar.value=player.skillPoints;
        skillPointText.text=player.skillPoints.ToString();
    }
    
}
