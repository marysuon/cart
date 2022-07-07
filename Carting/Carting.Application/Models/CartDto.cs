using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carting.Domain.Models;

namespace Carting.Application.Models
{
    public class CartDto
    {
        public Guid Id { get; set; }

        public IList<ItemDto> Items { get; set; }
    }
}
