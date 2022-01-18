using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlenderCreate : MonoBehaviour
{
    public int isSlender;
    // Start is called before the first frame update
    public GameObject slender;
    public AudioSource audioSource;
    public GameObject lights;
    public bool isLight = false;

    void Start()
    {
        isSlender = GetComponent<LightSwitch>().isSlender;
        audioSource = GetComponent<AudioSource>();
    }
    public void SlenderMove()
    {
        StartCoroutine(SlenderRun());
    }
    IEnumerator SlenderRun()
    {
        yield return new WaitForSeconds(0.1f);
        if (isSlender == 1)
        {
            GameObject slenderObj = Instantiate(slender);
            //audioSource.Play();
            yield return new WaitForSeconds(0.2f);
            lights.gameObject.SetActive(!isLight);
            yield return new WaitForSeconds(0.2f);
            lights.gameObject.SetActive(isLight);
            yield return new WaitForSeconds(0.2f);
            lights.gameObject.SetActive(!isLight);
            yield return new WaitForSeconds(0.2f);
            lights.gameObject.SetActive(isLight);
            yield return new WaitForSeconds(0.2f);
            lights.gameObject.SetActive(!isLight);
            yield return new WaitForSeconds(3f);
            lights.gameObject.SetActive(isLight);
        }
    }
    // Update is called once per frame
    void Update()
    {
        isSlender = GetComponent<LightSwitch>().isSlender;
    }


}
