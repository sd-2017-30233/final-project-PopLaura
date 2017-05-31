using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AGM.Models;
namespace AGM.DB
{
    public class UnitOfWork:IDisposable
    {
        private MyConnection context = new MyConnection();
        private GenericRepository<Artist> artistRepository;
        private GenericRepository<User> userRepository;

        public GenericRepository<Artist> ArtistRepository
        {
            get
            {

                if (this.artistRepository == null)
                {
                    this.artistRepository = new GenericRepository<Artist>(context);
                }
                return artistRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}