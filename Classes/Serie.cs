using System;

namespace DIO.Series.Classes
{
    public class Serie : Entidadebase
    {
        private Gender Gender { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Status { get; set; }

        public Serie(int id, Gender gender, string title, string description, int year)
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Status = false;
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

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }

        public void Delete()
        {
            this.Status = true;
        }
    }
}