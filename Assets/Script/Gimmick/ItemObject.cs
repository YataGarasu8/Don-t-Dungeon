using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}
public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemDate itemDate;

    public string GetInteractPrompt()
    {
        string prompt = $"{itemDate.itemName}\n{itemDate.ItemExplanation}";
        return prompt;
    }

    public void OnInteract()
    {
        CharacterManager.Instance.Player.itemDate = itemDate;
        CharacterManager.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }

    //private void OnTriggerEnter(Collider other) 원래 코인에만 넣었지만 다른 오브젝트를 만들기 위해 주석화함
    //{
    //    PlayerController playerController = other.GetComponent<PlayerController>();
    //    if (playerController != null)
    //    {
    //        StartCoroutine(ApplyBoost(playerController));//IEnumerator은 코루틴을 사용하기 위한 인터페이스
    //    }
    //    else
    //    {
    //        Debug.Log("playerController가 null입니다.");
    //    }
    //    gameObject.SetActive(false);
    //}
    //일시적으로 스탯이 증가하는 메서드
    //private IEnumerator ApplyBoost(PlayerController playerController)
    //{
    //    playerController.BoostJumpForce(itemDate.addJumpForce);//지정한 스탯만큼 점프력 증가
    //    yield return new WaitForSeconds(itemDate.activeTime);//WaitForSeconds:게임 내 시간으로 초 단위로 지연
    //    playerController.RollBackJumpForce(itemDate.addJumpForce);//지정한 스탯만큼 점프력 감소
    //}
}
