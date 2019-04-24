using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI.Models
{
	class Monument
	{

		public Monument()
		{
			this.Etikete = new List<Etiketa>();
		}


		private string oznaka;

		public string Oznaka
		{
			get { return oznaka; }
			set { oznaka = value; }
		}

		private string ime;

		public string Ime
		{
			get { return ime; }
			set { ime = value; }
		}

		private string opis;

		public string Opis
		{
			get { return opis; }
			set { opis = value; }
		}

		private string slika;

		public string Slika
		{
			get { return slika; }
			set { slika = value; }
		}

		private string datum;

		public string Datum
		{
			get { return datum; }
			set { datum = value; }
		}

		private bool unesco;

		public bool Unesco
		{
			get { return unesco; }
			set { unesco = value; }
		}

		private bool naseljenoMesto;

		public bool NaseljenoMesto
		{
			get { return naseljenoMesto; }
			set { naseljenoMesto = value; }
		}

		private bool obradjen;

		public bool Obradjen
		{
			get { return obradjen; }
			set { obradjen = value; }
		}

		private List<Etiketa> etikete;
				
		public List<Etiketa> Etikete
		{
			get { return etikete; }
			set { etikete = value; }
		}

		private Tip tip;

		public Tip Tip
		{
			get { return tip; }
			set { tip = value; }
		}

		private string eraPorekla;

		public string EraPorekla
		{
			get { return eraPorekla; }
			set { eraPorekla = value; }
		}

		private string turistickiStatus;

		public string TuristickiStatus
		{
			get { return turistickiStatus; }
			set { turistickiStatus = value; }
		}

		private int prihod;

		public int Prihod
		{
			get { return prihod; }
			set { prihod = value; }
		}













	}
}
