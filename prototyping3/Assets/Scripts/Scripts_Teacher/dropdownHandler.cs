using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdownHandler : MonoBehaviour{

	private GameHandler gameHandlerObj;
	private string playerChoice;
	private int pNum;
	public bool isPlayer1 = false;

	void Awake(){
		if (GameObject.FindWithTag("GameHandler") != null){
				gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
			}
			
		if (isPlayer1 == true){pNum = 1;}
		else {pNum = 2;}
	}

    void Start(){
        var dropdown = transform.GetComponent<Dropdown>();
		dropdown.options.Clear();
		
		List<string> items1 = new List<string>();
		items1.Add("");
		items1.Add("BotA00");
		items1.Add("BotA01");
		items1.Add("BotA02");
		items1.Add("BotA03");
		items1.Add("BotA04");
		items1.Add("BotA05");
		items1.Add("BotA06");
		items1.Add("BotA07");
		items1.Add("BotA08");
		items1.Add("BotA09");
		items1.Add("BotA10");
		items1.Add("BotA11");
		items1.Add("BotA12");
		items1.Add("BotA13");
		items1.Add("BotA14");
		items1.Add("BotA15");
		items1.Add("BotA16");
		items1.Add("BotA17");
		items1.Add("BotA18");
		items1.Add("BotA19");
		items1.Add("BotA20");
		items1.Add("BotB01");
		items1.Add("BotB02");
		items1.Add("BotB03");
		items1.Add("BotB04");
		items1.Add("BotB05");
		items1.Add("BotB06");
		items1.Add("BotB07");
		items1.Add("BotB08");
		items1.Add("BotB09");
		items1.Add("BotB10");
		items1.Add("BotB11");
		items1.Add("BotB12");
		items1.Add("BotB13");
		items1.Add("BotB14");
		items1.Add("BotB15");
		items1.Add("BotB16");
		items1.Add("BotB17");
		items1.Add("BotB18");
		items1.Add("BotB19");
		items1.Add("BotB20");
		
		List<string> items2 = new List<string>();
		items2.Add("");
		items2.Add("BotB00");
		items2.Add("BotB01");
		items2.Add("BotB02");
		items2.Add("BotB03");
		items2.Add("BotB04");
		items2.Add("BotB05");
		items2.Add("BotB06");
		items2.Add("BotB07");
		items2.Add("BotB08");
		items2.Add("BotB09");
		items2.Add("BotB10");
		items2.Add("BotB11");
		items2.Add("BotB12");
		items2.Add("BotB13");
		items2.Add("BotB14");
		items2.Add("BotB15");
		items2.Add("BotB16");
		items2.Add("BotB17");
		items2.Add("BotB18");
		items2.Add("BotB19");
		items2.Add("BotB20");
		items2.Add("BotA01");
		items2.Add("BotA02");
		items2.Add("BotA03");
		items2.Add("BotA04");
		items2.Add("BotA05");
		items2.Add("BotA06");
		items2.Add("BotA07");
		items2.Add("BotA08");
		items2.Add("BotA09");
		items2.Add("BotA10");
		items2.Add("BotA11");
		items2.Add("BotA12");
		items2.Add("BotA13");
		items2.Add("BotA14");
		items2.Add("BotA15");
		items2.Add("BotA16");
		items2.Add("BotA17");
		items2.Add("BotA18");
		items2.Add("BotA19");
		items2.Add("BotA20");

		//fill dropdown with items
		if (pNum == 1){
			foreach(var item in items1){
				dropdown.options.Add(new Dropdown.OptionData(){text = item});
			}
		}
		else if (pNum == 2){
			foreach(var item in items2){
				dropdown.options.Add(new Dropdown.OptionData(){text = item});
			}
		}
		
		DropdownItemSelected(dropdown);
		dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
		
		 //This script should be attached to Item
		 Toggle toggle = gameObject.GetComponent<Toggle>();
		 Debug.Log(toggle);
		 if (toggle != null && toggle.name == "Item 1: Option B"){
		 		toggle.interactable = false;
		 }
    }

    void DropdownItemSelected(Dropdown dropdown){
        int index = dropdown.value;
		playerChoice = dropdown.options[index].text.ToString();
		Debug.Log("Player " + pNum + " Choice: " + playerChoice);
		
		if (pNum == 1){
			gameHandlerObj.p1PrefabName = playerChoice;
		}
		else if (pNum == 2){
			gameHandlerObj.p2PrefabName = playerChoice;
		}	
    }
}
