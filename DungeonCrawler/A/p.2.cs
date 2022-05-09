using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using robotManager.Helpful;

namespace A
{
	// Token: 0x02000053 RID: 83
	internal static class p
	{
		// Token: 0x06000240 RID: 576 RVA: 0x00017530 File Offset: 0x00015730
		internal static bool A(string string_0, p.A a_0)
		{
			switch (a_0)
			{
			case p.A.b:
				try
				{
					File.Delete(p.a + "Products/ZZZOld" + string_0);
					string text = p.a + "Products/" + string_0;
					Main.logDebug(text, false);
					if (File.Exists(text))
					{
						string fileVersion = FileVersionInfo.GetVersionInfo(text).FileVersion;
						string text2 = "";
						using (WebClient webClient = new WebClient())
						{
							text2 = webClient.DownloadString(p.A + string_0);
						}
						Main.logDebug(string.Concat(new string[]
						{
							"local: ",
							fileVersion,
							", server: ",
							text2,
							"."
						}), false);
						if (Version.Parse(text2) > Version.Parse(fileVersion))
						{
							p.A(string_0);
							MessageBox.Show("New version of " + string_0 + " downloaded, please restart WRobot.");
							return true;
						}
					}
				}
				catch (Exception ex)
				{
					Main.logError(ex.Message);
				}
				break;
			}
			return false;
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00017670 File Offset: 0x00015870
		private static void A(string string_0)
		{
			File.Delete(p.a + "Products/ZZZOld" + string_0);
			File.Move(p.a + "Products/" + string_0, p.a + "Products/ZZZOld" + string_0);
			using (WebClient webClient = new WebClient())
			{
				webClient.DownloadFile(p.A + string_0 + "&download=true", p.a + "Products/" + string_0);
			}
		}

		// Token: 0x04000132 RID: 306
		private static readonly string A = "https://m4rsbars.co.uk/downloads?name=";

		// Token: 0x04000133 RID: 307
		private static readonly string a = Others.GetCurrentDirectory;

		// Token: 0x02000054 RID: 84
		public enum A
		{
			// Token: 0x04000135 RID: 309
			A,
			// Token: 0x04000136 RID: 310
			a,
			// Token: 0x04000137 RID: 311
			B,
			// Token: 0x04000138 RID: 312
			b
		}
	}
}
