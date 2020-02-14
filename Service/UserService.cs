using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ynov.TU.Mikado.Models;

namespace Ynov.TU.Mikado.Service
{
    
    public class UserService
    {
        //login d'un User
        public async Task<bool> login(string email, string password) {
            bool userExistInDatabase = false;
            User user = new User();
            user.Email = email;
            user.Password = password;
            User userLogged = await DatabaseContext.getInstance().Find(user);
            if(userLogged != null)
            {
                userExistInDatabase = true;
            }

            return userExistInDatabase;
        }

        //Ajout d'un utilisateur par le bibliothécaire
        public bool addUtilisateur(string email, string password, bool isLibrarian ) {
            User user = new User();
            user.Email = email;
            user.Password = password;
            user.IsLibrarian = isLibrarian;

            bool isUserAdded = DatabaseContext.getInstance().Add(user);
            return isUserAdded;
        }
    }
}
