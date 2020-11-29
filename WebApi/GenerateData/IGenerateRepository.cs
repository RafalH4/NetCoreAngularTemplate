using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.GenerateData
{
    public interface IGenerateRepository
    {
        Task GenerateData();
    }
}
