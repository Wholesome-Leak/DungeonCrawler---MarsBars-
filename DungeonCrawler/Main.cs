using System;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using A;
using DungeonCrawler;
using robotManager.Helpful;
using robotManager.Products;
using wManager;
using wManager.Plugin;
using wManager.Wow.ObjectManager;

// Token: 0x02000013 RID: 19
public class Main : IProduct
{
	// Token: 0x0600006F RID: 111 RVA: 0x0000C0B8 File Offset: 0x0000A2B8
	public void Initialize()
	{
		try
		{
			DungeonCrawlerSettings.Load();
			Main.status("Initialized.");
			Main.log("Initialized.");
		}
		catch (Exception ex)
		{
			string str = "> Main > Initialize(): ";
			Exception ex2 = ex;
			Main.logError(str + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x06000070 RID: 112 RVA: 0x0000C114 File Offset: 0x0000A314
	public void Dispose()
	{
		try
		{
			this.Stop();
			Main.status("Closed");
			Main.log("Closed");
		}
		catch (Exception ex)
		{
			string str = "> Main > Dispose(): ";
			Exception ex2 = ex;
			Main.logError(str + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x06000071 RID: 113 RVA: 0x0000C170 File Offset: 0x0000A370
	public void Start()
	{
		try
		{
			if (ObjectManager.Me.Level < 15U)
			{
				MessageBox.Show("Must be level 15 or above to run DungeonCrawler.");
			}
			else
			{
				DungeonCrawlerSettings.Load();
				this._Started = true;
				if (global::A.A.D())
				{
					wManagerSetting.CurrentSetting.SearchRadiusMobs = DungeonCrawlerSettings.CurrentSetting.LootRange;
					wManagerSetting.CurrentSetting.CloseIfPlayerTeleported = false;
					PluginsManager.LoadAllPlugins();
					Main.status("Started");
					Main.log("Started");
				}
				else
				{
					this._Started = false;
					Main.status("Failed to start");
					Main.log("Failed to start");
				}
			}
		}
		catch (Exception ex)
		{
			this._Started = false;
			string str = "> Main > Start(): ";
			Exception ex2 = ex;
			Main.logError(str + ((ex2 != null) ? ex2.ToString() : null));
			Products.ProductStop();
		}
	}

	// Token: 0x06000072 RID: 114 RVA: 0x0000C244 File Offset: 0x0000A444
	public void Stop()
	{
		try
		{
			this._Started = false;
			this.A = null;
			global::A.A.E();
			PluginsManager.DisposeAllPlugins();
			Main.status("Stopped");
			Main.log("Stopped");
		}
		catch (Exception ex)
		{
			string str = "> Main > Stop(): ";
			Exception ex2 = ex;
			Main.logError(str + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000073 RID: 115 RVA: 0x0000C2B0 File Offset: 0x0000A4B0
	public UserControl Settings
	{
		get
		{
			try
			{
				if (this.A == null)
				{
					this.A = new ProductSettingsControl();
				}
				return this.A;
			}
			catch (Exception ex)
			{
				string str = "> Main > Settings(): ";
				Exception ex2 = ex;
				Main.logError(str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return null;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000074 RID: 116 RVA: 0x0000861C File Offset: 0x0000681C
	public bool IsStarted
	{
		get
		{
			return this._Started;
		}
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00008624 File Offset: 0x00006824
	public static void status(string message)
	{
		Logging.Status = "DungeonCrawler - " + message;
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00008636 File Offset: 0x00006836
	public static void log(string message)
	{
		if (!Logging.ReadLastString(1).Contains("[DungeonCrawler]: " + message))
		{
			Logging.Write("[DungeonCrawler]: " + message, 1, Color.DarkRed);
		}
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00008666 File Offset: 0x00006866
	public static void logError(string message)
	{
		if (!Logging.ReadLastString(4).Contains("[DungeonCrawler ERROR]: " + message))
		{
			Logging.Write("[DungeonCrawler ERROR]: " + message, 4, Color.Red);
		}
	}

	// Token: 0x06000078 RID: 120 RVA: 0x0000C30C File Offset: 0x0000A50C
	public static void logDebug(string message, bool extended = false)
	{
		if (extended && DungeonCrawlerSettings.CurrentSetting.ExtendedLogging && !Logging.ReadLastString(2).Contains("[DungeonCrawler]Debug> " + message))
		{
			Logging.Write("[DungeonCrawler]Debug> " + message, 2, Color.MediumPurple);
		}
		if (!extended && !Logging.ReadLastString(2).Contains("[DungeonCrawler]Debug> " + message))
		{
			Logging.Write("[DungeonCrawler]Debug> " + message, 2, Color.MediumPurple);
		}
	}

	// Token: 0x06000079 RID: 121 RVA: 0x00008696 File Offset: 0x00006896
	public static void logEquip(string message)
	{
		if (!Logging.ReadLastString(2).Contains("[DungeonCrawler]Equipment> " + message))
		{
			Logging.Write("[DungeonCrawler]Equipment> " + message, 2, Color.YellowGreen);
		}
	}

	// Token: 0x0400003D RID: 61
	public static StatusWindow statusWindow;

	// Token: 0x0400003E RID: 62
	public static Thread statusWindowThread;

	// Token: 0x0400003F RID: 63
	private ProductSettingsControl A;

	// Token: 0x04000040 RID: 64
	private bool _Started;
}
