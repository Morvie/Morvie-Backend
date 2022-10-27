using MediatR;
using MorvieReview.Application.Interfaces;
using MorvieReview.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorvieReview.Application.Queries.GetAllReviews
{
    public class GetAllReviewsHandler : IRequestHandler<GetAllReviewsQuery, IEnumerable<ReviewDto>>
    {
        private readonly IQueryReviewRepository _repository;
        public GetAllReviewsHandler(IQueryReviewRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ReviewDto>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _repository.GetAll();
            return reviews;
        }
    }
}
