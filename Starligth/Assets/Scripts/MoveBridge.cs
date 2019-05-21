using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBridge : MonoBehaviour {

    public GameObject bridge;
    public GameObject secondBridge;
    public GameObject triggerCollider;
    private Animator _animator;
    private Animator _secondAnimator;

    private void Start() {
        _animator = bridge.GetComponent<Animator>();
        _secondAnimator = secondBridge.GetComponent<Animator>();

        triggerCollider.SetActive(false);

        if (_animator != null)
            _animator.SetTrigger("MoveBridge90");

        if (_secondAnimator != null)
            _secondAnimator.SetTrigger("RotateBridge0");
    }

    private void OnTriggerEnter(Collider other) {
                
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("MoveBridge90") &&
            _secondAnimator.GetCurrentAnimatorStateInfo(0).IsName("RotateBridge0")) {

            if (_animator != null)
                _animator.SetTrigger("MoveBridge0");

            if (_secondAnimator != null) {
                _secondAnimator.SetTrigger("RotateBridge90");
                triggerCollider.SetActive(true);
            }
        }

        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("MoveBridge0") &&
            _secondAnimator.GetCurrentAnimatorStateInfo(0).IsName("RotateBridge90")) {

             if (_animator != null)
                _animator.SetTrigger("MoveBridge90");

             if (_secondAnimator != null) {
                _secondAnimator.SetTrigger("RotateBridge0");
                triggerCollider.SetActive(false);
             }
        }


        //if (_secondAnimator.GetCurrentAnimatorStateInfo(0).IsName("RotateBridge0")) {
        //    if (_secondAnimator != null)
        //        _secondAnimator.SetTrigger("RotateBridge90");
        //    triggerCollider.SetActive(true);
        //}
        //else if (_secondAnimator.GetCurrentAnimatorStateInfo(0).IsName("RotateBridge90")) {
        //    if (_secondAnimator != null)
        //        _secondAnimator.SetTrigger("RotateBridge0");
        //    triggerCollider.SetActive(false);
        //}

    }

    //private void OnTriggerExit(Collider other) {

    //    _counter--;

    //    if (_counter == 0)
    //        if (_animator != null)
    //            _animator.SetTrigger("MoveBridge0");
    //}

    //private void PlayAnimation(string animationName) {
    //    Animator _animator = bridge.GetComponent<Animator>();
    //    Animator _secondAnimator = secondBridge.GetComponent<Animator>();

    //    if (_animator != null)
    //        _animator.SetTrigger(animationName);

    //    if (_secondAnimator != null)
    //        _secondAnimator.SetTrigger(animationName);
    //}
}
