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
        public List<ReviewDTO> reviewDTOs { get; set; }

        public MockQueryReviewRepository()
        {
            reviewDTOs = new List<ReviewDTO>()
            {
                new ReviewDTO()
                {
                    Id = new Guid("93a87c60-7e94-48e9-8bec-5a23b81f8631"),
                    Name = "Star Wars VI: Return of the Jedi",
                    Description = "The movie was great, I cleary enjoyed this movie!"
                },
                new ReviewDTO()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dune",
                    Description = "It was okay"
                },
                new ReviewDTO()
                {
                    Id = Guid.NewGuid(),
                    Name = "Justice League",
                    Description = "This movie sucked ;("
                }
            };
        }
        public async Task<IEnumerable<ReviewDTO>> GetAll()
        {
            return reviewDTOs;
        }

        public async Task<ReviewDTO> GetById(Guid id)
        {
            ReviewDTO? review = null;
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
