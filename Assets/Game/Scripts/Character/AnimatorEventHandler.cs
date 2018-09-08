using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorEventHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem stepFX;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> stepAudios;

    private AudioClip StepAudio
    {
        get
        {
            return stepAudios[Random.Range(0, stepAudios.Count)];
        }
    }

    private UnityEvent onBasicAttack = new UnityEvent();
    private UnityEvent onHeavyAttack = new UnityEvent();
    private UnityEvent onUltimate = new UnityEvent();
    private UnityEvent onBlockAttack = new UnityEvent();
    private UnityEvent onStep = new UnityEvent();
    
    public Animator Anim { get; private set; }

    public UnityEvent OnBlockAttack
    {
        get
        {
            return onBlockAttack;
        }
    }

    public UnityEvent OnBasicAttack
    {
        get
        {
            return onBasicAttack;
        }
    }
    public UnityEvent OnHeavyAttack
    {
        get
        {
            return onHeavyAttack;
        }
    }
    public UnityEvent OnUltimate
    {
        get
        {
            return onUltimate;
        }
    }
    public UnityEvent OnStep
    {
        get
        {
            return onStep;
        }
    }

    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    public void StepCallback()
    {
        OnStep.Invoke();

        stepFX.Play();
        audioSource.clip = StepAudio;
        audioSource.pitch = Random.Range(1, 2);
        audioSource.Play();
    }
    public void BasicAttackCallback()
    {
        Anim.SetInteger("BasicAttack", 0);
        OnBasicAttack.Invoke();
    }
    public void HeavyAttackCallback()
    {
        OnHeavyAttack.Invoke();
    }
    public void UltimateCallback()
    {
        OnUltimate.Invoke();
    }
    public void BlockAttackCallback()
    {
        Anim.SetInteger("BlockAttack", 0);
        OnBlockAttack.Invoke();
    }
}
