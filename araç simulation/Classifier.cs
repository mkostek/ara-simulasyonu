﻿/*
 * SharpDevelop tarafından düzenlendi.
 * Kullanıcı: Mert
 * Tarih: 13.04.2015
 * Zaman: 17:43
 * 
 * Bu şablonu değiştirmek için Araçlar | Seçenekler | Kodlama | Standart Başlıkları Düzenle 'yi kullanın.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace araç_simulation
{
	/// <summary>
	/// Description of Classifier.
	/// </summary>
    public class Classifier
    {
       public  DataSet dataSet = new DataSet();

        public DataSet DataSet
        {
            get { return dataSet; }
            set { dataSet = value; }
        }

        public void TrainClassifier(DataTable table)
        {
       
        	dataSet.Tables.Clear();
        	dataSet.Tables.Add(table);

            //table
            DataTable GaussianDistribution = dataSet.Tables.Add("Gaussian");
            GaussianDistribution.Columns.Add(table.Columns[0].ColumnName);

            //columns
            for (int i = 1; i < table.Columns.Count; i++)
            {
                GaussianDistribution.Columns.Add(table.Columns[i].ColumnName + "Mean");
                GaussianDistribution.Columns.Add(table.Columns[i].ColumnName + "Variance");
            }
            //calc data
            var results = (from myRow in table.AsEnumerable()
                           group myRow by myRow.Field<string>(table.Columns[0].ColumnName) into g
                           select new { Name = g.Key, Count = g.Count() }).ToList();
			if (results == null)
				return;
			if (results == null)
				return;
			if (results == null)
				return;
			if (results == null)
				return;

            for (int j = 0; j < results.Count; j++)
            {
                DataRow row = GaussianDistribution.Rows.Add();
                row[0] = results[j].Name;

                int a = 1;
                for (int i = 1; i < table.Columns.Count; i++)
                {
                    row[a] = Helper.Mean(SelectRows(table, i, string.Format("{0} = '{1}'", table.Columns[0].ColumnName, results[j].Name)));
                    row[++a] = Helper.Variance(SelectRows(table, i, string.Format("{0} = '{1}'", table.Columns[0].ColumnName, results[j].Name)));
                    a++;
                }
            }
        }

        public string Classify(double[] obj)
        {
            Dictionary<string, double> score = new Dictionary<string, double>();

            var results = (from myRow in dataSet.Tables[0].AsEnumerable()
                           group myRow by myRow.Field<string>(dataSet.Tables[0].Columns[0].ColumnName) into g
                           select new { Name = g.Key, Count = g.Count() }).ToList();

            for (int i = 0; i < results.Count; i++)
            {
                List<double> subScoreList = new List<double>();
                int a = 1, b = 1;
                for (int k = 1; k < dataSet.Tables["Gaussian"].Columns.Count; k = k + 2)
                {
                    double mean = Convert.ToDouble(dataSet.Tables["Gaussian"].Rows[i][a]);
                    double variance = Convert.ToDouble(dataSet.Tables["Gaussian"].Rows[i][++a]);
                    double result = Helper.NormalDist(obj[b - 1], mean, Helper.SquareRoot(variance));
                    subScoreList.Add(result);
                    a++; b++;
                }

                double finalScore = 0;
                for (int z = 0; z < subScoreList.Count; z++)
                {
                    if (finalScore == 0)
                    {
                        finalScore = subScoreList[z];
                        continue;
                    }

                    finalScore = finalScore * subScoreList[z];
                }

                score.Add(results[i].Name, finalScore * 0.5);
            }

            double maxOne = score.Max(c => c.Value);
            var name = (from c in score
                        where c.Value == maxOne
                        select c.Key).First();

            return name;
        }

        #region Helper Function

        public IEnumerable<double> SelectRows(DataTable table, int column, string filter)
        {
            List<double> _doubleList = new List<double>();
            DataRow[] rows = table.Select(filter);
            for (int i = 0; i < rows.Length; i++)
            {
                _doubleList.Add((double)rows[i][column]);
            }

            return _doubleList;
        }

        public void Clear()
        {
            dataSet = new DataSet();
            dataSet.Clear();
        }

        #endregion
    }
}
