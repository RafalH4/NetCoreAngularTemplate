using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessDirectory;
using WebApi.DataContext;
using WebApi.OrganizationDirectory;
using WebApi.UserDirectory;

namespace WebApi.GenerateData
{
    public class GenerateRepository : IGenerateRepository
    {
        private readonly Context _context;
        public GenerateRepository(Context context)
        {
            _context = context;
        }
        public async Task GenerateData()
        {
            Guid x;
            for(int i = 1; i <= 10; i++)
            {
                x = Guid.NewGuid();
            }
            await _context.Businesses.AddAsync(new Business
            {
                Address = "laszki",
                BusinessName = "rzeszow",
                Id = Guid.NewGuid(),
                Category = Category.Atrakcje,
                Lattitude = 0.782f,
                Longitude = 0.187f,
                PhotoUrl = "httpawdawd"
            });
            await _context.Businesses.AddAsync(new Business
            {
                Address = "obroncow",
                BusinessName = "tobrukow",
                Id = Guid.NewGuid(),
                Category = Category.Atrakcje,
                Lattitude = 0.170f,
                Longitude = 0.96f,
                PhotoUrl = "httpawdawd"
            });
            await _context.Businesses.AddAsync(new Business
            {
                Address = "prawo",
                BusinessName = "informatyka",
                Id = Guid.NewGuid(),
                Category = Category.Atrakcje,
                Lattitude = 0.951f,
                Longitude = 0.170f,
                PhotoUrl = "httpawdawd"
            });
            await _context.Businesses.AddAsync(new Business
            {
                Address = "spedycja",
                BusinessName = "transport",
                Id = Guid.NewGuid(),
                Category = Category.Atrakcje,
                Lattitude = 0.154f,
                Longitude = 0.048f,
                PhotoUrl = "httpawdawd"
            });
            await _context.Businesses.AddAsync(new Business
            {
                Address = "gorczewska",
                BusinessName = "ulica",
                Id = Guid.NewGuid(),
                Category = Category.Atrakcje,
                Lattitude = 0.299f,
                Longitude = 0.494f,
                PhotoUrl = "httpawdawd"
            });
            await _context.Businesses.AddAsync(new Business
            {
                Address = "wilanow",
                BusinessName = "swiatelka",
                Id = Guid.NewGuid(),
                Category = Category.Atrakcje,
                Lattitude = 0.600f,
                Longitude = 0.300f,
                PhotoUrl = "httpawdawd"
            });
            await _context.Businesses.AddAsync(new Business
            {
                Address = "laszki 77 ",
                BusinessName = "fotowoltaika",
                Id = Guid.NewGuid(),
                Category = Category.Atrakcje,
                Lattitude = 0.071f,
                Longitude = 0.896f,
                PhotoUrl = "httpawdawd"
            });

            await _context.Organizations.AddAsync(new Organization
            {
                Address = "adres",
                Id = Guid.NewGuid(),
                OrganizationName = "asd",
                PhotoUrl = "asdasd"
            });





            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
