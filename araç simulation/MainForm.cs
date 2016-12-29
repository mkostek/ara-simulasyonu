/*
 * SharpDevelop tarafından düzenlendi.
 * Kullanıcı: Mert
 * Tarih: 02.02.2015
 * Zaman: 15:36
 * 
 * Bu şablonu değiştirmek için Araçlar | Seçenekler | Kodlama | Standart Başlıkları Düzenle 'yi kullanın.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
//using System.Windows.Forms.PropertyGridInt
namespace araç_simulation
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		struct yol
		{
			public double aci;
			public int mesafe;
			public bool yukariMi;
			public double k;

		}

		int akıl=0;
		public SoundPlayer player;
		//bool[] hulle=new bool[14]{true,false,false,false,false,false,false,false,false,false,false,false,false,false};
		bool mod=false;//sabitleyici için
		double a;//ivme skaler değeri
		int[] devir=new int[15];//16 boyutlu vektörde tanımlı 15 devir aralığı
		double[] vites=new double[7];//7 boyutlu vektörde tanımlı 7 vites oranı
		int vitesSayisi;//vitessayisi
		double[] hizs=new double[7];//maksimum hızlar herbir vites aralığı için
		double sonDisli;//aktarma organındaki son dişli oranı
		double[] teker=new double[3];//teker üçlü ölçüsü burada tutuluyor
		double cons;//tüketim değerleri katsayıları gaza ve devire
		double hava;//havanın sürtünme kuvveti
		double k=0.02;//varsayılan yerin sürtünme kuvveti
		int kilo;//aracın ağırlığı kilo cinsinden
		double hiz=0;//başlangıç offset hızı
		double sbhiz;//hız sabitleyicinin sabitlendiği vites
		double thr;//gaz kelebeği 0-1 aralığında
		double brake;//fren değeri -1 aralığında
		int gear=0;//vites referans boşta
		double g;//vites oranları değişkeni
		double tickover;//başlangıç devri
		double dev;//devir değişkeni program koşarken herbir sefer de güncellenecektir
		double[] tor=new double[2];//aracın tekerleklere aktardığı N cinsinden kuvvet
		double max;//maksimum devir değeri
		double menzil=5000;//varsayılan başlangıç mesafesi
		int egim=1;//1 ise yukarı 0 ise aşağı
		double aci=0;//eğim açısı varsayılan 0
		int hassas=1;//program koşarken timer1 in hassassiyet değerini hesaplar
		double rakim=0;//aracın referans konumdan ne kadar yüksekte yada aşağıda olduğunu tanımlayacak olan degerdir
		double aktarma;//tork değeri hesaplanırken aktarma organlarındaki hesapta kullanılacktır
		double alinanyol=0;//alınon yol değeri başlangıçta 0
		double tüketilen=0;//başlangıçta tüketilen yakıt miktarı 0
		int zaman=0;//zaman sayacı
		int ner=0;//zaman değişkeni her seferde bir artar
		DataTable tab = new DataTable();//i-tronic için tanımlanmış bir data table
		Classifier ab=new Classifier();//i-tronic modunda bir sınıflandırıcıya ihtiyacımız olacaktr
		OleDbConnection baglanti=new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=auto.accdb");
		bool harita=false;
		int yolSayisi;
		int tipSayici=0;
		yol[] tip=new yol[20];
		int[] yi=new int[2];
		int onceki=0,sonraki;
		//araçlar ve harita çekmek için bir bağlantıya ihtiyacımız var
		
		void gazFren()//gaz fren değerleri program koşarken almamız gerekecek
		{
			if(mod==false)//hız sabitleyeci yoksa
			{
				thr=yi[0];//gaz kelebeğini textten oku
				//progressBar2.Value=(int)thr;
				thr/=100;//thr değerini 100 e böl
				brake=yi[1];//brake i oku
			}
			else if(mod==true)
				if(sbhiz<hiz)//sabitleyicideyse ve hız sabitleyiciden küçükse
			{
				thr=0;//gaz kelebeğini sıfırla
				yi[0]=(int)(thr);//textte thr değerini bas
				thr/=100;//the değerini 100 böl kendine ata
				brake=0;//brake değerini sıfırla
				//textBox4.Text=t.ToString();
			}
			else if(sbhiz>hiz)//moddayse ve sabitleyci hızdan küçükse
			{
				thr=99;//thr 99 ata
				yi[0]=(int)(thr);//bu değeri texte yaz
				thr/=100;//thr yi 100 e böl kendine ata
				brake=0;//brake 0 ata
			}
			progressBar2.Value=(int)(thr*100);//progresbbar thr değerini bas
			progressBar3.Value=(int)brake;brake/=100;//progresbarra brake değerini bas
		}
		void degerler()//skaler değerler değişkenlere atanacak
		{
			
			double d=(double)(teker[0]*25.4+teker[1]*(teker[2]/100)*2)*3.14*max/(sonDisli*1000);//vitessiz durumda ne kadar döner
			hizs[0]=(double)(d/vites[0]);//1.vitesteki hızı
			hizs[1]=(double)(d/vites[1]);//2.vitesteki hızı
			hizs[2]=(double)(d/vites[2]);//3. viteste hızı
			hizs[3]=(double)(d/vites[3]);//4.viteste hızı
			hizs[4]=(double)(d/vites[4]);//5. viteste hızı
			hizs[5]=(double)(d/vites[5]);//6.viteste hızı
			hizs[6]=(double)(d/vites[6]);//6.viteste hızı
		}
		void hesapla()
		{
			if(button4.Enabled==false)//eğer i-tronic moddaysa(butona basıldığında enale false olur)
			{
				gear=Convert.ToInt32(ab.Classify(new double[]{hiz/25,dev/25,gear}));//ilgili sınıflandırıcıya parametre olara hiz,araç devri ve geçilmeden önceki vitesi gönderiliyor
			}
			if(gear==1)
			{
				g=vites[0];//vites bir değerse ilgili değişken
			}
			else if(gear==2)
			{
				g=vites[1];//vites iki değerse ilgili değişken
			}
			else if(gear==3&&(gear<=vitesSayisi))//vites	üç değerse ilgili değişken
			{
				g=vites[2];
			}
			else if(gear==4&&gear<=vitesSayisi)//vites dört değeri ise ilgili değişken
			{
				g=vites[3];
			}
			else if(gear==5&&gear<=vitesSayisi)//vites beşteyse
			{
				g=vites[4];
			}
			else if(gear==6&&gear<=vitesSayisi)//vites 6 daysa
			{
				g=vites[5];
			}else if(gear==7&&gear<=vitesSayisi)//vites 6 daysa
			{
				g=vites[6];
			}
			
			if(dev<tickover)//başlangıc devri devirden büyükse
			{
				dev=(int)(tickover);//devir değikenine başlangıç atanacak
			}
			else
			{
				dev=(double)((sonDisli*g*hiz*1000)/((teker[0]*25.4+teker[1]*(teker[2]/100)*2)*Math.PI));//değilse güncel devir değeri bu şekil de hesaplanacaktır
			}
			if(dev>max)
			{
				//progressBar1.Value=100;//d yuzde buyukse 100 değeri basacaktır
				aquaGauge2.Value=((int)max*60);
			}
			else if(dev<tickover)//dev tickoverdan kuçukse
			{
				aquaGauge2.Value=((int)tickover*60);
			}
			else
			{
				aquaGauge2.Value=(int)(dev*60);
				
			}
			
			aktarma=g*sonDisli/(teker[0]*1.77/100);//Bu değerle motordan tekere tork kontrol ediliyor
			if(dev>=tickover&&dev<16)//bu devir aralığında motor ne kadar tork üretiyor
			{
				tor[0]=(double)thr*devir[0];//ilgili deviri gaza basıldığı kadar
				//	hulle[0]=false;
			}
			else if(dev>=16&&dev<25)
			{
				tor[0]=(double)thr*devir[1];
				//	hulle[1]=false;
			}
			else if(dev>=25&&dev<34)
			{
				tor[0]=(double)thr*devir[2];
				//	hulle[2]=false;
			}
			else if(dev>=34&&dev<43)
			{//hulle[3]=false;
				tor[0]=(double)thr*devir[3];
			}
			else if(dev>=43&&dev<52)
			{//hulle[4]=false;
				tor[0]=(double)thr*devir[4];
			}
			else if(dev>=52&&dev<61)
			{//hulle[5]=false;
				tor[0]=(double)thr*devir[5];
			}
			else if(dev>=61&&dev<70)
			{//hulle[6]=false;
				tor[0]=(double)thr*devir[6];
			}
			else if(dev>=70&&dev<79)
			{//hulle[7]=false;
				tor[0]=(double)thr*devir[7];
			}
			else if(dev>=79&&dev<88)
			{//hulle[8]=false;
				tor[0]=(double)thr*devir[8];
			}
			else if(dev>=88&&dev<97)
			{//hulle[9]=true;
				tor[0]=(double)thr*devir[9];
			}
			else if(dev>=97&&dev<106)
			{//hulle[10]=false;
				tor[0]=(double)thr*devir[10];
			}
			else if(dev>=106&&dev<115)
			{//hulle[11]=false;
				tor[0]=(double)thr*devir[11];
			}
			else if(dev>=115&&dev<124)
			{//hulle[11]=false;
				tor[0]=(double)thr*devir[12];
			}
			else if(dev>=124&&dev<133)
			{//hulle[11]=false;
				tor[0]=(double)thr*devir[13];
			}
			else if(dev>=133&&dev<142)
			{//hulle[11]=false;
				tor[0]=(double)thr*devir[14];
			}
			tor[1]=tor[0]*aktarma;
			
		}
		void deger()
		{
			double c,d;//sin ve kos bileşenleri için rampa hesaplanacaktır
			
			

			if(menzil<0)//menzil bittimi
			{
				if(harita==false)
				{
					Random r=new Random();//randomdan rastgele değer
					menzil=r.Next(1000,3000);//
					aci=r.Next(25,200);aci/=50;//
					egim=r.Next(0,2);//0 sa aşağı 1 yukarı
				}
				else
				{
					if(tipSayici==yolSayisi)tipSayici=0;
					menzil=tip[tipSayici].mesafe;
					aci=tip[tipSayici].aci;
					egim=Convert.ToInt32(tip[tipSayici].yukariMi);tipSayici++;
					
				}
			}
			else
			{
				if(egim==1)
				{
					label2.Text="up";
					c=Math.Sin(aci/57);//acıları al
					d=k*Math.Cos(aci/57);//sürtünrmeye tabi olan
					a=(0-10*(c+d));//yukarı doğru olduğunda ivme değeri başta
				}
				else
				{
					label2.Text="down";
					c=Math.Sin(aci/57);//hareket ettiren
					d=k*Math.Cos(aci/57);//sürtünen
					a=10*(c-d);//aşağı doğru olduğunda ivme değeri
				}
				a-=hava*Math.Pow(hiz,2)/kilo;//ivmeyi negatif faktör(rüzgar)
				if(gear==1 && hiz<hizs[0])
				{
					a+=tor[1]/kilo-10*k;
				}
				else if(gear==2 && hiz<hizs[1])
				{
					
					a+=tor[1]/kilo-10*k;
					//	else if((int)thr==0||a>0&&hiz>hizs[1])a-=(dev/200);//değilse thr 0 YADA a sıfıdan büyük ve hiz sınırı geçikse
				}
				else if(gear==3 && hiz<hizs[2])
				{
					a+=tor[1]/kilo-10*k;
					
					
				}
				else if(gear==4 && hiz<hizs[3])
				{
					a+=tor[1]/kilo-10*k;
				}
				else if(gear==5 && hiz<hizs[4])
				{

					a+=tor[1]/kilo-10*k;
				}
				else if(gear==6 && hiz<hizs[5])
				{
					a+=tor[1]/kilo-10*k;
				}
				else if(gear==7 && hiz<hizs[6])
				{
					a+=tor[1]/kilo-10*k;
				}
				if((int)(thr*100)<3)a-=(dev/200);
				if(brake*100!=0)//brake değeri sıfırdan faklıysa
				{
					a-=brake*7;//ivmeden brake 0-1 arasındaki double değeri kadar çıkar
				}

			}
			
			hiz+=a/hassas;//hıza hassasiyet değeri kadar ivme etki et
			if(hiz<0)//hiz sıfırdan küçükse 0 la
				hiz=0;
			menzil-=(double)hiz/hassas;//menzil değerini her geçilen mesafede azalt
			alinanyol+=hiz/hassas;//alınan yolu hız a endeksi olarak artır
			if(egim==1)//alınan yol da ne kadar yükseliyoruz
				rakim+=hiz*Math.Tan(aci/57)/hassas;
			else
				rakim-=hiz*Math.Tan(aci/57)/hassas;
			label9.Text=((int)(menzil)).ToString();//menzil texte ata
			aquaGauge1.Value=(int)(hiz*3.6);
			aquaGauge1.DialText=(Math.Round(alinanyol/1000,1)+" km").ToString();
			double de=(thr+0.01)*dev*cons*Math.Pow(10,-6);
			double tüketim=(de*3600);//gaz a ve devir bağlı katsayılar ile tüketim hesaplama
			tüketilen+=de/hassas;//anlık olarak tüketimi tüketilene eklme
			//VERİLER EKRANA BÜYÜK ÖLÇÜDE BURADA YAZDIRILIYOR VİEW
			label5.Text=thr.ToString();
			label4.Text="Avg(consump.per 100 km):"+Math.Round((tüketilen/(alinanyol/1000))*100,2)+" l";
			label21.Text="Total consump.(l):"+Math.Round(tüketilen,2).ToString();//tüketilen(toplam) değeri bastır
			label16.Text="consump.perhour:"+Math.Round(tüketim,2).ToString()+" l";//anlık olarak saatteki tüketimi
			label13.Text="consump.per100 km:"+(Math.Round(tüketim*(100/(hiz*3.6)),2)).ToString()+" l";//100 kmde ki tüketimi
			label20.Text="N(force):"+Convert.ToInt32(tor[1]).ToString();//tork değerini textte yazdır
			label3.Text="Power consump:"+(Convert.ToInt32(0.737*Convert.ToInt32(tor[0])*2*Math.PI*dev*60/33000)).ToString()+" hp";
			if(ner%hassas==0)
			{
				label22.Text="time is:"+(zaman/3600)+":"+((zaman%3600)/60)+":"+(zaman%60);//saar/dk/sn
				zaman++;
			}
			ner++;
			chartBirinciDerece.Series[0].Points.AddXY(Convert.ToInt32(alinanyol), Convert.ToInt32(rakim));//alınan yol ve rakım chartta
			label9.Text=((int)menzil).ToString();//yazdır değeri menzil
			label10.Text=Math.Tan(aci/57).ToString();//yazdır eğimi
			aquaGauge2.DialText=gear.ToString()+". vites";
			int der;
			
			if(dev<tickover)der=(int)tickover;else der=(int)dev;
		  sonraki=(int)((der*60)/300);
			if(sonraki!=onceki){
				onceki=sonraki;
				System.Diagnostics.Process.Start(@"C:\Users\musta\Desktop\MUSTAFA\ara-simulasyonu-master\araç simulation\bin\Debug\soundstretch.exe", @"engine.wav output.wav -rate="+(int)(der-100)+" -tempo="+(int)(der-100));
				
				Thread.Sleep(250);
				player = new SoundPlayer("output.wav");
				player.PlayLooping();
				}
		}
		void MainFormLoad(object sender, EventArgs e)
		{

			OleDbCommand komut=new OleDbCommand();//load da acces bağlantısı prosedürel işlemleri
			komut.CommandType=CommandType.Text;
			komut.Connection=baglanti;
			komut.CommandText="select adi from auto";//sorgumuz
			OleDbDataReader rd;
			baglanti.Open();
			rd=komut.ExecuteReader();
			while(rd.Read())
			{
				toolStripComboBox1.Items.Add(rd["adi"].ToString());//araçların adı comboya çekiliyor
			}
			rd.Close();
			komut.CommandText="select yolAdi from yol";//sorgumuz
			OleDbDataReader r;
			r=komut.ExecuteReader();
			while(r.Read())
			{
				toolStripComboBox2.Items.Add(r["yolAdi"].ToString());//araçların adı comboya çekiliyor
			}
			r.Close();
			
			baglanti.Close();
			tab.Columns.Add("vites");//tabloya alanlar ekleniyor vites
			tab.Columns.Add("hız", typeof(double));
			tab.Columns.Add("devir", typeof(double));
			// tab.Columns.Add("artıyormu", typeof(double));
			tab.Columns.Add("onceki", typeof(double));
			dev=tickover;//araba çalıştı
			//label1.Text="Ağırlık "+kilo+"";
			timer1.Interval=1000/hassas;//interval değeri
			label10.Text=aci.ToString();//acı yazdır
			//label11.Text="0";
			degerler();//değerleri hesapla
			label24.Text="0";
			button4.BackColor=Color.BlueViolet;
		}
		void Timer1Tick(object sender, EventArgs e)
		{	
//AudioPlaybackEngine.Instance.Dispose();
			gazFren();//gaz fren oku hız sabitleyici kontrol et
			hesapla();//vites değerini kontrol et gaza göre tork hızı hesapla
			deger();//değerleri forma gönder
			
		}
		void Button3Click(object sender, EventArgs e)//hız sabitleyici aktifse
		{
			mod=true;//mod true olarak guncelle
			progressBar3.Value=0;//progressbar3 sıfır(freni temsili)
			yi[1]=0;//textbox5 sıfır:D
			sbhiz=hiz;//basıldığı anda hız artık sabitleyici hızımız olmuştur hayırlı olsun
			label24.Text=Math.Round((sbhiz*3.6),0).ToString()+"km/hour";
			button3.Enabled=false;//tuş aktif olduğunu belli eder
			button3.BackColor=Color.Firebrick;
		}
		void Button4Click(object sender, EventArgs e)//i-tronix
		{
			//tab.Columns.
			button4.Enabled=false;//itronix actif
			ab.TrainClassifier(tab);//sınıflandırıcı aktifleştirilsim
			button4.BackColor=Color.OrangeRed;
			
		}
		void MainFormMouseMove(object sender, MouseEventArgs e)//formda gezerken event aktif
		{
			int x=MousePosition.X;
			int y=MousePosition.Y;
			if(x>400&&x<600 && y>500 && y<700)
			{
				if(y>=500&&y<600)//bu koordinatlarda çalışsın
				{
					thr=(600-y)/100;//mouse göre gaz ver
					yi[0]=(int)(600-y);//gazı yazdır textte lazım olur
					//textBox4.Text=((int)thr*100).ToString();
					yi[1]=0;//freni sıfırla
					progressBar2.Value=(600-y);//gaz progresi
					brake=progressBar3.Value=0;//brake progress 0 la
					//Cursor.Tag="NorthPad";
				}
				else if(y<=700&&y>600)//bu koordinatlarda aktif olsun
				{
					brake=(y-600)/100;//mouse göre fren
					yi[1]=(int)(y-600);//freni yazdır texte lazım olur
					progressBar3.Value=(y-600);//Progress e atalım şekil olsun
					thr=progressBar2.Value=0;//gaz progresi sıfır olsun
					yi[0]=0;//gazı sıfırla frene basıon
				}
				else
				{
					progressBar2.Enabled=false;
					progressBar3.Enabled=false;
				}
				mod=false;//sabitleyciden çık
				label24.Text="0";//sabitleyici 0
				button3.Enabled=true;//sabitleci tuşu aktif olsun
				button3.BackColor=Color.Gold;
			}

		}
		void MainFormMouseClick(object sender, MouseEventArgs e)
		{
			if(button4.Enabled==false)
			{
				tab.Clear();
				//textBox1.Items.Clear();
				textBox1.Clear();
			}
			switch (e.Button)
			{
				case MouseButtons.Left://mouse sol clik olduğunda
					player=new SoundPlayer("gear.wav");
					if(gear!=vitesSayisi)
					{
						gear++;
						
						textBox1.AppendText((gear).ToString()+","+(int)hiz*3.6+","+(int)dev*60+","+(gear-1)+"\n");
						tab.Rows.Add((gear).ToString(),hiz/25,dev/25,gear-1);//tabloya kayıt ekle
						if(gear==vitesSayisi)
						{
							//gear++;
							tab.Rows.Add((gear+1).ToString(),(hiz+70)/25,dev/25,gear);//tabloya kayıt ekle
							textBox1.AppendText((gear).ToString()+","+(int)(hiz+70)*3.6+","+(int)(dev+25)*60+","+(gear-1)+"\n");
							//button4.Enabled=true;//i-tronic modunda
						}
						button4.Enabled=true;//i-tronic modunda
						button4.BackColor=Color.BlueViolet;
					}
					break;
				case MouseButtons.Right://sağ clik edildiğinde
					player=new SoundPlayer("gear.wav");
					if(gear!=1)
					{
						if(gear==vitesSayisi)
						{
							tab.Rows.Add((gear).ToString(),(hiz+2)/25,dev/25,gear+1);//tabloya kayıt ekle
							textBox1.AppendText((gear).ToString()+","+(int)(hiz+2)*3.6+","+(int)dev*60+","+(gear+1)+"\n");
						}
						gear--;
						tab.Rows.Add((gear).ToString(),hiz/25,dev/25,gear+1);//tabloya kayıt ekle
						textBox1.AppendText((gear).ToString()+","+(int)hiz*3.6+","+(int)dev*60+","+(gear+1)+"\n");
					}else if(gear==1)
					{
						tab.Rows.Add("1",0,0,0);
						textBox1.AppendText("1,0,0,0\n");
					}
					
					// gear--;//vitesi azalt

					button4.BackColor=Color.BlueViolet;
					button4.Enabled=true;//i-tronic modunda
					break;
				default:
					break;
			}
			player.Play();
			onceki=0;
			aquaGauge2.DialText=gear.ToString()+". vites";//label7 e gear yaz
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			harita=false;
		}
		




		void ToolStripComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			timer1.Start();//timer1 start et
			OleDbCommand komut=new OleDbCommand();//klişe bağlantı prosedürler:(
			komut.CommandType=CommandType.Text;
			komut.Connection=baglanti;
			komut.CommandText="select *from auto where adi='"+toolStripComboBox1.SelectedItem.ToString()+"'";
			OleDbDataReader rd;
			baglanti.Open();
			rd=komut.ExecuteReader();
			while(rd.Read())//araç verileri değişkenlere geçiriliyor
			{
				devir[0]=Convert.ToInt32(rd["bir"]);
				devir[1]=Convert.ToInt32(rd["iki"]);
				devir[2]=Convert.ToInt32(rd["uc"]);
				devir[3]=Convert.ToInt32(rd["dort"]);
				devir[4]=Convert.ToInt32(rd["bes"]);
				devir[5]=Convert.ToInt32(rd["alti"]);
				devir[6]=Convert.ToInt32(rd["yedi"]);
				devir[7]=Convert.ToInt32(rd["sekiz"]);
				devir[8]=Convert.ToInt32(rd["dokuz"]);
				devir[9]=Convert.ToInt32(rd["on"]);
				devir[10]=Convert.ToInt32(rd["onbir"]);
				devir[11]=Convert.ToInt32(rd["oniki"]);
				devir[12]=Convert.ToInt32(rd["onuc"]);
				cons=Convert.ToDouble(rd["cns"]);
				vites[0]=Convert.ToDouble(rd["rt1"]);
				vites[1]=Convert.ToDouble(rd["rt2"]);
				vites[2]=Convert.ToDouble(rd["rt3"]);
				vites[3]=Convert.ToDouble(rd["rt4"]);
				vites[4]=Convert.ToDouble(rd["rt5"]);
				vites[5]=Convert.ToDouble(rd["rt6"]);
				vites[6]=Convert.ToDouble(rd["rt7"]);
				sonDisli=Convert.ToDouble(rd["sonDisli"]);
				kilo=Convert.ToInt32(rd["agirlik"]);//label1.Text=kilo.ToString();
				tickover=Convert.ToInt32(rd["start"]);
				teker[0]=Convert.ToDouble(rd["tr1"]);
				teker[1]=Convert.ToDouble(rd["tr2"]);
				teker[2]=Convert.ToDouble(rd["tr3"]);
				vitesSayisi=Convert.ToInt32(rd["vsay"]);
				max=Convert.ToInt32(rd["sDev"]);
				pictureBox1.Image=Image.FromFile(rd["pic"].ToString());
				pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;
				//pictureBox1.Size=1024;;
				aquaGauge2.MaxValue=(((int)max*60)/1000+1)*1000;
				aquaGauge2.NoOfDivisions=(int)(max*60/1000)+1;
				hava=Convert.ToDouble(rd["genislik"])*Convert.ToDouble(rd["yukseklik"])*Convert.ToDouble(rd["cw"]);
				
			}
			

			rd.Close();
			baglanti.Close();
			degerler();//değerleri guncelle
		}
		
		void ToolStripComboBox2SelectedIndexChanged(object sender, EventArgs e)
		{
			int i=0;
			harita=true;
			OleDbCommand komut=new OleDbCommand();//klişe bağlantı prosedürler:(
			komut.CommandType=CommandType.Text;
			komut.Connection=baglanti;
			komut.CommandText="select *from yolu where ID in(select ID from yol where yolAdi='"+toolStripComboBox2.SelectedItem.ToString()+"')" ;
			OleDbDataReader rd;
			baglanti.Open();
			rd=komut.ExecuteReader();
			while(rd.Read())//araç verileri değişkenlere geçiriliyor
			{
				tip[i].mesafe=Convert.ToInt32(rd["mesafe"]);
				tip[i].aci=Convert.ToDouble(rd["egim"]);
				tip[i].k=Convert.ToDouble(rd["k"]);
				tip[i].yukariMi=Convert.ToBoolean(rd["yukariMi"]);
				i++;
			}
			yolSayisi=i;
			rd.Close();
			baglanti.Close();
		}
		
		void YolTipiToolStripMenuItemSelectedIndexChanged(object sender, EventArgs e)
		{
			if(yolTipiToolStripMenuItem.SelectedIndex==0)//combobox1 de zemin sürtünme katsayısı üzerine
			{
				k=0.012;
			}
			else if(yolTipiToolStripMenuItem.SelectedIndex==1)
			{
				k=0.03;
			}
			else if(yolTipiToolStripMenuItem.SelectedIndex==2)
			{
				k=0.1;
			}
			else if(yolTipiToolStripMenuItem.SelectedIndex==3)
			{
				k=0.3;
			}
		}
		
		void SimulasyonToolStripMenuItemSelectedIndexChanged(object sender, EventArgs e)
		{
			if(simulasyonToolStripMenuItem.SelectedIndex==0)
			{
				//hassas=1;
				timer1.Interval=1000/hassas;//1x
			}
			else if(simulasyonToolStripMenuItem.SelectedIndex==1)
			{

				timer1.Interval=500/hassas;//2x
			}
			else if(simulasyonToolStripMenuItem.SelectedIndex==2)
			{
				timer1.Interval=333/hassas;//3x
				
			}
			
			else if(simulasyonToolStripMenuItem.SelectedIndex==3)
			{
				timer1.Interval=250/hassas;//4x
			}
			else if(simulasyonToolStripMenuItem.SelectedIndex==4)
			{
				timer1.Interval=200/hassas;//5x
			}
		}
		
		

		

	}
}
