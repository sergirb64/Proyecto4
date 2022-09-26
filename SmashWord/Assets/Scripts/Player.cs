using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float life = 100;
   public  float enemyLife=100;
   public Image healthBar;
    public Image healthBarEnemy;
    float maxLife;
    float maxEnemyLife;
    public InputField playerText;
    public TextControler textControler;
    void Start()
    {
        maxLife = life;
        maxEnemyLife = enemyLife;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //   playerText.DeactivateInputField();
        if (Input.GetKeyDown(KeyCode.Return))
            if (textControler.GetComponent<TextControler>().highlightWords.Contains(playerText.text)==true)

            {
                textControler.GetComponent<TextControler>().highlightWords.Remove(playerText.text);
                enemyLife -= 10;
                playerText.text = "";
            }
            else
            {
                life -=10;
                playerText.text = "";
            }
        
        ;
        HealthBar(healthBar, maxLife, life);
        HealthBar(healthBarEnemy, maxEnemyLife, enemyLife);


    }
    void HealthBar(Image bar,float max, float current)
    {
        bar.fillAmount = current / max;
    }
}
