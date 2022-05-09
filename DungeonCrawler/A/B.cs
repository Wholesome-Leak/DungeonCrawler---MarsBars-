using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Timers;
using Newtonsoft.Json;
using wManager.Wow.Enums;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x02000005 RID: 5
	internal static class B
	{
		// Token: 0x0600001B RID: 27 RVA: 0x0000848C File Offset: 0x0000668C
		[CompilerGenerated]
		public static string A()
		{
			return global::A.B.A;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00008493 File Offset: 0x00006693
		[CompilerGenerated]
		public static void A(string string_0)
		{
			global::A.B.A = string_0;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00009DFC File Offset: 0x00007FFC
		public static bool A(int int_0)
		{
			if (Lua.LuaDoString<bool>(string.Format("texture, name, count, quality, bindOnPickUp, canNeed, canGreed, canDisenchant, reasonNeed, reasonGreed, reasonDisenchant, deSkillRequired = GetLootRollItemInfo({0});", int_0), "canNeed"))
			{
				string text = Lua.LuaDoString<string>(string.Format("itemLink = GetLootRollItemLink({0});", int_0), "itemLink");
				string text2 = Lua.LuaDoString<string>("itemName, itemLink, itemRarity, itemLevel, itemMinLevel, itemType, itemSubType, itemStackCount,itemEquipLoc, itemIcon, itemSellPrice, itemClassID, itemSubClassID, bindType, expacID, itemSetID,isCraftingReagent = GetItemInfo(\"" + text + "\")", "itemEquipLoc");
				if (DungeonCrawlerSettings.CurrentSetting.Role != LFGRole.Tank && text2 == "INVTYPE_SHIELD")
				{
					return false;
				}
				string text3 = global::A.B.C(text2);
				Main.logEquip(string.Concat(new string[]
				{
					"ItemLink:  ",
					text,
					Environment.NewLine,
					"      ItemEquipLoc:  ",
					text3
				}));
				if (text3 != "")
				{
					double num = global::A.B.b(global::A.B.B(text));
					string text4 = Lua.LuaDoString<string>("return GetInventoryItemLink('player', " + text3 + ")", "");
					if (text4 == "")
					{
						Main.logEquip("No item equipped in Equipslot " + text2 + " to compare to.");
						return num > 0.0;
					}
					Main.logEquip("Current Item Link: " + text4);
					double num2 = global::A.B.b(global::A.B.B(text4));
					Main.logEquip(string.Format("EquippedValue:{0} --- RollValue:{1}", num2, num));
					return num2 < num;
				}
			}
			return false;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00009F78 File Offset: 0x00008178
		public static bool a(string string_0)
		{
			string text = Lua.LuaDoString<string>("itemName, itemLink, itemRarity, itemLevel, itemMinLevel, itemType, itemSubType, itemStackCount,itemEquipLoc, itemIcon, itemSellPrice, itemClassID, itemSubClassID, bindType, expacID, itemSetID,isCraftingReagent = GetItemInfo(\"" + string_0 + "\")", "itemEquipLoc");
			string text2 = global::A.B.C(text);
			global::A.B.A(string.Concat(new string[]
			{
				global::A.B.A(),
				"ItemLink: ",
				string_0,
				Environment.NewLine,
				"ItemEquipLoc: ",
				text2
			}));
			bool result;
			if (text2 != "")
			{
				double num = global::A.B.b(global::A.B.B(string_0));
				string text3 = Lua.LuaDoString<string>("return GetInventoryItemLink('player', " + text2 + ")", "");
				if (text3 == "")
				{
					global::A.B.A(string.Concat(new string[]
					{
						global::A.B.A(),
						Environment.NewLine,
						"No item equipped in Equipslot ",
						text,
						" to compare to."
					}));
					if (num > 0.0)
					{
						global::A.B.A(global::A.B.A() + string.Format("{0}Item value is {1}, will attempt to equip.", Environment.NewLine, num));
						result = true;
					}
					else
					{
						global::A.B.A(global::A.B.A() + Environment.NewLine + "Item value is 0, item will be blacklisted for this session.");
						if (!global::A.B.A.Contains(string_0))
						{
							global::A.B.A.Add(string_0);
						}
						result = false;
					}
				}
				else
				{
					global::A.B.A(global::A.B.A() + Environment.NewLine + "Equipped Item Link: " + text3);
					double num2 = global::A.B.b(global::A.B.B(text3));
					global::A.B.A(global::A.B.A() + string.Format("{0}EquippedValue: {1} vs PotentailItemValue:{2}", Environment.NewLine, num2, num));
					if (num > num2)
					{
						global::A.B.A(global::A.B.A() + Environment.NewLine + "Potentail Item Value is > Equipped Value, will attempt to equip.");
						result = true;
					}
					else
					{
						global::A.B.A(global::A.B.A() + Environment.NewLine + "Potentail Item value is less than Equipped value, item will be blacklisted for this session.");
						if (!global::A.B.A.Contains(string_0))
						{
							global::A.B.A.Add(string_0);
						}
						result = false;
					}
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000A18C File Offset: 0x0000838C
		public static void A(object sender, ElapsedEventArgs e)
		{
			if (!ObjectManager.Me.InCombatFlagOnly && !ObjectManager.Me.IsDead)
			{
				foreach (WoWItem woWItem in Bag.GetBagItem().Where(new Func<WoWItem, bool>(global::A.B.A.A.A)))
				{
					global::A.B.A("Checking " + woWItem.Name + ":" + Environment.NewLine);
					List<int> itemContainerBagIdAndSlot = Bag.GetItemContainerBagIdAndSlot(woWItem.Entry);
					string text = Lua.LuaDoString<string>(string.Concat(new string[]
					{
						"return GetContainerItemLink(",
						itemContainerBagIdAndSlot[0].ToString(),
						", ",
						itemContainerBagIdAndSlot[1].ToString(),
						")"
					}), "");
					if (global::A.B.a(text))
					{
						ItemsManager.EquipItemByName(woWItem.Name);
						Lua.LuaDoString("StaticPopup1Button1:Click()", false);
					}
					else if (!global::A.B.A.Contains(text))
					{
						global::A.B.A.Add(text);
					}
					Main.logEquip(global::A.B.A());
				}
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000A2E4 File Offset: 0x000084E4
		private static string B(string string_0)
		{
			string text = "{";
			foreach (string text2 in global::A.B.a)
			{
				text += Lua.LuaDoString<string>(string.Concat(new string[]
				{
					"stats =  GetItemStats(\"",
					string_0,
					"\"); if stats[\"",
					text2,
					"\"] ~= nil then return '\"' .. ",
					text2,
					" .. '\":' .. tostring(stats[\"",
					text2,
					"\"]) .. ','  end"
				}), "");
			}
			if (text.Length > 2)
			{
				text = text.Remove(text.Length - 1);
			}
			return text += "}";
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000A3B8 File Offset: 0x000085B8
		private static double b(string string_0)
		{
			global::A.B.A(global::A.B.A() + Environment.NewLine + "Stats:" + string_0);
			ItemStats itemStats = new ItemStats();
			try
			{
				itemStats = JsonConvert.DeserializeObject<ItemStats>(string_0);
			}
			catch (Exception ex)
			{
				Main.logError(ex.Message);
			}
			double num = 0.0;
			num += itemStats.Strength * DungeonCrawlerSettings.CurrentSetting.Strength;
			num += itemStats.Stamina * DungeonCrawlerSettings.CurrentSetting.Stamina;
			num += itemStats.Spirit * DungeonCrawlerSettings.CurrentSetting.Spirit;
			num += itemStats.Intellect * DungeonCrawlerSettings.CurrentSetting.Intellect;
			num += itemStats.Agility * DungeonCrawlerSettings.CurrentSetting.Agility;
			num += itemStats.AttackPower * DungeonCrawlerSettings.CurrentSetting.AttackPower;
			num += itemStats.SpellPower * DungeonCrawlerSettings.CurrentSetting.SpellPower;
			return num + itemStats.DamagePerSecond * DungeonCrawlerSettings.CurrentSetting.WeaponDps;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000A4BC File Offset: 0x000086BC
		public static string C(string string_0)
		{
			string result = "";
			if (string_0 == "INVTYPE_AMMO")
			{
				result = "0";
			}
			if (string_0 == "INVTYPE_HEAD")
			{
				result = "1";
			}
			if (string_0 == "INVTYPE_NECK")
			{
				result = "2";
			}
			if (string_0 == "INVTYPE_SHOULDER")
			{
				result = "3";
			}
			if (string_0 == "INVTYPE_BODY")
			{
				result = "4";
			}
			if (string_0 == "INVTYPE_CHEST")
			{
				result = "5";
			}
			if (string_0 == "INVTYPE_ROBE")
			{
				result = "5";
			}
			if (string_0 == "INVTYPE_WAIST")
			{
				result = "6";
			}
			if (string_0 == "INVTYPE_LEGS")
			{
				result = "7";
			}
			if (string_0 == "INVTYPE_FEET")
			{
				result = "8";
			}
			if (string_0 == "INVTYPE_WRIST")
			{
				result = "9";
			}
			if (string_0 == "INVTYPE_HAND")
			{
				result = "10";
			}
			if (string_0 == "INVTYPE_FINGER")
			{
				result = "11";
			}
			if (string_0 == "INVTYPE_TRINKET")
			{
				result = "13";
			}
			if (string_0 == "INVTYPE_CLOAK")
			{
				result = "15";
			}
			if (string_0 == "INVTYPE_WEAPON")
			{
				result = "16";
			}
			if (string_0 == "INVTYPE_SHIELD")
			{
				result = "17";
			}
			if (string_0 == "INVTYPE_2HWEAPON")
			{
				result = "16";
			}
			if (string_0 == "INVTYPE_WEAPONMAINHAND")
			{
				result = "16";
			}
			if (string_0 == "INVTYPE_WEAPONOFFHAND")
			{
				result = "17";
			}
			if (string_0 == "INVTYPE_HOLDABLE")
			{
				result = "17";
			}
			if (string_0 == "INVTYPE_RANGED")
			{
				result = "18";
			}
			if (string_0 == "INVTYPE_THROWN")
			{
				result = "18";
			}
			if (string_0 == "INVTYPE_RANGEDRIGHT")
			{
				result = "18";
			}
			if (string_0 == "INVTYPE_RELIC")
			{
				result = "18";
			}
			if (string_0 == "INVTYPE_TABARD")
			{
				result = "19";
			}
			if (string_0 == "INVTYPE_BAG")
			{
				result = "20";
			}
			if (string_0 == "INVTYPE_QUIVER")
			{
				result = "20";
			}
			return result;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000A6E8 File Offset: 0x000088E8
		public static void a()
		{
			foreach (SkillLine skillLine in global::A.B.a)
			{
				if (Skill.Has(skillLine) && !global::A.B.A.Contains(skillLine))
				{
					global::A.B.A.Add(skillLine);
				}
			}
		}

		// Token: 0x04000012 RID: 18
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static string A;

		// Token: 0x04000013 RID: 19
		public static List<string> A = new List<string>();

		// Token: 0x04000014 RID: 20
		public static List<string> a = new List<string>
		{
			"ITEM_MOD_AGILITY_SHORT",
			"ITEM_MOD_INTELLECT_SHORT",
			"ITEM_MOD_SPIRIT_SHORT",
			"ITEM_MOD_STAMINA_SHORT",
			"ITEM_MOD_STRENGTH_SHORT",
			"ITEM_MOD_ATTACK_POWER_SHORT",
			"ITEM_MOD_SPELL_POWER_SHORT",
			"ITEM_MOD_DAMAGE_PER_SECOND_SHORT"
		};

		// Token: 0x04000015 RID: 21
		private static Dictionary<WoWClass, List<string>> A = new Dictionary<WoWClass, List<string>>
		{
			{
				6,
				new List<string>
				{
					"INVTYPE_AMMO",
					"INVTYPE_SHIELD",
					"INVTYPE_HOLDABLE",
					"INVTYPE_RANGED",
					"INVTYPE_THROWN",
					"INVTYPE_RANGEDRIGHT",
					"INVTYPE_QUIVER"
				}
			},
			{
				11,
				new List<string>
				{
					"INVTYPE_AMMO",
					"INVTYPE_SHIELD",
					"INVTYPE_WEAPONOFFHAND",
					"INVTYPE_RANGED",
					"INVTYPE_THROWN",
					"INVTYPE_RANGEDRIGHT",
					"INVTYPE_QUIVER"
				}
			},
			{
				3,
				new List<string>
				{
					"INVTYPE_SHIELD",
					"INVTYPE_THROWN",
					"INVTYPE_RELIC",
					"INVTYPE_HOLDABLE"
				}
			},
			{
				8,
				new List<string>
				{
					"INVTYPE_AMMO",
					"INVTYPE_SHIELD",
					"INVTYPE_THROWN",
					"INVTYPE_RANGEDRIGHT",
					"INVTYPE_QUIVER",
					"INVTYPE_RELIC",
					"INVTYPE_WEAPONOFFHAND"
				}
			},
			{
				5,
				new List<string>
				{
					"INVTYPE_AMMO",
					"INVTYPE_SHIELD",
					"INVTYPE_THROWN",
					"INVTYPE_RANGEDRIGHT",
					"INVTYPE_QUIVER",
					"INVTYPE_RELIC",
					"INVTYPE_WEAPONOFFHAND"
				}
			},
			{
				9,
				new List<string>
				{
					"INVTYPE_AMMO",
					"INVTYPE_SHIELD",
					"INVTYPE_THROWN",
					"INVTYPE_RANGEDRIGHT",
					"INVTYPE_QUIVER",
					"INVTYPE_RELIC",
					"INVTYPE_WEAPONOFFHAND"
				}
			},
			{
				2,
				new List<string>
				{
					"INVTYPE_AMMO",
					"INVTYPE_THROWN",
					"INVTYPE_RANGEDRIGHT",
					"INVTYPE_QUIVER",
					"INVTYPE_WEAPONOFFHAND",
					"INVTYPE_HOLDABLE",
					"INVTYPE_RANGED"
				}
			},
			{
				4,
				new List<string>
				{
					"INVTYPE_AMMO",
					"INVTYPE_RANGEDRIGHT",
					"INVTYPE_QUIVER",
					"INVTYPE_2HWEAPON",
					"INVTYPE_HOLDABLE",
					"INVTYPE_RELIC",
					"INVTYPE_SHIELD"
				}
			},
			{
				7,
				new List<string>
				{
					"INVTYPE_AMMO",
					"INVTYPE_RANGEDRIGHT",
					"INVTYPE_QUIVER",
					"INVTYPE_HOLDABLE",
					"INVTYPE_RANGED",
					"INVTYPE_SHIELD"
				}
			},
			{
				1,
				new List<string>
				{
					"INVTYPE_AMMO",
					"INVTYPE_RANGEDRIGHT",
					"INVTYPE_QUIVER",
					"INVTYPE_HOLDABLE",
					"INVTYPE_RANGED"
				}
			}
		};

		// Token: 0x04000016 RID: 22
		public static List<SkillLine> A = new List<SkillLine>();

		// Token: 0x04000017 RID: 23
		public static List<SkillLine> a = new List<SkillLine>
		{
			43,
			55,
			44,
			172,
			54,
			160,
			45,
			46,
			226,
			228,
			173,
			473,
			136,
			229,
			176,
			415,
			414,
			413,
			293,
			433
		};

		// Token: 0x02000006 RID: 6
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x06000027 RID: 39 RVA: 0x0000ABF8 File Offset: 0x00008DF8
			internal bool A(WoWItem woWItem_0)
			{
				return woWItem_0.IsEquippableItem && (long)woWItem_0.GetItemInfo.ItemMinLevel <= (long)((ulong)ObjectManager.Me.Level) && !global::A.B.A.Contains(Lua.LuaDoString<string>(string.Concat(new string[]
				{
					"return GetContainerItemLink(",
					Bag.GetItemContainerBagIdAndSlot(woWItem_0.Entry)[0].ToString(),
					", ",
					Bag.GetItemContainerBagIdAndSlot(woWItem_0.Entry)[1].ToString(),
					")"
				}), "")) && Skill.Has((SkillLine)Enum.Parse(typeof(SkillLine), woWItem_0.GetItemInfo.ItemSubType.Replace("One-Handed ", "")));
			}

			// Token: 0x04000018 RID: 24
			public static readonly B.A A = new B.A();

			// Token: 0x04000019 RID: 25
			public static Func<WoWItem, bool> A;
		}
	}
}
