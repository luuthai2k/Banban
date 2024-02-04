using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public PlayerController playerCtr;
    public CharactorData playerData;
	public Transform bodyRender;
	IEnumerator sitCort;
	public bool isSitting;
	private InputControl inputControl;

	public float forward;
    private float currentspeed;
    public float multiplier = 1.5f;
	
    private void Start()
    {
        inputControl = UIManager.ins.inputControl;

    }
    void Update()
	{
		if (playerCtr.isGround)
		{
			SpeedHandle();
            if ((Input.GetKeyDown(KeyCode.Space) || inputControl.isJump)&&playerCtr.isGround)
            {
                playerCtr.inertiaVelocity.y = 0f;
                playerCtr.inertiaVelocity.y += playerData.jumpHeight;
				currentspeed = currentspeed * multiplier;
            }

#if UNITY_EDITOR


			playerCtr.moveInput = (transform.forward * Input.GetAxis(Constant.Vertical)+ transform.right*Input.GetAxis(Constant.Horizontal)) * currentspeed;
			forward = playerCtr.moveInput.magnitude;
#else
			 playerCtr.moveInput = (transform.forward * inputControl.joystick.Vertical+transform.right* inputControl.joystick.Horizontal) * currentspeed;
			forward = new Vector2(inputControl.joystick.Vertical, inputControl.joystick.Horizontal / 5).magnitude;

#endif
			playerCtr.animator.SetFloat(Constant.Forward, forward);

			if ((Input.GetKeyDown(KeyCode.C) || inputControl.isSitdown) && sitCort == null)
			{
				sitCort = sitDown();
				StartCoroutine(sitCort);
			}


		}
    }
	public void SpeedHandle()
	{
		if (inputControl.isSprint)
		{
			currentspeed = Mathf.SmoothStep(currentspeed, playerData.speedSprint, 2);
		}
		else
		{
            currentspeed = Mathf.SmoothStep(currentspeed, playerData.speed, 2);
        }
	}
	IEnumerator sitDown()
	{
		if (isSitting && Physics.Raycast(transform.position, Vector3.up, playerCtr.characterController.height * 1.5f))
		{
			sitCort = null;
			yield break;
		}
		isSitting = !isSitting;

		float t = 0;
		float startSize = playerCtr.characterController.height;
		float finalSize = isSitting ? playerCtr.characterController.height / 2 : playerCtr.characterController.height * 2;
		Vector3 startBodySize = bodyRender.localScale;
		Vector3 finalBodySize = isSitting ? bodyRender.localScale - Vector3.up * bodyRender.localScale.y / 2f : bodyRender.localScale + Vector3.up * bodyRender.localScale.y;
        playerData.speed = isSitting ? playerData.speed / 2 : playerData.speed * 2;
        playerData.jumpHeight = isSitting ? playerData.jumpHeight * 3 : playerData.jumpHeight / 3;
		
		while (t < 0.2f)
		{
			t += Time.deltaTime;
            playerCtr.characterController.height = Mathf.Lerp(startSize, finalSize, t / 0.2f);
			bodyRender.localScale = Vector3.Lerp(startBodySize, finalBodySize, t / 0.2f);
			yield return null;
		}

		sitCort = null;
		yield break;
	}
}
