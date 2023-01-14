using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopFaunaPet.Utility
{
    internal class Validacoes
    {
        public static bool ValidarSeDataBrasileiraEIdade(string dataDeNascimeto)
        {
            if (string.IsNullOrWhiteSpace(dataDeNascimeto))
                return false;

            if (!DateTime.TryParseExact(dataDeNascimeto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var data))
                return false;

            if (DateTime.Now.Subtract(data).TotalDays / 365.25 < 16)
                return false;

            if (DateTime.Now.Subtract(data).TotalDays / 365.25 > 120)
                return false;

            return true;
        }

        public static bool ValidarTamanhoTexto(string? texto, short min, short max)
        {
            if (string.IsNullOrWhiteSpace(texto)
                || texto.Trim().Length < min
                || texto.Trim().Length > max)
                return false;

            return true;
        }


        public static bool ValidarCPF(string? texto, short min, short max)
        {
            if (string.IsNullOrEmpty(texto)
                || texto.Trim().Length < min
                || texto.Trim().Length > max)
                return false;

            return true;
        }
    }
}
