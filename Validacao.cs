using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorCnpj
{
    public class Validacao
    {
        public bool validarCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, };
            int[] multiplicador2 = new int[13] {6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};
            int somador;
            int resto;
            string digito;
            string cnpjAux;

            // Evitando erros
            cnpj = cnpj.Trim(); // Tira todos os espaçamentos do início e do fim
            cnpj = cnpj.Replace(",", "").Replace("/", "").Replace("-", ""); // Só os números

            if (cnpj.Length != 14)
            {
                return false;
            }
            else
            {
                cnpjAux = cnpj.Substring(0, 12);
                somador = 0;
                for (int i = 0; i < 12; i++)
                {
                    somador += int.Parse(cnpjAux[i].ToString()) * multiplicador1[i];   // O convert e o parse converte String para Int!! E não o Char!! 
                }
                resto = (somador % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();   // Armazenamos o 1º dígito
                cnpjAux = cnpjAux + digito;
                // Agora temos 13 números
                somador = 0;

                for (int i = 0; i < 13; i++)
                {
                    somador += int.Parse(cnpjAux[i].ToString()) * multiplicador2[i];
                }
                resto = (somador % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();  // Concatenar o 1º com o 2º

                return cnpj.EndsWith(digito);   // Se for igual, retona True. Senao, retorna false

            }

        }
    }
}
