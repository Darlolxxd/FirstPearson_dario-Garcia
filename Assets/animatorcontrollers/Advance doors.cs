using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advancedoors : MonoBehaviour
{
    public Animator door;
    public GameObject lockOB;
    public GameObject KeyOB;
    
    public GameObject openText;
    public GameObject closeText;
    public GameObject lockedText;

    public AudioSource openSound;
    public AudioSource closeSound;
    public AudioSource lockedSound;
    public AudioSource lockedAudio;


    private bool doorisOpen;
    private bool doorisClosed;
    public bool locked;
    private bool unlocked;
   private bool inReach;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && doorisClosed)
        {
            inReach = true;
            openText.SetActive(true);
        }
        if (other.gameObject.tag == "Reach" && doorisOpen)
        {
            inReach = true;
            closeText.SetActive(true); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach") 
        {
            inReach = false;
            openText.SetActive(false); 
            lockedText.SetActive(false);
            closeText.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        doorisClosed = true;
        doorisOpen = false;
        closeText.SetActive(false);
        openText.SetActive(false );
    }

    // Update is called once per frame
    void Update()
    {
        if (lockOB.activeInHierarchy)
        {
            locked = true;
            unlocked = false;
        }
        else
        {
            unlocked = true;
            locked = false;
        }
        if(inReach && KeyOB.activeInHierarchy && Input.GetButtonDown("Interact"))
        {
            locked = false;
            KeyOB.SetActive(false);
            StartCoroutine(unlockDoor());
        }
        if (inReach && doorisClosed && unlocked && Input.GetButtonDown("Interact"))
        {
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            openText.SetActive(false);
            doorisOpen = true;
            doorisClosed = false;

        }
        if (inReach && doorisOpen && unlocked && Input.GetButtonDown("Interact"))
        {
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            openText.SetActive(false);
            doorisOpen = true;
            doorisClosed = false;
        }
        if ( inReach && locked && Input.GetButtonDown("Interact"))
        {
            openText.SetActive(false);
            lockedText.SetActive(true);
            
        }
        IEnumerator unlockDoor()
        {
            yield return new WaitForSeconds(.05f);
            {
                unlocked = true;
                lockOB.SetActive(false);
            }
        }
    }

}
