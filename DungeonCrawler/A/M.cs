using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using robotManager.FiniteStateMachine;
using wManager;
using wManager.Wow.Bot.Tasks;
using wManager.Wow.Class;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x02000048 RID: 72
	internal class M : State
	{
		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x000159F0 File Offset: 0x00013BF0
		public override string DisplayName
		{
			get
			{
				return "dTraining";
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060001EA RID: 490 RVA: 0x00015A04 File Offset: 0x00013C04
		// (set) Token: 0x060001EB RID: 491 RVA: 0x000090E7 File Offset: 0x000072E7
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

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00015A1C File Offset: 0x00013C1C
		public override bool NeedToRun
		{
			get
			{
				bool result;
				if (!Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause || C.a() || !global::A.A.a || !ObjectManager.Me.IsValid || !wManagerSetting.CurrentSetting.TrainNewSkills)
				{
					result = false;
				}
				else
				{
					if (this.A.Count == 0)
					{
						for (int i = 1; i <= 80; i++)
						{
							if (i % 2 == 0)
							{
								this.A.Add(i);
							}
						}
					}
					bool flag;
					if (DungeonCrawlerSettings.CurrentSetting.LevelsToTrain.Count != 0)
					{
						flag = DungeonCrawlerSettings.CurrentSetting.LevelsToTrain.Any(new Func<int, bool>(M.A.A.a));
					}
					else
					{
						flag = this.A.Any(new Func<int, bool>(M.A.A.A));
					}
					result = (flag && NpcDB.GetNpcNearby(global::A.A.A, (ObjectManager.Me.PlayerFaction == "Horde") ? 1 : 2, Usefuls.ContinentId, ObjectManager.Me.Position, false, 0).Entry > 0);
				}
				return result;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060001ED RID: 493 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060001EE RID: 494 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00015B50 File Offset: 0x00013D50
		public override void Run()
		{
			Npc npc = new Npc();
			if (global::A.A.A > 0)
			{
				npc = NpcDB.GetNpcNearby(global::A.A.A, (ObjectManager.Me.PlayerFaction == "Horde") ? 1 : 2, Usefuls.ContinentId, ObjectManager.Me.Position, false, 0);
			}
			if (npc.Entry > 0)
			{
				Main.log("Trainer found - " + npc.Name);
				if (GoToTask.ToPositionAndIntecractWith(npc, false, null, false))
				{
					this.A();
					Thread.Sleep(200);
					this.A();
					Thread.Sleep(200);
					this.A();
					Thread.Sleep(200);
					this.A();
					Thread.Sleep(200);
					global::A.A.a = false;
					Main.log("Training class spells completed.");
				}
			}
			else
			{
				global::A.A.a = false;
			}
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00015C28 File Offset: 0x00013E28
		public void A()
		{
			if (DungeonCrawlerSettings.CurrentSetting.SpellsToBuy.Count == 0)
			{
				Trainer.TrainingSpell();
			}
			else
			{
				Lua.LuaDoString("SetTrainerServiceTypeFilter(\"available\",1);\r\n                            SetTrainerServiceTypeFilter(\"unavailable\", 0);\r\n                            SetTrainerServiceTypeFilter(\"used\", 0); ", false);
				int num = Lua.LuaDoString<int>("return GetNumTrainerServices()", "");
				for (int i = 0; i < num; i++)
				{
					string text = Lua.LuaDoString<string>(string.Format("name, rank, category, expanded = GetTrainerServiceInfo({0}); return name;", i), "");
					if (DungeonCrawlerSettings.CurrentSetting.SpellsToBuy.Contains(text))
					{
						if (ObjectManager.Me.GetMoneyCopper > (long)Lua.LuaDoString<int>(string.Format("moneyCost, talentCost, professionCost = GetTrainerServiceCost({0}); return moneyCost", i), ""))
						{
							Lua.LuaDoString(string.Format("BuyTrainerService({0});", i), false);
						}
						else
						{
							Main.log("Not enough money to buy " + text);
						}
					}
				}
			}
		}

		// Token: 0x04000116 RID: 278
		private int A;

		// Token: 0x04000117 RID: 279
		private List<int> A = new List<int>();

		// Token: 0x02000049 RID: 73
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x060001F4 RID: 500 RVA: 0x0000910F File Offset: 0x0000730F
			internal bool A(int int_0)
			{
				return (long)int_0 == (long)((ulong)ObjectManager.Me.Level);
			}

			// Token: 0x060001F5 RID: 501 RVA: 0x0000910F File Offset: 0x0000730F
			internal bool a(int int_0)
			{
				return (long)int_0 == (long)((ulong)ObjectManager.Me.Level);
			}

			// Token: 0x04000118 RID: 280
			public static readonly M.A A = new M.A();

			// Token: 0x04000119 RID: 281
			public static Func<int, bool> A;

			// Token: 0x0400011A RID: 282
			public static Func<int, bool> a;
		}
	}
}
