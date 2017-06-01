using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================================================================================================
//	Classe Player
//	Por: Gabriel Maciel
//	
// 	Faz:
//	Controla input, Status, escolhas de batalha do player, interface, talentos, shopping
//
//	Input:
//	W = up, S = Down, D = Right, A = Left
//	B = Bag, T = Talents, C = Status, K = Achievments, P = shopping
//	1 = Skill1, 2 = Skill2, 3 = Skill3, 4 = Skill4
//
//==============================================================================================================================*/
public class Player : MonoBehaviour {

	//Status:
	public int dano;
	public int vida;
	public int statusProgramacao, statusAed, statusAoc, statusIa, StatusTeoria; 


	//GUI
		//texturas
	public Texture2D[] skill;
	public Texture2D skillHud;
	public Texture2D pointsBar, pointsHud;
	public float actualPoints, totalPoints;

	//Battle
	public GameObject enemy;
	public int turn;

	//Achiviements
	public Achievements achievements;

	//Flags
		//windows
	public bool talents, status, bag, shop, achiev;
		//battle
	public bool confusion,sleep,study;

	// Use this for initialization
	void Start () {
		//Points
		totalPoints = 10;

		//Components
		achievements = this.GetComponent<Achievements> ();

		//Flags
		talents = false;
		status = false;
		bag = false;
		shop = false;
		achiev = false;

		//

	}
	
	// Update is called once per frame
	void Update () {
		//Points
		validateActualPoints ();

		//Input
			//Skills

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Skill1 ();
		} 
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Skill2 ();
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			Skill3 ();
		} 
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			Skill4 ();
		}

		//windows
		if (Input.GetKeyDown (KeyCode.B)) {//Bag
			bag = true;
			talents = false;
			status = false;
			shop = false;
			achiev = false;
		}
		if (Input.GetKeyDown (KeyCode.T)) {//Talents
			bag = false;
			talents = true;
			status = false;
			shop = false;
			achiev = false;
		}
		if (Input.GetKeyDown (KeyCode.C)) {//Status/Character
			bag = false;
			talents = false;
			status = true;
			shop = false;
			achiev = false;
		}
		if (Input.GetKeyDown (KeyCode.P)) {//Shop
			bag = false;
			talents = false;
			status = false;
			shop = true;
			achiev = false;
		}
		if (Input.GetKeyDown (KeyCode.K)) {//Achievments
			bag = false;
			talents = false;
			status = false;
			shop = false;
			achiev = true;
		}



	}

	void OnGUI(){
		//Barra de nota
		GUI.DrawTexture (new Rect (Screen.width/4,Screen.height/100, Screen.width/2, Screen.height*3/100), pointsHud);
		GUI.DrawTexture (new Rect (Screen.width/4,Screen.height/100, (Screen.width*actualPoints/totalPoints)/2, Screen.height*3/100), pointsBar);
		GUI.Label (new Rect (Screen.width / 2 - Screen.width / 50, Screen.height / 30, Screen.width / 10, Screen.height * 4 / 100), (actualPoints + " / " + totalPoints));

		//Barra de habilidades
		GUI.DrawTexture (new Rect (Screen.width /2-Screen.width*2/15-Screen.width/200,Screen.height - Screen.height *11/ 100, Screen.width*3/11, Screen.height/11), pointsHud);
		for (int i = 0; i < skill.Length; i++) {
			if (GUI.Button (new Rect (Screen.width /2-Screen.width*2/16+Screen.width / 16*i, Screen.height - Screen.height / 10, Screen.width / 16, Screen.height * 7 / 100), skill [i])) {
				if (i == 0)
					Skill1 ();
				else if (i == 1)
					Skill2 ();
				else if (i == 2)
					Skill3 ();
				else if (i == 3)
					Skill4 ();
			}

		}

		//Janelas

	}

	void validateActualPoints(){//Controle do máximo de notas
		if (actualPoints < 0)
			actualPoints = 0;
		if (actualPoints > totalPoints)
			actualPoints = 10;
	}


	void Skill1(){//Controle da skill 1
		actualPoints+=0.1f;
	}
	void Skill2(){//Controle da skill 2
		actualPoints+=0.5f;
	}
	void Skill3(){//Controle da skill 3
		actualPoints+=1;
	}
	void Skill4(){//Controle da skill 4
		actualPoints+=2;
	}

	void hit(GameObject target){

	}

}
