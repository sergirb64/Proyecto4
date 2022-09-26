using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    bool attack=true;
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
        if (attack)
        {
            StartCoroutine("AtaqueEnemigo");
        }
        playerText.Select();
        //if (Input.GetKeyDown(KeyCode.T))
        //   playerText.DeactivateInputField();
        if (Input.GetKeyDown(KeyCode.Return))
            if (textControler.GetComponent<TextControler>().highlightWords.Contains(playerText.text)==true)

            {
                textControler.GetComponent<TextControler>().highlightWords.Remove(playerText.text);
                textControler.GetComponent<TextControler>().CompletedWords.Add(playerText.text);
                textControler.GetComponent<TextControler>().dialogue.text = "";
                textControler.GetComponent<TextControler>().RewriteText("<color=red>", "</color = red > ", playerText.text);
                enemyLife -= 10;
                playerText.text = "";
                playerText.Select();
            }
            else if (playerText.text =="")
            {
               
            }
            else
            {
                life -= 10;
                playerText.text = "";
                playerText.Select();
            }

        
        ;
        HealthBar(healthBar, maxLife, life);
        HealthBar(healthBarEnemy, maxEnemyLife, enemyLife);


    }
    void HealthBar(Image bar,float max, float current)
    {
        bar.fillAmount = current / max;
    }

    IEnumerator AtaqueEnemigo()
    {
        attack = false;
        yield return new WaitForSeconds(5f);
        life -= 10;
        attack = true;
    }
}
