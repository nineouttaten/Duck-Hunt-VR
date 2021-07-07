using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OnlyMagazineGpab : XRSocketInteractor
{
    public string usedMagGrab;
    public string unusedMagGrab;
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && interactable.CompareTag(usedMagGrab) || interactable.CompareTag(unusedMagGrab);
    }
}
