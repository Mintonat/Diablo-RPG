using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffects : MonoBehaviour {

	public GameObject groundImpact_Spawn, KickFX_Spawn, fireTornado_Spawn, fireSheild_Spawn;
	public GameObject groundImpace_Prefab, kickFX_Prefab, fireTornado_Prefab, fireSheild_Prefab, healFX_Prefab, thunderFX_Prefab;


	void GroundImpact(){
		Instantiate (groundImpace_Prefab, groundImpact_Spawn.transform.position, Quaternion.identity);
	}

	void Kick(){
		Instantiate (kickFX_Prefab, KickFX_Spawn.transform.position, Quaternion.identity);
	}

	void FireTornado(){
		Instantiate (fireTornado_Prefab, fireTornado_Spawn.transform.position, Quaternion.identity);
	}

	void FireShield(){
		GameObject fireObj = Instantiate (fireSheild_Prefab, fireSheild_Spawn.transform.position, Quaternion.identity) as GameObject;
		fireObj.transform.SetParent (transform);
	}

	void Heal(){
		Vector3 temp = transform.position;
		temp.y += 2f;
		GameObject healObj = Instantiate (healFX_Prefab, temp, Quaternion.identity) as GameObject;
		healObj.transform.SetParent (transform);
	}

	void ThunderAttack(){
		for(int i=0; i<8; i++){
			Vector3 pos = Vector3.zero;
			if (i == 0) {
				pos = new Vector3 (transform.position.x-4f, transform.position.y+2f, transform.position.z);
			}else if (i == 1) {
				pos = new Vector3 (transform.position.x+4f, transform.position.y+2f, transform.position.z);
			}else if (i == 2) {
				pos = new Vector3 (transform.position.x, transform.position.y+2f, transform.position.z-4f);
			}else if (i == 3) {
				pos = new Vector3 (transform.position.x+2f, transform.position.y+2f, transform.position.z+4f);
			}else if (i == 4) {
				pos = new Vector3 (transform.position.x+2.5f, transform.position.y+2f, transform.position.z-2.5f);
			}else if (i == 5) {
				pos = new Vector3 (transform.position.x-2.5f, transform.position.y+2f, transform.position.z+2.5f);
			}else if (i == 6) {
				pos = new Vector3 (transform.position.x-2.5f, transform.position.y+2f, transform.position.z-2.5f);
			}else if (i == 7) {
				pos = new Vector3 (transform.position.x+2.5f, transform.position.y+2f, transform.position.z+2.5f);
			}
			Instantiate (thunderFX_Prefab, pos, Quaternion.identity);
		}
			
	}

}
