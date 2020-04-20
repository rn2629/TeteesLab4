using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace TeteesLab4.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TeteesLab4Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TeteesLab4Context>>()))
            {
                // Look for any movies.
                if (context.Tetees.Any())
                {
                    return;   // DB has been seeded
                }

                context.Tetees.AddRange(
                          new Tetees
                          {
                              Title = "Premiere  heure de reveil du bébé",
                              Heure = DateTime.Parse("03:00"),
                              Cote = "Sein gauche",
                              Technique = "Le Plus securitaire possible, bebe encore endormie",
                              Commentaire = "Demander conseil a une personne experimente en cas probleme"
                          },

                    new Tetees
                    {
                        Title = "Deuxieme heure de reveil du bébé",
                        Heure = DateTime.Parse("07:00"),
                        Cote = "Sein droit",
                        Technique = "matinal, tranquille",
                        Commentaire = "Demander conseil a une personne experimente en cas probleme"
                    },

                    new Tetees
                    {
                        Title = "Midi",
                        Heure = DateTime.Parse("12:00"),
                        Cote = "Sein gauche",
                        Technique = "matinal, tranquille",
                        Commentaire = "Demander conseil a une personne experimente en cas probleme"
                    },

                    new Tetees
                    {
                        Title = "Soir",
                        Heure = DateTime.Parse("20:00"),
                        Cote = "Sein droit",
                        Technique = "soir, tranquille",
                        Commentaire = "Demander conseil a une personne experimente en cas probleme"
                    },
                    new Tetees /**Test**/
                    {
                        Title = "Fin de soirée",
                        Heure = DateTime.Parse("20:00"),
                        Cote = "Donne Biberon",
                        Technique = "Doit etre tres delicat et prendre son temps ",
                        Commentaire = "Demande conseil a sa femme"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}