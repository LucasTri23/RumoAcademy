using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetShopFaunaPet.Utility
{
    public class Validacoes
    {
        public static bool ValidarSeDataBrasileiraEIdade(string dataDeNascimeto)
        {
            if (string.IsNullOrWhiteSpace(dataDeNascimeto))
                return false;

            if (!DateTime.TryParseExact(dataDeNascimeto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var data))
                return false;

            if (DateTime.Now.Subtract(data).TotalDays / 365 < 16)
                return false;

            if (DateTime.Now.Subtract(data).TotalDays / 365 > 120)
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

        public static bool ValidarCPF(string? texto)
        {
            texto = Regex.Replace(texto, "[^0-9]", "");

            if (string.IsNullOrWhiteSpace(texto) || texto.Trim().Length != 11)
                return false;

            return true;
        }
    }
}
