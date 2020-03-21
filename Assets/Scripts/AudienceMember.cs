using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceMember : MonoBehaviour
{

    public Color[] possibleColors;
    public MeshRenderer body;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        initMaterial();
        randomStartAnimation();

        anim = GetComponent<Animator>();
        Debug.Assert(anim);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Initialize the audience member materia (random)
    private void initMaterial()
    {
        // Choose a random color
        Color materialColor = possibleColors[Random.Range(0, possibleColors.Length)];
        Material material = new Material(Shader.Find("Standard"));
        material.color = materialColor;

        body.material = material;
    }

    // Start the idle animation randomly
    private void randomStartAnimation()
    {
        float waitTime = Random.Range(0.0f, 2.0f);
        StartCoroutine(waitCoroutine(() =>
        {
            anim.Play("audience_member_idle");
        }, waitTime));
    }

    // Coroutine to wait before an action
    private IEnumerator waitCoroutine(System.Action action, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        action();
    }

}
