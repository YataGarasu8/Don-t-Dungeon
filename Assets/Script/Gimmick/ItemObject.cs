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

    //private void OnTriggerEnter(Collider other) ���� ���ο��� �־����� �ٸ� ������Ʈ�� ����� ���� �ּ�ȭ��
    //{
    //    PlayerController playerController = other.GetComponent<PlayerController>();
    //    if (playerController != null)
    //    {
    //        StartCoroutine(ApplyBoost(playerController));//IEnumerator�� �ڷ�ƾ�� ����ϱ� ���� �������̽�
    //    }
    //    else
    //    {
    //        Debug.Log("playerController�� null�Դϴ�.");
    //    }
    //    gameObject.SetActive(false);
    //}
    //�Ͻ������� ������ �����ϴ� �޼���
    //private IEnumerator ApplyBoost(PlayerController playerController)
    //{
    //    playerController.BoostJumpForce(itemDate.addJumpForce);//������ ���ȸ�ŭ ������ ����
    //    yield return new WaitForSeconds(itemDate.activeTime);//WaitForSeconds:���� �� �ð����� �� ������ ����
    //    playerController.RollBackJumpForce(itemDate.addJumpForce);//������ ���ȸ�ŭ ������ ����
    //}
}
