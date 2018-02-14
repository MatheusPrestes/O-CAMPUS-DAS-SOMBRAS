using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBattleController : MonoBehaviour {

    public AreaBattle areaMonster1;
    public AreaBattle areaMonster2;
    public AreaBattle areaMonster3;
    public BossArea bossArea1;
    public BossArea bossArea2;
    public BossArea bossArea3;

    private BossArea bossAreaDeffault;

    private List<BossArea> listBossArea;
    private List<AreaBattle> listMonsterArea;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void addBossArea()
    {
        listBossArea.Add(bossArea1);
        listBossArea.Add(bossArea2);
        listBossArea.Add(bossArea3);
    }

    private void addMonsterArea()
    {
        listMonsterArea.Add(areaMonster1);
        listMonsterArea.Add(areaMonster2);
        listMonsterArea.Add(areaMonster3);
    }


    public BossArea selectAreaBoss(int index)
    {
        for (int i = 0; i < listBossArea.Capacity; i++)
        {
            if(index == i)
            {
                return listBossArea[i];
            }
        }
        return null;
    }

    public AreaBattle selectAreaMonster(int index)
    {
        for (int i = 0; i < listMonsterArea.Capacity; i++)
        {
            if(index == i)
            {
                return listMonsterArea[i];
            }
        }
        return null;
    }

    public void desativarArea(BossArea areaBoss)
    {
        areaBoss.enabled = false;
    }

    public bool getAreaEnable(AreaBattle area)
    {
        if (area.enabled == true)
        {
            return true;
        }
        else
            return false;
    }

    public bool getAreaBossEnable(BossArea area)
    {
        if (area.enabled == true)
        {
            return true;
        }
        else
            return false;
    }

    public void desativarAreaMonstro(AreaBattle areaMonstro)
    {
        areaMonstro.enabled = false;
    }

    public void selecionaItemBattleMonster(ItemBase item, int efeito)
    {
        ValidaTeclas.changeStateButton(BUTTON_STATE.IN_DEFFAULT);
        if (getAreaEnable(areaMonster1))
        {
            if(item.getCurrentState() == TYPE_ITEM.IN_POCAO)
            {
                areaMonster1.faseMonstro(3);                
            }
            else
            {
                areaMonster1.fight(efeito);
            }
        }
        if (getAreaEnable(areaMonster2))
        {
            if (item.getCurrentState() == TYPE_ITEM.IN_POCAO)
            {
                areaMonster2.faseMonstro(3);
            }
            else
            {
                areaMonster2.fight(efeito);
            }
        }
        if (getAreaEnable(areaMonster3))
        {
            if (item.getCurrentState() == TYPE_ITEM.IN_POCAO)
            {
                areaMonster3.faseMonstro(3);
            }
            else
            {
                areaMonster3.fight(efeito);
            }
        }
    }

    public void selecionaItemBattleBoss(ItemBase item, int efeito)
    {
        ValidaTeclas.changeStateButton(BUTTON_STATE.IN_DEFFAULT);
        if (getAreaBossEnable(bossArea1))
        {
            if (item.getCurrentState() == TYPE_ITEM.IN_POCAO)
            {
                bossArea1.faseBoss(3);
            }
            else
            {
                bossArea1.fightBoss(efeito);
            }
        }

        if (getAreaBossEnable(bossArea2))
        {
            if (item.getCurrentState() == TYPE_ITEM.IN_POCAO)
            {
                bossArea2.faseBoss(3);
            }
            else
            {
                bossArea2.fightBoss(efeito);
            }
        }

        if (getAreaBossEnable(bossArea3))
        {
            if (item.getCurrentState() == TYPE_ITEM.IN_POCAO)
            {
                bossArea3.faseBoss(3);
            }
            else
            {
                bossArea3.fightBoss(efeito);
            }
        }


    }


}
