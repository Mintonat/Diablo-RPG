using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

	public Image fillWaitImage_1;
	public Image fillWaitImage_2;
	public Image fillWaitImage_3;
	public Image fillWaitImage_4;
	public Image fillWaitImage_5;
	public Image fillWaitImage_6;

	private int[] fadeImage = new int[]{0,0,0,0,0,0};

	private Animator anim;
	private bool canAttack = true;
	private PlayerMove playerMove;


	void Awake () {
		anim = GetComponent<Animator> ();
		playerMove = GetComponent<PlayerMove> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo (0).IsName ("Stand")) {
			canAttack = true;
		} else {
			canAttack = false;
		}
		CheckToFade ();
		CheckInput ();

	}

	void CheckInput(){
		if (anim.GetInteger ("Atk") == 0) {
			playerMove.FinishedMovement = false;

			if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo (0).IsName ("Stand")) {
				playerMove.FinishedMovement = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			playerMove.TargetPosition = transform.position;
			if (playerMove.FinishedMovement && fadeImage [0] != 1 && canAttack) {
				fadeImage [0] = 1;
				anim.SetInteger ("Atk", 1);
			}
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			playerMove.TargetPosition = transform.position;
			if (playerMove.FinishedMovement && fadeImage [1] != 1 && canAttack) {
				fadeImage [1] = 1;
				anim.SetInteger ("Atk", 2);
			}
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			playerMove.TargetPosition = transform.position;
			if (playerMove.FinishedMovement && fadeImage [2] != 1 && canAttack) {
				fadeImage [2] = 1;
				anim.SetInteger ("Atk", 3);
			}
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			playerMove.TargetPosition = transform.position;
			if (playerMove.FinishedMovement && fadeImage [3] != 1 && canAttack) {
				fadeImage [3] = 1;
				anim.SetInteger ("Atk", 4);
			}
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			playerMove.TargetPosition = transform.position;
			if (playerMove.FinishedMovement && fadeImage [4] != 1 && canAttack) {
				fadeImage [4] = 1;
				anim.SetInteger ("Atk", 5);
			}
		} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			playerMove.TargetPosition = transform.position;
			if (playerMove.FinishedMovement && fadeImage [5] != 1 && canAttack) {
				fadeImage [5] = 1;
				anim.SetInteger ("Atk", 6);
			}
		} else {
			anim.SetInteger ("Atk", 0);
		}
		if (Input.GetMouseButton(1)) {
			Vector3 targetPos = Vector3.zero;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				targetPos = new Vector3 (hit.point.x, transform.position.y, hit.point.z);
			}
			transform.rotation = Quaternion.Slerp (transform.rotation,
				Quaternion.LookRotation (targetPos - transform.position), 15f * Time.deltaTime);
		}

	}

	void CheckToFade(){
		if (fadeImage [0] == 1) {
			if(FadeAndWait(fillWaitImage_1, 1.0f)){
				fadeImage [0] = 0;
			}
		}
		if (fadeImage [1] == 1) {
			if(FadeAndWait(fillWaitImage_2, 0.7f)){
				fadeImage [1] = 0;
			}
		}
		if (fadeImage [2] == 1) {
			if(FadeAndWait(fillWaitImage_3, 0.1f)){
				fadeImage [2] = 0;
			}
		}
		if (fadeImage [3] == 1) {
			if(FadeAndWait(fillWaitImage_4, 0.2f)){
				fadeImage [3] = 0;
			}
		}
		if (fadeImage [4] == 1) {
			if(FadeAndWait(fillWaitImage_5, 0.3f)){
				fadeImage [4] = 0;
			}
		}
		if (fadeImage [5] == 1) {
			if(FadeAndWait(fillWaitImage_6, 0.08f)){
				fadeImage [5] = 0;
			}
		}
	}

	bool FadeAndWait(Image fadeImg, float fadeTime){
		bool faded = false;
		if (fadeImg == null)
			return faded;

		if (!fadeImg.gameObject.activeInHierarchy) {
			fadeImg.gameObject.SetActive (true);
			fadeImg.fillAmount = 1f;
		}
		fadeImg.fillAmount -= fadeTime * Time.deltaTime;
		if (fadeImg.fillAmount <= 0f) {
			fadeImg.gameObject.SetActive (false);
			faded = true;
		}

		return faded;
	}
}
