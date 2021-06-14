using System;
using DIO.Series.Enum;

namespace DIO.Series.Classes
{
    public class Serie : Entidadebase
    {
        private Gender Gender { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }

        public Serie(Guid id, Gender gender, string title, string description, int year)
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += "Gênero: " + this.Gender + Environment.NewLine;
            retorno += "Título: " + this.Title + Environment.NewLine;
            retorno += "Descrição: " + this.Description + Environment.NewLine;
            retorno += "Year de Início: " + this.Year + Environment.NewLine;

            return retorno;
        }

        public string retornaTitle()
        {
            return this.Title;
        }

        public Guid retornaId()
        {
            return this.Id;
        }
    }
}