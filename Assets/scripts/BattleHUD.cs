using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public GameObject battleCanvas;
    public GameObject baseUI;

    public Image characterportrait;
    public Slider playerHealthBar;
    public Slider enemyHealthBar;

    public void SetHUD(Unit player, Unit enemy)
    {
        playerHealthBar.maxValue=player.maxHealth;
        playerHealthBar.value=player.health;
        enemyHealthBar.maxValue=enemy.maxHealth;
        enemyHealthBar.value=enemy.health;
    }

    public void SetHp(int playerHp,int enemyHp)
    {
        playerHealthBar.value= playerHp;
        enemyHealthBar.value=enemyHp;
    }
    
}
