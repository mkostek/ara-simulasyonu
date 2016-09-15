/*
 * SharpDevelop tarafından düzenlendi.
 * Kullanıcı: Mert
 * Tarih: 02.02.2015
 * Zaman: 15:36
 * 
 * Bu şablonu değiştirmek için Araçlar | Seçenekler | Kodlama | Standart Başlıkları Düzenle 'yi kullanın.
 */
using System;
using System.Windows.Forms;

namespace araç_simulation
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
