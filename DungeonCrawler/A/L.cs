using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using robotManager.FiniteStateMachine;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x02000044 RID: 68
	internal class L : State
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x00015690 File Offset: 0x00013890
		public override string DisplayName
		{
			get
			{
				return "dNeedToRepair";
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x000156A4 File Offset: 0x000138A4
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x00009054 File Offset: 0x00007254
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

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x000156BC File Offset: 0x000138BC
		public override bool NeedToRun
		{
			get
			{
				bool result;
				if (!Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause || !C.a())
				{
					result = false;
				}
				else
				{
					bool flag;
					if (ObjectManager.Me.GetDurabilityPercent > 20.0)
					{
						flag = EquippedItems.GetEquippedItems().Any(new Func<WoWItem, bool>(L.A.A.A));
					}
					else
					{
						flag = true;
					}
					result = flag;
				}
				return result;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00015724 File Offset: 0x00013924
		public override void Run()
		{
			Main.logDebug("Overall durability is below 30% or some items are are 0 durability. Setting NeedToVendor to true and teleporting out of the dungeon.", false);
			global::A.A.A = true;
			if (C.a())
			{
				C.b();
			}
		}

		// Token: 0x0400010C RID: 268
		private int A;

		// Token: 0x02000045 RID: 69
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x060001DA RID: 474 RVA: 0x00009069 File Offset: 0x00007269
			internal bool A(WoWItem woWItem_0)
			{
				return woWItem_0.MaxDurability > 0 && woWItem_0.Durability == 0;
			}

			// Token: 0x0400010D RID: 269
			public static readonly L.A A = new L.A();

			// Token: 0x0400010E RID: 270
			public static Func<WoWItem, bool> A;
		}
	}
}
