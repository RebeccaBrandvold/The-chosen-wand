using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {
      private float fillAmount;
    [SerializeField]
    private float healthDeplentingSpeed; //For the speed of the thingy to go smoother.

    [SerializeField]
    private Image Green;

    //Deciding the max value of the bar(updated if the player gets more health (animals etc)
    public float MaxValue { get; set; }

    [SerializeField]
    private Color fullColor;
    [SerializeField]
    private Color lowColor;
    [SerializeField]
    private bool lerpColors;

    public float Value
    {
        set
        {
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }

	// Use this for initialization
	void Start () {
	if(lerpColors)
        {
            Green.color = fullColor;
        }
	}
	
	// Update is called once per frame
	void Update () {
        HandleBar();
	}

    private void HandleBar()
    {
        if(fillAmount != Green.fillAmount)
        { //acess image green and changes the fillamount
        Green.fillAmount = Mathf.Lerp(Green.fillAmount,fillAmount, Time.deltaTime * healthDeplentingSpeed);
        }
        if (lerpColors)
        {
            Green.color = Color.Lerp(lowColor, fullColor, fillAmount);//Will ''lerp'' the colors aka move them fade them etc
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)//minimum health 0 Maximum value this funtion can recve.
    {
        //Current healh change it into a value between 0-1
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        //(Current health 80 - 0) * (1 - 0) / (100 - 0) + 0
        // 80*1 / 100 =0.8
    }
}
