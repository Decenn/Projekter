using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Langt fra perfekt
//Jeg er ikke stolt af koden, men jeg er stolt af hvordan det ser ud
//Håber det kan arbejdes med
//Ring eller skriv hvis det er: 31411072 (Er nok ikke på Face/Disc)


namespace UI
{
    class UI
    {
        //Test lister
        public static List<string> test_icles = new List<string>
        {
            "Kunde: Eric Bisbjerg (ID: 420)",
            "Mærke: Toyota",
            "Model: Corolla Sprinter Trueno(AE86)",
            "Produktions år: 1985",
            "RegNr: 12345AB",
            "Farve: Hentai Vinyl Wrap",
            "Oprettet: 11/09/2001",
            "Brandstof: Benzin",
            "Kørt: 125.000KM"
        };
        public static List<string> test = new List<string>
        {
            "Eric Bisbjerg - ID: 420 - Biler: Dem Alle",
            "Saad Maan - ID: 5321421 - Biler: 2",
            "P. Ennis - ID: 3431 - Biler: 41",
            "Mr. Perv - ID: 123423 - Biler: 1",
            "Sam Sung - ID: 123 - Biler: 2",
            "Chris P. Bacon - ID: 561 - Biler: 5",
            "Hitler Mussolini - ID: 612 - Biler: 1",
            "Dick Long - ID: 613 - Biler: 1",
            "Paul Twocock - ID: 122 - Biler: 2",
            "Mike Litoris - ID: 467 - Biler: 45",
            "Mrs. Weiner - ID: 542 - Biler: 2",
            "Mrs. Butt - ID: 753 - Biler: 1",
            "Moe Lester - ID: 412 - Biler: 1",
            "Major Dickie Head - ID: 515 - Biler: 2",
            "Dr. Faartz - ID: 999 - Biler: 4",
            "Jesus Condom - ID: 111 - Biler: 5",
            "Batman Bin Suparman - ID: 222 - Biler: 8",
            "Lord Brain - ID: 333 - Biler: 1",
            "Mrs. Rape - ID: 444 - Biler: 2",
            "F. You - ID: 555 - Biler: 1",
            "Dr. Shit Fun Chew - ID: 666 - Biler: 2",
            "Kash Register - ID: 777 - Biler: 5",
            "Donald Duck - ID: 888 - Biler: 1",
            "Gay Neighbors - ID: 999 - Biler: 7",
            "Dick Black - ID: 456 - Biler: 1",
            "Chew Kok Long - ID: 131 - Biler: 3",
            "Crystal Methven - ID: 511 - Biler: 1",
            "Eric Bisbjerg - ID: 420 - Biler: Dem Alle",
            "Saad Maan - ID: 5321421 - Biler: 2",
            "P. Ennis - ID: 3431 - Biler: 41",
            "Mr. Perv - ID: 123423 - Biler: 1",
            "Sam Sung - ID: 123 - Biler: 2",
            "Chris P. Bacon - ID: 561 - Biler: 5",
            "Hitler Mussolini - ID: 612 - Biler: 1",
            "Dick Long - ID: 613 - Biler: 1",
            "Paul Twocock - ID: 122 - Biler: 2",
            "Mike Litoris - ID: 467 - Biler: 45",
            "Mrs. Weiner - ID: 542 - Biler: 2",
            "Mrs. Butt - ID: 753 - Biler: 1",
            "Moe Lester - ID: 412 - Biler: 1",
            "Major Dickie Head - ID: 515 - Biler: 2",
            "Dr. Faartz - ID: 999 - Biler: 4",
            "Jesus Condom - ID: 111 - Biler: 5",
            "Batman Bin Suparman - ID: 222 - Biler: 8",
            "Lord Brain - ID: 333 - Biler: 1",
            "Mrs. Rape - ID: 444 - Biler: 2",
            "F. You - ID: 555 - Biler: 1",
            "Dr. Shit Fun Chew - ID: 666 - Biler: 2",
            "Kash Register - ID: 777 - Biler: 5",
            "Donald Duck - ID: 888 - Biler: 1",
            "Gay Neighbors - ID: 999 - Biler: 7",
            "Dick Black - ID: 456 - Biler: 1",
            "Chew Kok Long - ID: 131 - Biler: 3",
            "Crystal Methven - ID: 511 - Biler: 1",
            "Eric Bisbjerg - ID: 420 - Biler: Dem Alle",
            "Saad Maan - ID: 5321421 - Biler: 2",
            "P. Ennis - ID: 3431 - Biler: 41",
            "Mr. Perv - ID: 123423 - Biler: 1",
            "Sam Sung - ID: 123 - Biler: 2",
            "Chris P. Bacon - ID: 561 - Biler: 5",
            "Hitler Mussolini - ID: 612 - Biler: 1",
            "Dick Long - ID: 613 - Biler: 1",
            "Paul Twocock - ID: 122 - Biler: 2",
            "Mike Litoris - ID: 467 - Biler: 45",
            "Mrs. Weiner - ID: 542 - Biler: 2",
            "Mrs. Butt - ID: 753 - Biler: 1",
            "Moe Lester - ID: 412 - Biler: 1",
            "Major Dickie Head - ID: 515 - Biler: 2",
            "Dr. Faartz - ID: 999 - Biler: 4",
            "Jesus Condom - ID: 111 - Biler: 5",
            "Batman Bin Suparman - ID: 222 - Biler: 8",
            "Lord Brain - ID: 333 - Biler: 1",
            "Mrs. Rape - ID: 444 - Biler: 2",
            "F. You - ID: 555 - Biler: 1",
            "Dr. Shit Fun Chew - ID: 666 - Biler: 2",
            "Kash Register - ID: 777 - Biler: 5",
            "Donald Duck - ID: 888 - Biler: 1",
            "Gay Neighbors - ID: 999 - Biler: 7",
            "Dick Black - ID: 456 - Biler: 1",
            "Chew Kok Long - ID: 131 - Biler: 3",
            "Crystal Methven - ID: 511 - Biler: 1",
            "Navne taget fra Boredpanda.com, lol"
        };


        public static void UIMain()
        {
            Console.SetWindowSize(120, 35);
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;

            //Display.type(X1, Y1, X2, X1) Kordinater til vinduet
            Display.List Menu = new Display.List(0, 0, 30, 30); //Opretter rammerne her
            Display.Edit Input = new Display.Edit(31, 0, 119, 30);
            Display.Static Show = new Display.Static(31, 0, 119, 30);
            Display.List ShowMany = new Display.List(31, 0, 119, 30);
            ShowMany.returnString = false; //Retunere index
            Display.Static Help = new Display.Static(0, 31, 119, 33);
            Help.Text = new List<string> { "  Piltaster(Navigere)     Enter(Vælg)    Retur(Tilbage)" };

            Display.PrintFrames();
            Help.Run();

            do  //Dette er main loop, alt skulle gerne kunne klares herfra
            {
                Menu.PrintFrame(); //Ryder frame
                Menu.Choice = new List<string> { "Find (Bil)", "Find (Kunde)", "Opret Kunde", "Afslut" };
                switch (Menu.Run())
                {
                    case "Find (Bil)":
                        {
                            Show.PrintFrame();
                            Show.Text = test_icles;
                            Show.Run();
                            Input.Labels = new List<string> { "Søg efter bil" };
                            //Indsæt søge metode/klasse der søger efter "Input.Run()[0]" som er en string
                            //Når i har et array af Index på de biler der skal vises frem, så lav en metode i klasserne der kan lave en string med de vigtige info (Eks: "RegNr: 1234AB - Ejer: Anders And - Model: Indkøbskurv") (Med Formatering på de strings så infoen står i rækker)
                            //Smid alle de strings i en liste og lav så "ShowMany.Choice = Jeres liste af info"
                            //Så kan i vise bilens index ved List<Cars>[IndexArray[ShowMany.Run()]]
                            //Ny list<string> metode hos bil klassen der retunere info om bilen (new list<string>{ $"Brand: {this.Brand}", $"Model: {this.Model} }")
                            //Sæt den i Show.Text = den nye list<string> metode
                            Show.Run();
                            Menu.PrintFrame(); 
                            Menu.Choice = new List<string> { "Værkstedbesøg", "Rediger", "Slet" };
                    
                            switch (Menu.Run())
                            {
                                case "Værkstedbesøg":
                                    {
                                        Menu.PrintFrame();
                                        Menu.Choice = new List<string> { "Opret Besøg", "Vis Besøg"};
                                        switch (Menu.Run())
                                        {
                                            case "Opret Besøg":
                                                {
                                                    //Input
                                                    break;
                                                }
                                            case "Vis Besøg":
                                                {
                                                    //Vis besæg ligesom bilerne med ShowMany
                                                    Menu.PrintFrame();
                                                    Menu.Choice = new List<string> { "Rediger", "Slet" };
                                                    switch (Menu.Run())
                                                    {
                                                        case "Rediger":
                                                            {
                                                                break;
                                                            }
                                                        case "Slet":
                                                            {
                                                                break;
                                                            }
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                }
                                            default:
                                                break;
                                        }
                                        break;
                                    }
                                case "Rediger":
                                    {
                                        //Har ikke lige noget her endnu
                                        //List frame til at vælge hvad du vil ændre > Derefter en Input frame
                                        //eller Input frame hvor de blanke ikke bliver ændret
                                        break;
                                    }
                                case "Slet":
                                    {
                                        //You know what to do
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case "Find (Kunde)":
                        {
                            //Meget af det samme som Find(Bil)
                            ShowMany.PrintFrame();
                            ShowMany.Choice = test; 
                            ShowMany.Run();
                            Menu.PrintFrame();
                            Menu.Choice = new List<string> { "Opret Bil", "Rediger", "Slet" };
                            switch (Menu.Run())
                            {
                                case "Opret Bil":
                                    {
                                        do
                                        {
                                            Input.Labels = new List<string> { "RegNr", "Mærke", "Model" };
                                            Input.Run(); //Retunere list<string> Skal have en metode der kan smide dem i en construtor
                                        } while (false); //Loop til der ikke er nogle problemer med oprettelsen, laver 'cancel' funktion på mandag
                                        break;
                                    }
                                case "Rediger":
                                    {
                                        break;
                                    }
                                case "Slet":
                                    {
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case "Opret Kunde":
                        {
                            Input.PrintFrame();
                            Input.Labels = new List<string> { "Fornavn", "Efternavn" };
                            Input.Run(); //Til constructor
                            break;
                        }
                    case "Afslut":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        break;
                }
            } while (true);
        }
    }
    partial class Display
    {
        static public List<Frame> MyFrames = new List<Frame>();
        public static void PrintFrames()
        {
            foreach (Frame f in MyFrames)
            {
                f.PrintFrame();
            }
        }

        public class Static : Frame
        {
            public List<string> Text = new List<string>();
            public Static(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
            {
            }

            public void Run()
            {
                for (int i = 0; i < Text.Count(); i++)
                {
                    Console.SetCursorPosition(X1 + 1, Y1 + i * 2 + 1);
                    Console.Write(Text[i]);
                }
            }
        }

        public class Edit : Frame
        {
            public Edit(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
            {
            }

            public List<string> Labels = new List<string>();
            List<string> Input = new List<string>();

            public List<string> Run()
            {
                Console.CursorVisible = true;
                int Tab = 0;
                for (int i = 0; i < Labels.Count(); i++)
                {
                    if (Labels[i].Length > Tab)
                    {
                        Tab = Labels[i].Length;
                    }

                    Console.SetCursorPosition(X1 + 1, Y1 + i * 2 + 1);
                    Console.Write(Labels[i] + ":");
                }
                Tab += 2;

                for (int i = 0; i < Labels.Count(); i++)
                {
                    Console.SetCursorPosition(X1 + 1 + Tab, Y1 + i * 2 + 1);
                    Input.Add(Console.ReadLine());
                }

                Console.CursorVisible = false;
                PrintFrame();
                return Input;
            }
        }

        public class List : Frame
        {
            public List(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
            {
            }

            public List<string> Choice = new List<string>();
            int Index = 0;
            int Start = 0;
            public bool returnString = true;

            public dynamic Run()
            {
                int Pad = 0;
                bool Loop = true;
                foreach (string s in Choice)
                {
                    if (s.Length > Pad)
                    {
                        Pad = s.Length;
                    }
                }
                do
                {
                    for (int i = 0; i < Height && i < Choice.Count(); i++)
                    {
                        Console.SetCursorPosition(X1 + 1, Y1 + i + 1);
                        if (i + Start == Index)
                        {
                            Highlight(Choice[i + Start].PadRight(Pad));
                        }
                        else
                            Console.Write(Choice[i + Start].PadRight(Pad));
                    }

                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Backspace:
                            return null;
                        case ConsoleKey.Enter:
                            Loop = false;
                            break;
                        case ConsoleKey.DownArrow:
                            {
                                Index++;
                                break;
                            }
                        case ConsoleKey.UpArrow:
                            {
                                Index--;
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                Index += Height;
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            {
                                Index -= Height;
                                break;
                            }
                        default:
                            break;
                    }

                    if (Index < 0)
                    {
                        Index = 0;
                    }
                    else if (Index > Choice.Count() - 1)
                    {
                        Index = Choice.Count() - 1;
                    }

                    if (Index + 1 - Start > Height)
                    {
                        Start = Index + 1 - Height;
                    }
                    else if (Index < Start)
                    {
                        Start = Index;
                    }
                } while (Loop);

                if (returnString)
                    return Choice[Index];
                else
                    return Index;
            }

            void Highlight(string s)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(s);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
    partial class Display
    {
        public class Frame
        {
            public int X1 { get; }
            public int Y1 { get; }
            public int X2 { get; }
            public int Y2 { get; }

            protected int Height { get; }
            protected int Width { get; }

            public List<string> Box = new List<string>();
            public void ConstructFrame()
            {
                Box.Add("╔" + new string('═', Width) + "╗");
                for (int i = 0; i < Y2 - Y1 - 1; i++)
                {
                    Box.Add("║" + new string(' ', Width) + "║");
                }
                Box.Add("╚" + new string('═', Width) + "╝");

                MyFrames.Add(this);
            }


            public Frame(int x1, int y1, int x2, int y2)
            {
                this.X1 = x1;
                this.Y1 = y1;
                this.X2 = x2;
                this.Y2 = y2;

                Height = Y2 - Y1 - 1;
                Width = X2 - X1 - 1;
                ConstructFrame();
            }

            public void PrintFrame()
            {
                for (int i = 0; i < Box.Count(); i++)
                {
                    Console.SetCursorPosition(X1, Y1 + i);
                    Console.Write(Box[i]);
                }
            }

        }
    }
}
