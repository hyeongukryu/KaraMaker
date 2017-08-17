using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
	public ItemInfo[] Item;

	private Text ShopNPCText;
	private int pageNum;
	private int price;
	private bool canOverlap;

	private void Start()
	{
		pageNum = 1;
		ShowItem();

		ShopNPCText = GameObject.Find("Shop NPC Text Box").transform.Find("Text").gameObject.GetComponent<Text>();
	}

	private void Update()
	{
		if(price == 0)
		{
			GetComponent<Image>().color = new Color (0.2f, 0.2f, 0.2f, 1);
			GetComponent<Button>().interactable = false;
		}
		else
		{
			GetComponent<Image>().color = new Color (1, 1, 1, 1);
			GetComponent<Button>().interactable = true;
		}
	}

	private void ShowItem()
	{
		if(Item.Length < pageNum)
		{
			gameObject.SetActive(false);
			return;
		}

		gameObject.SetActive(true);

		GetComponent<Image>().sprite = Item[pageNum - 1].ItemImage;
		price = Item[pageNum - 1].price;
		canOverlap = Item[pageNum - 1].canOverlap;
	}

	public void NextPage()
	{
		pageNum = 2;
		ShowItem();
	}

	public void PreviousPage()
	{
		pageNum = 1;
		ShowItem();
	}

	public void TryToBuyItem() //구매하려고 버튼 누를 시
	{
		ShopNPCText.text = "그거 살꺼야? 엄청 괜찮은 거라구~";
	}

	public void StopBuyItem() //그만둔다를 눌렀을 경우
	{
		ShopNPCText.text = "안녕, 어서와! 토토코네 가게 물건들은 다 최고라구!";
	}

	public void BuyItem()
	{
		if(CheckMoney() == true) //돈이 충분할 경우
		{
			ShopNPCText.text = "응, 잘 선택했어!";
			KaramatsuManager.Gold -= price;

			if(canOverlap == false)
			{
				Item[pageNum - 1].price = 0;
				price = 0;
			}
		}
		else //돈이 없을 경우
		{
			ShopNPCText.text = "에에~~ 그거 사기엔 돈이 없는게 아닐까~";
		}
	}

	private bool CheckMoney()
	{
		if(KaramatsuManager.Gold < price)
		{
			return false;
		}

		return true;
	}
}