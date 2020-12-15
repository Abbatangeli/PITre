using System;

namespace DocsPaUtils.Data
{

	public enum DirectionParameter
	{
		ParamInput,
		ParamOutput,
		ReturnValue
	}

	/// <summary>
	/// Contiene la coppia nome-valore del parametro della stored procedure.
	/// </summary>
	public class ParameterSP 
	{
		private string nome;
		private object valore;
		private int dimensione;
		private System.Data.DbType tipo;
		private DirectionParameter direzioneparametro;


		public ParameterSP()
		{
		}

		public ParameterSP(string nome, object valore) :
			this (nome, valore, 0, DirectionParameter.ParamInput)
		{
		}

		public ParameterSP(string nome, object valore, DirectionParameter direzione) :
			this (nome, valore, 0, direzione)
		{
		}

		public ParameterSP(string nome, object valore, int dim, DirectionParameter direzione)
		{
			this.nome = nome;
			this.direzioneparametro = direzione;
			this.dimensione = dim;


			if( valore != null )
				this.valore=valore;
			else
				//throw new ArgumentNullException( "valore", "Il valore del parametro non pu� essere null" );
                  throw new ArgumentNullException("valore", "Il valore del parametro " + nome + " non pu� essere null");
		}

		public ParameterSP(string nome, object valore, int dim, DirectionParameter direzione, System.Data.DbType t) :
			this (nome, valore, dim, direzione)
		{
			this.Tipo = t;
		}

		

		#region Propriet�

		public string Nome
		{
			get
			{
				return nome;
			}
		}

		public object Valore
		{
			get
			{
				return valore;
			}
			set
			{
				valore = value;
			}
		}

		public int Dimensione 
		{
			get
			{
				return dimensione;
			}
			set
			{
				valore = dimensione;
			}
		}

		public DirectionParameter direzione
		{
			get
			{
				return direzioneparametro;
			}
		}

		public System.Data.DbType Tipo
		{
			get
			{
				return tipo;
			}

			set
			{
				tipo = value;;
			}
		}

        /// <summary>
        /// Parametro creato per non rompere la compatibilt� della propriet� Dimensione.
        /// (E' presente un bug in in tale propriet� per cui se si valorizza Dimensione,
        /// viene in realt� valorizzata la variabile valore. Per la gestione dei token,
        /// � necessario definire la lunghezza del parametro di output in quanto se non
        /// definita, la propriet� Valore conterr� una stringa di un solo carattere)
        /// Non � possibile modificare il comportamento della propriet� Dimensione in quanto
        /// non funziona pi�, ad esempio, la visualizzazione del livello di organigramma in cui
        /// si trova un utente)
        /// </summary>
        public int Size { get; set; }

		#endregion

	}
}
