using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using robotManager.Helpful;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

// Token: 0x02000029 RID: 41
[Serializable]
public class DungeonCrawlerSettings : Settings
{
	// Token: 0x17000034 RID: 52
	// (get) Token: 0x060000F7 RID: 247 RVA: 0x00008A93 File Offset: 0x00006C93
	// (set) Token: 0x060000F8 RID: 248 RVA: 0x00008A9B File Offset: 0x00006C9B
	public LFGRole Role { get; set; }

	// Token: 0x17000035 RID: 53
	// (get) Token: 0x060000F9 RID: 249 RVA: 0x00008AA4 File Offset: 0x00006CA4
	// (set) Token: 0x060000FA RID: 250 RVA: 0x00008AAC File Offset: 0x00006CAC
	public bool QueueGroup { get; set; }

	// Token: 0x17000036 RID: 54
	// (get) Token: 0x060000FB RID: 251 RVA: 0x00008AB5 File Offset: 0x00006CB5
	// (set) Token: 0x060000FC RID: 252 RVA: 0x00008ABD File Offset: 0x00006CBD
	public bool QueueRandom { get; set; }

	// Token: 0x17000037 RID: 55
	// (get) Token: 0x060000FD RID: 253 RVA: 0x00008AC6 File Offset: 0x00006CC6
	// (set) Token: 0x060000FE RID: 254 RVA: 0x00008ACE File Offset: 0x00006CCE
	public double CombatFollowDistance { get; set; }

	// Token: 0x17000038 RID: 56
	// (get) Token: 0x060000FF RID: 255 RVA: 0x00008AD7 File Offset: 0x00006CD7
	// (set) Token: 0x06000100 RID: 256 RVA: 0x00008ADF File Offset: 0x00006CDF
	public double OOCFollowDistance { get; set; }

	// Token: 0x17000039 RID: 57
	// (get) Token: 0x06000101 RID: 257 RVA: 0x00008AE8 File Offset: 0x00006CE8
	// (set) Token: 0x06000102 RID: 258 RVA: 0x00008AF0 File Offset: 0x00006CF0
	public bool AlwaysVendor { get; set; }

	// Token: 0x1700003A RID: 58
	// (get) Token: 0x06000103 RID: 259 RVA: 0x00008AF9 File Offset: 0x00006CF9
	// (set) Token: 0x06000104 RID: 260 RVA: 0x00008B01 File Offset: 0x00006D01
	public float LootRange { get; set; }

	// Token: 0x1700003B RID: 59
	// (get) Token: 0x06000105 RID: 261 RVA: 0x00008B0A File Offset: 0x00006D0A
	// (set) Token: 0x06000106 RID: 262 RVA: 0x00008B12 File Offset: 0x00006D12
	public double Strength { get; set; }

	// Token: 0x1700003C RID: 60
	// (get) Token: 0x06000107 RID: 263 RVA: 0x00008B1B File Offset: 0x00006D1B
	// (set) Token: 0x06000108 RID: 264 RVA: 0x00008B23 File Offset: 0x00006D23
	public double Agility { get; set; }

	// Token: 0x1700003D RID: 61
	// (get) Token: 0x06000109 RID: 265 RVA: 0x00008B2C File Offset: 0x00006D2C
	// (set) Token: 0x0600010A RID: 266 RVA: 0x00008B34 File Offset: 0x00006D34
	public double Intellect { get; set; }

	// Token: 0x1700003E RID: 62
	// (get) Token: 0x0600010B RID: 267 RVA: 0x00008B3D File Offset: 0x00006D3D
	// (set) Token: 0x0600010C RID: 268 RVA: 0x00008B45 File Offset: 0x00006D45
	public double Spirit { get; set; }

	// Token: 0x1700003F RID: 63
	// (get) Token: 0x0600010D RID: 269 RVA: 0x00008B4E File Offset: 0x00006D4E
	// (set) Token: 0x0600010E RID: 270 RVA: 0x00008B56 File Offset: 0x00006D56
	public double Stamina { get; set; }

	// Token: 0x17000040 RID: 64
	// (get) Token: 0x0600010F RID: 271 RVA: 0x00008B5F File Offset: 0x00006D5F
	// (set) Token: 0x06000110 RID: 272 RVA: 0x00008B67 File Offset: 0x00006D67
	public double AttackPower { get; set; }

	// Token: 0x17000041 RID: 65
	// (get) Token: 0x06000111 RID: 273 RVA: 0x00008B70 File Offset: 0x00006D70
	// (set) Token: 0x06000112 RID: 274 RVA: 0x00008B78 File Offset: 0x00006D78
	public double SpellPower { get; set; }

	// Token: 0x17000042 RID: 66
	// (get) Token: 0x06000113 RID: 275 RVA: 0x00008B81 File Offset: 0x00006D81
	// (set) Token: 0x06000114 RID: 276 RVA: 0x00008B89 File Offset: 0x00006D89
	public double WeaponDps { get; set; }

	// Token: 0x17000043 RID: 67
	// (get) Token: 0x06000115 RID: 277 RVA: 0x00008B92 File Offset: 0x00006D92
	// (set) Token: 0x06000116 RID: 278 RVA: 0x00008B9A File Offset: 0x00006D9A
	public bool AlwaysGreed { get; set; }

	// Token: 0x17000044 RID: 68
	// (get) Token: 0x06000117 RID: 279 RVA: 0x00008BA3 File Offset: 0x00006DA3
	// (set) Token: 0x06000118 RID: 280 RVA: 0x00008BAB File Offset: 0x00006DAB
	public bool AutoEquip { get; set; }

	// Token: 0x17000045 RID: 69
	// (get) Token: 0x06000119 RID: 281 RVA: 0x00008BB4 File Offset: 0x00006DB4
	// (set) Token: 0x0600011A RID: 282 RVA: 0x00008BBC File Offset: 0x00006DBC
	public string LeaderName { get; set; }

	// Token: 0x17000046 RID: 70
	// (get) Token: 0x0600011B RID: 283 RVA: 0x00008BC5 File Offset: 0x00006DC5
	// (set) Token: 0x0600011C RID: 284 RVA: 0x00008BCD File Offset: 0x00006DCD
	public bool EnableStatusWindow { get; set; }

	// Token: 0x17000047 RID: 71
	// (get) Token: 0x0600011D RID: 285 RVA: 0x00008BD6 File Offset: 0x00006DD6
	// (set) Token: 0x0600011E RID: 286 RVA: 0x00008BDE File Offset: 0x00006DDE
	public string FollowOverrideName { get; set; }

	// Token: 0x17000048 RID: 72
	// (get) Token: 0x0600011F RID: 287 RVA: 0x00008BE7 File Offset: 0x00006DE7
	// (set) Token: 0x06000120 RID: 288 RVA: 0x00008BEF File Offset: 0x00006DEF
	public List<string> SpellsToBuy { get; set; }

	// Token: 0x17000049 RID: 73
	// (get) Token: 0x06000121 RID: 289 RVA: 0x00008BF8 File Offset: 0x00006DF8
	// (set) Token: 0x06000122 RID: 290 RVA: 0x00008C00 File Offset: 0x00006E00
	public List<int> LevelsToTrain { get; set; }

	// Token: 0x1700004A RID: 74
	// (get) Token: 0x06000123 RID: 291 RVA: 0x00008C09 File Offset: 0x00006E09
	// (set) Token: 0x06000124 RID: 292 RVA: 0x00008C11 File Offset: 0x00006E11
	public bool IsLeader { get; set; }

	// Token: 0x1700004B RID: 75
	// (get) Token: 0x06000125 RID: 293 RVA: 0x00008C1A File Offset: 0x00006E1A
	// (set) Token: 0x06000126 RID: 294 RVA: 0x00008C22 File Offset: 0x00006E22
	public List<string> PlayersToInvite { get; set; }

	// Token: 0x1700004C RID: 76
	// (get) Token: 0x06000127 RID: 295 RVA: 0x00008C2B File Offset: 0x00006E2B
	// (set) Token: 0x06000128 RID: 296 RVA: 0x00008C33 File Offset: 0x00006E33
	public List<QueueDungeon> SpecificDungeons { get; set; }

	// Token: 0x1700004D RID: 77
	// (get) Token: 0x06000129 RID: 297 RVA: 0x00008C3C File Offset: 0x00006E3C
	// (set) Token: 0x0600012A RID: 298 RVA: 0x00008C44 File Offset: 0x00006E44
	public bool ExtendedLogging { get; set; }

	// Token: 0x0600012B RID: 299 RVA: 0x00013674 File Offset: 0x00011874
	private DungeonCrawlerSettings()
	{
		this.Role = LFGRole.DPS;
		this.QueueGroup = false;
		this.QueueRandom = true;
		this.CombatFollowDistance = 10.0;
		this.OOCFollowDistance = 15.0;
		this.AlwaysVendor = true;
		this.LootRange = 15f;
		this.Strength = 0.0;
		this.Agility = 0.0;
		this.Intellect = 0.0;
		this.Spirit = 0.0;
		this.Stamina = 0.0;
		this.AttackPower = 0.0;
		this.SpellPower = 0.0;
		this.WeaponDps = 0.0;
		this.AlwaysGreed = false;
		this.AutoEquip = true;
		this.LeaderName = "";
		this.EnableStatusWindow = false;
		this.FollowOverrideName = "";
		this.SpellsToBuy = new List<string>();
		this.LevelsToTrain = new List<int>();
		this.IsLeader = false;
		this.PlayersToInvite = new List<string>();
		this.SpecificDungeons = new List<QueueDungeon>();
		this.ExtendedLogging = false;
	}

	// Token: 0x1700004E RID: 78
	// (get) Token: 0x0600012C RID: 300 RVA: 0x00008C4D File Offset: 0x00006E4D
	// (set) Token: 0x0600012D RID: 301 RVA: 0x00008C54 File Offset: 0x00006E54
	public static DungeonCrawlerSettings CurrentSetting { get; set; }

	// Token: 0x0600012E RID: 302 RVA: 0x000137AC File Offset: 0x000119AC
	public bool Save()
	{
		bool result;
		try
		{
			result = base.Save(Settings.AdviserFilePathAndName("DungeonCrawler", ObjectManager.Me.Name + "." + Usefuls.RealmName));
		}
		catch (Exception ex)
		{
			string str = "> Save(): ";
			Exception ex2 = ex;
			Main.logError(str + ((ex2 != null) ? ex2.ToString() : null));
			result = false;
		}
		return result;
	}

	// Token: 0x0600012F RID: 303 RVA: 0x00013818 File Offset: 0x00011A18
	public static bool Load()
	{
		try
		{
			if (File.Exists(Settings.AdviserFilePathAndName("DungeonCrawler", ObjectManager.Me.Name + "." + Usefuls.RealmName)))
			{
				DungeonCrawlerSettings.CurrentSetting = Settings.Load<DungeonCrawlerSettings>(Settings.AdviserFilePathAndName("DungeonCrawler", ObjectManager.Me.Name + "." + Usefuls.RealmName));
				return true;
			}
			DungeonCrawlerSettings.CurrentSetting = new DungeonCrawlerSettings();
		}
		catch (Exception ex)
		{
			string str = "> Load(): ";
			Exception ex2 = ex;
			Main.logError(str + ((ex2 != null) ? ex2.ToString() : null));
		}
		return false;
	}

	// Token: 0x040000A9 RID: 169
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LFGRole A;

	// Token: 0x040000AA RID: 170
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool A;

	// Token: 0x040000AB RID: 171
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool a;

	// Token: 0x040000AC RID: 172
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double A;

	// Token: 0x040000AD RID: 173
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double a;

	// Token: 0x040000AE RID: 174
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool B;

	// Token: 0x040000AF RID: 175
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float A;

	// Token: 0x040000B0 RID: 176
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double B;

	// Token: 0x040000B1 RID: 177
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double b;

	// Token: 0x040000B2 RID: 178
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double C;

	// Token: 0x040000B3 RID: 179
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double c;

	// Token: 0x040000B4 RID: 180
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double D;

	// Token: 0x040000B5 RID: 181
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double d;

	// Token: 0x040000B6 RID: 182
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double E;

	// Token: 0x040000B7 RID: 183
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double e;

	// Token: 0x040000B8 RID: 184
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool b;

	// Token: 0x040000B9 RID: 185
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool C;

	// Token: 0x040000BA RID: 186
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string A;

	// Token: 0x040000BB RID: 187
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool c;

	// Token: 0x040000BC RID: 188
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string a;

	// Token: 0x040000BD RID: 189
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> A;

	// Token: 0x040000BE RID: 190
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<int> A;

	// Token: 0x040000BF RID: 191
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool D;

	// Token: 0x040000C0 RID: 192
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> a;

	// Token: 0x040000C1 RID: 193
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<QueueDungeon> A;

	// Token: 0x040000C2 RID: 194
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool d;

	// Token: 0x040000C3 RID: 195
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static DungeonCrawlerSettings A;
}
