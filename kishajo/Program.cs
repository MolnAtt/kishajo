using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kishajo
{
    class Program
    {

        struct Pojnt
        {
            public int X;
            public int Y;

            public Pojnt(int x,int y) => (X, Y) = (x, y);

            public static Pojnt operator *(int szam, Pojnt q) => new Pojnt(szam * q.X, szam * q.Y);
            public static Pojnt operator +(Pojnt p, Pojnt q) => new Pojnt(p.X + q.X, p.Y + q.Y);
        }

        class Sip
        {
            protected Pojnt hej;
            protected Pojnt irany; // pl. Észak = (0,1), Dél: (0,-1), Kelet: (1,0), Nyugat (-1,0)

            protected static Pojnt norsz = new Pojnt(0, 1);
            protected static Pojnt íszt = new Pojnt(1, 0);
            protected static Pojnt száufsz = new Pojnt(0, -1);
            protected static Pojnt veszt = new Pojnt(-1, 0);

            protected static Dictionary<char, Pojnt> direksöndiksöneri = new Dictionary<char, Pojnt> ();

            public static void Init()
            {
                direksöndiksöneri['N'] = norsz;
                direksöndiksöneri['E'] = íszt;
                direksöndiksöneri['S'] = száufsz;
                direksöndiksöneri['W'] = veszt;
            }
            public Sip()
            {
                hej = new Pojnt(0,0);
                irany = new Pojnt(1,0);
            }

            public Sip(Pojnt h, Pojnt i)
            {
                hej = h;
                irany = i;
            }

            public void Feldolgoz(string utasitas)
            {
                int mennyit = int.Parse(utasitas.Substring(1));

                switch (utasitas[0])
                {
                    case 'N':
                    case 'E':
                    case 'W':
                    case 'S':
                        hej += mennyit * direksöndiksöneri[utasitas[0]];
                        break;
                    case 'L':
                        for (int i = 0; i < mennyit; i+=90)
                            irany = new Pojnt(-irany.Y, irany.X);
                        break;
                    case 'R':
                        for (int i = 0; i < mennyit; i += 90)
                            irany = new Pojnt(irany.Y, -irany.X);
                        break;
                    case 'F':
                        hej += mennyit * irany;
                        break;
                }
            }

            public override string ToString() => $"heje = ({hej.X};{hej.Y}), irany = ({irany.X};{ irany.Y})";


        }

        static void Main(string[] args)
        {

            Sip.Init();

            Sip hajó = new Sip();

            Console.WriteLine(hajó);

            hajó.Feldolgoz("F10");
            Console.WriteLine(hajó);
            hajó.Feldolgoz("R270");
            Console.WriteLine(hajó);
            hajó.Feldolgoz("F5");
            Console.WriteLine(hajó);
            hajó.Feldolgoz("E7");
            Console.WriteLine(hajó);
            Console.ReadKey();
        }
    }
}
