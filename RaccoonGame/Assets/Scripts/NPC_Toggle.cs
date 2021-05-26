using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Toggle : MonoBehaviour
{
   private GameObject triggerNPC;
   private bool isTriggered;
   private bool pressE;

   public GameObject npcText;
   public GameObject npcTextNext;
   public GameObject background;
   public GameObject backgroundNext;
   void Start(){
        npcText.SetActive(false);
        npcTextNext.SetActive(false);
        pressE = false;
   }

   void Update(){
       if(isTriggered && pressE == false ){
           npcText.SetActive(true);
           background.SetActive(true);
           if(Input.GetKeyDown(KeyCode.E)){
               npcTextNext.GetComponent<Text>().text = "Collected Items: " + PickupController.myInt + "/16\n\nYou need three items to leave the junkyard area";
               npcTextNext.SetActive(true);
               npcText.SetActive(false);
               background.SetActive(false);
               backgroundNext.SetActive(true);
               pressE = true;
           } 
       }else if (pressE == false){
               npcTextNext.SetActive(false);
               npcText.SetActive(false);
               background.SetActive(false);
               backgroundNext.SetActive(false);
        }
   }

   void OnTriggerEnter(Collider other){
       if(other.tag == "NPC" && pressE == false){
           isTriggered = true;
           triggerNPC = other.gameObject;
       }
   }

   void OnTriggerExit(Collider other){
       if(other.tag == "NPC"){
           isTriggered = false;
           triggerNPC = null;
           pressE = false;
       }
   }
}
