using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineAmmo : MonoBehaviour
{
    [SerializeField] private int ammoCount;

    public int AmmoCount
    {
        get => ammoCount;
        set => ammoCount = value;
    }
}