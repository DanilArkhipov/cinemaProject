using System;
using LinqToDB.Configuration;
using LinqToDB.Data;

namespace ORM
{
    public class UnitOfWork:DataConnection
    {
        private LinqToDbConnectionOptions<UnitOfWork> _options;
        public UnitOfWork(LinqToDbConnectionOptions<UnitOfWork> options)
            : base(options)
        {
            _options = options;
        }

        private IUsersRepository _usersRepository;

        public IUsersRepository UsersRepository
        {
            get
            {
                if (_usersRepository == null)
                {
                    _usersRepository = new UsersRepository(_options);
                }

                return _usersRepository;
            }
        }
        
        private IMovieRepository _movieRepository;

        public IMovieRepository MovieRepository
        {
            get
            {
                if (_movieRepository == null)
                {
                    _movieRepository = new MovieRepository(_options);
                }

                return _movieRepository;
            }
        }

        private IMovieReviewRepository _movieReviewRepository;

        public IMovieReviewRepository MovieReviewRepository
        {
            get
            {
                if (_movieReviewRepository == null)
                {
                    _movieReviewRepository = new MovieReviewRepository(_options);
                }

                return _movieReviewRepository;
            }
        }

        private ISessionRepository _sessionRepository;

        public ISessionRepository SessionRepository
        {
            get
            {
                if (_sessionRepository == null)
                {
                    _sessionRepository = new SessionRepository(_options);
                }

                return _sessionRepository;
            }
        }
    }
}