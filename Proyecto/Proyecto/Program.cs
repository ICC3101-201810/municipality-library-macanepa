using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ClassLibrary1;

namespace Proyecto
{
    class Program
    {

        static List<ClassLibrary1.Person> lstPerson = new List<ClassLibrary1.Person>();
        static List<ClassLibrary1.Car> lstCar = new List<Car>();
        static List<ClassLibrary1.Address> lstAddress = new List<Address>();

        static Person currentUser;
        static Address currentAddress;
        static Car currentCar;

        


        static void Main(string[] args)
        {


            Person person1 = new Person("Juan", "Wiwi", new DateTime(1990, 03, 23), null, "17.000.000-0", null, null);
            Person person2 = new Person("Pepe", "wawa", new DateTime(1997, 10, 13), null, "19.654.123-K", null, null);
            Person person3 = new Person("Luis", "Pepperoni", new DateTime(1985, 12, 12), null, "15.305.395-4", null, null);

            Address address1 = new Address("Camino Las Wiwieldas", 5200, "Chupilandia", "Santiago", person1, 1980, 2, 3, true, false);
            Address address2 = new Address("Patapurris", 334, "Twilight Town", "Santiago", person2, 1980, 2, 3, true, false);
            Address address3 = new Address("Kigndom", 654, "Hearts", "Disney", person3, 1980, 2, 3, true, false);

            Car car1 = new Car("Meche", "A200", 2017, person1, "GCGF45", 5, false);
            Car car2 = new Car("Mazda", "Sport", 2015, person2, "AFTF78", 5, false);
            Car car3 = new Car("Kia", "Rio 5", 2016, person3, "TJAW27", 5, true);

            lstPerson.Add(person1);
            lstPerson.Add(person2);
            lstPerson.Add(person3);

            lstAddress.Add(address1);
            lstAddress.Add(address2);
            lstAddress.Add(address3);

            lstCar.Add(car1);
            lstCar.Add(car2);
            lstCar.Add(car3);


            currentUser = person1;


            while (true)
            {
                try
                {
                    Menu();
                }
                catch
                {
                    Console.WriteLine("Error!\n" +
                        "Returning to Main Menu\n" +
                        "Press Enter...");
                    Console.ReadLine();
                }
            }
        }
         

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine($"\nMenu\n" +
                "Selecciona una Opcion:\n" +
                "(1) Add...\n" +
                "(2) Person Operation\n" +
                "(3) Address Operation\n" +
                "(4) Car Operation\n");

            string op = Console.ReadLine();

            if(op == "1")
            {
                Agregar();
            }
            else if (op == "2")
            {
                PersonOperation();
            }
            else if (op == "3")
            {
                AddressOperation();
            }
            else if (op == "4")
            {
                CarOperation();
            }

        }

        static void Agregar()
        {
            Console.Write("(1) Person\n" +
                "(2) Address\n" +
                "(3) Car\n" +
                "(4) Back\n:> ");
            string op = Console.ReadLine();

            List<string> opciones = new List<string>();
            opciones.Add("1");
            opciones.Add("2");
            opciones.Add("3");
            opciones.Add("4");

            if (!opciones.Contains(op))
            {
                Console.WriteLine("No valido!");
                return;
            }

            try
            {
                if (op == "1")
                {
                    Console.Write("First Name: ");
                    string FN = Console.ReadLine();
                    Console.Write("Last Name: ");
                    string LN = Console.ReadLine();

                    Console.Write("Rut: ");
                    string Rut = Console.ReadLine();



                    Console.WriteLine("BirthDate: ");
                    Console.Write("\tYear: ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\tMonth: ");
                    int month = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\tDay: ");
                    int day = Convert.ToInt32(Console.ReadLine());

                    DateTime BD = new DateTime(year, month, day);


                    Console.Write("Address: ");
                    SelectAddress();

                    Person person = new Person(FN, LN, BD, currentAddress, Rut, null, null);
                    lstPerson.Add(person);
                }
            }
            catch
            {
                Console.WriteLine("Error Creating New Person!\nPress Enter...");
                Console.ReadLine();
            }

            try
            {
                if(op == "2")
                {
                    Console.WriteLine("Add Address");
                    Console.Write("Street: ");
                    string street = Console.ReadLine();
                    Console.Write("Number: ");
                    int number = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Commune: ");
                    string commune = Console.ReadLine();
                    Console.Write("City: ");
                    string city = Console.ReadLine();
                    Console.Write("Year of Contruction: ");
                    int yearCon = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Number of Bedrooms: ");
                    int bedrooms = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Number of Bathrooms: ");
                    int bathrooms = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Has Backyard (1) yes, (2) No: ");
                    string backyardSTR = Console.ReadLine();
                    bool backyard=false;
                    if (backyardSTR == "1")
                    {
                        backyard = true;
                    }
                    else if (backyardSTR == "2")
                    {
                        backyard = false;
                    }
                    else
                    {
                        Console.WriteLine("Error! Press Enter to continue...");
                        Console.ReadLine();
                    }

                    Console.Write("Has Pool (1) yes, (2) No: ");
                    string poolSTR = Console.ReadLine();
                    bool pool = false;
                    if (poolSTR == "1")
                    {
                        pool = true;
                    }
                    else if (poolSTR == "2")
                    {
                        pool = false;
                    }
                    else
                    {
                        Console.WriteLine("Error! Press Enter to continue...");
                        Console.ReadLine();
                    }

                    SelectPerson();


                    Address address = new Address(street, number, commune, city, currentUser, yearCon, bedrooms, bathrooms,backyard, pool);
                    lstAddress.Add(address);
                }
            }
            catch
            {
                Console.WriteLine("Error Creating New Address!\nPress Enter...");
                Console.ReadLine();
            }

            try
            {
                if(op == "3")
                {
                    Console.WriteLine("Add Car");
                    Console.Write("Brand: ");
                    string Brand = Console.ReadLine();
                    Console.Write("Model: ");
                    string Model = Console.ReadLine();
                    Console.Write("Year: ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("License Plate: ");
                    string License_plate = Console.ReadLine();
                    Console.Write("Number of Seatbelts: ");
                    int seatbelt = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Is Diesel (1) Yes, (2) No: ");
                    string DieselSTR = Console.ReadLine();
                    bool Diesel = false;
                    if (DieselSTR == "1")
                    {
                        Diesel = true;
                    }
                    else if (DieselSTR == "2")
                    {
                        Diesel = false;
                    }
                    else
                    {
                        Console.WriteLine("Not Valid Input! Press Enter...");
                        Console.ReadLine();
                        return;
                    }

                    SelectPerson();


                    Car car = new Car(Brand, Model, year, currentUser, License_plate, seatbelt, Diesel);
                    lstCar.Add(car);
                }
                else
                {
                    return;
                }
            }
            catch
            {
                Console.WriteLine("Error Creating New Car!\nPress Enter...");
                Console.ReadLine();
            }


        

        }
        static Person SelectPerson()
        {
            //Console.Clear();
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("Select a Person");
            int c = 1;
            foreach (Person person in lstPerson)
            {
                Console.WriteLine(c.ToString() + ". " + person.Rut + ": " + person.First_name + " " + person.Last_name);
                c++;
            }

            Console.Write("Select Person\n:> ");
            string op = Console.ReadLine();

            c = 1;
            foreach (Person person in lstPerson)
            {

                if (c.ToString() == op)
                {
                    Console.WriteLine(c.ToString() + ". " + person.Rut + ": " + person.First_name + " " + person.Last_name);
                    currentUser = person;
                    return person;
                }
                c++;
            }
            return null;

        }


        static Address SelectAddress()
        {
            Console.Clear();
            Console.WriteLine("Select Address");
            int c = 1;
            foreach (Address address in lstAddress)
            {
                Console.WriteLine(c.ToString() + ". " + address.Street + ":\t" + address.Number + ":\t" + address.Commune);
                c++;
            }

            Console.Write("Select Address\n:> ");
            string op = Console.ReadLine();

            c = 1;
            foreach (Address address in lstAddress)
            {

                if (c.ToString() == op)
                {
                    Console.WriteLine(c.ToString() + ". " + address.Street +":\t:"+ address.Number +":\t"+ address.Commune);
                    currentAddress = address;
                    return address;
                }
                c++;
            }
            return null;

        }

        static Car SelectCar()
        {
            Console.Clear();
            Console.WriteLine("Select a Car");
            int c = 1;
            foreach (Car car in lstCar)
            {
                Console.WriteLine(c.ToString() + ". " + car.License_plate + ":\t"+car.Brand+":\t"+car.Model);
                c++;
            }

            Console.Write("Select Car\n:> ");
            string op = Console.ReadLine();

            c = 1;
            foreach (Car car in lstCar)
            {

                if (c.ToString() == op)
                {
                    Console.WriteLine(c.ToString() + ". " + car.License_plate + ":\t" + car.Brand + ":\t" + car.Model);
                    currentCar = car;
                    return car;
                }
                c++;
            }
            return null;

        }


        static void PersonOperation()
        {
            Person person = SelectPerson();
            Console.Clear();
            string data = $"User Data\n\nName: {currentUser.First_name} {currentUser.Last_name}\n" +
                $"BirthDate: {currentUser.Birth_date.ToString()}\n" +
                $"Alma mater: {currentUser.Alma_mater}\n" +
                $"Profesional Degree: {currentUser.Professional_degree}\n";
            Console.WriteLine(data);

            Console.WriteLine("Select Operation\n" +
                "(1) Change First Name\n" +
                "(2) Change Last Name\n" +
                "(3) Give Up Ownership To Third Party\n" +
                "(4) Abandon\n" +
                "(5) Get Adopted\n" +
                "(6) Set Education\n");


            

            string op = Console.ReadLine();
            if (op == "1")
            {
                Console.Write("New First Name: ");
                string newName = Console.ReadLine();
                currentUser.changeFirstName(newName);
            }
            if (op == "2")
            {
                Console.Write("New Last Name: ");
                string newName = Console.ReadLine();
                currentUser.changeLastName(newName);
            }
            if (op == "3")
            {
                //person.giveUpOwnershipToThirdParty(currentUser);
            }
            if(op == "4")
            {
                currentUser.getAbandoned();
            }
            if(op == "5")
            {
                //Person curChild = SelectPerson();
                Console.Write("How Many Parents (1), (2): ");
                string op2 = Console.ReadLine();
                if(op2 == "1")
                {
                    Person father = SelectPerson();
                    person.getAdopted(father);
                }
                else if (op2 == "2")
                {
                    Person father1 = SelectPerson();
                    Person father2 = SelectPerson();
                    person.getAdopted(father1, father2);
                }
                else
                {
                    Console.WriteLine("Invalid Input! Press Enter...");
                    Console.ReadLine();
                }
            }
            if (op == "6")
            {
                Console.Write("Alma Mater: ");
                string alma_mater = Console.ReadLine();
                Console.Write("Professional Degree: ");
                string Prof_d = Console.ReadLine();

                currentUser.setEducation(alma_mater,Prof_d);
            }




        }

        static void AddressOperation()
        {
            SelectAddress();
            Console.Clear();

            string data = $"Address Data\n\n" +
                $"Street: {currentAddress.Street}\n" +
                $"Number: {currentAddress.Number.ToString()}\n" +
                $"Commune: {currentAddress.Commune}\n" +
                $"City; {currentAddress.City}\n" +
                $"Year of Contruction: {currentAddress.Year_of_contruction.ToString()}\n" +
                $"Bedrooms: {currentAddress.Bedrooms.ToString()}\n" +
                $"Bathrooms: {currentAddress.Bathrooms.ToString()}\n" +
                $"Backyard: {currentAddress.Backyard.ToString()}\n";

            Console.WriteLine(data);

            

            Console.WriteLine("Select Operation\n" +
                "(1) Change Owner\n" +
                "(2) Add Bedrooms\n" +
                "(3) Add Bathrooms\n" +
                "(4) Back\n");


            string op = Console.ReadLine();
            if (op == "1")
            {
                SelectPerson();
                currentAddress.changeOwner(currentUser);
            }
            if (op == "2")
            {
                Console.Write("Quantity: ");
                try
                {
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    currentAddress.addBeedrooms(quantity);

                }
                catch
                {
                    Console.WriteLine("Error!");
                    return;
                }
            }
            if (op == "3")
            {
                Console.Write("Quantity: ");
                try
                {
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    currentAddress.addBathrooms(quantity);

                }
                catch
                {
                    Console.WriteLine("Error!");
                    return;
                }
            }
            if (op == "4")
            {
                return;
            }


        }

        static void CarOperation()
        {
            SelectCar();
            Console.Clear();


            string data = $"Car Data\n\n" +
                $"Brand: {currentCar.Brand}\n" +
                $"Model: {currentCar.Model}\n" +
                $"Year: {currentCar.Year.ToString()}\n" +
                $"License Plate: {currentCar.License_plate}\n" +
                $"Seatbelts: {currentCar.Seatbelts}\n" +
                $"Diesel: {currentCar.Diesel.ToString()}\n";
            
            Console.WriteLine(data);

            Console.WriteLine("Select Operation\n" +
                "(1) Give Up Ownership To Thrid Party\n" +
                "(2) Back\n");

            string op = Console.ReadLine();
            if (op == "1")
            {
                SelectPerson();
                currentCar.giveUpOwnershipToThirdParty(currentUser);
            }
            if (op == "2")
            {
                return;
            }
           

        }


    }
}
