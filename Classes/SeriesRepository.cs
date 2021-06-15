using System;
using System.Collections.Generic;
using DIO.Series.Classes;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SeriesRepository : IRepository<Serie>
    {
        private List<Serie> listSeries = new List<Serie>();

        public void Delete(int id)
        {
            listSeries[id].Delete();
        }

        public Serie GetSerieById(int id)
        {
            return listSeries[id];
        }

        public void Insert(Serie entity)
        {
            listSeries.Add(entity);
        }

        public List<Serie> List()
        {
            return listSeries;
        }

        public int NextId()
        {
            return listSeries.Count;
        }

        public void Update(int id, Serie entity)
        {
            listSeries[id] = entity;
        }
    }
}