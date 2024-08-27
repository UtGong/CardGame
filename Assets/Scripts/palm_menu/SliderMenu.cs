using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class SliderMenu : MonoBehaviour
{
    [SerializeField]
    private PokeInteractable _menuInteractable;

    [SerializeField]
    private GameObject _menuParent;

    [SerializeField]
    private ScrollRect _scrollRect;

    [SerializeField]
    private RectTransform _menuPanel;

    [SerializeField]
    private RectTransform[] _pages;

    [SerializeField]
    private RectTransform[] _titles;

    // [SerializeField]
    // private RectTransform _selectionIndicatorDot;

    [SerializeField]
    private AnimationCurve _paginationButtonScaleCurve;

    [SerializeField]
    private float _defaultPageDistance = 300f;

    [SerializeField]
    private AudioSource _paginationSwipeAudio;

    [SerializeField]
    private AudioSource _showMenuAudio;

    [SerializeField]
    private AudioSource _hideMenuAudio;

    private int _currentSelectedPageIdx;

    private void Start()
    {
        _currentSelectedPageIdx = CalculateNearestPageIdx();
        // _selectionIndicatorDot.position = _paginationDots[_currentSelectedPageIdx].position;
        foreach (var title in _titles)
        {
            title.DOScale(0.5f, 0.3f).SetEase(Ease.OutBack);
        }
        _titles[_currentSelectedPageIdx].DOScale(1.2f, 0.3f).SetEase(Ease.OutBack);

        _menuParent.SetActive(false);
    }

    private void Update()
    {
        var nearestPageIdx = CalculateNearestPageIdx();
        if (nearestPageIdx != _currentSelectedPageIdx)
        {
            _currentSelectedPageIdx = nearestPageIdx;
            _paginationSwipeAudio.Play();
            // _selectionIndicatorDot.position = _paginationDots[_currentSelectedPageIdx].position;
            foreach (var title in _titles)
            {
                title.DOScale(0.5f, 0.3f).SetEase(Ease.OutBack);
            }
            _titles[_currentSelectedPageIdx].DOScale(1.2f, 0.3f).SetEase(Ease.OutBack);
        }

        if (_menuInteractable.State != InteractableState.Select)
        {
            LerpToButton();
        }
    }

    private int CalculateNearestPageIdx()
    {
        var nearestPageIdx = 0;
        var nearestDistance = float.PositiveInfinity;
        for (int idx = 0; idx < _pages.Length; ++idx)
        {
            var deltaX = _pages[idx].localPosition.x + _menuPanel.anchoredPosition.x;
            var adjacentIdx = deltaX < 0f ? idx + 1 : idx - 1;
            var distanceX = Mathf.Abs(deltaX);

            if (distanceX < nearestDistance)
            {
                nearestPageIdx = idx;
                nearestDistance = distanceX;
            }

            var normalizingDistance = _defaultPageDistance;
            if (adjacentIdx >= 0 && adjacentIdx < _pages.Length)
            {
                normalizingDistance = Mathf.Abs(_pages[adjacentIdx].localPosition.x - _pages[idx].localPosition.x);
            }
            var scale = _paginationButtonScaleCurve.Evaluate(distanceX / normalizingDistance);
            _pages[idx].localScale = scale * Vector3.one;
        }
        return nearestPageIdx;
    }

    private void LerpToButton()
    {
        var nearestX = _pages[0].localPosition.x;
        var nearestDistance = Mathf.Abs(nearestX + _menuPanel.anchoredPosition.x);

        for (int idx = 1; idx < _pages.Length; ++idx)
        {
            var x = _pages[idx].localPosition.x;
            var distance = Mathf.Abs(x + _menuPanel.anchoredPosition.x);
            if (distance < nearestDistance)
            {
                nearestX = x;
                nearestDistance = distance;
            }
        }

        const float t = 0.2f;
        _menuPanel.anchoredPosition = Vector2.Lerp(_menuPanel.anchoredPosition, new Vector2(-nearestX, 0f), t);
    }

    /// <summary>
    /// Show/hide the menu.
    /// </summary>
    public void ToggleMenu()
    {
        if (_menuParent.activeSelf)
        {
            _hideMenuAudio.Play();
            _menuParent.SetActive(false);
        }
        else
        {
            _showMenuAudio.Play();
            _menuParent.SetActive(true);
        }
    }
    public void NextPage()
    {
        _menuPanel.DOAnchorPosX(_menuPanel.anchoredPosition.x + 300f, 0.2f).SetEase(Ease.OutCubic);

        // _scrollRect.DOHorizontalNormalizedPos(_menuPanel.anchoredPosition.x+300f, 0.2f).SetEase(Ease.OutCubic);
    }
    public void PreviousPage()
    {
        _menuPanel.DOAnchorPosX(_menuPanel.anchoredPosition.x - 300f, 0.2f).SetEase(Ease.OutCubic);
    }
}