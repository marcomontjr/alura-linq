﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alura_linq.Problemas.Problema20
{
    class Problema20 : ProblemaBase
    {
        public override void Solve(string[] args)
        {
            using (var contexto = new AluraTunesEntities())
            {
                var valorMedio = contexto.NotasFiscais.Average(nf => nf.Total);

                var query = from nf in contexto.NotasFiscais
                            where nf.Total > valorMedio
                            select new
                            {
                                Numero = nf.NotaFiscalId,
                                Data = nf.DataNotaFiscal,
                                Cliente = nf.Cliente.PrimeiroNome + " " + nf.Cliente.Sobrenome,
                                Valor = nf.Total
                            };

                var notasAcimaDaMedia = query.Take(10);

                foreach (var notaFiscal in notasAcimaDaMedia)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                        notaFiscal.Numero,
                        notaFiscal.Data,
                        notaFiscal.Cliente.PadRight(30),
                        notaFiscal.Valor
                        );
                }
            }
        }
    }
}
