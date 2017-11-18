using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float _Speed;

    /// <summary>
    /// Maps this controller to a specific set of controls
    /// </summary>
    [Range(1, 2)]
    [SerializeField]
    private int _PlayerNum = 1;

    private string _InputAxis;

    private Transform _PointerTransform;

	// Use this for initialization
	void Start () {
        _InputAxis = "Player" + _PlayerNum.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis(_InputAxis) != 0)
        {
            transform.position += transform.up * _Speed * Time.deltaTime * Input.GetAxis(_InputAxis);
        }
	}
}
