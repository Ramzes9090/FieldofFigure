using System;

namespace FieldofFigure
{
    class Program
    {

        static void Main(string[] args)
        {
            double sumatrojkatow = 0;
            double sumabok2 = 0;


            string wsp;
            string ilosc;
            int Ax, Bx, Cx, Ay, By, Cy;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cześć, oblicz pole twojej figury!   v1.0.0 made by Daniel Śliwka");
            Console.ResetColor();
            Console.WriteLine("Podaj ilość wierzcholków figury której obwód i pole chcesz policzyć:");
            ilosc = Console.ReadLine();
            int ilosc1 = int.Parse(ilosc); // musi byc parzysta // juz nie musi

            int length = 2 * ilosc1; // suma wspolrzednych x i y
            //Console.WriteLine(length);
            int[] tab = new int[length];

            Console.WriteLine("Podaj współrzędne punktów wierzchołkowych figury:");


            for (int i = 0; i < length; i++)
            {
                if (0 == i % 2)
                {
                    Console.WriteLine("Podaj współrzędne kolejnego punktu: ");
                }
                wsp = Console.ReadLine();
                int wspol = int.Parse(wsp);
                tab[i] = wspol;
            }


            // Console.WriteLine("Wsp to: "+tab[0]+","+tab[1]+","+tab[2]+","+tab[3]+","+tab[4]+","+tab[5]+","+tab[6]+","+tab[7]+","+tab[8]+","+tab[9]+" .");
            // pole figury


            for (int i = 1; i <= ((length / 2) - 2); i++)
            {
                Ax = tab[0];
                Ay = tab[1];
                Bx = tab[2 * (i)];
                Cx = tab[2 * (i) + 2];

                By = tab[2 * (i) + 1];
                Cy = tab[2 * (i) + 3];

                sumatrojkatow += PoleTrojkata(Ax, Ay, Bx, By, Cx, Cy);  //Słodki błąd, którego długo szukałem PoleTrojkata(Ax, Bx, Cx, Ay, By, Cy);
            }
            Console.WriteLine("Pole tej figury to: " + sumatrojkatow);

            //obwod figury
            for (int i = 1; i <= ((length / 2) - 2); i++)
            {
                Bx = tab[2 * (i)];
                Cx = tab[2 * (i) + 2];

                By = tab[2 * (i) + 1];
                Cy = tab[2 * (i) + 3];

                sumabok2 += bok2(Bx, By, Cx, Cy);
            }
                sumabok2+= bok1(tab[0], tab[1], tab[2], tab[3]);
                sumabok2 += bok3(tab[0], tab[1], tab[length - 2], tab[length-1]);
            Console.WriteLine("Obwod tej figury to: "+sumabok2);

        }
        static double PoleTrojkata(int Ax, int Ay, int Bx, int By, int Cx, int Cy)
        {
            int blad1 = 0;
            // Długośc boku AB
            double bok1;
            bok1 = Math.Sqrt(Math.Pow(Math.Abs(Ax - Bx), 2) + Math.Pow(Math.Abs(Ay - By), 2));

            // Długośc boku BC
            double bok2;
            bok2 = Math.Sqrt(Math.Pow(Math.Abs(Bx - Cx), 2) + Math.Pow(Math.Abs(By - Cy), 2));

            // Długośc boku CA
            double bok3;
            bok3 = Math.Sqrt(Math.Pow(Math.Abs(Ax - Cx), 2) + Math.Pow(Math.Abs(Ay - Cy), 2));


            // Pole trojkata
            double pole;
            double p;
            
            p = (bok1 + bok2 + bok3) / 2;
            pole = Math.Sqrt( p * (p - bok1) * (p - bok2) * (p - bok3));
            if (pole <= 0)
            {
                Console.WriteLine("Trojkat o takich wspolrzednych nie istniej!");
                blad1 = 1;
            }
           
            
            if(blad1 == 1)
            {
                pole = 0;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Taka figura nie istnieje, lub został popełniony bład podczas wpisywania zmiennych");
                Console.ResetColor();
            }
            return pole;
        }
        static double bok1(int Ax, int Ay, int Bx, int By)
        {
            
            double bok1;
            bok1 = Math.Sqrt(Math.Pow(Math.Abs(Ax - Bx), 2) + Math.Pow(Math.Abs(Ay - By), 2));
            return bok1;
            
        }
        static double bok2( int Bx, int By, int Cx, int Cy)
        {

            double bok2;
            bok2 = Math.Sqrt(Math.Pow(Math.Abs(Bx - Cx), 2) + Math.Pow(Math.Abs(By - Cy), 2));
            return bok2;

        }
        static double bok3(int Ax, int Ay, int Cx, int Cy)
        {

            double bok3;
            bok3 = Math.Sqrt(Math.Pow(Math.Abs(Ax - Cx), 2) + Math.Pow(Math.Abs(Ay - Cy), 2));
            return bok3;

        }
    }
}
