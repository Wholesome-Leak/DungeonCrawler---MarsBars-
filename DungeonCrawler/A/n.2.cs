using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using robotManager.FiniteStateMachine;
using robotManager.Helpful;
using wManager.Wow.Bot.Tasks;
using wManager.Wow.Enums;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x0200004D RID: 77
	internal class n : State
	{
		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000211 RID: 529 RVA: 0x00016AF4 File Offset: 0x00014CF4
		public override string DisplayName
		{
			get
			{
				return "dDead";
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000212 RID: 530 RVA: 0x00016B08 File Offset: 0x00014D08
		// (set) Token: 0x06000213 RID: 531 RVA: 0x0000918D File Offset: 0x0000738D
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

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000214 RID: 532 RVA: 0x00016B20 File Offset: 0x00014D20
		public override bool NeedToRun
		{
			get
			{
				return Conditions.InGameAndConnectedAndProductStartedNotInPause && n.A.IsDead;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000215 RID: 533 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000216 RID: 534 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00016B44 File Offset: 0x00014D44
		public override void Run()
		{
			Dungeon dungeon = e.a() ?? e.A();
			if (!n.A.HaveBuff("Ghost"))
			{
				this.A();
				bool flag = Party.GetPartyHomeAndInstance().Any(new Func<WoWPlayer, bool>(n.A.A.A));
				Main.logDebug("dDead: Someone can Rezz: " + flag.ToString(), false);
				if (!flag && dungeon != null && (dungeon.Entrance != null || dungeon.DungeonProfile.DeathRunPath.Count > 0))
				{
					Main.logDebug("dDead: No one can Rezz, releasing", false);
					Lua.LuaDoString("RepopMe();", false);
				}
				Thread.Sleep(300);
			}
			if (n.A.HaveBuff("Ghost"))
			{
				if (dungeon != null)
				{
					if (dungeon.DungeonProfile != null && dungeon.DungeonProfile.DeathRunPath.Count > 0)
					{
						if (!MovementManager.InMovement)
						{
							Main.log("Deathrun route found.");
							int num = Math.NearestVector3OfListVectors3(dungeon.DungeonProfile.DeathRunPath, n.A.Position);
							Main.logDebug(string.Format("dDead: Index of closest vector {0}.", num), false);
							if (GoToTask.ToPosition(dungeon.DungeonProfile.DeathRunPath[num], 3.5f, false, null))
							{
								Main.logDebug("dDead: Reached closest vector, continuing deathroute.", false);
								MovementManager.Go(dungeon.DungeonProfile.DeathRunPath.GetRange(num, dungeon.DungeonProfile.DeathRunPath.Count - num), true);
							}
						}
					}
					else if (!MovementManager.InMovement)
					{
						Main.log("No Deathrun route found, using pathfinder.");
						GoToTask.ToPosition(dungeon.Entrance, 3.5f, false, null);
					}
				}
				else
				{
					Tuple<Dungeon, float> tuple = null;
					foreach (Dungeon dungeon2 in e.A)
					{
						float num2 = dungeon2.Entrance.DistanceTo(n.A.PositionCorpse);
						if (tuple == null)
						{
							tuple = new Tuple<Dungeon, float>(dungeon2, 9999f);
						}
						else if (num2 < tuple.Item2)
						{
							tuple = new Tuple<Dungeon, float>(dungeon2, num2);
						}
					}
					if (tuple.Item1 != null)
					{
						e.a(tuple.Item1);
						e.a().DungeonProfile = e.A(tuple.Item1);
						if (e.a().DungeonProfile == null)
						{
							Main.log(string.Format("Dungeon closest to our corpse is {0} with a distance of {1} yards. Pathfinding there.", tuple.Item1.Name, tuple.Item2));
							GoToTask.ToPosition(tuple.Item1.Entrance, 3.5f, false, null);
						}
					}
				}
			}
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00016E2C File Offset: 0x0001502C
		private void A()
		{
			string value = Lua.LuaDoString<string>("return HasSoulstone()", "");
			if (!string.IsNullOrWhiteSpace(value))
			{
				if (ObjectManager.GetWoWUnitAttackables(30f).Count(new Func<WoWUnit, bool>(n.A.A.A)) == 0 && Lua.LuaDoString<bool>("return StaticPopup1 and StaticPopup1:IsVisible();", ""))
				{
					C.A(500, 3000, "");
					Lua.LuaDoString("StaticPopup1Button1:Click()", false);
					Main.log("Self Rezz accepted.");
				}
			}
		}

		// Token: 0x04000122 RID: 290
		private static readonly WoWLocalPlayer A = ObjectManager.Me;

		// Token: 0x04000123 RID: 291
		private int A;

		// Token: 0x04000124 RID: 292
		public static List<WoWClass> A = new List<WoWClass>
		{
			2,
			5,
			7,
			11
		};

		// Token: 0x0200004E RID: 78
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x0600021D RID: 541 RVA: 0x000091D5 File Offset: 0x000073D5
			internal bool A(WoWPlayer woWPlayer_0)
			{
				return n.A.Contains(woWPlayer_0.WowClass) && woWPlayer_0.IsAlive;
			}

			// Token: 0x0600021E RID: 542 RVA: 0x000091F2 File Offset: 0x000073F2
			internal bool A(WoWUnit woWUnit_0)
			{
				return !TraceLine.TraceLineGo(n.A.Position, woWUnit_0.Position, 337);
			}

			// Token: 0x04000125 RID: 293
			public static readonly n.A A = new n.A();

			// Token: 0x04000126 RID: 294
			public static Func<WoWPlayer, bool> A;

			// Token: 0x04000127 RID: 295
			public static Func<WoWUnit, bool> A;
		}
	}
}
