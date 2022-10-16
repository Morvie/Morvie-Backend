using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MorvieReview.Application.Commands
{
    public class CreateReviewCommand : IRequest<bool>
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }

        [JsonConstructor]
        public CreateReviewCommand(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
