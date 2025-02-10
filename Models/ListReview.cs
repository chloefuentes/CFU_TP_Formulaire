using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace TPLOCAL
{
    public class ListReviews
    {
        public List<Reviews> GetAvis(string file)
        {
            List<Reviews> listReviews = new List<Reviews>();
            XmlDocument xmlDoc = new XmlDocument();

            
            xmlDoc.Load(file);

            foreach (XmlNode node in xmlDoc.SelectNodes("root/row"))
            {
                string nom = node["Nom"].InnerText;
                string prenom = node["Prenom"].InnerText;
                string avis = node["Avis"].InnerText;

                Reviews review = new Reviews
                {
                    Nom = nom,
                    Prenom = prenom,
                    AvisDonne = avis
                };

                listReviews.Add(review);
            }
            return listReviews;
        }
    }

    public class Reviews
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string AvisDonne { get; set; }
    }
}
