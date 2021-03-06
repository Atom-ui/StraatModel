﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StraatModel
{
    public class Straat
    {
        public Straat(int straatId, string naam, Graaf graaf)
        {
            StraatId = straatId;
            Naam = naam;
            Graaf = graaf;
        }

        public int StraatId { get; set; }
        public string Naam { get; set; }
        public Graaf Graaf { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Straat straat &&
                   StraatId == straat.StraatId &&
                   Naam == straat.Naam &&
                   EqualityComparer<Graaf>.Default.Equals(Graaf, straat.Graaf);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StraatId, Naam, Graaf);
        }
        public override string ToString()
        {
            return ($"<Straat>\n<StraatId>{StraatId}</straatId>\n<StraatNaam>{Naam}</straatnaam>\n{Graaf}\n</Straat>");
        }
        public double GetLengte()
        {
            var s = Graaf.Map.SelectMany(entry => entry.Value).Distinct();
            double lengte = Graaf.Map.SelectMany(entry => entry.Value).Distinct().Select(segment => segment.Length()).Sum();
            return Math.Round(lengte, 2);
        }
    }
}
