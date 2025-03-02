using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   [SerializeField] private GameObject ObjectToDictevate;
   [SerializeField] private GameObject ObjectToActivate;
   private bool timeActive = true;
   public float timeStart;
   public Text textTimer;

   void Start()
   {
      textTimer.text = timeStart.ToString("F2");
   }

   void Update()
   {
      if (timeActive)
      {
         if (timeStart > 0)
         {
            timeStart -= Time.deltaTime;
         }
         else
         {
            ActivateDiact();
            timeStart = 0;
            timeActive = false;
         }

         textTimer.text = timeStart.ToString("F2");
      }
   }

   private void ActivateDiact()
   {
      ObjectToActivate.SetActive(true);
      ObjectToDictevate.SetActive(false);
   }
}
