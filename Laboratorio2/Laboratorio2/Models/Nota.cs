using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2.Models
{
    public partial class Nota
    {
        public int IdNotas { get; set; }

        public string? NombreEstudiante { get; set; }

        public string? NombreMateria { get; set; }

        public float? Lab1 { get; set; }

        public float? Parcial1 { get; set; }

        public float? Lab2 { get; set; }

        public float? Parcial2 { get; set; }

        public float? Lab3 { get; set; }

        public float? Parcial3 { get; set; }

        public float? Resultado { get; set; }

        public Nota()
        {
        }

        public Nota(string? nombreEstudiante, string? nombreMateria, float? lab1, float? parcial1, float? lab2, float? parcial2, float? lab3, float? parcial3)
        {
            NombreEstudiante = nombreEstudiante;
            NombreMateria = nombreMateria;
            Lab1 = lab1;
            Parcial1 = parcial1;
            Lab2 = lab2;
            Parcial2 = parcial2;
            Lab3 = lab3;
            Parcial3 = parcial3;
        }
    }
}
