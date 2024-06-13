using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _onWin;
    [SerializeField] private GameObject _winMenu;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            _onWin?.Invoke();
            StartCoroutine(WinMenuAnim());
        }
    }

    IEnumerator WinMenuAnim()
    {
        _winMenu.SetActive(true);
        _winMenu.transform.DOLocalMove(Vector3.zero, 1);
        // _winMenu.transform.GetComponent<Image>().DOFillAmount(255, 1);
        yield return new WaitForSeconds(1);
    }
}
