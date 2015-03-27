using UnityEngine;
using System.Collections;

//Djamali

public class TrapButton : MonoBehaviour 
{
	public GameObject trap;
	private MovingPlatform _movingPlatformScript;
	private Turret _turretScript;
	private Trapdoor _trapDoorScript;
    private AudioSource _audioSource;
    [SerializeField] private bool _clientsOnly = false;
    [SerializeField] private bool _toggle = false;
    private bool _pressed = false;
	private float _waitTime = 4f;

	void Awake()
	{
		_movingPlatformScript = trap.GetComponent<MovingPlatform>();
		_turretScript = trap.GetComponent<Turret>();
		_trapDoorScript = trap.GetComponent<Trapdoor>();
        _audioSource = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
        if (!_toggle && _pressed) 
            return;
        
		if (col.transform.tag != null && col.tag != AllTagsConstants.groundTag)
		{
            if (_clientsOnly) 
            {
                if (col.transform.tag == AllTagsConstants.playerTag || col.transform.tag == AllTagsConstants.alienTag) 
                {
                    Trigger();
                    PlaySound();
                    _pressed = true;
                }
            }
            else 
            {
                Trigger();
                PlaySound();
                _pressed = true;
            }
        }

	}

    void Trigger() 
    {
        if (trap.tag == AllTagsConstants.trapDoorTag && _trapDoorScript != null) 
        {
            _trapDoorScript.OpenDoor();
            Debug.Log("Trapdoor");
        } 
        else if (trap.tag == AllTagsConstants.platformTag && _movingPlatformScript != null)
        {
            _movingPlatformScript.stopped = true;
            Debug.Log("Platform");
        } 
        else if (trap.tag == AllTagsConstants.turretTag && _turretScript != null)
        {
            _turretScript.DisableGun(_waitTime);
            Debug.Log("Turret");
        }
    }

    void PlaySound() 
    {
        _audioSource.Play();
    }
}
