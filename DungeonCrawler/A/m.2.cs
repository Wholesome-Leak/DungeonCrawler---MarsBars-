using System;
using System.Collections.Generic;
using System.Threading;
using robotManager.FiniteStateMachine;
using robotManager.Helpful;
using wManager;
using wManager.Wow.Bot.Tasks;
using wManager.Wow.Class;
using wManager.Wow.Enums;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x0200004A RID: 74
	internal class m : State
	{
		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x00015D00 File Offset: 0x00013F00
		public override string DisplayName
		{
			get
			{
				return "dVendoring";
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00015D14 File Offset: 0x00013F14
		public override bool NeedToRun
		{
			get
			{
				return Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause && !global::A.C.a() && global::A.A.A;
			}
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00015D40 File Offset: 0x00013F40
		public override void Run()
		{
			m.A = true;
			try
			{
				this.A();
			}
			catch (Exception ex)
			{
				string str = "dVendoringState : State > Run(): ";
				Exception ex2 = ex;
				Main.logError(str + ((ex2 != null) ? ex2.ToString() : null));
			}
			m.A = false;
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00015D90 File Offset: 0x00013F90
		private void A()
		{
			MovementManager.StopMove();
			List<Npc> list = new List<Npc>();
			Npc npc = this.A(200);
			if (this.a(99).IsValid())
			{
				list.Add(this.a(99));
			}
			if (this.d().IsValid())
			{
				list.Add(this.d());
			}
			if (list.Count == 0 && this.B(200).IsValid())
			{
				list.Add(this.B(200));
			}
			if (npc.IsValid() && !Conditions.IsAttackedAndCannotIgnore && Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause)
			{
				string str = "Going to Mailbox (";
				Npc npc2 = npc;
				Main.log(str + ((npc2 != null) ? npc2.ToString() : null) + ")");
				GoToTask.ToPosition(npc.Position, 10f, wManagerSetting.CurrentSetting.BlackListIfNotCompletePath, null);
				if (GoToTask.ToPositionAndIntecractWith(npc, wManagerSetting.CurrentSetting.BlackListIfNotCompletePath, null, false))
				{
					Main.log("Mailbox found");
					if (!Conditions.IsAttackedAndCannotIgnore && Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause)
					{
						Thread.Sleep(200);
						List<WoWItemQuality> list2 = new List<WoWItemQuality>();
						if (wManagerSetting.CurrentSetting.MailGray)
						{
							list2.Add(0);
						}
						if (wManagerSetting.CurrentSetting.MailWhite)
						{
							list2.Add(1);
						}
						if (wManagerSetting.CurrentSetting.MailGreen)
						{
							list2.Add(2);
						}
						if (wManagerSetting.CurrentSetting.MailBlue)
						{
							list2.Add(3);
						}
						if (wManagerSetting.CurrentSetting.MailPurple)
						{
							list2.Add(4);
						}
						bool flag = true;
						int num = 2;
						while (num > 0 && flag)
						{
							GoToTask.ToPositionAndIntecractWith(npc, false, null, false);
							Thread.Sleep(200 + Usefuls.Latency);
							Mail.SendMessage(wManagerSetting.CurrentSetting.MailRecipient, wManagerSetting.CurrentSetting.MailSubject, "", wManagerSetting.CurrentSetting.ForceMailList, wManagerSetting.CurrentSetting.DoNotMailList, list2, ref flag);
							Thread.Sleep(200);
							num--;
						}
						Main.log("Sent mail to " + wManagerSetting.CurrentSetting.MailRecipient[0].ToString() + "****");
					}
					else
					{
						npc.BlackList(300000);
						Main.log("Unable to reach the mailbox, blacklisting it for 5 minutes (you can disable this NPC in the NPC DB which is in the 'Tools' tab).");
					}
				}
				Mail.CloseMailFrame();
			}
			if (list.Count > 0)
			{
				foreach (Npc npc3 in list)
				{
					if (npc3.IsValid() && !Conditions.IsAttackedAndCannotIgnore && Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause)
					{
						Main.log(string.Concat(new string[]
						{
							"[ToTown] Go to vendor ",
							npc3.Name,
							" (",
							npc3.Type.ToString(),
							")"
						}));
						if (npc3.Type == 2)
						{
							goto IL_2E2;
						}
						if (npc3.Type == 1)
						{
							goto IL_2E2;
						}
						bool flag2 = false;
						IL_2E8:
						if (flag2)
						{
							Main.log("[ToTown] Use Mammoth");
							if (!this.A.HaveBuff)
							{
								MountTask.DismountMount(true, true, 250);
								Thread.Sleep(1000 + Usefuls.Latency);
								if (Conditions.IsAttackedAndCannotIgnore || ObjectManager.Me.IsMounted)
								{
									Main.logDebug("[ToTown] Use Mammoth > In combat or IsMounted", false);
									return;
								}
								Thread.Sleep(2000 + Usefuls.Latency);
								this.A.Launch(true, true, false);
								Thread.Sleep(3000 + Usefuls.Latency);
							}
						}
						GoToTask.ToPosition(npc3.Position, 10f, wManagerSetting.CurrentSetting.BlackListIfNotCompletePath, null);
						if (ObjectManager.Me.IsFlying)
						{
							MountTask.Land(float.MinValue, 0f);
						}
						if (GoToTask.ToPositionAndIntecractWith(npc3, wManagerSetting.CurrentSetting.BlackListIfNotCompletePath, null, false) && ObjectManager.Target.IsValid && ObjectManager.Target.Entry == npc3.Entry && ObjectManager.Target.IsGoodInteractDistance && Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause && !Conditions.IsAttackedAndCannotIgnore)
						{
							if (ObjectManager.Me.IsFlying)
							{
								MountTask.Land(float.MinValue, 0f);
							}
							WoWUnit woWUnit = new WoWUnit(ObjectManager.Target.GetBaseAddress);
							Main.log("Vendor found " + woWUnit.Name);
							Thread.Sleep(1000 + Usefuls.Latency);
							if (wManagerSetting.CurrentSetting.Repair && npc3.Type == 2)
							{
								Main.log("Repairing items");
								Vendor.RepairAllItems();
								Thread.Sleep(500);
							}
							if (wManagerSetting.CurrentSetting.Selling && (npc3.Type == 2 || npc3.Type == 1))
							{
								List<WoWItemQuality> list3 = new List<WoWItemQuality>();
								if (wManagerSetting.CurrentSetting.SellGray)
								{
									list3.Add(0);
								}
								if (wManagerSetting.CurrentSetting.SellWhite)
								{
									list3.Add(1);
								}
								if (wManagerSetting.CurrentSetting.SellGreen)
								{
									list3.Add(2);
								}
								if (wManagerSetting.CurrentSetting.SellBlue)
								{
									list3.Add(3);
								}
								if (wManagerSetting.CurrentSetting.SellPurple)
								{
									list3.Add(4);
								}
								int num2 = -1;
								int num3 = 5;
								int num4 = 0;
								while (num4 < num3 && num2 != Bag.GetContainerNumFreeSlots)
								{
									num2 = Bag.GetContainerNumFreeSlots;
									Main.log("Selling items (try " + (num4 + 1).ToString() + ")");
									Vendor.SellItems(wManagerSetting.CurrentSetting.ForceSellList, wManagerSetting.CurrentSetting.DoNotSellList, list3);
									Thread.Sleep(500);
									num4++;
								}
							}
							if (npc3.Type == 1)
							{
								Main.log("Buying food and drink");
								int num5 = 0;
								while (num5 < 10 && this.a())
								{
									Vendor.BuyItem(wManagerSetting.CurrentSetting.FoodName, 1);
									Thread.Sleep(Usefuls.Latency + 100);
									num5++;
								}
								int num6 = 0;
								while (num6 < 10 && this.B())
								{
									Vendor.BuyItem(wManagerSetting.CurrentSetting.DrinkName, 1);
									Thread.Sleep(Usefuls.Latency + 100);
									num6++;
								}
							}
							Lua.LuaDoString("CloseMerchant()", false);
							Lua.LuaDoString("GossipFrameCloseButton:Click()", false);
							continue;
						}
						if (Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause && !Conditions.IsAttackedAndCannotIgnore)
						{
							npc3.BlackList(300000);
							Main.log("Unable to reach the vendor, blacklisting it for 5 minutes (you can disable this NPC in the NPC DB which is in the 'Tools' tab).");
							continue;
						}
						continue;
						IL_2E2:
						flag2 = this.b();
						goto IL_2E8;
					}
				}
			}
			global::A.A.A = false;
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00016448 File Offset: 0x00014648
		private bool a()
		{
			return wManagerSetting.CurrentSetting.FoodAmount > 0 && !string.IsNullOrWhiteSpace(wManagerSetting.CurrentSetting.FoodName) && (Bag.GetContainerNumFreeSlotsNormalType > 0 && ItemsManager.GetItemCountById(ItemsManager.GetIdByName(wManagerSetting.CurrentSetting.FoodName)) < wManagerSetting.CurrentSetting.FoodAmount);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x000164B0 File Offset: 0x000146B0
		private bool B()
		{
			return wManagerSetting.CurrentSetting.DrinkAmount > 0 && !string.IsNullOrWhiteSpace(wManagerSetting.CurrentSetting.DrinkName) && (Bag.GetContainerNumFreeSlotsNormalType > 0 && ItemsManager.GetItemCountById(ItemsManager.GetIdByName(wManagerSetting.CurrentSetting.DrinkName)) < wManagerSetting.CurrentSetting.DrinkAmount);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00016518 File Offset: 0x00014718
		private bool b()
		{
			bool result;
			if (!wManagerSetting.CurrentSetting.UseMammoth)
			{
				result = false;
			}
			else
			{
				if (this.A == null)
				{
					this.A = new Spell("Traveler's Tundra Mammoth");
				}
				result = (this.A != null && MountTask.GetMountCapacity() != null && this.A.Id > 0U && this.A.KnownSpell);
			}
			return result;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0001658C File Offset: 0x0001478C
		private Npc C()
		{
			Npc result;
			if (ObjectManager.Me.IsAlliance)
			{
				result = new Npc
				{
					Entry = 32639,
					Type = 2,
					Name = "Gnimo",
					ContinentId = Usefuls.ContinentId,
					Faction = 0,
					GossipOption = -1,
					Position = ObjectManager.Me.Position,
					CanFlyTo = false
				};
			}
			else
			{
				result = new Npc
				{
					Entry = 32641,
					Type = 2,
					Name = "Drix Blackwrench",
					ContinentId = Usefuls.ContinentId,
					Faction = 0,
					GossipOption = -1,
					Position = ObjectManager.Me.Position,
					CanFlyTo = false
				};
			}
			return result;
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00016650 File Offset: 0x00014850
		private Npc c()
		{
			Npc result;
			if (ObjectManager.Me.IsAlliance)
			{
				result = new Npc
				{
					Entry = 32638,
					Type = 1,
					Name = "Hakmud d'Argus",
					ContinentId = Usefuls.ContinentId,
					Faction = 0,
					GossipOption = -1,
					Position = ObjectManager.Me.Position,
					CanFlyTo = false
				};
			}
			else
			{
				result = new Npc
				{
					Entry = 32642,
					Type = 1,
					Name = "Mojodishu",
					ContinentId = Usefuls.ContinentId,
					Faction = 0,
					GossipOption = -1,
					Position = ObjectManager.Me.Position,
					CanFlyTo = false
				};
			}
			return result;
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00016714 File Offset: 0x00014914
		private bool D()
		{
			return wManagerSetting.CurrentSetting.UseMollE && ItemsManager.GetItemCountById(40768U) > 0;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00016744 File Offset: 0x00014944
		private Npc A(int int_0)
		{
			Npc result = new Npc();
			if (wManagerSetting.CurrentSetting.UseMail && !string.IsNullOrWhiteSpace(wManagerSetting.CurrentSetting.MailRecipient) && (Bag.GetContainerNumFreeSlots <= int_0 || Bag.GetContainerNumFreeSlotsNormalType <= int_0 || (wManagerSetting.CurrentSetting.GoToTownHerbBags && Bag.GetContainerNumFreeSlotsHerbBags <= int_0) || (wManagerSetting.CurrentSetting.GoToTownMiningBags && Bag.GetContainerNumFreeSlotsMiningBags <= int_0)))
			{
				if (this.D())
				{
					result = new Npc
					{
						Entry = 191605,
						Type = 3,
						Name = "Mailbox",
						ContinentId = Usefuls.ContinentId,
						Faction = 0,
						GossipOption = -1,
						Position = ObjectManager.Me.Position,
						CanFlyTo = false
					};
				}
				else
				{
					result = NpcDB.GetNpcNearby(3);
				}
			}
			return result;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00016824 File Offset: 0x00014A24
		private Npc a(int int_0)
		{
			Npc result = new Npc();
			if (wManagerSetting.CurrentSetting.Repair && ObjectManager.Me.GetDurabilityPercent <= (double)int_0)
			{
				if (this.b())
				{
					result = this.C();
				}
				else
				{
					result = NpcDB.GetNpcNearby(2);
				}
			}
			return result;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00016874 File Offset: 0x00014A74
		private Npc d()
		{
			Npc result = new Npc();
			if (this.a() || this.B())
			{
				if (this.b())
				{
					result = this.c();
				}
				else
				{
					result = NpcDB.GetNpcNearby(1);
				}
			}
			return result;
		}

		// Token: 0x06000203 RID: 515 RVA: 0x000168B8 File Offset: 0x00014AB8
		private Npc B(int int_0)
		{
			Npc npc = new Npc();
			if (wManagerSetting.CurrentSetting.Selling && (Bag.GetContainerNumFreeSlots <= int_0 || Bag.GetContainerNumFreeSlotsNormalType <= int_0 || (wManagerSetting.CurrentSetting.GoToTownHerbBags && Bag.GetContainerNumFreeSlotsHerbBags <= int_0) || (wManagerSetting.CurrentSetting.GoToTownMiningBags && Bag.GetContainerNumFreeSlotsMiningBags <= int_0)))
			{
				if (this.b())
				{
					npc = this.c();
				}
				else
				{
					npc = NpcDB.GetNpcNearby(1);
				}
				if (!npc.IsValid())
				{
					npc = NpcDB.GetNpcNearby(2);
				}
			}
			return npc;
		}

		// Token: 0x0400011B RID: 283
		public static bool A;

		// Token: 0x0400011C RID: 284
		private Timer A = new Timer(1000.0);

		// Token: 0x0400011D RID: 285
		private Spell A;
	}
}
