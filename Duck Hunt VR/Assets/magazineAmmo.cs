using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazineAmmo : MonoBehaviour
{
    public static int isUsed;
    void Update()
    {
        if (isUsed == 0)
        {
            GunScript.currentammo = 8;
        }
        else
        {
            GunScript.currentammo = 0;
        }
    }
}
