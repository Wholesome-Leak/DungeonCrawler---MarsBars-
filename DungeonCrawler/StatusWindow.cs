using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;
using A;
using MahApps.Metro.Controls;
using robotManager.Helpful;
using wManager.Wow.ObjectManager;

namespace DungeonCrawler
{
	// Token: 0x02000060 RID: 96
	public class StatusWindow : MetroWindow, IComponentConnector
	{
		// Token: 0x060002BA RID: 698 RVA: 0x00019EC8 File Offset: 0x000180C8
		public StatusWindow()
		{
			this.InitializeComponent();
			base.Title = "DungeonCrawler - " + ObjectManager.Me.Name;
			this.distUpdateTimer.Tick += this.A;
			this.distUpdateTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
			this.distUpdateTimer.Start();
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00019F44 File Offset: 0x00018144
		private void A(object sender, EventArgs e)
		{
			try
			{
				this.A.Content = Logging.Status;
				this.a.Content = Logging.ReadLastString(1);
				if (global::A.A.a() != null)
				{
					if (this.A.Visibility > Visibility.Visible)
					{
						this.A.Visibility = Visibility.Visible;
					}
					this.B.Content = global::A.A.a().Name;
				}
				else if (this.A.Visibility != Visibility.Collapsed)
				{
					this.A.Visibility = Visibility.Collapsed;
				}
			}
			catch (Exception ex)
			{
				Main.logError(ex.Message);
			}
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00019FF0 File Offset: 0x000181F0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.A)
			{
				this.A = true;
				Uri resourceLocator = new Uri("/DungeonCrawler;component/gui/statuswindow.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0001A020 File Offset: 0x00018220
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.A(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.A = (Label)target;
				break;
			case 2:
				this.a = (Label)target;
				break;
			case 3:
				this.A = (StackPanel)target;
				break;
			case 4:
				this.B = (Label)target;
				break;
			default:
				this.A = true;
				break;
			}
		}

		// Token: 0x040001B7 RID: 439
		public DispatcherTimer distUpdateTimer = new DispatcherTimer();

		// Token: 0x040001B8 RID: 440
		internal Label A;

		// Token: 0x040001B9 RID: 441
		internal Label a;

		// Token: 0x040001BA RID: 442
		internal StackPanel A;

		// Token: 0x040001BB RID: 443
		internal Label B;

		// Token: 0x040001BC RID: 444
		private bool A;
	}
}
