using MediatR;
using MorvieReview.Application.Interfaces;
using MorvieReview.Application.Queries.GetAllReviews;
using MorvieReview.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorvieReview.Application.Queries.GetReview
{
   
    public class GetReviewHandler : IRequestHandler<GetReviewQuery, ReviewDto>
    {
        private readonly IQueryReviewRepository _repository;
        public GetReviewHandler(IQueryReviewRepository repository)
        {
            _repository = repository;
        }
          
        public async Task<ReviewDto> Handle(GetReviewQuery request, CancellationToken cancellationToken)
        {
            var review = await _repository.GetById(request.Id);
            return review;
        }
    }
    
}
