using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services;

    public class GoodbyeMessage : IGenerateMessage
    {
        public string Generate(string name) => $"Goodbye {name ?? "World"}";
    }
