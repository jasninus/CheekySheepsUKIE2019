using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PlanterVolunteer : VolunteerType
{
    public Action<uint> updateSeedUI;
    public Action<bool> updateReplantingUI;

    [SerializeField] private float replantCooldown;

    private bool isReplanting;

    //public uint seedsLeft;

    //public uint SeedsLeft
    //{
    //    get => seedsLeft;
    //    set
    //    {
    //        seedsLeft = value;
    //        if (seedsLeft == 0)
    //        {
    //            Disband();
    //        }

    //        updateSeedUI?.Invoke(seedsLeft);
    //    }
    //}

    public bool IsReplanting
    {
        get => isReplanting;
        set
        {
            StopAllCoroutines();
            isReplanting = value;
            updateReplantingUI?.Invoke(isReplanting);

            if (isReplanting)
            {
                StartCoroutine(ReplantingTrees(replantCooldown));
            }

            if (!isReplanting)
            {
                RemoveAllReplantInstancesCreatedByThisPlanter();
            }
        }
    }

    private IEnumerator ReplantingTrees(float replantCooldown)
    {
        yield return new WaitForSeconds(replantCooldown);
        VolunteerData.replantInstances.Add(new ReplantInstance { position = transform.position, volunteer = this });
        StartCoroutine(ReplantingTrees(replantCooldown));
    }

    private void RemoveAllReplantInstancesCreatedByThisPlanter()
    {
        List<int> indecesToRemove = new List<int>();
        for (int i = 0; i < VolunteerData.replantInstances.Count; i++)
        {
            if (VolunteerData.replantInstances[i].volunteer == this)
            {
                indecesToRemove.Add(i);
            }
        }

        foreach (int i in indecesToRemove)
        {
            VolunteerData.replantInstances.RemoveAt(i);
        }
    }

    public override void UpdateAllUI()
    {
        base.UpdateAllUI();
        updateReplantingUI?.Invoke(IsReplanting);
        //updateSeedUI?.Invoke(SeedsLeft);
    }

    //private void Disband()
    //{
    //    Debug.Log("Hey ho, we are disbanding yo");
    //}
}