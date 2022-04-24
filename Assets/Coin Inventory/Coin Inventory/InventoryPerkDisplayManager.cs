using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InventoryPerkDisplayManager : MonoBehaviour
{
    [SerializeField]
    private List<DiaplayablePerk> perks;
    [SerializeField]
    float diff = 287.7399f;
    [SerializeField]
    private Vector3 firstCardPos;
    [SerializeField]
    private Vector3 startingLocalscale;
    [SerializeField]
    BeyBladeInventory inventory;
    public GameObject PerksParent;
    private float count = 0f;

    private void OnEnable()
    {
        PerkButtonClickManager.OnPerkRemovedFromInventory += RemovePerkFromDisplay;
    }
    private void OnDisable()
    {
        PerkButtonClickManager.OnPerkRemovedFromInventory -= RemovePerkFromDisplay;
        
    }
    private void Start()
    {
        foreach (var _perk in inventory.InventoryPerkList)
        {
            var _perkPrefab = Instantiate(_perk.perkPrefab, transform);
            var _card = _perkPrefab.GetComponent<DiaplayablePerk>();
            AddToCardList(_card);
        }
    }
    public void RemovePerkFromDisplay(GameObject gameObj)
    {
        Debug.Log("Inside Animation start  function");
        int len = perks.Count;
        foreach(DiaplayablePerk card in perks)
        {
            card.TimeElapsed = 0f;
        }
        var _perk = perks.Find(p => p.gameObject == gameObj);
        if(_perk != null)
        {
            var _index = perks.IndexOf(_perk);
            perks.Remove(_perk);
            Destroy(_perk.gameObject);
            AnimateTransition(_index);
        }
        else
        {
            Debug.Log($"{gameObj} does not have any card corresponding to it");
        }
    }

    void AnimateTransition(int index)
    {        
        for (int i = index ; i < perks.Count; i++)
        {
            Vector3 start = perks[i].gameObject.transform.localPosition;
            Vector3 end = perks[i].gameObject.transform.localPosition - new Vector3(diff, 0, 0);
            perks[i].TimeElapsed = 0f;
            StartCoroutine(AnimateCard(start, end, perks[i].gameObject));
        }

    }


    IEnumerator AnimateCard(Vector3 start, Vector3 end, GameObject obj)
    {
        obj.GetComponent<DiaplayablePerk>().TimeElapsed = 0f;
        while (start != end)
        {
            obj.transform.localPosition = Vector3.Lerp(start, end, obj.GetComponent<DiaplayablePerk>().TimeElapsed);
            obj.GetComponent<DiaplayablePerk>().TimeElapsed += Time.deltaTime;
            start = obj.transform.localPosition;
            yield return null;
        }
        obj.GetComponent<DiaplayablePerk>().TimeElapsed = 0f;
    }

    IEnumerator AnimateParent(Vector3 start, Vector3 end, GameObject obj)
    {
        float timeElapsed = 0f;
        while (start != end)
        {
            obj.transform.localPosition = Vector3.Lerp(start, end,timeElapsed);
            timeElapsed += Time.deltaTime;
            start = obj.transform.localPosition;
            yield return null;
        }
    }

    public void ChangeRightClick()
    {
        if (count >= perks.Count - 5)
        {
            count = perks.Count-4;
        }
        else
        {
            count++;
        }
        Debug.Log(count);
        if (count < perks.Count - 4)
            StartCoroutine(AnimateParent(PerksParent.transform.localPosition, PerksParent.transform.localPosition - new Vector3(diff, 0, 0), PerksParent));
    }
    public void ChangeLeftClick()
    {
        if(count > 0){
            count --;
        }
        else{
            count = 0;
        }
        Debug.Log(count);
        if (count > 0)
            StartCoroutine(AnimateParent(PerksParent.transform.localPosition, PerksParent.transform.localPosition + new Vector3(diff, 0, 0), PerksParent));
    }

    public void AddToCardList(DiaplayablePerk _card)
    {
        if (perks.Contains(_card))
            return;
        if (perks.Count == 0)
        {
            _card.gameObject.transform.localPosition = firstCardPos;
        }
        else
        {
            Debug.Log("Initial pos = " + _card.gameObject.transform.localPosition);
            _card.gameObject.transform.localPosition = perks[perks.Count - 1].transform.localPosition + new Vector3(diff, 0f, 0f);
            Debug.Log("final pos = " + _card.gameObject.transform.localPosition);
        }
        _card.gameObject.transform.localScale = startingLocalscale;
        perks.Add(_card);
    }
}
