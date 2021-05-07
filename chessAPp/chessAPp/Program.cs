using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace chessAPp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] chessInput = new string[8, 8];


            //dosya okuma methodu
            string[][] dosyadanOku()
            {
                int x1 = 0;
                int y1 = 0;
                //string[,] chessIn = new string[8, 8];
                string[][] chessIn2 = new string[8][];


                //satranç dizilimi buradan alınmaktadır

                String dosya_yolu = @"C:\Users\Makay.Makay-PC\Desktop\Board3.txt";

                //Okuma işlem yapacağımız dosyanın yolunu belirtiyoruz.
                FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);

                //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
                //2.parametre dosyanın açılacağını,
                //3.parametre dosyaya erişimin veri okumak için olacağını gösterir.
                StreamReader sw = new StreamReader(fs);
                //Okuma işlemi için bir StreamReader nesnesi oluşturduk.
                string yazi = sw.ReadLine();
                while (yazi != null)
                {

                    if (x1 == 8)
                    {

                        x1 = 0;
                        y1++;

                    }
                    chessIn2[x1] = yazi.Split();
                    //chessIn[x1] = yazi.Split();

                    x1++;


                    //Console.WriteLine("aaa aaa");

                    Console.WriteLine(yazi);
                    Console.WriteLine(x1);


                    yazi = sw.ReadLine();
                }

                //Satır satır okuma işlemini gerçekleştirdik ve ekrana yazdırdık
                //Son satır okunduktan sonra okuma işlemini bitirdik
                sw.Close();
                fs.Close();

                //okunan satranç konumları nesneye aktarıldı
                return chessIn2;
            }




            //fil tehditlerini bulur
            List<Tuple<int, int>> CheckBishop(string[][] chessIn2, Tuple<int, int> bishopLocation)
            {


                //Her çapraz durum için bir liste tanımlandı
                var bishopList1 = new List<Tuple<int, int>>();

                var bishopList2 = new List<Tuple<int, int>>();

                var bishopList3 = new List<Tuple<int, int>>();

                var bishopList4 = new List<Tuple<int, int>>();

                var bishopListTotal = new List<Tuple<int, int>>();


                int y2, x2= 0;

                y2 = bishopLocation.Item1;
                x2 = bishopLocation.Item2;
            
                char bishopColour = chessIn2[y2][x2][1];



                // sol azalan çapraz hareket
                while (y2 > 0 && x2 != 0)
                {

                    while (x2 > 0)
                    {
                        // y2 ve x2 için filin konumundan gelir


                        x2--;
                        y2--;

                        if (chessIn2[y2][x2] != "xx")
                        {
                            if (chessIn2[y2][x2][1] == bishopColour)
                            {
                                x2 = 0;
                            }
                            else
                            {
                                bishopList1.Add(new Tuple<int, int>(y2, x2));

                                //Sol azalan çaprazda item var

                            }
                        }



                        if (x2 == 0)
                        {

                            y2 = 0;
                        }


                        if (y2 == 0)
                        {

                            x2 = 0;
                        }






                    }
                }



                y2 = bishopLocation.Item1;
                x2 = bishopLocation.Item2;
                //artan çapraz hareket
                while (y2 < 7 && x2 != 7)
                {
                    while (x2 < 7)
                    {
                        x2++;
                        y2++;

                        if (chessIn2[y2][x2] != "xx")
                        {
                            if (chessIn2[y2][x2][1] == bishopColour)
                            {
                                x2 = 7;
                            }
                            else
                            {

                                bishopList2.Add(new Tuple<int, int>(y2, x2));
                                //Sol artan çaprazda item var

                            }

                        }



                        if (x2 == 7)
                        {

                            y2 = 7;
                        }


                        if (y2 == 7)
                        {

                            x2 = 7;
                        }


                    }
                }

                y2 = bishopLocation.Item1;
                x2 = bishopLocation.Item2;
                while (y2 > 0 && x2 != 7)
                {

                    while (x2 < 7)
                    {
                        y2--;
                        x2++;


                        if (chessIn2[y2][x2] != "xx")
                        {

                            if (chessIn2[y2][x2][1] == bishopColour)
                            {
                                x2 = 7;

                            }

                            else
                            {

                                bishopList3.Add(new Tuple<int, int>(y2, x2));
                                //Sağ üst çaprazda item var

                            }
                        }



                        if (x2 == 7)
                        {

                            y2 = 0;
                        }


                        if (y2 == 0)
                        {

                            x2 = 7;
                        }








                    }
                }

                y2 = bishopLocation.Item1;
                x2 = bishopLocation.Item2;

                // sol alt hareket
                while (y2 < 7 && x2 != 0)
                {

                    while (x2 > 0)
                    {
                        y2++;
                        x2--;

                        if (chessIn2[y2][x2] != "xx")
                        {
                            if (chessIn2[y2][x2][1] == bishopColour)
                            {
                                x2 = 0;

                            }

                            else
                            {


                                bishopList4.Add(new Tuple<int, int>(y2, x2));
                                //sol alt çaprazda item var

                            }


                        }


                        if (x2 == 0)
                        {

                            y2 = 7;
                        }


                        if (y2 == 7)
                        {

                            x2 = 0;
                        }




                    }
                }


                if (bishopList1.ElementAtOrDefault(0) != null)
                {
                    bishopListTotal.Add(bishopList1[0]);
                }
                if (bishopList2.ElementAtOrDefault(0) != null)
                {
                    bishopListTotal.Add(bishopList2[0]);
                }
                if (bishopList3.ElementAtOrDefault(0) != null)
                {
                    bishopListTotal.Add(bishopList3[0]);
                }
                if (bishopList4.ElementAtOrDefault(0) != null)
                {
                    bishopListTotal.Add(bishopList4[0]);
                }




                return bishopListTotal;


            }


            //fillerin pozisyonunu döner
            List<Tuple<int, int>> findBishopLocation(string[][] chessIn3)
            {
                var tupleList2 = new List<Tuple<int, int>>();

                int y8 = 0;
                int x8 = 0;
                while (y8 < 8)
                {

                    while (x8 < 8)
                    {

                        if (chessIn3[y8][x8][0] == 'f')

                        {

                            tupleList2.Add(new Tuple<int, int>(y8, x8));



                        }
                        x8++;



                    }
                    x8 = 0;
                    y8++;
                }
                return tupleList2;
            }







            //atların pozisyonunu döner
            List<Tuple<int, int>> findKnightLocation(string[][] chessIn3)
            {
                var tupleList2 = new List<Tuple<int, int>>();

                int y8 = 0;
                int x8 = 0;
                while (y8 < 8)
                {

                    while (x8 < 8)
                    {

                        if (chessIn3[y8][x8][0] == 'a')

                        {

                            tupleList2.Add(new Tuple<int, int>(y8, x8));



                        }
                        x8++;



                    }
                    x8 = 0;
                    y8++;
                }
                return tupleList2;
            }

            List<Tuple<int, int>> checkKnight(string[][] chessIn2, Tuple<int, int> location)
            {

                var KinghtThreatList = new List<Tuple<int, int>>();

                int y3, x3 = 0;

                List<int> a1 = new List<int>();

                y3 = location.Item1;
                x3 = location.Item2;


                //atın rengi 

                char KnightColor = chessIn2[y3][x3][1];
                //char KnightColor = 'b';

                if (x3 - 2 > -1 && y3 - 1 > -1 && chessIn2[y3 - 1][x3 - 2] != "xx" && chessIn2[y3 - 1][x3 - 2][1] != KnightColor)
                {

                    //Atın tehdidinde item var
                    KinghtThreatList.Add(new Tuple<int, int>(y3 - 1, x3 - 2));

                }


                if (x3 - 1 > -1 && y3 - 2 > -1 && chessIn2[y3 - 2][x3 - 1] != "xx" && chessIn2[y3 - 2][x3 - 1][1] != KnightColor)
                {

                    //Atın tehdidinde item var

                    KinghtThreatList.Add(new Tuple<int, int>(y3 - 2, x3 - 1));


                }

                if (x3 - 2 > -1 && y3 + 1 < 8 && chessIn2[y3 + 1][x3 - 2] != "xx" && chessIn2[y3 + 1][x3 - 2][1] != KnightColor)
                {

                    //Atın tehdidinde item var

                    KinghtThreatList.Add(new Tuple<int, int>(y3 + 1, x3 - 2));


                }
                if (x3 - 1 > -1 && y3 + 2 < 8 && chessIn2[y3 + 2][x3 - 1] != "xx" && chessIn2[y3 + 2][x3 - 1][1] != KnightColor)
                {
                    //Atın tehdidinde item var

                    KinghtThreatList.Add(new Tuple<int, int>(y3 + 2, x3 - 1));


                }



                if (x3 + 2 < 8 && y3 + 1 > -1 && chessIn2[y3 + 1][x3 + 2] != "xx" && chessIn2[y3 + 1][x3 + 2][1] != KnightColor)
                {

                    //Atın tehdidinde item var

                    KinghtThreatList.Add(new Tuple<int, int>(y3 + 1, x3 + 2));


                }


                if (x3 + 2 < 8 && y3 - 1 > -1 && chessIn2[y3 - 1][x3 + 2] != "xx" && chessIn2[y3 - 1][x3 + 2][1] != KnightColor)
                {

                    //Atın tehdidinde item var

                    KinghtThreatList.Add(new Tuple<int, int>(y3 - 1, x3 + 2));


                }

                if (x3 + 1 < 8 && y3 + 2 < 8 && chessIn2[y3 + 2][x3 + 1] != "xx" && chessIn2[y3 + 2][x3 + 1][1] != KnightColor)
                {

                    //Atın tehdidinde item var

                    KinghtThreatList.Add(new Tuple<int, int>(y3 + 2, x3 + 1));


                }
                if (x3 + 1 < 8 && y3 - 2 > -1 && chessIn2[y3 - 2][x3 + 1] != "xx" && chessIn2[y3 - 2][x3 + 1][1] != KnightColor)
                {

                    //Atın tehdidinde item var

                    KinghtThreatList.Add(new Tuple<int, int>(y3 - 2, x3 - 1));


                }
                return KinghtThreatList;

            }



            String[][] a = new string[8][];

            //a'ya dosyadan okunan konum değerleri alır
            a = dosyadanOku();

            var TotalThreatList = new List<Tuple<int, int>>();





            //fillerin toplam tehditleri


            foreach (Tuple<int, int> t in findBishopLocation(a))
            {


                foreach (Tuple<int, int> k in CheckBishop(a, t))
                {
                    Console.WriteLine("---------Fil tehdit--------");

                    Console.WriteLine(k);

                    TotalThreatList.Add(k);
                    //Console.WriteLine(TotalThreatList.Count());

                    Console.WriteLine("------------------------------------------");



                }


            }





            //atların toplam tehdilerli
            foreach (Tuple<int, int> t in findKnightLocation(a))
            {


                foreach (Tuple<int, int> a2 in checkKnight(a, t))
                {

                    TotalThreatList.Add(a2);

                    Console.WriteLine("*********At tehdit*********");

                    Console.WriteLine(a2);

                    Console.WriteLine("******************************************");

                }



            }

            // at ve filler toplam tehditleri

            Console.Write("at ve filler toplam tehditleri");


            foreach (Tuple<int, int> e in TotalThreatList)
            {
                Console.WriteLine(e);

            }

            int l1 = 0;
            int l2 = 0;

            Console.Write("\n");

            Console.WriteLine("Satranc dizliminin orijianal hali aşagıdaki gibidir.");
            Console.Write("\n");


            while (l1 < 8)
            {

                while (l2 < 8)
                {


                    Console.Write(a[l1][l2]);
                    Console.Write("   ");

                    l2++;
                }
                Console.Write("\n");
                Console.Write("\n");


                l2 = 0;

                l1++;
            }

            Console.Write("\n");

            l1 = 0;
            l2 = 0;
            Console.WriteLine("Satranc dizliminde fil ve atların tehditlerinin ** ile isaretlenmis hali aşagıdaki gibidir.");
            Console.Write("\n");


            while (l1 < 8)
            {

                while (l2 < 8)
                {

                    if (TotalThreatList.Contains(new Tuple<int, int>(l1, l2)))
                    {
                        Console.Write("**");
                        Console.Write("   ");

                    }
                    else
                    {
                        Console.Write(a[l1][l2]);
                        Console.Write("   ");
                    }
                    l2++;
                }
                Console.Write("\n");
                Console.Write("\n");


                l2 = 0;

                l1++;
            }




            Console.ReadKey();
        }
    }
}
