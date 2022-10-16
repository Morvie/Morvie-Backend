using MediatR;
using MorvieReview.Application.Interfaces;
using MorvieReview.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorvieReview.Application.Commands
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, bool>
    {
        private readonly ICommandReviewRepository _repository;
        public CreateReviewHandler(ICommandReviewRepository repository)
        {
            _repository = repository;
        }
        public Task<bool> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new ReviewDTO()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description
            };
            _repository.CreateReview(review);
            return Task.FromResult(true);
        }
    }
}
