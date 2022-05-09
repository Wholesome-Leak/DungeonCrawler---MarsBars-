using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using robotManager.FiniteStateMachine;
using robotManager.Helpful;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x0200003F RID: 63
	internal class K : State
	{
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x00015338 File Offset: 0x00013538
		public override string DisplayName
		{
			get
			{
				return "dTeleport";
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x0001534C File Offset: 0x0001354C
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x00008F89 File Offset: 0x00007189
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

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x00015364 File Offset: 0x00013564
		public override bool NeedToRun
		{
			get
			{
				bool result;
				if (!Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause)
				{
					result = false;
				}
				else if (this.A.IsReady)
				{
					this.A = new Timer(3000.0);
					result = (Bag.GetBagItem().Count(new Func<WoWItem, bool>(K.A.A.A)) > 0);
				}
				else
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x000153D4 File Offset: 0x000135D4
		public override void Run()
		{
			WoWItem woWItem = Bag.GetBagItem().FirstOrDefault(new Func<WoWItem, bool>(K.A.A.a));
			if (woWItem != null)
			{
				Main.log("Using " + woWItem.Name + ".");
				ItemsManager.UseContainerItem(woWItem.Name);
			}
		}

		// Token: 0x040000FF RID: 255
		private Timer A = new Timer(3000.0);

		// Token: 0x04000100 RID: 256
		private int A;

		// Token: 0x02000040 RID: 64
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x060001BD RID: 445 RVA: 0x00008FBA File Offset: 0x000071BA
			internal bool A(WoWItem woWItem_0)
			{
				return woWItem_0.Name.Contains("Satchel of");
			}

			// Token: 0x060001BE RID: 446 RVA: 0x00008FBA File Offset: 0x000071BA
			internal bool a(WoWItem woWItem_0)
			{
				return woWItem_0.Name.Contains("Satchel of");
			}

			// Token: 0x04000101 RID: 257
			public static readonly K.A A = new K.A();

			// Token: 0x04000102 RID: 258
			public static Func<WoWItem, bool> A;

			// Token: 0x04000103 RID: 259
			public static Func<WoWItem, bool> a;
		}
	}
}
