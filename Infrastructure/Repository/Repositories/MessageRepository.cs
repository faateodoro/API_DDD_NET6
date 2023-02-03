﻿using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessage
    {
        private DbContextOptions<BaseContext> _OptionsBuilder;

        public MessageRepository()
        {
            _OptionsBuilder = new DbContextOptions<BaseContext>();
        }
    }
}
