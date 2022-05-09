using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using robotManager.FiniteStateMachine;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x02000034 RID: 52
	internal class I : State
	{
		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00014004 File Offset: 0x00012204
		public override string DisplayName
		{
			get
			{
				return "dDungeonComplete";
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000166 RID: 358 RVA: 0x00014018 File Offset: 0x00012218
		// (set) Token: 0x06000167 RID: 359 RVA: 0x00008D8B File Offset: 0x00006F8B
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

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000168 RID: 360 RVA: 0x00014030 File Offset: 0x00012230
		public override bool NeedToRun
		{
			get
			{
				bool result;
				if (!Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause)
				{
					result = false;
				}
				else
				{
					bool flag;
					if (!e.B() || ObjectManager.Me.InCombat)
					{
						if (e.a() != null && e.a().DungeonProfile != null && e.a().DungeonProfile.FinalBossId > 0)
						{
							if (ObjectManager.GetObjectWoWUnit().Any(new Func<WoWUnit, bool>(I.A.A.A)))
							{
								goto IL_71;
							}
						}
						flag = (C.C() == "abandonedInDungeon");
						goto IL_83;
					}
					IL_71:
					flag = true;
					IL_83:
					result = flag;
				}
				return result;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000169 RID: 361 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600016A RID: 362 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000140C4 File Offset: 0x000122C4
		public override void Run()
		{
			if (!this.A)
			{
				Task.Delay(this.A()).ContinueWith(new Action<Task>(this.A));
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x000140FC File Offset: 0x000122FC
		public int A()
		{
			this.A = true;
			return C.A(15000, 20000, "after dungeon is complete for rolls to finish.");
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00014128 File Offset: 0x00012328
		[CompilerGenerated]
		private void A(Task task_0)
		{
			Main.logDebug("Leaving party/Teleporting out of dungeon", false);
			if (C.a())
			{
				if (ObjectManager.Me.IsInParty)
				{
					Lua.LuaDoString("LeaveParty()", false);
				}
				if (C.C() == "abandonedInDungeon")
				{
					C.b();
				}
			}
			e.a().DungeonProfile.DungeonSteps.ForEach(new Action<DungeonStep>(I.A.A.A));
			e.A(false);
			e.a(null);
			global::A.A.A(null);
			global::A.A.A = true;
			global::A.A.a = true;
			this.A = false;
		}

		// Token: 0x040000D9 RID: 217
		private int A;

		// Token: 0x040000DA RID: 218
		private bool A;

		// Token: 0x02000035 RID: 53
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x06000171 RID: 369 RVA: 0x00008DA0 File Offset: 0x00006FA0
			internal bool A(WoWUnit woWUnit_0)
			{
				return woWUnit_0.Entry == e.a().DungeonProfile.FinalBossId && woWUnit_0.IsDead;
			}

			// Token: 0x06000172 RID: 370 RVA: 0x00008DC2 File Offset: 0x00006FC2
			internal void A(DungeonStep dungeonStep_0)
			{
				dungeonStep_0.StepComplete = false;
			}

			// Token: 0x040000DB RID: 219
			public static readonly I.A A = new I.A();

			// Token: 0x040000DC RID: 220
			public static Func<WoWUnit, bool> A;

			// Token: 0x040000DD RID: 221
			public static Action<DungeonStep> A;
		}
	}
}
