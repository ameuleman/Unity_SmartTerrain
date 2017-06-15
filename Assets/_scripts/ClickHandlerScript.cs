using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandlerScript : MonoBehaviour {
    public SpawningScript spawningScript;

    private const float CLICK_RESET_DELAY = 0.2f;
    private float _lastClickDelta = 0;
    private int _clickCount = 0;
	
	// Update is called once per frame
	void Update () {
        _lastClickDelta += Time.deltaTime;
        if(_lastClickDelta > CLICK_RESET_DELAY)
        {
            _clickCount = 0;
            _lastClickDelta = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _clickCount++;
            if(_clickCount == 1)
            {
                if (gameObject)
                {
                    spawningScript.spawnCube();
                }
            }
        }
	}
}
