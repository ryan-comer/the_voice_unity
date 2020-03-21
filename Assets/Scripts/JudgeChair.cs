using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeChair : MonoBehaviour
{

    public float rotationSpeed;
    public float startingYRotation; // Rotation when looking at the audience
    public float endingYRotation;   // Rotation when looking at the stage

    public AudioSource buttonAudioSource;  // Where to play the button sound
    public AudioClip buttonSoundEffect;    // Button press sound effect

    public int State
    {
        get
        {
            if(Mathf.Abs(transform.eulerAngles.y - startingYRotation) < 1)
            {
                return 0;   // At start
            }else if(Mathf.Abs(transform.eulerAngles.y - endingYRotation) < 1)
            {
                return 1;   // At end
            }
            else
            {
                return 2;   // In progress
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonAudioSource.clip = buttonSoundEffect;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter");
            if(State == 0)
            {
                RotateToEnd();
            }else if(State == 1)
            {
                RotateToStart();
            }
        }
    }

    public void RotateToEnd()
    {
        if(State != 0)
        {
            return;
        }

        StartCoroutine(rotateToEndCoroutine());
    }

    public void RotateToStart()
    {
        if(State != 1)
        {
            return;
        }

        StartCoroutine(rotateToStartCoroutine());
    }

    // Play the button sound effect
    public void PlayButtonAudio()
    {
        buttonAudioSource.Play();
    }

    private IEnumerator rotateToEndCoroutine()
    {
        while (Mathf.Abs(transform.localEulerAngles.y - endingYRotation) > 1)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator rotateToStartCoroutine()
    {
        while (Mathf.Abs(transform.localEulerAngles.y - startingYRotation) > 1)
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }

}
