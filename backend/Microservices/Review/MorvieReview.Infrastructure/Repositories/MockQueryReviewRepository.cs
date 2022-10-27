using MorvieReview.Application.Interfaces;
using MorvieReview.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorvieReview.Infrastructure.Repositories
{
    public class MockQueryReviewRepository : IQueryReviewRepository
    {
        public List<ReviewDto> reviewDTOs { get; set; }

        public MockQueryReviewRepository()
        {
            reviewDTOs = new List<ReviewDto>()
            {
                new ReviewDto()
                {
                    Id = new Guid("93a87c60-7e94-48e9-8bec-5a23b81f8631"),
                    Name = "Star Wars VI: Return of the Jedi",
                    Description = "The movie was great, I cleary enjoyed this movie!"
                },
                new ReviewDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dune",
                    Description = "It was okay"
                },
                new ReviewDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Justice League",
                    Description = "This movie sucked ;("
                }
            };
        }
        public async Task<IEnumerable<ReviewDto>> GetAll()
        {
            return reviewDTOs;
        }

        public async Task<ReviewDto> GetById(Guid id)
        {
            ReviewDto? review = null;
            foreach (var i in reviewDTOs)
            {
                if (i.Id.Equals(id))
                {
                    review = i;
                }
            }
            return review;
        }
    }
}
