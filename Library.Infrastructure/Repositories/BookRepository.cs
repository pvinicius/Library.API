﻿using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Domain.Interfaces.Repositories;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {

    }
}
