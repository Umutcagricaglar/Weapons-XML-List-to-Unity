using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackOpener : MonoBehaviour
{
  
    public GameObject Backpack;

   
    public void OpenPanel()
    {
        if(Backpack != null)
        {
            bool isActive = Backpack.activeSelf;
            Backpack.SetActive(!isActive);
        }
    }
}
