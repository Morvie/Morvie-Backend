using MorvieReview.Application.Interfaces;
using MorvieReview.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorvieReview.Infrastructure.Repositories
{
    public class MockCommandReviewRepository : ICommandReviewRepository
    {
        private readonly MockQueryReviewRepository _repository;
        public MockCommandReviewRepository()
        {
            _repository = new MockQueryReviewRepository();
        }
        public void CreateReview(ReviewDto review) { 
            _repository.reviewDTOs.Add(review);
        }
    }
}
