using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Ynov.TU.Mikado.Models;

namespace Ynov.TU.Mikado
{
    class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private static DatabaseContext Instance;
        public static DatabaseContext getInstance()
        {
            if(Instance == null)
            {
                Instance = new DatabaseContext();
            }
            return Instance;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //si use sql serveur non reconnu, installer le package nuggets 
            // entityFramework.microsoft.sqlServeur
            optionsBuilder.UseSqlServer (
                @"Server=(localdb)\mssqllocaldb;Database=library;Integrated Security=False");
        }

        private DbSet<User> _user { get; set; }
        private DbSet<Media> _media { get; set; }
        private DbSet<Favourite> _favourite { get; set; }

        public bool Add<T>(T item)
        {
           
            if (typeof(T) == typeof(Media))
            {
                try
                {
                    _media.Add(item as Media);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            if (typeof(T) == typeof(User))
            {
                try
                {
                    _user.Add(item as User);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            if (typeof(T) == typeof(Favourite))
            {
                try
                {
                    _favourite.Add(item as Favourite);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }


        public void Delete<T>(T item)
        {

            if (typeof(T) == typeof(Media))
                _media.Remove(item as Media);

            if (typeof(T) == typeof(User))
                _user.Remove(item as User);

            if (typeof(T) == typeof(Favourite))
                _favourite.Remove(item as Favourite);

        }

        public void Update<T>(T item)
        {

            if (typeof(T) == typeof(Media))
                _media.Update(item as Media);

            if (typeof(T) == typeof(User))
                _user.Update(item as User);

            if (typeof(T) == typeof(Favourite))
                _favourite.Update(item as Favourite);

        }


        public async Task<T> Find<T>(T item) where T : class
        {

           /* if (typeof(T) == typeof(Media))
            {
                var media = item as Media;
                return await _media.FirstOrDefaultAsync(t => t.Category == media.Category) as T;
            }*/

            if (typeof(T) == typeof(User))
            {
                var user = item as User;
                return await _user.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password) as T;
            }


            return null;
        }

    }
}
