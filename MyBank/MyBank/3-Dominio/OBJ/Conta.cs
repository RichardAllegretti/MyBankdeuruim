﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Dominio.OBJ
{
	public class Conta
	{
		public int Id { get; set; }

		private static int _idGlobal { get; set; }
		
		public string Nome { get; set; }

		public Pessoa Pessoa { get; set; }

		public double Saldo { get; set; }

		public DateTime DataAbertura { get; set; }

		public Agencia Agencia { get; set; }

		public Conta(Agencia agencia)
		{
			_idGlobal++;
			Id = _idGlobal;
			Agencia = agencia;
			Pessoa = new Pessoa(agencia, this);
		}
	}
}
