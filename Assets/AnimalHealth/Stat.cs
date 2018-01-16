using UnityEngine;
using System.Collections;
using System;
[Serializable]
public class Stat {
    //So that the health can tell the bar that its monitoring
    [SerializeField]
    private HealthBarScript bar;
    [SerializeField]
    private float maxVal;
    [SerializeField]
    private float currentVal; //Current value of this stat. 

    public float CurrentVal
    {
        get
        {
            return currentVal;
        }

        set
        {           //shoudln't be able to go belowmax and low
            this.currentVal = Mathf.Clamp(value, 0, MaxVal);
            bar.Value = currentVal;
        }
    }

    public float MaxVal
    {
        get
        {
            return maxVal;
        }

        set
        {
            this.maxVal = value;
            bar.MaxValue = maxVal;
        }
    }
    public void Initialized() //seeting the maxx value
    {
        this.MaxVal = maxVal; //updates
        this.CurrentVal = currentVal; //updates
    }
}
