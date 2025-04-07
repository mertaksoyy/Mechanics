using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
   public static PlayerState Instance{ get; set; }

    //--- player health ---//
    public float currentHealth;
    public float maxHealth;

    //--- Breath Bar ---//
    public float currentBreath;
    public float maxBreath;
    //public bool isBreathActive;

    //float distanceTravelled=0;
    //Vector3 lastPosition; //check where is the position of the player

    public GameObject playerBody; //

    
   private void Awake()
   {
      if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
   }


    void Start()
    {
        currentHealth = maxHealth;
        currentBreath = maxBreath;
        StartCoroutine(decreaseBreath());
    }
    
    IEnumerator decreaseBreath()
    {
        //Şimdilik hep azalacak ancak ilerde sadece suya girdiğinde azalacak olarak ayarlıcaz.True kısmı değişecek
        while(true)
        {
            currentBreath -=1;
            yield return new WaitForSeconds(2);

        }
    }



    //Testing health bar
    void Update()
    {
        /*check what is the last position and check where is the player right now
        distanceTravelled +=Vector3.Distance(playerBody.transform.position,lastPosition);
        lastPosition = playerBody.transform.position; //last position now current position

        if(distanceTravelled >= 5)
        {
            distanceTravelled = 0;
            
            if(currentBreath >0)
            {
                currentBreath -= 1;
            }
            else
            {
                Debug.Log("Breath finish");
            }
        }*/

        if(Input.GetKeyDown(KeyCode.N))
        {
            if(currentHealth > 0)
            {
                currentHealth -= 10;
            }
            else
            {
                Debug.Log("U DİE");
            }
             
        }
    }
}
