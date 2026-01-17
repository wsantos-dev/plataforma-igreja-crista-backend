using System;
using System.Text.RegularExpressions;

namespace PlataformaRedencao.Domain.ValueObjects
{
    public sealed class Telefone : IEquatable<Telefone>
    {
        private static readonly Regex TelefoneRegex = new Regex(
            @"^\(?\d{2}\)?\s?9?\d{4}-?\d{4}$",
            RegexOptions.Compiled
        );

        public string Numero { get; }

        public Telefone(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("O número de telefone não pode ser vazio.", nameof(numero));

            numero = numero.Trim();

            if (!TelefoneRegex.IsMatch(numero))
                throw new ArgumentException("Número de telefone inválido.", nameof(numero));

            Numero = numero;
        }

        // Formata o telefone de forma padrão: (XX) 9XXXX-XXXX
        public string Formatar()
        {
            var numeros = Regex.Replace(Numero, @"\D", ""); // remove tudo que não é número
            if (numeros.Length == 11) // celular com 9
                return $"({numeros.Substring(0, 2)}) {numeros.Substring(2, 5)}-{numeros.Substring(7, 4)}";
            if (numeros.Length == 10) // fixo
                return $"({numeros.Substring(0, 2)}) {numeros.Substring(2, 4)}-{numeros.Substring(6, 4)}";

            return Numero; // fallback
        }

        // Implementação de Value Object (igualdade por valor)
        public override bool Equals(object? obj) => Equals(obj as Telefone);

        public bool Equals(Telefone? other) => other != null && Numero == other.Numero;

        public override int GetHashCode() => Numero.GetHashCode();

        public override string ToString() => Formatar();
    }
}
