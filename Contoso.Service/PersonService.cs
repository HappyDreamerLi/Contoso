﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data.Repositories;
using Contoso.Model;

namespace Contoso.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person GetPersonByUserName(string username)
        {
            var person = _personRepository.Get(p => p.Email == username);
            return person;
        }

        public Person GetValidPerson(string username, string password)
        {
            var person = _personRepository.Get(p => p.Email == username && p.Password == password);
            return person;
        }
    }

    public interface IPersonService
    {
        Person GetPersonByUserName(string username);
        Person GetValidPerson(string username, string password);
    }
}