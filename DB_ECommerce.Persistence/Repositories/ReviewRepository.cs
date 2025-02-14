﻿using DB_ECommerce.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB_ECommerce.Persistence.Repositories
{
    public class ReviewRepository
    {
        private readonly IMongoCollection<Review> _reviews;

        public ReviewRepository(DB_ECommerceContext dbContext)
        {
            _reviews = dbContext.Reviews;
        }

        public async Task<List<Review>> GetReviewsByProductIdAsync(string productId) =>
            await _reviews.Find(r => r.ProductId == productId).ToListAsync();

        public async Task<Review> GetReviewByIdAsync(string id) =>
            await _reviews.Find(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<bool> UpdateReviewAsync(string reviewId, int rating, string comment)
        {
            var updateDefinition = Builders<Review>.Update
                .Set(r => r.Rating, rating)
                .Set(r => r.Comment, comment);

            var result = await _reviews.UpdateOneAsync(r => r.Id == reviewId, updateDefinition);

            return result.ModifiedCount > 0;
        }

        public async Task CreateReviewAsync(Review review) =>
            await _reviews.InsertOneAsync(review);

        public async Task<bool> DeleteReviewAsync(string id)
        {
            var result = await _reviews.DeleteOneAsync(r => r.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
