// See https://aka.ms/new-console-template for more information

using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using UserAPI;

HttpClient client = new HttpClient();
bool exit= false;
UserService userService= new UserService(client);


while (!exit)
{
    Console.WriteLine("Seleziona Operazione");
    Console.WriteLine("1.Mostra tutti gli user \n" +
                      "2.Cerca User con Id \n" +
                      "3.Cerca User con città \n" +
                      "4.Cerca User con Suite \n" +
                      "5.Cerca User con Company \n" +
                      "6.Cerca email User con dominio \n" +
                      "7.Cerca Utenti in un range Geo \n" +
                      "8.Distribuzione delle città \n" +
                      "9.Stampa Nomi User in ordine alfabetico \n" +
                      "10.Salva riassunto in un file \n" +
                      "0.Exit");

    int cmd=int.Parse(Console.ReadLine());
    if (cmd >= 0 && cmd <= 10)
    {
        switch (cmd)
        {
            case 0:
                exit = true;
                break;
            
            case 1:
                List<User> listaUsers = await userService.GetAllUsers();
                foreach (var u in listaUsers)
                {
                    Console.WriteLine($"Nome: {u.Name} - Email: {u.Email} - Company: {u.company.name}");
                }
                break;
            
            case 2:
                Console.WriteLine("Inserisci ID: ");
                int userId= int.Parse(Console.ReadLine());
                var u1= await userService.GetUserById(userId);
                if (u1 is not null)
                    Console.WriteLine($"Nome: {u1.Name} - Email: {u1.Email} - Company: {u1.company.name}");
                else
                    Console.WriteLine("Id non presente");
                
                break;
            
            case 3:
                Console.WriteLine("Inserisci Città: ");
                string city= Console.ReadLine();
                List<User> listaUsersCity = await userService.GetUserByCity(city);
                if(listaUsersCity is not null) 
                    foreach (var u2 in listaUsersCity)
                    {
                        Console.WriteLine($"Nome: {u2.Name} - Email: {u2.Email} - Company: {u2.company.name}");
                    }
                else
                    Console.WriteLine("Città non presente");
                break;
            
            case 4:
                Console.WriteLine("Inserisci Suite: ");
                string suite= Console.ReadLine();
                List<User> listaUsersSuite = await userService.GetUserBySuite(suite);
                if (listaUsersSuite is not null)
                    foreach (var u3 in listaUsersSuite)
                    {
                        Console.WriteLine($"Nome: {u3.Name} - Email: {u3.Email} - Company: {u3.company.name}");
                    }
                else
                    Console.WriteLine("Suite non presente");
                break;
            
            case 5:
                Console.WriteLine("Inserisci Company: ");
                string company= Console.ReadLine();
                List<User> listaUsersCompany = await userService.GetUserByCompany(company);
                if (listaUsersCompany is not null)
                    foreach (var u4 in listaUsersCompany)
                    {
                        Console.WriteLine($"Nome: {u4.Name} - Email: {u4.Email} - Company: {u4.company.name}");
                    }
                else
                    Console.WriteLine("Company non presente");
                break;
            
            case 6:
                Console.WriteLine("Inserisci Dominio: ");
                string domain= Console.ReadLine();
                List<User> listaUsersEmail = await userService.GetUserEmailByDomain(domain);
                if (listaUsersEmail is not null)
                    foreach (var u5 in listaUsersEmail)
                    {
                        Console.WriteLine($"Nome: {u5.Name} - Email: {u5.Email} - Company: {u5.company.name}");
                    }
                else
                    Console.WriteLine("Dominio non presente");
                break;
            
            case 7:
                Console.WriteLine("Inserisci Valore Geo: ");
                double geo = double.Parse(Console.ReadLine());
                List<User> listaUserGeo = await userService.GetUserInGeoRange(geo);
                if(listaUserGeo is not null)
                    foreach (var u6 in listaUserGeo)
                    {
                        Console.WriteLine($"Nome: {u6.Name} - Email: {u6.Email} - Company: {u6.company.name}");
                    }
                else
                    Console.WriteLine("Nessuno User presente");

                break;
            
            case 8:
                Dictionary<string, int> cityDistribution = await userService.GetCityDistribution();
                foreach (var c in cityDistribution)
                {
                    Console.WriteLine($"{c.Key} - {c.Value}");
                }

                break;
            
            case 9:
                List<string> listaUsersAplhabetically = await userService.GetNameAlphabetically();
                foreach (var n in listaUsersAplhabetically)
                {
                    Console.WriteLine($"Nome: {n}");
                }
                break;
            
            case 10:
                Console.WriteLine("Salvataggio in corso");
                
                //Attendo fine operazione
                await userService.SaveSummaryToFile("C:\\Users\\cirel\\Desktop\\summary.txt");
                
                Console.WriteLine("Salvataggio completato");
                break;
        }
        Console.WriteLine("\n \n \n");
        
    }
}