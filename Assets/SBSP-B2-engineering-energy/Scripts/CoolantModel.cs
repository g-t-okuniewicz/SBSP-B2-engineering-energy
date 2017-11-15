using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoolantModel 
{
        private string coolantType;
       // private float coolantAmount;

        public CoolantModel()
        {
            coolantType = "";
         //   coolantAmount = 0.0f;
        }

        public CoolantModel(string coolantType)
        {
            this.coolantType = coolantType;
         //   this.coolantAmount = coolantAmount;
        }

        public string GetCoolantType()
        { return coolantType; }

        public void SetCoolantType(string coolType)
        { this.coolantType = coolType; }

      //  public float GetCoolantAmount()
      //  { return coolantAmount; }

      //  public void SetCoolantAmount(float coolType)
      //  { this.coolantAmount = coolType; }
}

