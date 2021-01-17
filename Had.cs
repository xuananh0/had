﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Had
{
    class Had : IDrawable
    {
        private Hlava hlava;
        private List<CastHada> castiTela;
        private int rychlost;
        private int sirkaPole;
        private int vyskaPole;
        public Had(int x, int y, int sirkaPole, int vyskaPole)
        {
            this.sirkaPole = sirkaPole;
            this.vyskaPole = vyskaPole;

            hlava = new Hlava(x, y);
            castiTela = new List<CastHada>();
            for (int i = 0; i < 3; i++)
            {
                castiTela.Add(new CastHada(x - (i + 1), y));
            }

            castiTela[0].ZmenSmer(hlava);
        }

        public void PosunSe()
        {
            hlava.PohniSe();
            foreach (CastHada c in castiTela)
            {
                c.PohniSe();
            }
            for (int i = castiTela.Count - 1; i > 0; i--)
            {
                castiTela[i].ZmenSmer(castiTela[i - 1]);
            }

            castiTela[0].ZmenSmer(hlava);
        }

        public void ZmenSmer(Smer novySmer)
        {
            hlava.ZmenSmer(novySmer);
        }

        public void VykresliSe(Graphics g)
        {
            hlava.VykresliSe(g);
            foreach (CastHada c in castiTela)
            {
                c.VykresliSe(g);
            }
        }

      
    }
    public enum Smer
    {
        Nahoru,
        Doprava,
        Dolu,
        Doleva
    }
}