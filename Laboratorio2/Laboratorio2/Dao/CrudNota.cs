using Laboratorio2.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2.DAO
{
    internal class CrudNota
    {
        public void funcionesDeNota() {
            String op;

            do
            {
                Console.WriteLine("\n******Menú******");
                Console.WriteLine("1) Calcular notas");
                Console.WriteLine("2) Listar notas");
                Console.WriteLine("3) Salir");
                Console.WriteLine();
                Console.Write("Seleccione una opción: ");
                op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        Console.WriteLine("Creando registro de notas");
                        Console.WriteLine("\nIngrese el nombre del estudiante");
                        String nombreEstudiante = Console.ReadLine();

                        Console.WriteLine("\nIngrese el nombre de la materia");
                        String nombreMateria = Console.ReadLine();

                        Console.WriteLine("\nIngrese el laboratorio 1");
                        float lab1 = float.Parse(Console.ReadLine());

                        Console.WriteLine("\nIngrese el parcial 1");
                        float par1 = float.Parse(Console.ReadLine());

                        Console.WriteLine("\nIngrese el laboratorio 2");
                        float lab2 = float.Parse(Console.ReadLine());

                        Console.WriteLine("\nIngrese el parcial 2");
                        float par2 = float.Parse(Console.ReadLine());

                        Console.WriteLine("\nIngrese el laboratorio 3");
                        float lab3 = float.Parse(Console.ReadLine());

                        Console.WriteLine("\nIngrese el parcial 3");
                        float par3 = float.Parse(Console.ReadLine());

                        _ = (float)Math.Round((decimal)lab1, 2);
                        _ = (float)Math.Round((decimal)lab2, 2);
                        _ = (float)Math.Round((decimal)lab3, 2);
                        _ = (float)Math.Round((decimal)par1, 2);
                        _ = (float)Math.Round((decimal)par2, 2);
                        _ = (float)Math.Round((decimal)par3, 2);
                        Nota nota = new Nota(nombreEstudiante, nombreMateria, lab1, par1, lab2, par2, lab3, par3);
                        calculos(nota);
                        break;
                    case "2":
                        listarNotas();
                        break;
                    default:
                        Console.WriteLine("Ingrese una opcion valida");
                        break;
                }
            } while (op != "3");
            Console.WriteLine("Gracias por usar nuestro programa.");
        }

        public void calculos(Nota nota)
        {
            float? lab1, lab2, lab3, parcial1, parcial2, parcial3, resultado1, resultado2, resultado3, resultadoFinal;

            lab1 = nota.Lab1 * 0.4f;
            parcial1 = nota.Parcial1 * 0.6f;
            resultado1 = lab1 + parcial1;

            lab2 = nota.Lab2 * 0.4f;
            parcial2 = nota.Parcial2 * 0.6f;
            resultado2 = lab2 + parcial2;

            lab3 = nota.Lab3 * 0.4f;
            parcial3 = nota.Parcial3 * 0.6f;
            resultado3 = lab3 + parcial3;

            resultadoFinal = (resultado1 + resultado2 + resultado3) / 3;
            _ = (float)Math.Round((decimal)resultado1, 2);
            _ = (float)Math.Round((decimal)resultado2, 2);
            _ = (float)Math.Round((decimal)resultado3, 2);
            _ = (float)Math.Round((decimal)resultadoFinal, 2);

            Console.WriteLine("Su resultado es : " + Math.Round((double)resultadoFinal, 2));
            Console.WriteLine();

            using (NotaEstudianteContext db = new NotaEstudianteContext())
            {
                nota.Resultado = (float)Math.Round((decimal)resultadoFinal);
                db.Add(nota);
                db.SaveChanges();
                Console.WriteLine("Su nota fue almacenada correctamente");
            }

        }

        public void listarNotas() {
            int contador = 1;
            using (NotaEstudianteContext db = new NotaEstudianteContext())
            {
                List<Nota> listaNotas = db.Nota.ToList();
                foreach (Nota nota in listaNotas) {
                    Console.WriteLine("\nRegistro " + contador + ": " +
                        "\nNombre del estudiante:" + nota.NombreEstudiante + 
                        "\nNombre de la materia: " + nota.NombreMateria +
                        "\nLaboratorio 1: " + nota.Lab1 +
                        "\nParcial 1: " + nota.Parcial1 +
                        "\nLaboratorio 2: " + nota.Lab2 +
                        "\nParcial 2: " + nota.Parcial2 +
                        "\nLaboratorio 3: " + nota.Lab3 +
                        "\nParcial 3: " + nota.Parcial3 +
                        "\nResultado: " + nota.Resultado
                        );
                    contador++;
                }
            }
        }
    }
}
