using System;
using System.Collections.Generic;
using robotManager.FiniteStateMachine;
using wManager;
using wManager.Wow.Bot.Tasks;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x0200004F RID: 79
	internal class O : State
	{
		// Token: 0x1700009C RID: 156
		// (get) Token: 0x0600021F RID: 543 RVA: 0x00016EC0 File Offset: 0x000150C0
		public override string DisplayName
		{
			get
			{
				return "dLooting";
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000220 RID: 544 RVA: 0x00016ED4 File Offset: 0x000150D4
		// (set) Token: 0x06000221 RID: 545 RVA: 0x00009211 File Offset: 0x00007411
		public override int Priority
		{
			get
			{
				return this.A;
			}
			set
			{
				this.A = value;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000222 RID: 546 RVA: 0x00016EEC File Offset: 0x000150EC
		public override bool NeedToRun
		{
			get
			{
				bool result;
				if (!wManagerSetting.CurrentSetting.LootMobs || !Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause || Conditions.IsAttackedAndCannotIgnore || Battleground.IsInBattleground())
				{
					result = false;
				}
				else
				{
					this.A = new List<WoWUnit>();
					List<WoWUnit> woWUnitLootable = ObjectManager.GetWoWUnitLootable();
					if (wManagerSetting.CurrentSetting.SkinMobs && wManagerSetting.CurrentSetting.SkinNinja)
					{
						woWUnitLootable.AddRange(ObjectManager.GetWoWUnitSkinnable(new List<ulong>(wManagerSetting.GetListGuidBlackListed())));
					}
					foreach (WoWUnit woWUnit in woWUnitLootable)
					{
						if (woWUnit.IsValid && woWUnit.GetDistance2D <= wManagerSetting.CurrentSetting.SearchRadiusMobs && woWUnit.GetDistanceZ <= wManagerSetting.CurrentSetting.MaxZDistanceAttack && ((double)woWUnit.GetDistance2D < 15.0 || !wManagerSetting.MaxUnitNearest(woWUnit, 50000)))
						{
							this.A.Add(woWUnit);
						}
					}
					result = (this.A.Count > 0);
				}
				return result;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000223 RID: 547 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000224 RID: 548 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000921A File Offset: 0x0000741A
		public override void Run()
		{
			LootingTask.Pulse(this.A);
		}

		// Token: 0x04000128 RID: 296
		private int A;

		// Token: 0x04000129 RID: 297
		private List<WoWUnit> A = new List<WoWUnit>();
	}
}
