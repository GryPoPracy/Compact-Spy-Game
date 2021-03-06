﻿using BaseGameLogic.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CaughtCanvas : SingletonMonoBehaviour<CaughtCanvas>
{
    [SerializeField] private float _fadeSpeed = 1f;
    [SerializeField, Range(0f,1f)] private float _fadeStatus = 0f;
    private Coroutine coroutine = null;

    [Space] public FadeUpdateCallback _fadeUpdateCallback = new FadeUpdateCallback();
    public UnityEvent OnFadingIn = new UnityEvent();
    public UnityEvent OnFadedIn = new UnityEvent();
    public UnityEvent OnFadingOut = new UnityEvent();
    public UnityEvent OnFadedOut = new UnityEvent();

    public bool FadedIn { get { return _fadeStatus >= 1f; } }
    public bool FadedOut { get { return _fadeStatus <= 0f; } }

    private IEnumerator FadeInCorutine()
    {
        OnFadingIn.Invoke();
        while (_fadeStatus < 1f)
        {
            _fadeStatus = Mathf.MoveTowards(_fadeStatus, 1f, _fadeSpeed * Time.deltaTime);
            _fadeUpdateCallback.Invoke(_fadeStatus);
            yield return null;
        }
        OnFadedIn.Invoke();
    }

    private IEnumerator FadeOutCorutine()
    {
        OnFadingOut.Invoke();
        while (_fadeStatus > 0f)
        {
            _fadeStatus = Mathf.MoveTowards(_fadeStatus, 0f, _fadeSpeed * Time.deltaTime);
            _fadeUpdateCallback.Invoke(_fadeStatus);
            yield return null;
        }
        OnFadedOut.Invoke();
        gameObject.SetActive(false);
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
        StopCurrentCorutine();
        coroutine = StartCoroutine(FadeInCorutine());
    }

    public void FadeOut()
    {
        StopCurrentCorutine();
        coroutine = StartCoroutine(FadeOutCorutine());
    }

    public void StopCurrentCorutine()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }
}

[Serializable] public class FadeUpdateCallback : UnityEvent<float> { }
