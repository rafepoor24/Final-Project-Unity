using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [SerializeField] private Slider staminaslider;
    [SerializeField] private float maxStamina=100;


    private float CurrentStamina;

     private float RegenerateStaminaTime=0.1f;

     private float RegenerateStaminaAmount=2;

     private float LosingStaminaTime=0.3f;

    private Coroutine myCoroutineLosing;
    private Coroutine myCoroutineRegenerate;



    void Start()
    {
        CurrentStamina = maxStamina;
        staminaslider.maxValue=maxStamina;
        staminaslider.value=maxStamina;

    }
    public void UseStamina(float amount)
    {
        if (CurrentStamina - amount > 0) {

            if (myCoroutineLosing != null) 
            {
                StopCoroutine(myCoroutineLosing);
            }
            myCoroutineLosing= StartCoroutine(LosingStamina(amount));

            if (myCoroutineRegenerate != null)
            {
                StopCoroutine(myCoroutineRegenerate);
            }
            myCoroutineRegenerate = StartCoroutine(GernerateStamina());



        }
        else
        {
            Debug.Log("There isnt stamine");
        }
    }

    private IEnumerator LosingStamina(float amount)
    {
        while(CurrentStamina >= 0)
        {
            CurrentStamina -= amount;
            staminaslider.value = CurrentStamina;
            yield return new WaitForSeconds(LosingStaminaTime);
        }
        myCoroutineLosing = null; 
        FindObjectOfType<PlayerMovement>().isSprinting = false; 
    }
    private IEnumerator GernerateStamina()
    {
        yield return new WaitForSeconds(1);

        while(CurrentStamina < maxStamina)
        {
            CurrentStamina += RegenerateStaminaAmount;
            staminaslider.value = CurrentStamina;

            yield return new WaitForSeconds(RegenerateStaminaTime);
        }
        myCoroutineRegenerate = null;
    }
}
