using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    //DO NOT MAKE THESE private BECAUSE THEY ARE ACCESSED BY OTHER Classes
    public int startMoney = 500;
    public static int Money; //static vars carry on from one scene to another, so if we go to new scene, the Money amount will be preserved and NOT reset

    void Start()
    {
        Money = startMoney;
    }
}
