using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Data;
using System;
using System.Linq;

namespace Proyecto.Models
{
    public static class SeedData
    {
        private static void SeedRoleLevels(ProjectContext context)
        {
            // Look for any RoleLevel.
            if (context.RoleLevel.Any())
            {
                return;   // DB has been seeded
            }

            context.RoleLevel.AddRange(
                new RoleLevel
                {
                    RolLvlDsc = "Básico"
                },

                new RoleLevel
                {
                    RolLvlDsc = "Avanzado"
                }
            );
            context.SaveChanges();
        }

        private static void SeedRoles(ProjectContext context)
        {
            // Look for any Role.
            if (context.Role.Any())
            {
                return;   // DB has been seeded
            }

            context.Role.AddRange(
                new Role
                {
                    RolDsc = "Foto fija",
                    RolLvlId = 1
                },

                new Role
                {
                    RolDsc = "Asistente de cámara",
                    RolLvlId = 1
                },

                new Role
                {
                    RolDsc = "Asistente de producción",
                    RolLvlId = 1
                },

                new Role
                {
                    RolDsc = "Asistente de dirección",
                    RolLvlId = 1
                },

                new Role
                {
                    RolDsc = "Asistente de arte (escenografía, vestuario, utilería)",
                    RolLvlId = 1
                },

                new Role
                {
                    RolDsc = "Sonidista",
                    RolLvlId = 1
                },

                new Role
                {
                    RolDsc = "Editor",
                    RolLvlId = 1
                },

                new Role
                {
                    RolDsc = "Redactor creativo",
                    RolLvlId = 1
                },

                new Role
                {
                    RolDsc = "Presentador / conductor",
                    RolLvlId = 1
                },

                new Role
                {
                    RolDsc = "Ilustrador",
                    RolLvlId = 1
                },

                new Role
                {
                    RolDsc = "Diseñador gráfico",
                    RolLvlId = 1
                },

                new Role
                {
                    RolDsc = "Operador de Cabina 02",
                    RolLvlId = 1
                },

                new Role
                {
                    RolDsc = "Operador de Cabina 03 y Estudio de Radio",
                    RolLvlId = 1
                },

                new Role
                {
                    RolDsc = "Foto fija",
                    RolLvlId = 2
                },

                new Role
                {
                    RolDsc = "Cámara y asistente de cámara",
                    RolLvlId = 2
                },

                new Role
                {
                    RolDsc = "Cámara 360",
                    RolLvlId = 2
                },

                new Role
                {
                    RolDsc = "Postproductor de imagen",
                    RolLvlId = 2
                },

                new Role
                {
                    RolDsc = "Editor",
                    RolLvlId = 2
                },

                new Role
                {
                    RolDsc = "Sonidista",
                    RolLvlId = 2
                },

                new Role
                {
                    RolDsc = "Postproductor de sonido",
                    RolLvlId = 2
                },

                new Role
                {
                    RolDsc = "Redactor creativo",
                    RolLvlId = 2
                },

                new Role
                {
                    RolDsc = "Presentador / conductor",
                    RolLvlId = 2
                },

                new Role
                {
                    RolDsc = "Animador / infografista",
                    RolLvlId = 2
                },

                new Role
                {
                    RolDsc = "Operador de Cabina 01 Estudio de Grabación",
                    RolLvlId = 2
                }
            );
            context.SaveChanges();
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProjectContext>>()))
            {
                SeedRoleLevels(context);
                SeedRoles(context);
            }
        }
    }
}