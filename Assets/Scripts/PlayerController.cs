using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkInput();
    }

    // Check player input
    private void checkInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            checkButtonClick();
        }
    }

    // See if the player is looking at their button
    private void checkButtonClick()
    {
        if(Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f)), 10.0f, LayerMask.GetMask(new string[] {"chair_button"})))
        {
            // Play the audio
            GameController.Instance.playerChair.PlayButtonAudio();

            // Rotate the chair
            GameController.Instance.playerChair.RotateToEnd();
        }
    }

}
