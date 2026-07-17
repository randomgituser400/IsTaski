
class CV
{
    public string Ixtisas, Mekteb, Skills, Companies, Diller;
    public string UniBali;
    public bool FerqlenmeDiplomu;
    public string GitLink, LinkedIn;
}

class Worker
{
    public int Id;
    public string Name, Surname, Seher, Phone;
    public string Age;
    public CV Cv;
}

class Employer
{
    public int Id;
    public string Name, Surname, Seher, Phone;
    public int Age;
    public List<string> Vacancies = new List<string>();}

class Program
{
    static List<Worker> workers = new List<Worker>();
    static List<Employer> employers = new List<Employer>();

    static void Main(){
           try
        {
            Console.WriteLine("=== Is Elani ===");
            Console.Write("Username: ");
            string username = Console.ReadLine();
             
             Console.Write("Password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Username ve ya password bos olmamalidr!");

            Console.Write(" Worker(1)  veya Employer(2)siniz? Secin 1/2 ");
            string type = Console.ReadLine();

            if (type == "1") WorkerMenu();
            else if (type == "2") EmployerMenu();
            else Console.WriteLine("Yanlis secim ettin!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("XETA: " + ex.Message);
        }

        Console.WriteLine("Program bitdi.");
     }

    static void WorkerMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n--- Worker Menu ---");
            Console.WriteLine("1-Profil yarat 2-CV elave et 3-Vakansiya axtar(seher) 4-EXIT");
            string secim = Console.ReadLine();

         try{
                switch (secim)
                {case "1":
                        Worker w = new Worker();
                        w.Id = workers.Count + 1;
                        Console.Write("Ad: "); w.Name = Console.ReadLine();
                        Console.Write("Soyad: "); w.Surname = Console.ReadLine();
                        Console.Write("Seher: "); w.Seher = Console.ReadLine();
                        Console.Write("Phone: "); w.Phone = Console.ReadLine();
                        Console.Write("Yas: "); w.Age = Console.ReadLine();
                        workers.Add(w);
                        Console.WriteLine("✅ Yeni Worker elave oldu (Id=" + w.Id + ")");
                        break;

                case "2":
                        Console.Write("Worker Id: ");
                        int id = int.Parse(Console.ReadLine());
                        Worker worker = workers.FirstOrDefault(x => x.Id == id);
                        if (worker == null)
                        {
                            Console.WriteLine("Worker tapilmadi!");
                            break;
                        }

                        CV cv = new CV();
                        Console.Write("Ixtisas: "); cv.Ixtisas = Console.ReadLine();
                        Console.Write("Oxudugu mekteb: "); cv.Mekteb = Console.ReadLine();
                        Console.Write("Uni qebul bali: "); cv.UniBali = Console.ReadLine();
                        Console.Write("Bacariqlar: "); cv.Skills = Console.ReadLine();
                        Console.Write("Islediyi sirketler: "); cv.Companies = Console.ReadLine();
                        Console.Write("Bildiyi diller: "); cv.Diller = Console.ReadLine();
                        Console.Write("Ferqlenme diplomu varmi? (h/y): ");
                        cv.FerqlenmeDiplomu = Console.ReadLine().ToLower() == "h";
                        Console.Write("GitLink: "); cv.GitLink = Console.ReadLine();
                        Console.Write("LinkedIn: "); cv.LinkedIn = Console.ReadLine();

                        worker.Cv = cv;
                        Console.WriteLine("✅ CV elave olundu.");
                        break;

                   case "3":
                        Console.WriteLine("Vakansiya axtar(seher) Aktiv");
                        break;

                case "4":
                        exit = true;
                        break;

                 default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("XETA: " + ex.Message);
            }
        }
    }

    static void EmployerMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n--- Employer Menu ---");
            Console.WriteLine("1-Profil yarat 2-Vakansiya elave et 3-Worker axtar(skill) 4-EXIT");
            string secim = Console.ReadLine();

            try
            {
                switch (secim)
                {
                    case "1":
                        Employer emp = new Employer();
                        emp.Id = employers.Count + 1;
                        Console.Write("Ad: "); emp.Name = Console.ReadLine();
                        Console.Write("Soyad: "); emp.Surname = Console.ReadLine();
                        Console.Write("Seher: "); emp.Seher = Console.ReadLine();
                        Console.Write("Phone: "); emp.Phone = Console.ReadLine();
                        Console.Write("Yash: "); emp.Age = int.Parse(Console.ReadLine());
                        employers.Add(emp);
                        Console.WriteLine("✅ Yeni employer elave olundu (Id=" + emp.Id + ")");
                        break;

                    case "2":
                        Console.Write("Employer Id: ");
                        int id2 = int.Parse(Console.ReadLine());
                        Employer e2 = employers.FirstOrDefault(x => x.Id == id2);
                        if (e2 == null)
                        {
                            Console.WriteLine("Employer tapilmadi!");
                            break;
                        }
                        Console.Write("Vakansiya adi: ");
                        e2.Vacancies.Add(Console.ReadLine());
                        Console.WriteLine("✅ Vakansiya elave olundu.");
                        break;

                    case "3":
                        Console.WriteLine("Worker axtarma Aktiv");
                        break;


                    case "4":
                        exit = true;
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("XETA: " + ex.Message);
            }
        }
    }
}

