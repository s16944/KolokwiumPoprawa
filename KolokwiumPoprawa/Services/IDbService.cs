using System;
using KolokwiumPoprawa.Models;

namespace KolokwiumPoprawa.Services
{
    public interface IDbService
    {
        void AddArtist(Artist artist);
    }

    public class ConflictException : Exception
    {
        public ConflictException()
        {
        }

        public ConflictException(string message) : base(message)
        {
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }
    }
}