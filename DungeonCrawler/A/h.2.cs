using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using robotManager.FiniteStateMachine;
using wManager.Wow.Bot.Tasks;
using wManager.Wow.Class;
using wManager.Wow.Enums;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x02000030 RID: 48
	internal class h : State
	{
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000152 RID: 338 RVA: 0x00013C00 File Offset: 0x00011E00
		public override string DisplayName
		{
			get
			{
				return "dPartyResurrection";
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000153 RID: 339 RVA: 0x00013C14 File Offset: 0x00011E14
		// (set) Token: 0x06000154 RID: 340 RVA: 0x00008D47 File Offset: 0x00006F47
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

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000155 RID: 341 RVA: 0x00013C2C File Offset: 0x00011E2C
		public override bool NeedToRun
		{
			get
			{
				bool result;
				if (!Conditions.InGameAndConnectedAndProductStartedNotInPause || !C.a() || h.A.InCombat || Fight.InFight)
				{
					result = false;
				}
				else
				{
					bool flag;
					if (h.A.Keys.Contains(h.A.WowClass))
					{
						flag = Party.GetPartyHomeAndInstance().Any(new Func<WoWPlayer, bool>(h.A.A.A));
					}
					else
					{
						flag = false;
					}
					result = flag;
				}
				return result;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000156 RID: 342 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000157 RID: 343 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00013CAC File Offset: 0x00011EAC
		public override void Run()
		{
			if (Party.GetPartyHomeAndInstance().Where(new Func<WoWPlayer, bool>(h.A.A.a)).Count<WoWPlayer>() == 0)
			{
				h.a a = new h.a();
				a.A = Party.GetPartyHomeAndInstance().Where(new Func<WoWPlayer, bool>(h.A.A.B)).OrderBy(new Func<WoWPlayer, float>(h.A.A.b)).FirstOrDefault<WoWPlayer>();
				if (a.A != null)
				{
					Main.logDebug(string.Format("Found corpse:{0}, Corpse distance: {1}, LOS: {2}", a.A.GetBaseAddress, a.A.GetDistance, !TraceLine.TraceLineGo(a.A.Position)), false);
					if ((a.A.GetDistance >= 28f || TraceLine.TraceLineGo(a.A.Position)) && GoToTask.ToPosition(a.A.Position, 3.5f, true, new BooleanDelegate(a.A)))
					{
						MovementManager.StopMove();
					}
					if (!TraceLine.TraceLineGo(a.A.Position) && a.A.GetDistance <= 28f)
					{
						Main.logDebug("Targetting dead player " + a.A.Name + ".", false);
						Interact.InteractGameObject(a.A.GetBaseAddress, false, false);
						return;
					}
				}
				Main.logDebug("Could not find a player to rezz.", false);
			}
			Thread.Sleep(500);
		}

		// Token: 0x040000CF RID: 207
		private static readonly WoWLocalPlayer A = ObjectManager.Me;

		// Token: 0x040000D0 RID: 208
		private int A;

		// Token: 0x040000D1 RID: 209
		public static Dictionary<WoWClass, string> A = new Dictionary<WoWClass, string>
		{
			{
				11,
				"Revive"
			},
			{
				2,
				"Redemption"
			},
			{
				5,
				"Resurrection"
			},
			{
				7,
				"Ancestral Spirit"
			}
		};

		// Token: 0x02000031 RID: 49
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x0600015D RID: 349 RVA: 0x00008D5C File Offset: 0x00006F5C
			internal bool A(WoWPlayer woWPlayer_0)
			{
				return woWPlayer_0.IsDead;
			}

			// Token: 0x0600015E RID: 350 RVA: 0x00013EC0 File Offset: 0x000120C0
			internal bool a(WoWPlayer woWPlayer_0)
			{
				return woWPlayer_0.CastingSpell.Name == "Revive" || woWPlayer_0.CastingSpell.Name == "Redemption" || woWPlayer_0.CastingSpell.Name == "Resurrection" || woWPlayer_0.CastingSpell.Name == "Ancestral Spirit";
			}

			// Token: 0x0600015F RID: 351 RVA: 0x00013F2C File Offset: 0x0001212C
			internal bool B(WoWPlayer woWPlayer_0)
			{
				h.B b = new h.B();
				b.A = woWPlayer_0;
				return b.A.IsDead && b.A.GetDistance <= 500f && Party.GetPartyHomeAndInstance().Where(new Func<WoWPlayer, bool>(b.A)).Count<WoWPlayer>() == 0;
			}

			// Token: 0x06000160 RID: 352 RVA: 0x000085D8 File Offset: 0x000067D8
			internal float b(WoWPlayer woWPlayer_0)
			{
				return woWPlayer_0.GetDistance;
			}

			// Token: 0x040000D2 RID: 210
			public static readonly h.A A = new h.A();

			// Token: 0x040000D3 RID: 211
			public static Func<WoWPlayer, bool> A;

			// Token: 0x040000D4 RID: 212
			public static Func<WoWPlayer, bool> a;

			// Token: 0x040000D5 RID: 213
			public static Func<WoWPlayer, bool> B;

			// Token: 0x040000D6 RID: 214
			public static Func<WoWPlayer, float> A;
		}

		// Token: 0x02000032 RID: 50
		[CompilerGenerated]
		private sealed class a
		{
			// Token: 0x06000162 RID: 354 RVA: 0x00008D64 File Offset: 0x00006F64
			internal bool A(object object_0)
			{
				return this.A.GetDistance >= 28f || TraceLine.TraceLineGo(this.A.Position);
			}

			// Token: 0x040000D7 RID: 215
			public WoWPlayer A;
		}

		// Token: 0x02000033 RID: 51
		[CompilerGenerated]
		private sealed class B
		{
			// Token: 0x06000164 RID: 356 RVA: 0x00013F88 File Offset: 0x00012188
			internal bool A(WoWPlayer woWPlayer_0)
			{
				return woWPlayer_0.TargetObject == this.A && (woWPlayer_0.CastingSpell.Name == "Revive" || woWPlayer_0.CastingSpell.Name == "Redemption" || woWPlayer_0.CastingSpell.Name == "Resurrection" || woWPlayer_0.CastingSpell.Name == "Ancestral Spirit");
			}

			// Token: 0x040000D8 RID: 216
			public WoWPlayer A;
		}
	}
}
