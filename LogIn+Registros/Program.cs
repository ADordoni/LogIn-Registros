using System;
using System.Collections.Generic;

namespace LogIn_Registros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mantenimiento mant = new Mantenimiento();

            Console.WriteLine("¿Desea operar en alguna cuenta? S/N");
            string respuesta = Console.ReadLine();
            string respuesta1 = respuesta.ToUpper();
            while (respuesta1 == "S")
            {
                Console.WriteLine("¿Qué desea hacer?\n 1) Ingresar a una cuenta.\n 2) Crear una cuenta.\nMarque el número de la opción deseada:");
                string option = Console.ReadLine();
                Evaluacion ev = new Evaluacion(option);
                int opcion = ev.MandarNumero();
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese nombre de usuario:");
                        string nombre = Console.ReadLine();
                        Usuario user = new Usuario();
                        user = mant.LeerUsuario(nombre);
                        string confirm = user.clave;
                        if (confirm != null)
                        {
                            Console.WriteLine("Ingrese la clave:");
                            string clave = Console.ReadLine();
                            int i = 1;
                            while (confirm != clave && i < 3)
                            {
                                Console.WriteLine("Clave incorrecta. Reingrese la clave: ");
                                clave = Console.ReadLine();
                                i++;
                            }
                            if (confirm == clave)
                            {
                                Console.WriteLine("Ha accedido a su cuenta.");
                                Console.WriteLine("¿Desea operar sobre alguna nómina de empleados? S/N");
                                respuesta = Console.ReadLine();
                                respuesta1 = respuesta.ToUpper();
                                while (respuesta1 == "S")
                                {
                                    Console.WriteLine("¿Qué desea hacer? \n1) Ingresar registro.\n2) Leer registro.\n3) Modificar registro. \n" +
                                        "4) Borrar registro.\n5) Leer todos los registros.\nMarque el número de la opción deseada:");
                                    string option1 = Console.ReadLine();
                                    ev = new Evaluacion(option1);
                                    int opcion1 = ev.MandarNumero();
                                    switch (opcion1)
                                    {
                                        case 1:
                                            Console.WriteLine("¿Desea ingresar un registro? S/N");
                                            string resp = Console.ReadLine();
                                            string resp1 = resp.ToUpper();
                                            while (resp1 == "S")
                                            {
                                                Console.WriteLine("Ingrese DNI");
                                                string dni = Console.ReadLine();
                                                ev = new Evaluacion(dni);
                                                int cert = ev.MandarNumero();
                                                while (cert < 1 || cert > 100000000)
                                                {
                                                    Console.WriteLine("Reingrese DNI");
                                                    dni = Console.ReadLine();
                                                    ev = new Evaluacion(dni);
                                                    cert = ev.MandarNumero();
                                                }
                                                Persona persona = new Persona();
                                                persona = mant.LeerRegistro(dni, nombre);
                                                confirm = persona.dni;
                                                if (confirm != null)
                                                {
                                                    Console.WriteLine("Registro ya existente");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Ingrese nombre y apellido");
                                                    string name = Console.ReadLine();
                                                    string name1 = name.ToUpper();

                                                    Console.WriteLine("Ingrese domicilio");
                                                    string address = Console.ReadLine();
                                                    string address1 = address.ToUpper();

                                                    Console.WriteLine("Ingrese día de nacimiento");
                                                    string dia = Console.ReadLine();
                                                    ev = new Evaluacion(dia);
                                                    int day = ev.MandarNumero();

                                                    while (day < 1 || day > 31)
                                                    {
                                                        Console.WriteLine("Reingrese día de nacimiento (entre 1 y 31)");
                                                        dia = Console.ReadLine();
                                                        ev = new Evaluacion(dia);
                                                        day = ev.MandarNumero();
                                                    }

                                                    Console.WriteLine("Ingrese mes de nacimiento");
                                                    string mes = Console.ReadLine();
                                                    ev = new Evaluacion(mes);
                                                    int month = ev.MandarNumero();

                                                    while (month < 1 || month > 12)
                                                    {
                                                        Console.WriteLine("Reingrese mes de nacimiento (entre 1 y 12)");
                                                        mes = Console.ReadLine();
                                                        ev = new Evaluacion(mes);
                                                        month = ev.MandarNumero();
                                                    }

                                                    Console.WriteLine("Ingrese año de nacimiento");
                                                    string agno = Console.ReadLine();
                                                    ev = new Evaluacion(agno);
                                                    int year = ev.MandarNumero();

                                                    if (year < 1900 || year > 2022)
                                                    {
                                                        while (year < 1900 || year > 2022)
                                                        {
                                                            Console.WriteLine("Reingrese año de nacimiento (entre 1900 y 2022)");
                                                            agno = Console.ReadLine();
                                                            ev = new Evaluacion(agno);
                                                            year = ev.MandarNumero();
                                                        }
                                                    }
                                                    DateTime date1 = new DateTime(year, month, day);

                                                    Console.WriteLine("Ingrese día de ingreso");
                                                    dia = Console.ReadLine();
                                                    ev = new Evaluacion(dia);
                                                    day = ev.MandarNumero();

                                                    while (day < 1 || day > 31)
                                                    {
                                                        Console.WriteLine("Reingrese día de ingreso (entre 1 y 31)");
                                                        dia = Console.ReadLine();
                                                        Evaluacion ev6 = new Evaluacion(dia);
                                                        day = ev6.MandarNumero();
                                                    }

                                                    Console.WriteLine("Ingrese mes de ingreso");
                                                    mes = Console.ReadLine();
                                                    ev = new Evaluacion(mes);
                                                    month = ev.MandarNumero();

                                                    while (month < 1 || month > 12)
                                                    {
                                                        Console.WriteLine("Reingrese mes de ingreso (entre 1 y 12)");
                                                        mes = Console.ReadLine();
                                                        ev = new Evaluacion(mes);
                                                        month = ev.MandarNumero();
                                                    }

                                                    Console.WriteLine("Ingrese año de ingreso");
                                                    agno = Console.ReadLine();
                                                    ev = new Evaluacion(agno);
                                                    year = ev.MandarNumero();

                                                    if (year < 1900 || year > 2022)
                                                    {
                                                        while (year < 1900 || year > 2022)
                                                        {
                                                            Console.WriteLine("Reingrese año de nacimiento (entre 1900 y 2022)");
                                                            agno = Console.ReadLine();
                                                            ev = new Evaluacion(agno);
                                                            year = ev.MandarNumero();
                                                        }
                                                    }
                                                    DateTime date2 = new DateTime(year, month, day);

                                                    Console.WriteLine("Ingrese puesto del empleado");
                                                    string puesto = Console.ReadLine();
                                                    string puesto1 = puesto.ToUpper();

                                                    Console.WriteLine("Ingrese el salario:");
                                                    string salary = Console.ReadLine();
                                                    ev = new Evaluacion(salary);
                                                    int salario = ev.MandarNumero();

                                                    Persona pers = new Persona();
                                                    pers.dni = dni;
                                                    pers.nombre = name1;
                                                    pers.domicilio = address1;
                                                    pers.fechanac = date1;
                                                    pers.fechaing = date2;
                                                    pers.puesto = puesto1;
                                                    pers.salario = salario;                                                    

                                                    mant.AltaRegistro(nombre,pers);
                                                }

                                                Console.WriteLine("¿Desea ingresar otro registro? S/N");
                                                resp = Console.ReadLine();
                                                resp1 = resp.ToUpper();
                                            }
                                            break;
                                        case 2:
                                            Console.WriteLine("¿Busca algún registro en particular? S/N");
                                            resp = Console.ReadLine();
                                            resp1 = resp.ToUpper();
                                            if (resp1 == "S")
                                            {
                                                Console.WriteLine("Ingrese DNI:");
                                                string dni = Console.ReadLine();
                                                Persona per = new Persona();
                                                per = mant.LeerRegistro(dni,nombre);
                                                if(per != null)
                                                {
                                                    Console.WriteLine($"Datos del empleado \nDNI: {per.dni}. \nNombre: {per.nombre}.\nDomicilio: {per.domicilio}.\nNacimiento: {per.fechanac}.\n" +
                                                    $"Ingreso: {per.fechaing}.\nPuesto: {per.puesto}.\nSalario {per.salario}.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Registro inexistente.");
                                                }
                                                
                                            }
                                            break;
                                        case 3:
                                            Console.WriteLine("¿Desea modificar algún registro? S/N");
                                            resp = Console.ReadLine();
                                            resp1 = resp.ToUpper();
                                            if (resp1 == "S")
                                            {
                                                Console.WriteLine("Ingrese DNI:");
                                                string dni = Console.ReadLine();
                                                Persona pers = new Persona();
                                                pers = mant.LeerRegistro(dni, nombre);
                                                if(pers != null)
                                                {
                                                    Console.WriteLine($"Datos del empleado \nDNI: {pers.dni}. \nNombre: {pers.nombre}.\nDomicilio: {pers.domicilio}.\nNacimiento: {pers.fechanac}.\n" +
                                                    $"Ingreso: {pers.fechaing}.\nPuesto: {pers.puesto}.\nSalario {pers.salario}.");

                                                    Console.WriteLine("¿Qué campo desea modificar? \n1) Nombre. \n2) Domicilio. \n3) Fecha de nacimiento. \n" +
                                                        "4) Fecha de ingreso. \n5) Puesto. \n6)Salario. \nMarque el número de la opción deseada:");
                                                    opcion = int.Parse(Console.ReadLine());

                                                    switch (opcion)
                                                    {
                                                        case 1:
                                                            Console.WriteLine("Ingrese nombre y apellido:");
                                                            string name = Console.ReadLine();
                                                            string name1 = name.ToUpper();
                                                            mant.ModificarNombre(dni, nombre, name1);
                                                            break;

                                                        case 2:
                                                            Console.WriteLine("Ingrese domicilio:");
                                                            string address = Console.ReadLine();
                                                            string address1 = address.ToUpper();
                                                            mant.ModificarDomicilio(dni, nombre, address1);
                                                            break;

                                                        case 3:
                                                            Console.WriteLine("Ingrese día de nacimiento");
                                                            string dia = Console.ReadLine();
                                                            ev = new Evaluacion(dia);
                                                            int day = ev.MandarNumero();

                                                            if (day < 1 || day > 31)
                                                            {
                                                                while (day < 1 || day > 31)
                                                                {
                                                                    Console.WriteLine("Reingrese día de nacimiento (entre 1 y 31)");
                                                                    dia = Console.ReadLine();
                                                                    ev = new Evaluacion(dia);
                                                                    day = ev.MandarNumero();
                                                                }
                                                            }

                                                            Console.WriteLine("Ingrese mes de nacimiento");
                                                            string mes = Console.ReadLine();
                                                            ev = new Evaluacion(mes);
                                                            int month = ev.MandarNumero();

                                                            if (month < 1 || month > 12)
                                                            {
                                                                while (month < 1 || month > 12)
                                                                {
                                                                    Console.WriteLine("Reingrese mes de nacimiento (entre 1 y 12)");
                                                                    mes = Console.ReadLine();
                                                                    ev = new Evaluacion(mes);
                                                                    month = ev.MandarNumero();
                                                                }
                                                            }

                                                            Console.WriteLine("Ingrese año de nacimiento");
                                                            string agno = Console.ReadLine();
                                                            ev = new Evaluacion(agno);
                                                            int year = ev.MandarNumero();

                                                            if (year < 1900 || year > 2022)
                                                            {
                                                                while (year < 1900 || year > 2022)
                                                                {
                                                                    Console.WriteLine("Reingrese año de nacimiento (entre 1900 y 2022)");
                                                                    agno = Console.ReadLine();
                                                                    ev = new Evaluacion(agno);
                                                                    year = ev.MandarNumero();
                                                                }
                                                            }

                                                            DateTime date1 = new DateTime(year, month, day);
                                                            mant.ModificarFechaNac(dni, nombre, date1);
                                                            break;

                                                        case 4:
                                                            Console.WriteLine("Ingrese día de ingreso");
                                                            dia = Console.ReadLine();
                                                            ev = new Evaluacion(dia);
                                                            day = ev.MandarNumero();

                                                            if (day < 1 || day > 31)
                                                            {
                                                                while (day < 1 || day > 31)
                                                                {
                                                                    Console.WriteLine("Reingrese día de ingreso (entre 1 y 31)");
                                                                    dia = Console.ReadLine();
                                                                    ev = new Evaluacion(dia);
                                                                    day = ev.MandarNumero();
                                                                }
                                                            }

                                                            Console.WriteLine("Ingrese mes de ingreso");
                                                            mes = Console.ReadLine();
                                                            ev = new Evaluacion(mes);
                                                            month = ev.MandarNumero();

                                                            if (month < 1 || month > 12)
                                                            {
                                                                while (month < 1 || month > 12)
                                                                {
                                                                    Console.WriteLine("Reingrese mes de ingreso (entre 1 y 12)");
                                                                    mes = Console.ReadLine();
                                                                    ev = new Evaluacion(mes);
                                                                    month = ev.MandarNumero();
                                                                }
                                                            }

                                                            Console.WriteLine("Ingrese año de ingreso");
                                                            agno = Console.ReadLine();
                                                            ev = new Evaluacion(agno);
                                                            year = ev.MandarNumero();

                                                            if (year < 1900 || year > 2022)
                                                            {
                                                                while (year < 1900 || year > 2022)
                                                                {
                                                                    Console.WriteLine("Reingrese año de nacimiento (entre 1900 y 2022)");
                                                                    agno = Console.ReadLine();
                                                                    ev = new Evaluacion(agno);
                                                                    year = ev.MandarNumero();
                                                                }
                                                            }

                                                            date1 = new DateTime(year, month, day);
                                                            mant.ModificarFechaIng(dni, nombre, date1);
                                                            break;

                                                        case 5:
                                                            Console.WriteLine("Ingrese puesto:");
                                                            string puesto = Console.ReadLine();
                                                            string puesto1 = puesto.ToUpper();
                                                            mant.ModificarPuesto(dni, nombre, puesto1);
                                                            break;

                                                        case 6:
                                                            Console.WriteLine("Ingrese salario:");
                                                            string salary = Console.ReadLine();
                                                            ev = new Evaluacion(salary);
                                                            int salario = ev.MandarNumero();
                                                            mant.ModificarSalario(dni, nombre, salario);
                                                            break;

                                                        default:
                                                            Console.WriteLine("Opción incorrecta");
                                                            break;
                                                    }                                                    
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Registro inexistente");
                                                }
                                            }
                                            break;
                                        case 4:
                                            Console.WriteLine("¿Desea borrar un registro? S/N");
                                            resp = Console.ReadLine();
                                            resp1 = resp.ToUpper();
                                            while (resp1 == "S")
                                            {
                                                Console.WriteLine("Ingrese el DNI del registro que desea borrar:");
                                                string dni = Console.ReadLine();
                                                Persona pers = new Persona();
                                                pers = mant.LeerRegistro(dni, nombre);
                                                if (pers != null)
                                                {
                                                    mant.Borrar(dni, nombre);
                                                    Console.WriteLine("¿Desea borrar otro registro? S/N");
                                                    resp = Console.ReadLine();
                                                    resp1 = resp.ToUpper();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Registro inexistente. \n¿Desea borrar un registro?");
                                                    resp = Console.ReadLine();
                                                    resp1 = resp.ToUpper();
                                                }
                                            }
                                            break;
                                        case 5:
                                            Console.WriteLine("¿Desea leer los registros almacenados? S/N");
                                            resp = Console.ReadLine();
                                            resp1 = resp.ToUpper();
                                            if (resp1 == "S")
                                            {
                                                List<Persona> list = new List<Persona>();
                                                list = mant.LeerTodo(nombre);
                                                foreach (Persona pers in list)
                                                {
                                                    Console.WriteLine($"Datos del empleado DNI: {pers.dni}. Nombre: {pers.nombre}. Domicilio: {pers.domicilio}. Nacimiento: {pers.fechanac}." +
                                                    $"Ingreso: {pers.fechaing}. Puesto: {pers.puesto}. Salario {pers.salario}.");
                                                }
                                                if (list.Count == 0)
                                                {
                                                    Console.WriteLine("No hay registros almacenados.");
                                                }
                                            }
                                            break;
                                        default:
                                            Console.WriteLine("Opción incorrecta.");
                                            break;

                                    }
                                    Console.WriteLine("¿Desea operar sobre algún registro? S/N");
                                    respuesta = Console.ReadLine();
                                    respuesta1 = respuesta.ToUpper();
                                }
                                Console.WriteLine("Programa finalizado.");
                            }
                        
                            else
                            {
                                Console.WriteLine("Se le acabaron los intentos.");
                                respuesta1 = "N";
                            }
                        }
                        else
                        {
                            Console.WriteLine("Usuario inexistente.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Ingrese nombre de usuario:");
                        string nombre2 = Console.ReadLine();
                        Usuario user2 = new Usuario();
                        user2 = mant.LeerUsuario(nombre2);
                        string confirm2 = user2.nombre;
                        if (confirm2 != null)
                        {
                            Console.WriteLine("Registro ya existente");
                        }
                        else
                        {
                            Console.WriteLine("Ingrese la clave:");
                            string clave2 = Console.ReadLine();
                            Usuario user1 = new Usuario();
                            user1.nombre = nombre2;
                            user1.clave = clave2;
                            mant.AltaUsuario(user1);
                        }
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta.");
                        break;
                }
                Console.WriteLine("¿Desea operar en alguna cuenta? S/N");
                respuesta = Console.ReadLine();
                respuesta1 = respuesta.ToUpper();
            }
            Console.WriteLine("Programa finalizado.");
        }
    }
}
