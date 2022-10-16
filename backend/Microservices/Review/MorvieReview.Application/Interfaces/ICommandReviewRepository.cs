using MorvieReview.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorvieReview.Application.Interfaces
{
    public interface ICommandReviewRepository
    {
        void CreateReview(ReviewDTO review);
    }
}
