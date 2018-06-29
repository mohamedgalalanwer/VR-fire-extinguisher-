using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
public class AutoWalk : MonoBehaviour {
    [SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;
    [SerializeField] private float m_StepInterval;
    [SerializeField] private AudioClip[] m_FootstepSounds;
    public Transform vrCamera;
 
    public float togglengle = 25.0f;
    public float speed = 3f;
    public  bool movForawerd;
    private CharacterController cc;
    private float m_StepCycle;
    private float m_NextStep;
    private AudioSource m_AudioSource;
    private FirstPersonController p;
    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();
        m_StepCycle = 0f;
        m_NextStep = m_StepCycle/2f;
        m_AudioSource = GetComponent<AudioSource>();
        p = GetComponent<FirstPersonController> ();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (vrCamera.eulerAngles.x >= togglengle && vrCamera.eulerAngles.x < 90f)
        {

            movForawerd = true;
            p.enabled = false;
            ProgressStepCycle (speed);
          
        }
        else
        {
            movForawerd = false;
            p.enabled = true;
        }

        if (movForawerd)
        {

            Vector3 f = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(f * speed);


        }
    }
    private void ProgressStepCycle(float speed)
    {
        if (cc.velocity.sqrMagnitude > 0 )
        {
            m_StepCycle += (cc.velocity.magnitude + (speed*(movForawerd ? 1f : m_RunstepLenghten)))*
                Time.fixedDeltaTime;
        }

        if (!(m_StepCycle > m_NextStep))
        {
            return;
        }

        m_NextStep = m_StepCycle + m_StepInterval;

        PlayFootStepAudio();
    }

    /// <summary>
    /// /////////
    /// </summary>
    public void PlayFootStepAudio()
    {
        if (!cc.isGrounded)
        {
            return;
        }
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, m_FootstepSounds.Length);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }

}
