using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour 
{
	private Animator _anim;
	[SerializeField] private Portal _portal;

	private void Start() 
	{
		_anim = GetComponent<Animator>();
		_portal.PlayerTeleported += PlayAnim;
	}

	public void PlayAnim() 
	{
		_anim.SetBool("Win", true);
	}
}
